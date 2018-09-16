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

namespace ExclusiveGym.WinForms.UserControls
{
    public partial class ReportControl : UserControl
    {
        private string m_sumTxt;
        public ReportControl()
        {
            InitializeComponent();
            m_sumTxt = dailySumPriceLabel.Text;
            dailySumPriceLabel.Text = "รายได้รวม : 0";
            monthlySumPriceLabel.Text = dailySumPriceLabel.Text;
            yearSumPriceLabel.Text = dailySumPriceLabel.Text;
            //monthDateTimePicker.
        }
       
        private void dailyView_Click(object sender, EventArgs e)
        {
            List<ApplyCourseLog> applyCourseLogs = StorageManager.GetSingleton().GetIncomeByDay(dailyDatePicker.Value.Day, dailyDatePicker.Value.Month, dailyDatePicker.Value.Year);
            dailyDataView.DataSource = applyCourseLogs;
            DisplayText(dailySumPriceLabel, applyCourseLogs);
        }

        private void monthlyView_Click(object sender, EventArgs e)
        {
            List<ApplyCourseLog> applyCourseLogs = StorageManager.GetSingleton().GetIncomeByMonth(dailyDatePicker.Value.Month, dailyDatePicker.Value.Year);
            montDataView.DataSource = applyCourseLogs;
            DisplayText(monthlySumPriceLabel, applyCourseLogs);
        }

        private void yearView_Click(object sender, EventArgs e)
        {
            List<ApplyCourseLog> applyCourseLogs = StorageManager.GetSingleton().GetIncomeByYear(dailyDatePicker.Value.Year);
            yearDataView.DataSource = applyCourseLogs;
            DisplayText(yearSumPriceLabel, applyCourseLogs);
        }

        private void DisplayText(Label label, List<ApplyCourseLog> applyCourseLogs)
        {
            int sum = 0;
            foreach (ApplyCourseLog acl in applyCourseLogs)
            {
                sum += acl.CoursePrice;
            }
            label.Text = string.Format(m_sumTxt, sum);
        }
    }
}
