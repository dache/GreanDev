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
            dailyDatePicker.CustomFormat = dailyDatePicker.Value.ToString("dd MMMM yyyy ", new System.Globalization.CultureInfo("th-TH"));
            monthDateTimePicker.CustomFormat = monthDateTimePicker.Value.ToString("MMMM yyyy ", new System.Globalization.CultureInfo("th-TH"));
            yearDateTimePicker.CustomFormat = yearDateTimePicker.Value.ToString("yyyy ", new System.Globalization.CultureInfo("th-TH"));
        }

        public void TotalOfReport()
        {
            List<ApplyCourseLog> applyCourseLogs = StorageManager.GetSingleton().GetIncomeTotal();
            List<ReportTotal> reportData = new List<ReportTotal>();
            foreach (var log in applyCourseLogs)
            {
                var r = new ReportTotal()
                {
                    CourseName = log.Course.CourseName,
                    CoursePrice = log.CoursePrice
                };
                reportData.Add(r);
            }
            dataGridView1.DataSource = reportData;
            decimal sumPrice = reportData.Sum(f => f.CoursePrice);
            label4.Text = string.Format(m_sumTxt, sumPrice);

            dataGridView1.Columns[0].HeaderText = "ชื่อครอส";
            dataGridView1.Columns[1].HeaderText = "ราคา";

            dataGridView1.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            dataGridView1.Columns[0].Width = 330;
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Refresh();
        }
        private void dailyView_Click(object sender, EventArgs e)
        {
            List<ApplyCourseLog> applyCourseLogs = StorageManager.GetSingleton().GetIncomeByDay(dailyDatePicker.Value.Day, dailyDatePicker.Value.Month, dailyDatePicker.Value.Year);
            List<ReportTypeDaily> reportData = new List<ReportTypeDaily>();
            foreach (var log in applyCourseLogs)
            {
                var r = new ReportTypeDaily()
                {
                    ApplyDate = log.ApplyDate,
                    CourseName = log.Course.CourseName,
                    CoursePrice = log.CoursePrice,
                    MemberName = $"{log.Member.Name}  {log.Member.LastName}"
                };
                reportData.Add(r);
            }
            dailyDataView.DataSource = reportData;
            decimal sumPrice = reportData.Sum(f => f.CoursePrice);
            dailySumPriceLabel.Text = string.Format(m_sumTxt, sumPrice);

            dailyDataView.Columns[0].HeaderText = "วันที่";
            dailyDataView.Columns[1].HeaderText = "ชื่อครอส";
            dailyDataView.Columns[2].HeaderText = "ราคา";
            dailyDataView.Columns[3].HeaderText = "ชื่อสมาชิก";

            dailyDataView.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dailyDataView.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dailyDataView.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dailyDataView.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dailyDataView.Columns[0].DefaultCellStyle.Format = "dd MMMM yyyy";
            dailyDataView.Columns[0].DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("th-TH");
            dailyDataView.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dailyDataView.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dailyDataView.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dailyDataView.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dailyDataView.Columns[0].Width = 200;
            dailyDataView.Columns[1].Width = 230;
            dailyDataView.Columns[2].Width = 100;
            dailyDataView.Columns[3].Width = 250;
            dailyDataView.Refresh();
        }

        private void monthlyView_Click(object sender, EventArgs e)
        {
            List<ApplyCourseLog> applyCourseLogs = StorageManager.GetSingleton().GetIncomeByMonth(monthDateTimePicker.Value.Month, monthDateTimePicker.Value.Year);
            List<ReportTypeMonthly> reportData = new List<ReportTypeMonthly>();
            foreach (var log in applyCourseLogs)
            {
                var r = new ReportTypeMonthly()
                {
                    ApplyDate = log.ApplyDate,
                    CourseName = log.Course.CourseName,
                    CoursePrice = log.CoursePrice
                };
                reportData.Add(r);
            }
            montDataView.DataSource = reportData;
            decimal sumPrice = reportData.Sum(f => f.CoursePrice);
            monthlySumPriceLabel.Text = string.Format(m_sumTxt, sumPrice);

            montDataView.Columns[0].HeaderText = "วันที่";
            montDataView.Columns[1].HeaderText = "ชื่อครอส";
            montDataView.Columns[2].HeaderText = "ราคา";

            montDataView.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            montDataView.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            montDataView.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            montDataView.Columns[0].DefaultCellStyle.Format = "MMMM yyyy";
            montDataView.Columns[0].DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("th-TH");
            montDataView.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            montDataView.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            montDataView.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            montDataView.Columns[0].Width = 200;
            montDataView.Columns[1].Width = 230;
            montDataView.Columns[2].Width = 100;
            montDataView.Refresh();
        }

        private void yearView_Click(object sender, EventArgs e)
        {
            List<ApplyCourseLog> applyCourseLogs = StorageManager.GetSingleton().GetIncomeByYear(yearDateTimePicker.Value.Year);
            List<ReportTypeYear> reportData = new List<ReportTypeYear>();
            foreach (var log in applyCourseLogs)
            {
                var r = new ReportTypeYear()
                {
                    ApplyDate = log.ApplyDate,
                    CourseName = log.Course.CourseName,
                    CoursePrice = log.CoursePrice
                };
                reportData.Add(r);
            }
            yearDataView.DataSource = reportData;
            decimal sumPrice = reportData.Sum(f => f.CoursePrice);
            yearSumPriceLabel.Text = string.Format(m_sumTxt, sumPrice);

            yearDataView.Columns[0].HeaderText = "วันที่";
            yearDataView.Columns[1].HeaderText = "ชื่อครอส";
            yearDataView.Columns[2].HeaderText = "ราคา";

            yearDataView.Columns[0].DefaultCellStyle.Format = "MMMM yyyy";
            yearDataView.Columns[0].DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("th-TH");
            yearDataView.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            yearDataView.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            yearDataView.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            
            yearDataView.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            yearDataView.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            yearDataView.Columns[0].Width = 200;
            yearDataView.Columns[1].Width = 100;
            yearDataView.Columns[2].Width = 100;
            yearDataView.Refresh();
        }

        private void dailyDatePicker_ValueChanged(object sender, EventArgs e)
        {
            dailyDatePicker.CustomFormat = dailyDatePicker.Value.ToString("dd MMMM yyyy ", new System.Globalization.CultureInfo("th-TH"));
        }

        private void monthDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            monthDateTimePicker.CustomFormat = monthDateTimePicker.Value.ToString("yyyy ", new System.Globalization.CultureInfo("th-TH"));
        }

        private void yearDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            yearDateTimePicker.CustomFormat = yearDateTimePicker.Value.ToString("yyyy ", new System.Globalization.CultureInfo("th-TH"));

        }

        private void ReportControl_Load(object sender, EventArgs e)
        {
            TotalOfReport();
        }
    }

    public class ReportTypeDaily
    {
        public DateTime ApplyDate { get; set; }
        public string CourseName { get; set; }
        public decimal CoursePrice { get; set; }
        public string MemberName { get; set; }
    }

    public class ReportTypeMonthly
    {
        public DateTime ApplyDate { get; set; }
        public string CourseName { get; set; }
        public decimal CoursePrice { get; set; }
    }

    public class ReportTypeYear
    {
        public DateTime ApplyDate { get; set; }
        public string CourseName { get; set; }
        public decimal CoursePrice { get; set; }
    }

    public class ReportTotal
    {
        public string CourseName { get; set; }
        public decimal CoursePrice { get; set; }
    }

}
