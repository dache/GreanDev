﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using AxZKFPEngXControl;
using ExclusiveGym.WinForms.Models;
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
            FormManager.GetSingleton().SetMainForm(this);
            FormManager.GetSingleton().SetCurrentFocusForm(this);
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
            SetupFingerprint();
            InitialAxZkfp();
            homeControl1.BringToFront();
            btnHomeMenu.BackColor = Color.DimGray;

            m_backgroundWorker = new System.Threading.Thread(BackgroundThreadForm1);
            m_backgroundWorker.IsBackground = true;
            m_backgroundWorker.Start();
            //for(int i = 0;i<300; i++)
            //{
            //    Member m = new Member();
            //    m.Name = i.ToString();
            //    m.LastName = i.ToString();
            //    m.FingerPrint = i.ToString();
            //    m.BirthDate = DateTime.Now;
            //    m.CreateDate = DateTime.Now;
            //    m.Age = 0;
            //    m.MemberId = i + 5;
            //    StorageManager.GetSingleton().AddMember(m);
            //}

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
        public void FocusToMainForm()
        {
            FormManager.GetSingleton().SetCurrentFocusForm(this);
            homeControl1.Refresh();
        }
        public void SetupFingerprint()
        {
            FocusToMainForm();
            FingerPrint.GetSingleton().SetupFingerprintEvent(Controls, zkFprint_OnFeatureInfo, zkFprint_OnImageReceived, zkFprint_OnEnroll, zkFprint_OnCapture);
        }

        private void zkFprint_OnImageReceived(object sender, IZKFPEngXEvents_OnImageReceivedEvent e)
        {
            //Console.WriteLine("zkFprint_OnImageReceived");
        }
        private void zkFprint_OnFeatureInfo(object sender, IZKFPEngXEvents_OnFeatureInfoEvent e)
        {
            //Console.WriteLine("zkFprint_OnFeatureInfo");
        }
        private void zkFprint_OnEnroll(object sender, IZKFPEngXEvents_OnEnrollEvent e)
        {
            //Console.WriteLine("zkFprint_OnEnroll");
        }
        private void zkFprint_OnCapture(object sender, IZKFPEngXEvents_OnCaptureEvent e)
        {
           // Console.WriteLine("zkFprint_OnCapture");
            string template = m_zkFprint.EncodeTemplate1(e.aTemplate);
            //Console.WriteLine("Scan string : " + template);

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
                //DisplayNeedRegistryForm();
                NotificationManager.GetSingleton().ShowNotification(this, "ไม่พบข้อมูลสมาชิก");
            }
            else
            {
                if (currentMember.ExpireDate == null || currentMember.ExpireDate < DateTime.Now)
                {
                    //var dialogForm = new DialogForm("Exclusive Gym", $"คุณ {currentMember.Name} {currentMember.LastName} \r\nยังไม่ได้สมัครคอร์ส ต้องการสมัครคอร์สหรือไม่");
                    //if (dialogForm.ShowDialog() == DialogResult.OK)
                    //{
                    //    var DialogNeedApplyCourse = new DialogNeedApplyCourse(currentMember, ApplyCourseCallback);
                    //    DialogNeedApplyCourse.ShowDialog();
                    //}
                    NotificationManager.GetSingleton().ShowNotification(this, $"สวัสดี คุณ {currentMember.Name} {currentMember.LastName} \nยังไม่ได้สมัครคอร์ส");
                }
                else
                {
                    NotificationManager.GetSingleton().ShowNotification(this, $"สวัสดี คุณ {currentMember.Name} {currentMember.LastName}" + $"\nสมาชิกหมดอายุวันที่ {currentMember.ExpireDate.Value.ToString("dd MMMM yyyy ", new System.Globalization.CultureInfo("th-TH"))}");
                    StorageManager.GetSingleton().MemberAccessGym(currentMember);

                    //var welcomeForm = new WelcomeDialogForm(currentMember);
                    //welcomeForm.ShowDialog();
                    //MemberApplyCourse memberApplyCourse = StorageManager.GetSingleton().GetMemberApplyCourseByMemberID(currentMember.MemberId);
                    //Course course = StorageManager.GetSingleton().GetCourseByID(memberApplyCourse.CourseID);
                    homeControl1.Refresh();
                }
            }

        }
        
        protected void btnMenu_Click(object sender, EventArgs e)
        {
            btnHomeMenu.BackColor = Color.Transparent;
            btnMemberMenu.BackColor = Color.Transparent;
            btnPromotionMenu.BackColor = Color.Transparent;
            btnIncomeMenu.BackColor = Color.Transparent;
            btnPayment.BackColor = Color.Transparent;

            Button btn = (Button)sender;
            currentMenuPanel.Top = btn.Top;
            btn.BackColor = Color.DimGray;
           // NotificationManager.GetSingleton().ShowNotification(this, "สวัสดี คุณ "+ btn.Name);
            if (btn == btnHomeMenu)
            {
                homeControl1.BringToFront();
                homeControl1.Refresh();
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
            else if(btn == btnPayment)
            {
                paymentControl1.BringToFront();
                paymentControl1.InitData();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            m_zkFprint.EndEngine();
            Application.Exit();
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
            //FingerPrint.GetSingleton().RemoveFingerprintEvent(Controls);
            var memberForm = new MemberForm();
            memberForm.m_registryiSdone = SetupFingerprint;
            memberForm.ShowDialog();
        }
     
        private void ApplyCourseCallback(Member member)
        {
            FormManager.GetSingleton().SetCurrentFocusForm(this);
            NotificationManager.GetSingleton().ShowNotification(this, $"สวัสดี คุณ {member.Name} {member.LastName}" + $"\nสมาชิกหมดอายุวันที่ {member.ExpireDate.Value.ToString("dd MMMM yyyy ", new System.Globalization.CultureInfo("th-TH"))}");
            StorageManager.GetSingleton().MemberAccessGym(member);
            //var welcomeForm = new WelcomeDialogForm(member);
            //welcomeForm.ShowDialog();

            homeControl1.Refresh();


            
        }
    }
}
