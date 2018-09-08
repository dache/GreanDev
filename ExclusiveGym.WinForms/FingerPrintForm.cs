using AxZKFPEngXControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExclusiveGym.WinForms
{
    public partial class FingerPrintForm : Form
    {
        private const int WS_EX_TRANSPARENT = 0x20;

        public delegate void SendFingerPrint(string fingerPrint);
        public SendFingerPrint Send;

        private AxZKFPEngX m_zkFprint;

        public FingerPrintForm()
        {
            InitializeComponent();
            SetStyle(ControlStyles.Opaque, true);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle = cp.ExStyle | WS_EX_TRANSPARENT;
                return cp;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            using (var brush = new SolidBrush(Color.FromArgb(50 * 255 / 100, this.BackColor)))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
            base.OnPaint(e);
        }

        private void FingerPrintForm_Load(object sender, EventArgs e)
        {
            m_zkFprint = FingerPrint.GetSingleton().GetSDK();
            m_zkFprint.CancelEnroll();
            m_zkFprint.EnrollCount = 3;
            m_zkFprint.BeginEnroll();
            ShowMessage("Please give fingerprint regis.");
        }

        private void zkFprint_OnImageReceived(object sender, IZKFPEngXEvents_OnImageReceivedEvent e)
        {
            Graphics g = fingerPicture.CreateGraphics();
            Bitmap bmp = new Bitmap(fingerPicture.Width, fingerPicture.Height);
            g = Graphics.FromImage(bmp);
            int dc = g.GetHdc().ToInt32();
            m_zkFprint.PrintImageAt(dc, 0, 0, bmp.Width, bmp.Height);
            g.Dispose();
            fingerPicture.Image = bmp;
        }

        private void zkFprint_OnFeatureInfo(object sender, IZKFPEngXEvents_OnFeatureInfoEvent e)
        {

            String strTemp = string.Empty;
            if (m_zkFprint.EnrollIndex != 1)
            {
                if (m_zkFprint.IsRegister)
                {
                    if (m_zkFprint.EnrollIndex - 1 > 0)
                    {
                        int eindex = m_zkFprint.EnrollIndex - 1;
                        strTemp = "Please scan again ..." + eindex;
                    }
                }
            }
            ShowMessage(strTemp);
        }

        private void zkFprint_OnEnroll(object sender, IZKFPEngXEvents_OnEnrollEvent e)
        {
            if (e.actionResult)
            {                
                string template = m_zkFprint.EncodeTemplate1(e.aTemplate);
                Send(template);
                this.Close();
            }
            else
            {
                ShowMessage("Error, please register again.");

            }
        }

        private void ShowMessage(string msg)
        {
            lblMessage.Text = msg;
        }
    }
}
