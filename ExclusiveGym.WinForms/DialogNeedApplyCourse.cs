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

namespace ExclusiveGym.WinForms
{
    public partial class DialogNeedApplyCourse : Form
    {
        private const int WS_EX_TRANSPARENT = 0x20;

        private FinishCallbackWithMember m_finishCallback;
        private Member m_currentMemberWillApply;


        private Course currentCourse;

        public DialogNeedApplyCourse(Member member, FinishCallbackWithMember callback)
        {

            m_finishCallback = callback;
            m_currentMemberWillApply = member;
            InitializeComponent();
            SetStyle(ControlStyles.Opaque, true);
            label1.Text = $"Hello : {member.Name + " " + member.LastName}";
            SetStyle(ControlStyles.Opaque, true);

            // create button course
            var courses = StorageManager.GetSingleton().GetAllCourses().ToList();
            foreach (var course in courses)
            {
                Panel panel = new Panel() { Width = 300, Height = 80, BorderStyle = BorderStyle.FixedSingle, BackColor = Color.White };
                panel.Tag = course;
                Label lblName = new Label()
                {
                    Text = course.CourseName,
                    Location = new Point(5, 5),
                    Font = new Font(new FontFamily("Prompt"), 14),
                    ForeColor = Color.DimGray
                };
                panel.Click += panel_Click;
                panel.Controls.Add(lblName);
                Label lblPrice = new Label()
                {
                    Text = course.CoursePrice.ToString(),
                    Location = new Point(5, 34),
                    Font = new Font(new FontFamily("Prompt"), 20),
                    ForeColor = Color.YellowGreen,
                    Height = 40
                };
                panel.Controls.Add(lblPrice);
                courseFlowLayout.Controls.Add(panel);
            }
        }

        private void Daily_Click(object sender, EventArgs e)
        {
            StorageManager.GetSingleton().MemberApplyCourse(m_currentMemberWillApply,
                StorageManager.GetSingleton().GetDailyCourse());
            m_finishCallback(this.m_currentMemberWillApply);
            this.Close();
        }

        private void FindOtherCourse_Click(object sender, EventArgs e)
        {
            //var FormCourseList = new FormCourseList(m_currentMemberWillApply, m_finishCallback);
            //FormCourseList.ShowDialog();
            //this.Close();
        }

        private void chkCourse_CheckedChanged(object sender, System.EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            if (chk.Checked)
            {
                foreach (Panel panel in chk.Parent.Parent.Controls)
                {
                    CheckBox c = panel.Controls.OfType<CheckBox>().SingleOrDefault();
                    if (c != chk) c.Checked = false;
                }
                chk.Parent.BackColor = Color.Red;
            }
            else
            {
                chk.Parent.BackColor = Color.White;
            }
        }

        private void panel_Click(object sender, System.EventArgs e)
        {
            Panel panel = (Panel)sender;
            foreach (Panel p in panel.Parent.Controls)
            {
                if (p != panel) p.BackColor = Color.White;
            }
            //panel.BackColor = (panel.BackColor == Color.White) ? Color.OrangeRed : Color.White;
            panel.BackColor = Color.OrangeRed;

            currentCourse = (Course)panel.Tag;
        }

        #region BGOpacity
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void btnApply_Click(object sender, EventArgs e)
        {
            Course a = this.currentCourse;

            //StorageManager.GetSingleton().MemberApplyCourse(m_currentMemberWillApply, a);
            m_finishCallback(this.m_currentMemberWillApply);
            this.Close();
        }
    }
}
