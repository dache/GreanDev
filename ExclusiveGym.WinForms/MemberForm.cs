﻿using System;
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

        public FinishCallback m_registryiSdone;

        private AxZKFPEngX m_zkFprint;

        public Member Member { get; set; }

        public MemberForm()
        {
            InitializeComponent();
            SetStyle(ControlStyles.Opaque, true);
            lblMemberCourse.Visible = false;
            lblCourse.Visible = false;
            // new Member
            this.Member = new Member();

            // 
            btnSave.BringToFront();
            datePicker.CustomFormat = datePicker.Value.ToString("dd MMMM yyyy ", new System.Globalization.CultureInfo("th-TH"));
        }

        public MemberForm(Member member)
        {
            InitializeComponent();
            this.Member = member;
            lblHeader.Text = "ดู/แก้ไข ข้อมูลสมาชิก";
            InitMember();

            btnEdit.BringToFront();
        }

        private void InitMember()
        {
            // Detail
            txtName.Text = this.Member.Name;
            txtLastName.Text = this.Member.LastName;
            txtThaiId.Text = this.Member.ThaiId;
            datePicker.Value = this.Member.BirthDate;
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

            foreach (var problem in StorageManager.GetSingleton().GetMedicalProblemsByMemberId(this.Member.MemberId))
            {
                var chk = problemPanel.Controls.OfType<CheckBox>().Where(f => f.Text == problem.ProblemName).SingleOrDefault();
                if (chk != null)
                    chk.Checked = true;
                else
                    txtOtherProblem.Text += problem.ProblemName + " ";
            }
            //
            foreach (var memberKnow in StorageManager.GetSingleton().GetMemberKnowsByMemberId(this.Member.MemberId))
            {
                var chk = memberKnowPanel.Controls.OfType<CheckBox>().Where(f => f.Name.ToString().Replace("chkKnow", "") == memberKnow.MemberKnowFrom.ToString("D")).SingleOrDefault();
                if (chk != null)
                    chk.Checked = true;
            }

            // Member Course
            //lblCourse.Text = "";
        }

        private async void MemberForm_Load(object sender, EventArgs e)
        {
            m_zkFprint = FingerPrint.GetSingleton().GetFingerprint();
            FingerPrint.GetSingleton().SetupFingerprintEvent(Controls, zkFprint_OnFeatureInfo, zkFprint_OnImageReceived, zkFprint_OnEnroll, zkFprint_OnCapture);
        }

        private async void CloseForm()
        {
            FingerPrint.GetSingleton().RemoveFingerprintEvent(Controls);
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
                this.Member.BirthDate = DateTime.Now;
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
                this.Member.Problems = GetMedicalProblem();
                this.Member.MemberKnows = GetMemberKnows();

                StorageManager.GetSingleton().AddMember(this.Member);
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

        public async void ReceiveFingerPrint(string fingerPrint)
        {
            FingerPrint.GetSingleton().SetupFingerprintEvent(Controls, zkFprint_OnFeatureInfo, zkFprint_OnImageReceived, zkFprint_OnEnroll, zkFprint_OnCapture);
            lblFingerPrint.Text = fingerPrint;
        }

        private async void btnFingerPrint_Click(object sender, EventArgs e)
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
            Console.WriteLine("zkFprint_OnImageReceived member form");
        }

        private void zkFprint_OnFeatureInfo(object sender, IZKFPEngXEvents_OnFeatureInfoEvent e)
        {
            Console.WriteLine("zkFprint_OnFeatureInfo  member form");
        }

        private void zkFprint_OnEnroll(object sender, IZKFPEngXEvents_OnEnrollEvent e)
        {
            Console.WriteLine("zkFprint_OnEnroll  member form");
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



        private void chkNoProblem_CheckedChanged(object sender, EventArgs e)
        {
            foreach (CheckBox c in problemPanel.Controls.OfType<CheckBox>().ToList())
            {
                if (c != chkNoProblem)
                {
                    if (chkNoProblem.Checked)
                    {
                        c.Enabled = false;
                        c.Checked = false;
                    }
                    else
                    {
                        c.Enabled = true;
                    }
                }
            }
        }

        private void datePicker_ValueChanged(object sender, EventArgs e)
        {
            DateTime zeroTime = new DateTime(1, 1, 1);
            DateTime toDay = DateTime.Now;
            TimeSpan span = (toDay - datePicker.Value);
            int years = (zeroTime + span).Year - 1;
            txtAge.Text = years.ToString();
            datePicker.CustomFormat = datePicker.Value.ToString("dd MMMM yyyy ", new System.Globalization.CultureInfo("th-TH"));
        }

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
                this.Member.BirthDate = DateTime.Now;
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


                List<MedicalProblem> medicalProblemsOriginal = this.Member.Problems;

                List<MedicalProblem> medicalProblemsNew = GetMedicalProblem();


                foreach (MedicalProblem medicalProblem in medicalProblemsOriginal.ToList())
                {
                    MedicalProblem mp = medicalProblemsNew.Where(f => f.ProblemName == medicalProblem.ProblemName).SingleOrDefault();
                    if (mp == null)
                    {
                        StorageManager.GetSingleton().GetDB().Entry(medicalProblem).State = System.Data.Entity.EntityState.Deleted;
                    }
                }
                foreach (MedicalProblem medicalProblem in medicalProblemsNew)
                {
                    MedicalProblem mp = this.Member.Problems.Where(f => f.ProblemName == medicalProblem.ProblemName).SingleOrDefault();
                    if (mp == null)
                    {
                        this.Member.Problems.Add(medicalProblem);
                    }
                }

                List<MemberKnow> memberKnowsOriginal = this.Member.MemberKnows;
                List<MemberKnow> memberKnowsNew = GetMemberKnows();
                foreach (MemberKnow mk in memberKnowsOriginal.ToList())
                {
                    MemberKnow mp = memberKnowsNew.Where(f => f.MemberKnowFrom == mk.MemberKnowFrom).SingleOrDefault();
                    if (mp == null)
                    {
                        StorageManager.GetSingleton().GetDB().Entry(mk).State = System.Data.Entity.EntityState.Deleted;
                    }
                }
                foreach (MemberKnow mk in memberKnowsNew)
                {
                    MemberKnow mp = this.Member.MemberKnows.Where(f => f.MemberKnowFrom == mk.MemberKnowFrom).SingleOrDefault();
                    if (mp == null)
                    {
                        this.Member.MemberKnows.Add(mk);
                    }
                }
                StorageManager.GetSingleton().SaveObjectChanged(this.Member);

                //StorageManager.GetSingleton().MemberApplyCourse(this.Member, StorageManager.GetSingleton().GetCourseByID(1));
                //StorageManager.GetSingleton().MemberAccessGym(this.Member);
                CloseForm();
            }
        }

        private List<MemberKnow> GetMemberKnows()
        {
            var mk = new List<MemberKnow>();
            foreach (CheckBox c in memberKnowPanel.Controls.OfType<CheckBox>().ToList().Where(f => f.Checked))
            {
                var mem = new MemberKnow();
                mem.MemberKnowFrom = (enumMemberKnow)Enum.Parse(typeof(enumMemberKnow), c.Name.ToString().Replace("chkKnow", "")); //Convert.ToInt32();
                mem.MemberId = this.Member.MemberId;
                mem.Member = this.Member;
                mk.Add(mem);
            }
            return mk;
        }

        private List<MedicalProblem> GetMedicalProblem()
        {
            var mp = new List<MedicalProblem>();
            if (!string.IsNullOrEmpty(txtOtherProblem.Text))
            {
                var problem = new MedicalProblem();
                problem.ProblemName = txtOtherProblem.Text;
                problem.MemberId = this.Member.MemberId;
                problem.Member = this.Member;
                mp.Add(problem);
            }
            foreach (CheckBox c in problemPanel.Controls.OfType<CheckBox>().ToList().Where(f => f.Checked))
            {
                string mId = c.Name.ToString().Replace("chk", "");
                var problem = new MedicalProblem();
                problem.MedicalID = (mId == "NoProblem") ? 0 : Convert.ToInt32(mId);
                problem.ProblemName = c.Text;
                problem.MemberId = this.Member.MemberId;
                problem.Member = this.Member;
                mp.Add(problem);
            }
            return mp;
        }
    }
}
