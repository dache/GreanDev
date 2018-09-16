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
            DisplayText(dailySumPriceLabel, applyCourseLogs, dailyDataView);
        }

        private void monthlyView_Click(object sender, EventArgs e)
        {
            List<ApplyCourseLog> applyCourseLogs = StorageManager.GetSingleton().GetIncomeByMonth(dailyDatePicker.Value.Month, dailyDatePicker.Value.Year);
            DisplayText(monthlySumPriceLabel, applyCourseLogs, montDataView);
        }

        private void yearView_Click(object sender, EventArgs e)
        {
            List<ApplyCourseLog> applyCourseLogs = StorageManager.GetSingleton().GetIncomeByYear(dailyDatePicker.Value.Year);
            DisplayText(yearSumPriceLabel, applyCourseLogs, yearDataView);
        }

        private void DisplayText(Label label, List<ApplyCourseLog> applyCourseLogs, DataGridView gv)
        {
            List<ReportData> reportData = new List<ReportData>();
            foreach (var log in applyCourseLogs)
            {
                var r = new ReportData()
                {
                    ApplyDate = log.ApplyDate,
                    CourseName = log.Course.CourseName,
                    CoursePrice = log.Course.CoursePrice,
                    MemberName = $"{log.Member.Name}  {log.Member.LastName}"
                };
                reportData.Add(r);
            }
            gv.DataSource = reportData;

            decimal sumPrice = reportData.Sum(f => f.CoursePrice);
            label.Text = string.Format(m_sumTxt, sumPrice); // Tostring("C2");

            gv.Columns[0].HeaderText = "ชื่อคอร์ส";
            gv.Columns[1].HeaderText = "ราคา";
            gv.Columns[2].HeaderText = "วันที่สมัคร";
            gv.Columns[3].HeaderText = "ชื่อสมาชิก";

            gv.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gv.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gv.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gv.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            gv.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gv.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            gv.Columns[0].Width = 200;
            gv.Columns[1].Width = 100;
            gv.Columns[2].Width = 150;
            gv.Columns[3].Width = 250;            
        }
    }

    public class ReportData
    {
        public string CourseName { get; set; }
        public decimal CoursePrice { get; set; }
        public DateTime ApplyDate { get; set; }
        public string MemberName { get; set; }
    }
}
