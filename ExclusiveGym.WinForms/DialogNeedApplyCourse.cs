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

        private FinishCallback m_finishCallback;
        private Member m_currentMemberWillApply;

        public DialogNeedApplyCourse(Member member, FinishCallback callback)
        {
            
            m_finishCallback = callback;
            m_currentMemberWillApply = member;
            InitializeComponent();
            SetStyle(ControlStyles.Opaque, true);
            label1.Text = $"Hello : {member.Name + " " + member.LastName}";
            SetStyle(ControlStyles.Opaque, true);
        }

        private void Daily_Click(object sender, EventArgs e)
        {
            StorageManager.GetSingleton().MemberApplyCourse(m_currentMemberWillApply,
                StorageManager.GetSingleton().GetDailyCourse());
            m_finishCallback();
            this.Close();
        }

        private void FindOtherCourse_Click(object sender, EventArgs e)
        {
            var FormCourseList = new FormCourseList(m_currentMemberWillApply, m_finishCallback);
            FormCourseList.ShowDialog();
            this.Close();
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
    }
}
