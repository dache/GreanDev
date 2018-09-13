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
       
        private FinishCallback m_finishCallback;
        private Member m_currentMemberWillApply;
        public DialogNeedApplyCourse(Member member, FinishCallback callback)
        {
            
            m_finishCallback = callback;
            m_currentMemberWillApply = member;
            InitializeComponent();
            label1.Text = $"Hello : {member.Name + " " + member.LastName}";
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
    }
}
