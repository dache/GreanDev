using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExclusiveGym.WinForms.Models;
using ExclusiveGym.WinForms.CustomControls;

namespace ExclusiveGym.WinForms.UserControls
{
    public partial class HomeControl : UserControl
    {
        public HomeControl()
        {
            InitializeComponent();
            InitHome();
        }

        private void InitHome()
        {

            var logs = StorageManager.GetSingleton().GetAccessLogList();
            foreach (var memberLog in logs)
            {
                var customControl = new MemberSignControl(memberLog);
                tableLayoutPanel1.Controls.Add(customControl);
            }

            lblMemberCount.Text = logs.Count().ToString();
            List<ApplyCourseLog> applyCourseLogs = StorageManager.GetSingleton().GetIncomeByDay(DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);
            int income = 0;
            foreach (ApplyCourseLog acl in applyCourseLogs)
            {
                var course = StorageManager.GetSingleton().GetCourseByID(acl.CourseID);
                if (course.CourseType == COURSETYPE.DAILY) income += acl.CoursePrice;
            }

            //lblIncome.Text = $"฿ { income.ToString() } ";
            lblIncome.Text = $"฿ { 100 } ";

        }
        public void Refresh()
        {
            tableLayoutPanel1.Controls.Clear();
            InitHome();
        }
    }
}
