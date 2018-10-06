using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;
using ExclusiveGym.WinForms.Models;

namespace ExclusiveGym.WinForms.UserControls
{
    public partial class PaymentControl : UserControl
    {
        private PrintDocument printDocument = new PrintDocument();
        private static String RECEIPT = Environment.CurrentDirectory + @"\temp\payment.txt";
        private String stringToPrint = "";

        private PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();
        private PrintDocument printDocument1 = new PrintDocument();
        // Declare a string to hold the entire document contents.
        private string documentContents;

        public PaymentControl()
        {
            InitializeComponent();
            printDocument1.PrintPage +=
               new PrintPageEventHandler(printPage);

            // Data Gridview
            InitData();
        }

        private void InitData()
        {
            List<ApplyCourseLog> courses = StorageManager.GetSingleton().GetAllPayment();
            var payment = from p in courses
                          orderby p.ApplyDate descending
                          select new PaymentInfo()
                          {
                              PayDate = p.ApplyDate.ToString("dd/MM/yyyy"),
                              PayTime = p.ApplyDate.ToString("hh:mm:ss"),
                              PayName = $"{p.Name} {p.LastName}",
                              Price = p.CoursePrice,
                              CourseName = p.CourseName
                          };

            gvPayments.DataSource = payment.ToList();

            gvPayments.Columns[0].HeaderText = "ประเภท";
            gvPayments.Columns[1].HeaderText = "วันที่จ่ายเงิน";
            gvPayments.Columns[2].HeaderText = "เวลา";
            gvPayments.Columns[3].HeaderText = "ชื่อผู้จ่าย";
            gvPayments.Columns[4].HeaderText = "ราคา";
           
            gvPayments.Columns[0].Width = 100;
            gvPayments.Columns[1].Width = 120;
            gvPayments.Columns[2].Width = 120;
            gvPayments.Columns[3].Width = 270;
            gvPayments.Columns[4].Width = 100;

            gvPayments.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvPayments.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvPayments.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvPayments.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            gvPayments.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvPayments.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvPayments.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvPayments.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            gvPayments.Columns[4].DefaultCellStyle.Format = "N0";
            gvPayments.Columns[4].DefaultCellStyle.Padding = new Padding(5, 0, 5, 0);

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
                gvPayments.Columns[4].Width = 120;
            }
        }

        private void gvPayments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == gvPayments.Columns["printButton"].Index)
            {
                PaperSize customSize = new PaperSize();
                customSize.Width = 80;
                customSize.Height = 150;
                printDocument1.DefaultPageSettings.PaperSize = customSize;
                printPreviewDialog1.Document = printDocument1;
                printPreviewDialog1.ShowDialog();

                //printReceipt(); // Print แบบไม่ต้องโชว์ตัวอย่าง
            }
        }    

        private void printReceipt()
        {
            FileStream fs = new FileStream(RECEIPT, FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            stringToPrint = sr.ReadToEnd();
            //printDocument.PrinterSettings.PrinterName = DefaultPrinter.GetDefaultPrinterName();
            printDocument.PrintPage += new PrintPageEventHandler(printPage);
            printDocument.Print();
            sr.Close();
            fs.Close();
        }

        private void printPage(object sender, PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;

            Font regular = new Font(FontFamily.GenericSansSerif, 3f, FontStyle.Regular);
            Font bold = new Font(FontFamily.GenericSansSerif, 5f, FontStyle.Bold);

            Pen blackPen = new Pen(Color.Black, 1);

            float[] dashValues = { 1, 1, 1, 1 };
            Pen dashPen = new Pen(Color.Black, 0.5f);
            dashPen.DashPattern = dashValues;

            StringFormat format = new StringFormat(StringFormatFlags.DirectionRightToLeft);

            // Data
            PaymentInfo payment = (PaymentInfo)gvPayments.CurrentRow.DataBoundItem;

            //print header            
            graphics.DrawString("EXCLUSIVE GYM", bold, Brushes.Black, 8, 5);
            graphics.DrawString("10 ม.6 ต.แม่สอด อ.เถิน", regular, Brushes.Black, 5, 15);
            graphics.DrawString("จ.ลำปาง 52160 โทร. 088-263-1900", regular, Brushes.Black, 5, 20);

            //// Receive
            graphics.DrawString("ใบเสร็จรับเงิน", bold, Brushes.Black, 18, 30);
            //graphics.DrawLine(blackPen, 0, 30, 80, 30);
            graphics.DrawString($"เลขที่ : { Guid.NewGuid()}", regular, Brushes.Black, 2, 40);
            graphics.DrawString($"วันที่ : { payment.PayDate}", regular, Brushes.Black, 2, 45);
            graphics.DrawString($"เวลา : { payment.PayTime}", regular, Brushes.Black, 45, 45);
            graphics.DrawString("CASH : เงินสด", regular, Brushes.Black, 2, 50);
            graphics.DrawString($"ชื่อลูกค้า : { payment.PayName}", regular, Brushes.Black, 2, 55);

            /// Item
            graphics.DrawString("ประเภท", regular, Brushes.Black, 13, 65);
            graphics.DrawString("|", regular, Brushes.Black, 40, 65);
            graphics.DrawString("ราคา", regular, Brushes.Black, 54, 65);
            graphics.DrawLine(dashPen, 5, 72, 75, 72);
            graphics.DrawString(payment.CourseName, regular, Brushes.Black, 5, 75);
            graphics.DrawString(String.Format("{0:N}", payment.Price), regular, Brushes.Black, 75, 75, format);
            // sumary
            graphics.DrawLine(dashPen, 5, 95, 75, 95);
            graphics.DrawString("รวม", bold, Brushes.Black, 2, 97);            
            graphics.DrawString("บาท", bold, Brushes.Black, 78, 97, format);
            graphics.DrawString(String.Format("{0:N}", payment.Price), bold, Brushes.Black, 65, 97, format);

            //print footer
            graphics.DrawLine(dashPen, 5, 110, 75, 110);
            graphics.DrawString("THANK YOU.", bold, Brushes.Black, 15, 112);

            regular.Dispose();
            bold.Dispose();

            // Check to see if more pages are to be printed.
            //e.HasMorePages = (itemList.Count > 20);
        }
    }

    public class PaymentInfo
    {
        public string CourseName { get; set; }
        public string PayDate { get; set; }
        public string PayTime { get; set; }
        public string PayName { get; set; }
        public decimal Price { get; set; }        
    }
}
