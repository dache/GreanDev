using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AxZKFPEngXControl;
using ExclusiveGym.WinForms.Models;
using AForge.Video;
using AForge.Video.DirectShow;

namespace ExclusiveGym.WinForms
{
    public partial class MemberForm : Form
    {
        private const int WS_EX_TRANSPARENT = 0x20;

        public FinishCallback m_registryiSdone;

        //private AxZKFPEngX m_zkFprint;

        public Member Member { get; set; }

        VideoCaptureDevice videoSource;
        FilterInfoCollection videoDevices;

        public MemberForm()
        {
            InitializeComponent();
            SetStyle(ControlStyles.Opaque, true);
            // lblMemberCourse.Visible = false;
            // lblCourse.Visible = false;
            // new Member
            this.Member = new Member();
            this.Member.MemberId = -1;
            textBox1.Text = DateTime.Now.Day.ToString();
            comboBox1.Text = DateTime.Now.Date.ToString("MMMM", new System.Globalization.CultureInfo("th-TH"));
            textBox2.Text = DateTime.Now.Date.ToString("yyyy", new System.Globalization.CultureInfo("th-TH"));
            problemPanel.Visible = false;


            btnSave.BringToFront();
        }
        private void DetectCamera()
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo info in videoDevices)
            {
                camerabox.Items.Add(info.Name);
            }
            saveImg.Visible = (camerabox.Items.Count > 0);
            btnUpload.Visible = (camerabox.Items.Count == 0);
            camerabox.Visible = saveImg.Visible;
            saveImg.Enabled = saveImg.Visible && (videoSource != null);
        }
             
        public MemberForm(Member member)
        {
            InitializeComponent();
            SetStyle(ControlStyles.Opaque, true);
            this.Member = member;
            lblHeader.Text = "ดู/แก้ไข ข้อมูลสมาชิก";
            InitMember();
            
            btnEdit.BringToFront();
        }
        private ApplyCourseLog m_currentMemberCourse;
        private void InitMember()
        {
            problemPanel.Visible = true;
            // Detail
            txtName.Text = this.Member.Name;
            txtLastName.Text = this.Member.LastName;
            txtThaiId.Text = this.Member.ThaiId;

            textBox1.Text = this.Member.BirthDate.Day.ToString();
            comboBox1.Text = this.Member.BirthDate.Date.ToString("MMMM", new System.Globalization.CultureInfo("th-TH"));
            textBox2.Text = this.Member.BirthDate.Date.ToString("yyyy", new System.Globalization.CultureInfo("th-TH"));

            if (this.Member.ExpireDate != null)
            {
                textBox6.Text = this.Member.ExpireDate?.Day.ToString();
                comboBox3.Text = this.Member.ExpireDate?.Date.ToString("MMMM", new System.Globalization.CultureInfo("th-TH"));
                textBox5.Text = this.Member.ExpireDate?.Date.ToString("yyyy", new System.Globalization.CultureInfo("th-TH"));
            }
            m_currentMemberCourse = StorageManager.GetSingleton().GetApplyCourseLogByMemberID(this.Member.MemberId);
            if (m_currentMemberCourse != null)
            {
                button1.Visible = true;
                textBox4.Text = m_currentMemberCourse.ApplyDate.Day.ToString();
                comboBox2.Text = m_currentMemberCourse.ApplyDate.Date.ToString("MMMM", new System.Globalization.CultureInfo("th-TH"));
                textBox3.Text = m_currentMemberCourse.ApplyDate.Date.ToString("yyyy", new System.Globalization.CultureInfo("th-TH"));
                textBox7.Text = m_currentMemberCourse.CoursePrice.ToString();
            }
            else
            {
                textBox7.Text = "0";
                button1.Visible = false;
                textBox4.Text = DateTime.Now.Day.ToString();
                comboBox2.Text = DateTime.Now.Date.ToString("MMMM", new System.Globalization.CultureInfo("th-TH"));
                textBox3.Text = DateTime.Now.Date.ToString("yyyy", new System.Globalization.CultureInfo("th-TH"));

                textBox6.Text = DateTime.Now.Day.ToString();
                comboBox3.Text = DateTime.Now.Date.ToString("MMMM", new System.Globalization.CultureInfo("th-TH"));
                textBox5.Text = DateTime.Now.Date.ToString("yyyy", new System.Globalization.CultureInfo("th-TH"));
            }
            txtAge.Text = this.Member.Age.ToString();
            lblFingerPrint.Text = this.Member.FingerPrint;

            chkMale.Checked = (this.Member.Gender == enumGender.Male);
            chkFemale.Checked = (this.Member.Gender == enumGender.Female);

            txtHouseNumber.Text = this.Member.HouseNumber;
            txtVillageNumber.Text = this.Member.VillageNumber;
            txtVillageName.Text = this.Member.VillageName;
            txtLane.Text = this.Member.Lane;
            txtRoad.Text = this.Member.Road;
            txtSubDistrict.Text = this.Member.SubDistrict;
            txtDistrict.Text = this.Member.District;
            txtProvince.Text = this.Member.Province;
            txtPostCode.Text = this.Member.PostCode;
            txtPhoneNumber.Text = this.Member.PhoneNumber;
            txtEmail.Text = this.Member.Email;

            if (this.Member.MemberProfile != null)
            {
                Image img = (Bitmap)((new ImageConverter()).ConvertFrom(this.Member.MemberProfile.ImageByte));
                memberProfileImage.Image = img;
            }
        }

        private void MemberForm_Load(object sender, EventArgs e)
        {
            DetectCamera();
            FormManager.GetSingleton().SetCurrentFocusForm(this);
            //System.Threading.Thread backgroundWorker = new System.Threading.Thread(BeginDisplay);
            //backgroundWorker.IsBackground = true;
            //backgroundWorker.Start();
            //m_zkFprint = FingerPrint.GetSingleton().GetFingerprint();
            //FingerPrint.GetSingleton().SetupFingerprintEvent(Controls, zkFprint_OnFeatureInfo, zkFprint_OnImageReceived, zkFprint_OnEnroll, zkFprint_OnCapture);
        }
        void BeginDisplay()
        {
            //lblCourse.BeginInvoke((MethodInvoker)async delegate ()
            //{
            //    await Task.Delay(1000);
            //    NotificationManager.GetSingleton().ShowNotification(this, "test");
            //});
        }
        private void CloseForm()
        {
            //FingerPrint.GetSingleton().RemoveFingerprintEvent(Controls);
            if (m_registryiSdone != null)
                m_registryiSdone();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CloseForm();
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            if (isFromValid())
            {
                this.Member.Name = txtName.Text;
                this.Member.LastName = txtLastName.Text;
                this.Member.ThaiId = txtThaiId.Text;
                DateTime dateTime = DateTime.ParseExact(textBox1.Text + " " + comboBox1.Text + " " + textBox2.Text, "d MMMM yyyy",
            new System.Globalization.CultureInfo("th-TH"));
                this.Member.BirthDate = dateTime;
                this.Member.Age = Convert.ToInt32(txtAge.Text);
                this.Member.FingerPrint = lblFingerPrint.Text;
                this.Member.Gender = (chkMale.Checked) ? enumGender.Male : enumGender.Female;
                this.Member.HouseNumber = txtHouseNumber.Text;
                this.Member.VillageNumber = txtVillageNumber.Text;
                this.Member.VillageName = txtVillageName.Text;
                this.Member.Lane = txtLane.Text;
                this.Member.Road = txtRoad.Text;
                this.Member.SubDistrict = txtSubDistrict.Text;
                this.Member.District = txtDistrict.Text;
                this.Member.Province = txtProvince.Text;
                this.Member.PostCode = txtPostCode.Text;
                this.Member.PhoneNumber = txtPhoneNumber.Text;
                this.Member.Email = txtEmail.Text;
                this.Member.CreateDate = DateTime.Now;
                this.Member.IsActive = true;
                //this.Member.Problems = GetMedicalProblem();
                //this.Member.MemberKnows = GetMemberKnows();
                
                StorageManager.GetSingleton().AddMember(this.Member);
                if(m_memberProfile != null)
                {
                    m_memberProfile.MemberId = this.Member.MemberId;
                    StorageManager.GetSingleton().SaveProfileImage(m_memberProfile);
                }
               

                CloseForm();
            }
        }



        private bool isFromValid()
        {
            if (txtAge.Text == "")
            {
                MessageBox.Show("กรุณาเลือกวันเกิด");
                return false;
            }
            if (!chkMale.Checked && !chkFemale.Checked)
            {
                MessageBox.Show("กรุณาเลือกเพศ");
                return false;
            }

            if (string.IsNullOrEmpty(textBox1.Text) && string.IsNullOrEmpty(comboBox1.SelectedText) && string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("กรุณากรอกวันเกิดให้ครบ");
                return false;
            }
            if (string.IsNullOrEmpty(lblFingerPrint.Text))
            {
                // MessageBox.Show("กรุณาเก็บลายนิ้วมือ");
                var dialogForm = new DialogForm("Exclusive Gym", "คุณยังไม่ได้เก็บลายนิ้วมือต้องการจะเก็บเลยหรือไม่");
                if (dialogForm.ShowDialog() == DialogResult.OK)
                {
                    ShowRecordFingerprint();
                    return false;
                }
                else
                    return true;
            }
            return true;
        }

        public void ReceiveFingerPrint(string fingerPrint)
        {
            // FingerPrint.GetSingleton().SetupFingerprintEvent(Controls, zkFprint_OnFeatureInfo, zkFprint_OnImageReceived, zkFprint_OnEnroll, zkFprint_OnCapture);
            lblFingerPrint.Text = fingerPrint;
        }

        private void btnFingerPrint_Click(object sender, EventArgs e)
        {
            ShowRecordFingerprint();
        }

        private void ShowRecordFingerprint()
        {
            FingerPrint.GetSingleton().RemoveFingerprintEvent(Controls);
            var fingerForm = new FingerPrintForm();
            fingerForm.m_fingerPrintCallback = ReceiveFingerPrint;
            fingerForm.ShowDialog();
        }

        #region BG Tranparent
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
        #endregion






        private void chkGender_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox currentChk = (CheckBox)sender;
            if (currentChk.Checked)
            {
                if (currentChk == chkMale)
                {
                    chkFemale.Checked = false;
                }
                else
                {
                    chkMale.Checked = false;
                }
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (isFromValid())
            {
                this.Member.Name = txtName.Text;
                this.Member.LastName = txtLastName.Text;
                this.Member.ThaiId = txtThaiId.Text;

                this.Member.Name = txtName.Text;
                this.Member.LastName = txtLastName.Text;
                this.Member.ThaiId = txtThaiId.Text;
                DateTime dateTime = DateTime.ParseExact(textBox1.Text + " " + comboBox1.Text + " " + textBox2.Text, "d MMMM yyyy",
            new System.Globalization.CultureInfo("th-TH"));
                this.Member.BirthDate = dateTime;
                this.Member.Age = Convert.ToInt32(txtAge.Text);
                this.Member.FingerPrint = lblFingerPrint.Text;
                this.Member.Gender = (chkMale.Checked) ? enumGender.Male : enumGender.Female;
                this.Member.HouseNumber = txtHouseNumber.Text;
                this.Member.VillageNumber = txtVillageNumber.Text;
                this.Member.VillageName = txtVillageName.Text;
                this.Member.Lane = txtLane.Text;
                this.Member.Road = txtRoad.Text;
                this.Member.SubDistrict = txtSubDistrict.Text;
                this.Member.District = txtDistrict.Text;
                this.Member.Province = txtProvince.Text;
                this.Member.PostCode = txtPostCode.Text;
                this.Member.PhoneNumber = txtPhoneNumber.Text;
                this.Member.Email = txtEmail.Text;


                StorageManager.GetSingleton().SaveObjectChanged(this.Member);

                if (m_memberProfile != null)
                {
                    m_memberProfile.MemberId = this.Member.MemberId;
                    StorageManager.GetSingleton().SaveProfileImage(m_memberProfile);
                }

                //StorageManager.GetSingleton().MemberApplyCourse(this.Member, StorageManager.GetSingleton().GetCourseByID(1));
                //StorageManager.GetSingleton().MemberAccessGym(this.Member);
                CloseForm();
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            HandleNumber(textBox1);
            CalcAge();
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            CalcAge();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            HandleNumber(textBox2);
            CalcAge();
        }

        private void CalcAge()
        {
            try
            {
                DateTime dateTime = DateTime.ParseExact(textBox1.Text + " " + comboBox1.Text + " " + textBox2.Text, "d MMMM yyyy",
            new System.Globalization.CultureInfo("th-TH"));
                //Console.WriteLine(dateTime.ToString("d MMMM yyyy ", new System.Globalization.CultureInfo("th-TH")));
                DateTime zeroTime = new DateTime(1, 1, 1);
                DateTime toDay = DateTime.Now;
                TimeSpan span = (toDay - dateTime);
                int years = (zeroTime + span).Year - 1;
                txtAge.Text = years.ToString();
            }
            catch
            {

            }
        }

        private void txtThaiId_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            HandleNumber(textBox4);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            HandleNumber(textBox3);
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            HandleNumber(textBox6);
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            HandleNumber(textBox5);
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            HandleNumber(textBox7);
        }

        private void HandleNumber(TextBox textBox)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox.Text, "[^0-9]"))
            {
                textBox.Text = textBox.Text.Remove(textBox.Text.Length - 1);
                textBox.SelectionStart = textBox.Text.Length;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //try
            //{
                DateTime dateTime = DateTime.ParseExact(textBox4.Text + " " + comboBox2.Text + " " + textBox3.Text, "d MMMM yyyy",
         new System.Globalization.CultureInfo("th-TH"));

                dateTime = dateTime.AddHours(DateTime.Now.Hour);
                dateTime = dateTime.AddMinutes(DateTime.Now.Minute);
                dateTime = dateTime.AddSeconds(DateTime.Now.Second);

                DateTime expireDate = DateTime.ParseExact(textBox6.Text + " " + comboBox3.Text + " " + textBox5.Text, "d MMMM yyyy",
               new System.Globalization.CultureInfo("th-TH"));

                this.Member.ExpireDate = expireDate;

                m_currentMemberCourse.ApplyDate = dateTime;
                m_currentMemberCourse.CoursePrice = Convert.ToInt32(textBox7.Text.Trim());
                StorageManager.GetSingleton().SaveObjectChanged(this.Member);
                StorageManager.GetSingleton().SaveObjectChanged(this.m_currentMemberCourse);
            //}
            //catch
            //{

            //}

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dateTime = DateTime.ParseExact(textBox4.Text + " " + comboBox2.Text + " " + textBox3.Text, "d MMMM yyyy",
          new System.Globalization.CultureInfo("th-TH"));
                dateTime = dateTime.AddHours(DateTime.Now.Hour);
                dateTime = dateTime.AddMinutes(DateTime.Now.Minute);
                dateTime = dateTime.AddSeconds(DateTime.Now.Second);
                var memCourse = new ApplyCourseLog();
                memCourse.ApplyDate = dateTime;

                memCourse.MemberId = this.Member.MemberId;
                memCourse.CourseName = "รายเดือน";
                memCourse.Name = this.Member.Name;
                memCourse.LastName = this.Member.LastName;
                memCourse.CoursePrice = Convert.ToInt32(textBox7.Text.Trim());

                DateTime expireDate = DateTime.ParseExact(textBox6.Text + " " + comboBox3.Text + " " + textBox5.Text, "d MMMM yyyy",
               new System.Globalization.CultureInfo("th-TH"));

                this.Member.ExpireDate = expireDate;
                StorageManager.GetSingleton().SaveObjectChanged(this.Member);

                StorageManager.GetSingleton().MemberMontlyApplyCourse(this.Member, memCourse, dateTime);

                m_currentMemberCourse = StorageManager.GetSingleton().GetApplyCourseLogByMemberID(this.Member.MemberId);
            }
            catch
            {

            }

        }
        MemberProfile m_memberProfile = null;
        void videoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
       {
           Bitmap b = (Bitmap)eventArgs.Frame.Clone();
            DateTime now = DateTime.Now;
            Graphics g = Graphics.FromImage(b);
            // paint current time            
            SolidBrush brush = new SolidBrush(Color.Red);
            g.DrawString(now.ToString(), this.Font, brush, new PointF(5, 5));
            brush.Dispose();
            g.Dispose();
            cap = b;
            memberProfileImage.Image = b;
            saveImg.BeginInvoke((MethodInvoker) delegate ()
            {
                saveImg.Enabled = saveImg.Visible && videoSource.IsRunning;
            });
            
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Files|*.jpg;*.jpeg;*.png;";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog.FileName;
                using (Image image = Image.FromFile(path))
                {
                    using (MemoryStream m = new MemoryStream())
                    {
                        image.Save(m, image.RawFormat);
                        byte[] imageBytes = m.ToArray();
                        m_memberProfile = new MemberProfile();
                        m_memberProfile.Id = Guid.NewGuid();
                        m_memberProfile.MemberId = this.Member.MemberId;
                        m_memberProfile.ImageByte = imageBytes;

                        //StorageManager.GetSingleton().SaveProfileImage(m_memberProfile);
                        // Convert byte[] to Base64 String
                        //string base64String = Convert.ToBase64String(imageBytes);
                        //return base64String;                        
                    }
                }

                Image img = (Bitmap)((new ImageConverter()).ConvertFrom(m_memberProfile.ImageByte));
                memberProfileImage.Image = img;

            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (videoSource != null)
            {
                videoSource.Stop();
            }
            // create video source
            videoSource = new VideoCaptureDevice(videoDevices[camerabox.SelectedIndex].MonikerString);
            videoSource.NewFrame += new NewFrameEventHandler(videoSource_NewFrame);
            //videoSource = new VideoCaptureDevice(info.MonikerString);
            //videoSource.NewFrame += new NewFrameEventHandler(videoSource_NewFrame);
            videoSource.Start();
        }
        Bitmap cap;
        private void saveImg_Click(object sender, EventArgs e)
        {
            if (videoSource.IsRunning)
            {
                string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
                path = path.Replace("ExclusiveGym.WinForms.exe", "temp.bmp");
                //string fileName = Path.Combine(path, "temp.bmp");
                cap.Save(path);
                memberProfileImage.Image = cap;
                using (Image image = Image.FromFile(path))
                {
                    using (MemoryStream m = new MemoryStream())
                    {
                        videoSource.Stop();
                        image.Save(m, image.RawFormat);
                        byte[] imageBytes = m.ToArray();
                        m_memberProfile = new MemberProfile();

                        m_memberProfile.Id = Guid.NewGuid();
                        m_memberProfile.MemberId = this.Member.MemberId;
                        m_memberProfile.ImageByte = imageBytes;
                    }
                }

                Image img = (Bitmap)((new ImageConverter()).ConvertFrom(m_memberProfile.ImageByte));
                memberProfileImage.Image = img;
                File.Delete(path);
                //SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                //saveFileDialog1.Filter = "JPEG(*.jpg)|*.jpg|png(*.png)|*.png|Bitmap(*.bmp)|*.bmp"; videoSource.Stop(); // กล้องหยุด            
                //videoSource.Stop();
                //memberProfileImage.Image = cap;
                //if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                //{
                //    cap.Save(saveFileDialog1.FileName);
                //    m_memberProfile = new MemberProfile();

                //    string path = saveFileDialog1.FileName;
                //    using (Image image = Image.FromFile(path))
                //    {
                //        using (MemoryStream m = new MemoryStream())
                //        {
                //            image.Save(m, image.RawFormat);
                //            byte[] imageBytes = m.ToArray();

                //            m_memberProfile.Id = Guid.NewGuid();
                //            m_memberProfile.MemberId = this.Member.MemberId;
                //            m_memberProfile.ImageByte = imageBytes;                    
                //        }
                //    }

                //    Image img = (Bitmap)((new ImageConverter()).ConvertFrom(m_memberProfile.ImageByte));
                //    memberProfileImage.Image = img;
                //}
                //else
                //{
                //    videoSource.Start();
                //}
            }
            else
            {
                videoSource.Start();
            }
           
            //System.Threading.Thread.Sleep(500);
            //videoSource.Start(); // กล้องทำงานต่อ    
        }

        private void MemberForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (videoSource != null)
            {
                videoSource.Stop();
            }
        }
    }
}
