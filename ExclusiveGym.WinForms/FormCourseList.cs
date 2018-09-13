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
    public partial class FormCourseList : Form
    {
        private FinishCallback m_finishCallback;
        private Member m_currentMemberWillApply;
        public FormCourseList(Member member, FinishCallback callback)
        {
            
            m_finishCallback = callback;
            m_currentMemberWillApply = member;
            InitializeComponent();
            label1.Text = $"Select course for : {member.Name + " " + member.LastName}";
        }
     
        private void ApplyCourse_Click(object sender, EventArgs e)
        {
            //must get course from checkbox listview
            StorageManager.GetSingleton().MemberApplyCourse(m_currentMemberWillApply,
                StorageManager.GetSingleton().GetDailyCourse());


            m_finishCallback();
            this.Close();
        }
    }
}
