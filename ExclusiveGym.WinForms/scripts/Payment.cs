using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExclusiveGym.WinForms.UserControls;

class Payment
{
    private static Payment m_singleton;
    private PaymentInfo payment;
    private PrintDocument printDocument1 = new PrintDocument();
    private PrintPreviewDialog previewDialog = new PrintPreviewDialog();

    public static Payment GetPayment()
    {
        if (m_singleton == null) m_singleton = new Payment();
        return m_singleton;
    }

    private Payment()
    {
        printDocument1.PrintPage +=
             new PrintPageEventHandler(printPage);
    }

    public void PrintRecipt(PaymentInfo pm, bool isShowDialog = false)
    {
        payment = pm;
       // printDocument1.PrintPage += new PrintPageEventHandler(printPage);
        if(isShowDialog)
        {
            PaperSize paperSize = new PaperSize();
            paperSize.Width = 180;
            paperSize.Height = 320;
            printDocument1.DefaultPageSettings.PaperSize = paperSize;
            previewDialog.Document = printDocument1;
            previewDialog.ShowDialog();
        }
        else
        {
           
            printDocument1.Print();
            printDocument1.Dispose();
        }
       
    }
    private void printPage(object sender, PrintPageEventArgs e)
    {
        Graphics graphics = e.Graphics;

        Font regular = new Font(FontFamily.GenericSansSerif, 6f, FontStyle.Regular);
        Font bold = new Font(FontFamily.GenericSansSerif, 10f, FontStyle.Bold);

        Pen blackPen = new Pen(Color.Black, 1);

        float[] dashValues = { 1, 1, 1, 1 };
        Pen dashPen = new Pen(Color.Black, 0.5f);
        dashPen.DashPattern = dashValues;

        StringFormat format = new StringFormat(StringFormatFlags.DirectionRightToLeft);


        //print header            
        graphics.DrawString("EXCLUSIVE GYM", bold, Brushes.Black, 20, 5);
        graphics.DrawString("113-115 ราษเกษมอุทิศ ในเมืองพิจิตร", regular, Brushes.Black, 8, 30);
        graphics.DrawString("จ.พิจิตร 66000 โทร. 088-273-9321", regular, Brushes.Black, 8, 40);

        //// Receive
        graphics.DrawString("ใบเสร็จรับเงิน", bold, Brushes.Black, 50, 65);
        graphics.DrawString($"เลขที่ : { payment.ID}", regular, Brushes.Black, 2, 80);
        graphics.DrawString($"วันที่ : { payment.PayDate}", regular, Brushes.Black, 2, 90);
        graphics.DrawString($"เวลา : { payment.PayTime}", regular, Brushes.Black, 2, 100);
        graphics.DrawString($"ชื่อ: { payment.PayName}", new Font(FontFamily.GenericSansSerif, 8f, FontStyle.Regular), Brushes.Black, 2, 120);

        /// Item
        graphics.DrawString("ประเภท", regular, Brushes.Black, 30, 150);
        graphics.DrawString("|", regular, Brushes.Black, 100, 150);
        graphics.DrawString("ราคา", regular, Brushes.Black, 130, 150);
        graphics.DrawLine(dashPen, 5, 170, 200, 170);

        graphics.DrawString(payment.CourseName, regular, Brushes.Black, 30, 175);
        graphics.DrawString(String.Format("{0:N}", payment.Price), regular, Brushes.Black, 150, 175, format);
        // sumary
        graphics.DrawLine(dashPen, 5, 190, 200, 190);
        graphics.DrawString(String.Format("รวม {0:N} บาท", payment.Price), bold, Brushes.Black, 150, 210, format);

        //print footer
        graphics.DrawLine(dashPen, 5, 230, 200, 230);
        graphics.DrawString("THANK YOU.", bold, Brushes.Black, 50, 250);

        regular.Dispose();
        bold.Dispose();

        // Check to see if more pages are to be printed.
        //e.HasMorePages = (itemList.Count > 20);
    }
}
