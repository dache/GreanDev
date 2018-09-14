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

        public SendFingerPrint m_fingerPrintCallback;

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

        private async void FingerPrintForm_Load(object sender, EventArgs e)
        {
            m_zkFprint = FingerPrint.GetSingleton().GetFingerprint();

            await FingerPrint.GetSingleton().SetupFingerprintEvent(Controls, zkFprint_OnFeatureInfo, zkFprint_OnImageReceived, zkFprint_OnEnroll, zkFprint_OnCapture);
            //Console.WriteLine();
            // m_zkFprint.BeginCapture();
            // m_zkFprint.CancelEnroll();
            m_zkFprint.EnrollCount = 3;
            m_zkFprint.BeginEnroll();
            ShowMessage("Please give fingerprint regiss.");
        }
        private void zkFprint_OnCapture(object sender, IZKFPEngXEvents_OnCaptureEvent e)
        {

        }
        private void zkFprint_OnImageReceived(object sender, IZKFPEngXEvents_OnImageReceivedEvent e)
        {
            Console.WriteLine("zkFprint_OnImageReceived 2");
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
            Console.WriteLine("zkFprint_OnFeatureInfo 2");
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

        private async void zkFprint_OnEnroll(object sender, IZKFPEngXEvents_OnEnrollEvent e)
        {
            Console.WriteLine("zkFprint_OnEnroll 2");
            if (e.actionResult)
            {
                string template = m_zkFprint.EncodeTemplate1(e.aTemplate);
                await FingerPrint.GetSingleton().RemoveFingerprintEvent(Controls, zkFprint_OnFeatureInfo, zkFprint_OnImageReceived, zkFprint_OnEnroll, zkFprint_OnCapture);
                m_fingerPrintCallback(template);

                this.Close();
            }
            else
            {
                ShowMessage("Error, please register again.");
                this.Close();
            }
        }

        private void ShowMessage(string msg)
        {
            lblMessage.Text = msg;
        }
    }
}
