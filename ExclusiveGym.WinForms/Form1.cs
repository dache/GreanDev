using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AxZKFPEngXControl;
using ExclusiveGym.WinForms.Models;



namespace ExclusiveGym.WinForms
{
    public partial class Form1 : Form, IMessageFilter
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        public const int WM_LBUTTONDOWN = 0x0201;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private HashSet<Control> controlsToMove = new HashSet<Control>();

        private AxZKFPEngX m_zkFprint;
        private bool Check;

        private Member m_testMember;
        public Form1()
        {
            InitializeComponent();
            
            //
            StorageManager.GetSingleton();
            m_zkFprint = FingerPrint.GetSingleton().GetFingerprint();

            // Custom Move title bar 
            Application.AddMessageFilter(this);
            controlsToMove.Add(this.TitleBarPanel);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitialAxZkfp();

            //SampleData();
        }

        private void SampleData()
        {
            StorageManager.GetSingleton().CreateSampleMember();
            StorageManager.GetSingleton().CreateSampleCourse();
        }

        

        private void InitialAxZkfp()
        {
            try
            {
                SetupFingerprint();
                if (m_zkFprint.InitEngine() == 0)
                {
                    m_zkFprint.FPEngineVersion = "9";
                    m_zkFprint.EnrollCount = 3;
                    //deviceSerial.Text += " " + m_zkFprint.SensorSN + " Count: " + m_zkFprint.SensorCount.ToString() + " Index: " + m_zkFprint.SensorIndex.ToString();
                    Console.WriteLine("Device successfully connected");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Device init err, error: " + ex.Message);
            }
        }

        private void SetupFingerprint()
        {
            FingerPrint.GetSingleton().SetupFingerprintEvent(Controls, zkFprint_OnFeatureInfo, zkFprint_OnImageReceived, zkFprint_OnEnroll, zkFprint_OnCapture);
        }
        
        private void zkFprint_OnImageReceived(object sender, IZKFPEngXEvents_OnImageReceivedEvent e)
        {
            Console.WriteLine("zkFprint_OnImageReceived");
        }
        private void zkFprint_OnFeatureInfo(object sender, IZKFPEngXEvents_OnFeatureInfoEvent e)
        {
            Console.WriteLine("zkFprint_OnFeatureInfo");
        }
        private void zkFprint_OnEnroll(object sender, IZKFPEngXEvents_OnEnrollEvent e)
        {
            Console.WriteLine("zkFprint_OnEnroll");
        }
        private void zkFprint_OnCapture(object sender, IZKFPEngXEvents_OnCaptureEvent e)
        {
            Console.WriteLine("zkFprint_OnCapture");
            string template = m_zkFprint.EncodeTemplate1(e.aTemplate);
            Console.WriteLine("Scan string : " + template);

            Member currentMember = null;
            foreach (Member member in StorageManager.GetSingleton().GetMemberList())
            {
                if (m_zkFprint.VerFingerFromStr(ref template, member.FingerPrint, false, ref Check))
                {
                    currentMember = member;
                    break;
                }
            }

            if (currentMember == null)
            {
                DisplayNeedRegistryForm();
            }
            else
            {
                if (currentMember.ExpireDate == null || currentMember.ExpireDate < DateTime.Now)
                {
                    DisplayNeedApplySomeCourse();
                }
                else
                {
                    var welcomeForm = new WelcomeDialogForm(currentMember);
                    welcomeForm.ShowDialog();
                }
            }

        }

      
        private void btnVerify_Click(object sender, EventArgs e)
        {
            

        }
        
        private void InitMenu()
        {

        }

        protected void btnMenu_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            currentMenuPanel.Top = btn.Top;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void btnSlideMenu_Click(object sender, EventArgs e)
        {
            var menuWidth = (MenuPanel.Width == 205) ? 50 : 205;
            MenuPanel.Width = menuWidth;
        }

        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == WM_LBUTTONDOWN &&
            controlsToMove.Contains(Control.FromHandle(m.HWnd)))
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                return true;
            }
            return false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenMemberForm();
        }
        private void DisplayNeedRegistryForm()
        {
            var dialogForm = new DialogForm("Exclusive Gym", "ไม่พบข้อมูลสมาชิก ต้องการสมัครสมาชิกใหม่หรือไม่");
            if (dialogForm.ShowDialog() == DialogResult.OK)
            {
                OpenMemberForm();
            }
        }

        private void OpenMemberForm()
        {
            FingerPrint.GetSingleton().RemoveFingerprintEvent(Controls, zkFprint_OnFeatureInfo, zkFprint_OnImageReceived, zkFprint_OnEnroll, zkFprint_OnCapture);
            var memberForm = new MemberForm();
            memberForm.m_registryiSdone = SetupFingerprint;
            memberForm.ShowDialog();
        }

        private void DisplayNeedApplySomeCourse()
        {
            //MessageBox.Show("เลือกโปรโมชั่นที่ต้องการ");
            
            var DialogNeedApplyCourse = new DialogNeedApplyCourse(StorageManager.GetSingleton().GetSampleMember(), ApplyCourseCallback);
            DialogNeedApplyCourse.ShowDialog();
        }

        private void ApplyCourseCallback()
        {
            var welcomeForm = new WelcomeDialogForm(StorageManager.GetSingleton().GetSampleMember());
            welcomeForm.ShowDialog();
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            //case 1
            DisplayNeedRegistryForm();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            //case 2
            Member scanedMember = StorageManager.GetSingleton().GetSampleMember();
            if (scanedMember.ExpireDate == null || scanedMember.ExpireDate <= DateTime.Now)
            {
                DisplayNeedApplySomeCourse();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //case 3
            var welcomeForm = new WelcomeDialogForm(StorageManager.GetSingleton().GetSampleMember());
            welcomeForm.ShowDialog();
        }
        
    }

    
}
