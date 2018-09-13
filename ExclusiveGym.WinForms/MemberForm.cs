using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AxZKFPEngXControl;
using ExclusiveGym.WinForms.Models;

namespace ExclusiveGym.WinForms
{
    public partial class MemberForm : Form
    {
        private const int WS_EX_TRANSPARENT = 0x20;
               
        public MemberForm()
        {
            InitializeComponent();            
            SetStyle(ControlStyles.Opaque, true);
            m_zkFprint = FingerPrint.GetSingleton().GetFingerprint();

            FingerPrint.GetSingleton().SetupFingerprintEvent(Controls, zkFprint_OnFeatureInfo, zkFprint_OnImageReceived, zkFprint_OnEnroll, zkFprint_OnCapture);
        }
        

        public FinishCallback m_registryiSdone;

        private AxZKFPEngX m_zkFprint;

        private void CloseForm()
        {
            FingerPrint.GetSingleton().RemoveFingerprintEvent(Controls, zkFprint_OnFeatureInfo, zkFprint_OnImageReceived, zkFprint_OnEnroll, zkFprint_OnCapture);
            if (m_registryiSdone != null)
                m_registryiSdone();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CloseForm();
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            var newMember = new Member();
            newMember.Name = txtName.Text;
            newMember.LastName = txtLastName.Text;
            newMember.CreateDate = DateTime.Now;
            newMember.BirthDate = DateTime.Now;
            newMember.FingerPrint = lblFingerPrint.Text;

            StorageManager.GetSingleton().AddMember(newMember);
            CloseForm();
        }

        public void ReceiveFingerPrint(string fingerPrint)
        {
            FingerPrint.GetSingleton().SetupFingerprintEvent(Controls, zkFprint_OnFeatureInfo, zkFprint_OnImageReceived, zkFprint_OnEnroll, zkFprint_OnCapture);
            lblFingerPrint.Text = fingerPrint;
        }

        private void btnFingerPrint_Click(object sender, EventArgs e)
        {
            FingerPrint.GetSingleton().RemoveFingerprintEvent(Controls, zkFprint_OnFeatureInfo, zkFprint_OnImageReceived, zkFprint_OnEnroll, zkFprint_OnCapture);
            var fingerForm = new FingerPrintForm();
            fingerForm.m_fingerPrintCallback = ReceiveFingerPrint;
            fingerForm.ShowDialog();
        }



        private void zkFprint_OnCapture(object sender, IZKFPEngXEvents_OnCaptureEvent e)
        {
            string template = m_zkFprint.EncodeTemplate1(e.aTemplate);
            Console.WriteLine("Scan string : " + template);
            bool Check = false;
            foreach (Member member in StorageManager.GetSingleton().GetMemberList())
            {
                if (m_zkFprint.VerFingerFromStr(ref template, member.FingerPrint, false, ref Check))
                {
                    txtName.Text = member.Name;
                    txtLastName.Text = member.LastName = txtLastName.Text;
                    break;
                }
            }
        }
        private void zkFprint_OnImageReceived(object sender, IZKFPEngXEvents_OnImageReceivedEvent e)
        {
            Console.WriteLine("zkFprint_OnImageReceived 2");
            //Graphics g = fingerPicture.CreateGraphics();
            //Bitmap bmp = new Bitmap(fingerPicture.Width, fingerPicture.Height);
            //g = Graphics.FromImage(bmp);
            //int dc = g.GetHdc().ToInt32();
            //m_zkFprint.PrintImageAt(dc, 0, 0, bmp.Width, bmp.Height);
            //g.Dispose();
            //fingerPicture.Image = bmp;
        }

        private void zkFprint_OnFeatureInfo(object sender, IZKFPEngXEvents_OnFeatureInfoEvent e)
        {
            Console.WriteLine("zkFprint_OnFeatureInfo 2");
            //String strTemp = string.Empty;
            //if (m_zkFprint.EnrollIndex != 1)
            //{
            //    if (m_zkFprint.IsRegister)
            //    {
            //        if (m_zkFprint.EnrollIndex - 1 > 0)
            //        {
            //            int eindex = m_zkFprint.EnrollIndex - 1;
            //            strTemp = "Please scan again ..." + eindex;
            //        }
            //    }
            //}
            //ShowMessage(strTemp);
        }

        private void zkFprint_OnEnroll(object sender, IZKFPEngXEvents_OnEnrollEvent e)
        {
            Console.WriteLine("zkFprint_OnEnroll 2");
            //if (e.actionResult)
            //{
            //    string template = m_zkFprint.EncodeTemplate1(e.aTemplate);
            //    FingerPrint.GetSingleton().RemoveFingerprintEvent(Controls, zkFprint_OnFeatureInfo, zkFprint_OnImageReceived, zkFprint_OnEnroll, zkFprint_OnCapture);
            //    m_fingerPrintCallback(template);

            //    this.Close();
            //}
            //else
            //{
            //    ShowMessage("Error, please register again.");

            //}
        }
    }
}
