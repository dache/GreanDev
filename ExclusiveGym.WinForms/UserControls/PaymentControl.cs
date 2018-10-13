using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using ExclusiveGym.WinForms.Models;

namespace ExclusiveGym.WinForms.UserControls
{
    public partial class PaymentControl : UserControl
    {
        public PaymentControl()
        {
            InitializeComponent();
        }

        public void InitData()
        {
            gvPayments.DataSource = null;

            gvPayments.Refresh();
            try
            {
                gvPayments.Columns.Remove("printButton");
            }
            catch { }

            List<ApplyCourseLog> courses = StorageManager.GetSingleton().GetAllPayment();
            var payment = from p in courses
                          orderby p.ApplyDate descending
                          select new PaymentInfo()
                          {
                              ID = p.AutoID,
                              PayDate = p.ApplyDate.ToString("dd MMMM yyyy"),
                              PayTime = p.ApplyDate.ToString("hh:mm:ss"),
                              PayName = $"{p.Name} {p.LastName}",
                              Price = p.CoursePrice,
                              CourseName = p.CourseName
                          };

            gvPayments.DataSource = payment.ToList();

            gvPayments.Columns[0].HeaderText = "ลำดับ";
            gvPayments.Columns[1].HeaderText = "ประเภท";
            gvPayments.Columns[2].HeaderText = "วันที่จ่ายเงิน";
            gvPayments.Columns[3].HeaderText = "เวลา";
            gvPayments.Columns[4].HeaderText = "ชื่อผู้จ่าย";
            gvPayments.Columns[5].HeaderText = "ราคา";

            gvPayments.Columns[2].DefaultCellStyle.Format = "dd MMMM yyyy";
            gvPayments.Columns[2].DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("th-TH");
           
            gvPayments.Columns[0].Width = 10;
            gvPayments.Columns[1].Width = 100;
            gvPayments.Columns[2].Width = 120;
            gvPayments.Columns[3].Width = 120;
            gvPayments.Columns[4].Width = 270;
            gvPayments.Columns[5].Width = 100;

            gvPayments.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvPayments.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvPayments.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvPayments.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvPayments.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            gvPayments.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvPayments.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvPayments.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvPayments.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvPayments.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            gvPayments.Columns[5].DefaultCellStyle.Format = "N0";
            gvPayments.Columns[5].DefaultCellStyle.Padding = new Padding(5, 0, 5, 0);

            DataGridViewButtonColumn newButton = new DataGridViewButtonColumn();
            newButton.Name = "printButton";
            newButton.Text = "พิมพ์ใบเสร็จ";
            newButton.HeaderText = "";
            newButton.UseColumnTextForButtonValue = true;
            newButton.DefaultCellStyle.BackColor = Color.FromArgb(240, 173, 78);
            newButton.FlatStyle = FlatStyle.Flat;
            newButton.DefaultCellStyle.ForeColor = Color.White;
            newButton.DefaultCellStyle.SelectionForeColor = Color.Wheat;
            if (gvPayments.Columns["printButton"] == null)
            {
                gvPayments.Columns.Insert(gvPayments.Columns.Count, newButton);
                gvPayments.Columns[6].Width = 120;
            }
        }

        private void gvPayments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == gvPayments.Columns["printButton"].Index)
            {
                Payment.GetPayment().PrintRecipt((PaymentInfo)gvPayments.CurrentRow.DataBoundItem);
            }
        }    
    }

    public class PaymentInfo
    {
        public int ID { get; set; }
        public string CourseName { get; set; }
        public string PayDate { get; set; }
        public string PayTime { get; set; }
        public string PayName { get; set; }
        public decimal Price { get; set; }        
    }
}
