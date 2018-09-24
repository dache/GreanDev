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
using USBLib;
using static USBLib.USB;
using System.IO;

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


        private System.Threading.Thread m_backgroundWorker;

        public Form1()
        {
            InitializeComponent();

            // UsbNotification.RegisterUsbDeviceNotification(this.Handle);
            StorageManager.GetSingleton();
            m_zkFprint = FingerPrint.GetSingleton().GetFingerprint();

            // Custom Move title bar 
            Application.AddMessageFilter(this);
            controlsToMove.Add(this.TitleBarPanel);
            m_instance = this;

        }

      

        //protected override void WndProc(ref Message m)
        //{
        //    base.WndProc(ref m);
        //    if (m.Msg == UsbNotification.WmDevicechange)
        //    {
        //        switch ((int)m.WParam)
        //        {
        //            case UsbNotification.DbtDeviceremovecomplete:


        //                //m_zkFprint.EndInit();
        //                //Console.WriteLine(m_zkFprint.Active);
        //                bool isFingerprintConnected = false;
        //                foreach(USBDevice d in USB.GetConnectedDevices())
        //                {
        //                    if (d.DeviceName.ToLower().IndexOf("fingerprint") != -1)
        //                    {
        //                        isFingerprintConnected = true;
        //                        break;
        //                    }
        //                }
        //                if(!isFingerprintConnected)
        //                {
        //                    if (m_zkFprint.Active)
        //                    {
        //                        m_zkFprint.EndEngine();
        //                        m_zkFprint.EndInit();
        //                        FingerPrint.GetSingleton().RemoveFingerprintEvent(Controls);

        //                        this.lblDeviceStatus.Text = "Disconnected";
        //                    }
        //                }
        //                    //Usb_DeviceRemoved(); // this is where you do your magic
        //                    break;
        //            case UsbNotification.DbtDevicearrival:
        //               // Console.WriteLine("m_zkFprint " + m_zkFprint.SensorSN);
        //                foreach (USBDevice d in USB.GetConnectedDevices())
        //                {
        //                    if(d.DeviceName.ToLower().IndexOf("fingerprint") != -1)
        //                    {
        //                        if (m_zkFprint == null || !m_zkFprint.Active)
        //                        {
        //                            //FingerPrint.GetSingleton().BeginInit();
        //                            m_zkFprint = FingerPrint.GetSingleton().GetFingerprint();
        //                            SetupFingerprint();
        //                            InitialAxZkfp();
        //                        }
        //                        break;
        //                    }

        //                }

        //                //Usb_DeviceAdded(); // this is where you do your magic
        //                break;
        //        }
        //    }
        //}

        private void Form1_Load(object sender, EventArgs e)
        {
            Console.WriteLine("Form1_Load");
            SetupFingerprint();
            InitialAxZkfp();
            homeControl1.BringToFront();
            btnHomeMenu.BackColor = Color.DimGray;

            m_backgroundWorker = new System.Threading.Thread(BackgroundThreadForm1);
            m_backgroundWorker.IsBackground = true;
            m_backgroundWorker.Start();
        }

        private void InitialAxZkfp()
        {
            try
            {
                string status = "Not Connected";
                if (m_zkFprint.InitEngine() == 0)
                {
                    m_zkFprint.FPEngineVersion = "9";

                    status = "Connected ";
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

        private void BackgroundThreadForm1()
        {
            while (true)
            {
                System.Threading.Thread.Sleep(1000);

                this.lblDate.BeginInvoke((MethodInvoker)delegate () { this.lblDate.Text = DateTime.Now.ToString("dd MMMM yyyy hh:mm:ss tt", new System.Globalization.CultureInfo("th-TH")); });
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
            btn.BackColor = Color.DimGray;

            if (btn == btnHomeMenu)
            {
                homeControl1.BringToFront();
            }
            else if (btn == btnMemberMenu)
            {
                memberControl1.BringToFront();
                memberControl1.InitMember();
            }
            else if (btn == btnPromotionMenu)
            {
                courseControl1.BringToFront();
            }
            else if (btn == btnIncomeMenu)
            {
                reportControl1.BringToFront();
                reportControl1.TotalOfReport();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //watching.Abort();
            m_zkFprint.EndEngine();
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
