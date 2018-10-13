using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExclusiveGym.WinForms.Models;
using ExclusiveGym.WinForms.UserControls;

namespace ExclusiveGym.WinForms
{
    public partial class DailyDialogForm : Form
    {
        private const int WS_EX_TRANSPARENT = 0x20;

        public DailyDialogForm()
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var member = new Member();
            member.Name = txtName.Text.Trim();
            member.LastName = txtLastName.Text.Trim();
            member.BirthDate = DateTime.Now;
            member.Age = 0;
            member.Gender = enumGender.Male;
            member.CreateDate = DateTime.Now;
            member.IsActive = true;
            member.FingerPrint = "Daily";

            var memCourse = new ApplyCourseLog();
            memCourse.ApplyDate = DateTime.Now;
            memCourse.CourseName = "รายวัน";
            memCourse.MemberId = member.MemberId;
            memCourse.Name = txtName.Text.Trim();
            memCourse.LastName = txtLastName.Text.Trim();
            memCourse.CoursePrice = Convert.ToInt32(txtPrice.Text.Trim());

            StorageManager.GetSingleton().MemberDailyApplyCourse(member, memCourse);

            PaymentInfo payment = new PaymentInfo();
            ApplyCourseLog applyCourseLog = StorageManager.GetSingleton().GetLastPayment();
            payment.ID = applyCourseLog.AutoID;
            payment.PayDate = applyCourseLog.ApplyDate.ToString("dd/MM/yyyy");
            payment.PayTime = applyCourseLog.ApplyDate.ToString("hh:mm:ss");
            payment.PayName = $"{applyCourseLog.Name} {applyCourseLog.LastName}";
            payment.Price = applyCourseLog.CoursePrice;
            payment.CourseName = applyCourseLog.CourseName;
            Payment.GetPayment().PrintRecipt(payment);
            Form1.m_instance.FocusToMainForm();
            this.Close();
        }

        private void DailyDialogForm_Load(object sender, EventArgs e)
        {
            FormManager.GetSingleton().SetCurrentFocusForm(this);
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtPrice.Text, "[^0-9]"))
            {
                txtPrice.Text = txtPrice.Text.Remove(txtPrice.Text.Length - 1);
                txtPrice.SelectionStart = txtPrice.Text.Length;
            }
        }
    }
}
