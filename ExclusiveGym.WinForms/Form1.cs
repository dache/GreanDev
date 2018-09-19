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
using ExclusiveGym.WinForms.CustomControls;

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

        Timer t = new Timer();

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
            m_instance = this;
        }
        private System.Threading.Thread watching;
        private void Form1_Load(object sender, EventArgs e)
        {
            SetupFingerprint();
            // Date
            lblDate.Text = DateTime.Now.ToString("dd/MM/yyyy") + " |";
            //timer interval
            t.Interval = 1000;  //in milliseconds
            t.Tick += new EventHandler(this.t_Tick);
            //start timer when form loads
            t.Start();  //this will use t_Tick() method

            
            homeControl1.BringToFront();
            btnHomeMenu.BackColor = Color.DimGray;
            watching = new System.Threading.Thread(WatchingDevice);
            watching.IsBackground = true;
            watching.Start();
        }

        #region Timer
        //timer eventhandler
        private void t_Tick(object sender, EventArgs e)
        {
            //get current time
            int hh = DateTime.Now.Hour;
            int mm = DateTime.Now.Minute;
            int ss = DateTime.Now.Second;

            //time
            string time = "";

            //padding leading zero
            if (hh < 10)
            {
                time += "0" + hh;
            }
            else
            {
                time += hh;
            }
            time += ":";

            if (mm < 10)
            {
                time += "0" + mm;
            }
            else
            {
                time += mm;
            }
            time += ":";

            if (ss < 10)
            {
                time += "0" + ss;
            }
            else
            {
                time += ss;
            }

            //update label
            lblTimer.Text = time;
        }
        #endregion

      


        private void InitialAxZkfp()
        {
            try
            {
                string status = "Not Connected";
                if (m_zkFprint.InitEngine() == 0)
                {
                    m_zkFprint.FPEngineVersion = "9";
                    Console.WriteLine("Device successfully connected");
                    status = "Connected " + m_zkFprint.Active;
                }
                if (this.lblDeviceStatus.InvokeRequired)
                {
                    this.lblDeviceStatus.BeginInvoke((MethodInvoker)delegate () { this.lblDeviceStatus.Text = status; });
                }
                else
                {
                    this.lblDeviceStatus.Text = status;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Device init err, error: " + ex.Message);
            }
        }

        private void WatchingDevice()
        {
            while(true)
            {
                System.Threading.Thread.Sleep(1000);
               // Console.WriteLine("watching you " + m_zkFprint.InitEngine());
                InitialAxZkfp();
            }
        }
        public static Form1 m_instance;
        public void SetupFingerprint()
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
                    var dialogForm = new DialogForm("Exclusive Gym", $"คุณ {currentMember.Name} {currentMember.LastName} \r\nยังไม่ได้สมัครคอร์ส ต้องการสมัครคอร์สหรือไม่");
                    if (dialogForm.ShowDialog() == DialogResult.OK)
                    {
                        var DialogNeedApplyCourse = new DialogNeedApplyCourse(currentMember, ApplyCourseCallback);
                        DialogNeedApplyCourse.ShowDialog();
                    }
                }
                else
                {
                    var welcomeForm = new WelcomeDialogForm(currentMember);
                    welcomeForm.ShowDialog();
                    MemberApplyCourse memberApplyCourse = StorageManager.GetSingleton().GetMemberApplyCourseByMemberID(currentMember.MemberId);
                    Course course = StorageManager.GetSingleton().GetCourseByID(memberApplyCourse.CourseID);
                    homeControl1.Refresh();

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
            btnHomeMenu.BackColor = Color.Transparent;
            btnMemberMenu.BackColor = Color.Transparent;
            btnPromotionMenu.BackColor = Color.Transparent;
            btnIncomeMenu.BackColor = Color.Transparent;

            Button btn = (Button)sender;
            currentMenuPanel.Top = btn.Top;
            btn.BackColor = Color.DimGray ;

            if (btn == btnHomeMenu)
            {
                homeControl1.BringToFront();
            }
            else if (btn == btnMemberMenu)
            {
                memberControl1.BringToFront();
            }
            else if (btn == btnPromotionMenu)
            {
                courseControl1.BringToFront();
            }
            else if (btn == btnIncomeMenu)
            {
                reportControl1.BringToFront();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //watching.Abort();
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        //private void btnSlideMenu_Click(object sender, EventArgs e)
        //{
        //    var menuWidth = (MenuPanel.Width == 205) ? 50 : 205;
        //    MenuPanel.Width = menuWidth;
        //}

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

        private async void OpenMemberForm()
        {
            FingerPrint.GetSingleton().RemoveFingerprintEvent(Controls);
            var memberForm = new MemberForm();
            memberForm.m_registryiSdone = SetupFingerprint;
            memberForm.ShowDialog();
        }

        private void ApplyCourseCallback(Member member)
        {
            var welcomeForm = new WelcomeDialogForm(member);
            welcomeForm.ShowDialog();

            homeControl1.Refresh();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //case 1
            DisplayNeedRegistryForm();
            //SampleData();
        }      
    }
}
