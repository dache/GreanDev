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

        private AxZKFPEngX ZkFprint = new AxZKFPEngX();
        private bool Check;

        private List<UserFinger> Fingers = new List<UserFinger>();

        public Form1()
        {
            InitializeComponent();
            Application.AddMessageFilter(this);
            controlsToMove.Add(this.TitleBarPanel);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            Controls.Add(ZkFprint);
            InitialAxZkfp();
        }

        private void InitialAxZkfp()
        {
            try
            {
                ZkFprint.OnCapture += zkFprint_OnCapture;
                ZkFprint.OnImageReceived += zkFprint_OnImageReceived;
                ZkFprint.OnFeatureInfo += zkFprint_OnFeatureInfo;
                //zkFprint.OnFingerTouching 
                //zkFprint.OnFingerLeaving
                ZkFprint.OnEnroll += zkFprint_OnEnroll;

                if (ZkFprint.InitEngine() == 0)
                {
                    ZkFprint.FPEngineVersion = "9";
                    ZkFprint.EnrollCount = 3;
                    deviceSerial.Text += " " + ZkFprint.SensorSN + " Count: " + ZkFprint.SensorCount.ToString() + " Index: " + ZkFprint.SensorIndex.ToString();
                    ShowHintInfo("Device successfully connected");
                }

            }
            catch (Exception ex)
            {
                ShowHintInfo("Device init err, error: " + ex.Message);
            }
        }

        private void zkFprint_OnImageReceived(object sender, IZKFPEngXEvents_OnImageReceivedEvent e)
        {
            Graphics g = fpicture.CreateGraphics();
            Bitmap bmp = new Bitmap(fpicture.Width, fpicture.Height);
            g = Graphics.FromImage(bmp);
            int dc = g.GetHdc().ToInt32();
            ZkFprint.PrintImageAt(dc, 0, 0, bmp.Width, bmp.Height);
            g.Dispose();
            fpicture.Image = bmp;
        }

        private void zkFprint_OnFeatureInfo(object sender, IZKFPEngXEvents_OnFeatureInfoEvent e)
        {

            String strTemp = string.Empty;
            if (ZkFprint.EnrollIndex != 1)
            {
                if (ZkFprint.IsRegister)
                {
                    if (ZkFprint.EnrollIndex - 1 > 0)
                    {
                        int eindex = ZkFprint.EnrollIndex - 1;
                        strTemp = "Please scan again ..." + eindex;
                    }
                }
            }
            ShowHintInfo(strTemp);
        }
        private void zkFprint_OnEnroll(object sender, IZKFPEngXEvents_OnEnrollEvent e)
        {
            if (e.actionResult)
            {

                Console.WriteLine("zkFprint_OnEnroll");
                string template = ZkFprint.EncodeTemplate1(e.aTemplate);
                // txtTemplate.Text = template;
                ShowHintInfo("Registration successful. You can verify now");
                //btnRegister.Enabled = false;
                //btnVerify.Enabled = true;

                var newUser = new UserFinger();
                newUser.Name = txtName.Text;
                newUser.FingerPrint = template;
                Console.WriteLine("regis finger string : " + template);
                Fingers.Add(newUser);
            }
            else
            {
                ShowHintInfo("Error, please register again.");

            }
        }
        private void zkFprint_OnCapture(object sender, IZKFPEngXEvents_OnCaptureEvent e)
        {
            Console.WriteLine("zkFprint_OnCapture");
            string template = ZkFprint.EncodeTemplate1(e.aTemplate);
            Console.WriteLine("Scan string : " + template);
            bool found = false;
            foreach (UserFinger uf in Fingers)
            {
                if (ZkFprint.VerFingerFromStr(ref template, uf.FingerPrint, false, ref Check))
                {
                    ShowHintInfo("Verified");
                    MessageBox.Show($"Hello, {uf.Name}");
                    found = true;
                    break;
                }
                else
                    ShowHintInfo("Not Verified");
            }

            if (!found)
            {
                MessageBox.Show("User Is Not Register!");
                ShowHintInfo("Not Verified");
            }

        }



        private void ShowHintInfo(String s)
        {
            prompt.Text = s;
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            if (ZkFprint.IsRegister)
            {
                ZkFprint.CancelEnroll();
            }

            ZkFprint.BeginCapture();
            ShowHintInfo("Please give fingerprint sample.");


        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            //ZkFprint.CancelCapture();
            ZkFprint.CancelEnroll();
            ZkFprint.EnrollCount = 3;
            ZkFprint.BeginEnroll();
            ShowHintInfo("Please give fingerprint regis.");

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            fpicture.Image = null;
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
            var f = new MemberForm();
            f.ShowDialog();
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
            var dialogForm = new DialogForm("Exclusive Gym","ไม่พบข้อมูลสมาชิก ต้องการสมัครสมาชิกใหม่หรือไม่");
            if(dialogForm.ShowDialog() == DialogResult.OK)
            {
                var memberForm = new MemberForm();
                memberForm.ShowDialog();
            }           
        }
    }

    public class UserFinger
    {
        public string Name { get; set; }
        public string FingerPrint { get; set; }
    }
}
