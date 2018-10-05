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
            //printDocument1.PrintPage +=
            //    new PrintPageEventHandler(printDocument1_PrintPage);
            printDocument1.PrintPage +=
               new PrintPageEventHandler(printPage);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            generateReceipt();
            //printReceipt();
            ReadDocument();
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void generateReceipt()
        {
            FileStream fs = new FileStream(RECEIPT, FileMode.Create);
            StreamWriter writer = new StreamWriter(fs);
            writer.WriteLine("========================");
            writer.WriteLine("    EXCLUSIVE GYM      ");
            writer.WriteLine("=======================");
            writer.Close();
            fs.Close();
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

        //private void printPage(object sender, PrintPageEventArgs e)
        //{
        //    int charactersOnPage = 0;
        //    int linesPerPage = 0;
        //    Graphics graphics = e.Graphics;

        //    // Sets the value of charactersOnPage to the number of characters 
        //    // of stringToPrint that will fit within the bounds of the page.
        //    graphics.MeasureString(stringToPrint, this.Font,
        //        e.MarginBounds.Size, StringFormat.GenericTypographic,
        //        out charactersOnPage, out linesPerPage);

        //    // Draws the string within the bounds of the page
        //    graphics.DrawString(stringToPrint, this.Font, Brushes.Black,
        //        e.MarginBounds, StringFormat.GenericTypographic);

        //    // Remove the portion of the string that has been printed.
        //    stringToPrint = stringToPrint.Substring(charactersOnPage);

        //    // Check to see if more pages are to be printed.
        //    e.HasMorePages = (stringToPrint.Length > 0);
        //}

        private void ReadDocument()
        {
            string docName = "testPage.txt";            
            printDocument1.DocumentName = docName;

            PrinterSettings ps = new PrinterSettings();
            IEnumerable<PaperSize> paperSizes = ps.PaperSizes.Cast<PaperSize>();

            PaperSize sizeA4 = paperSizes.First<PaperSize>(size => size.Kind == PaperKind.Statement); //
            PaperSize customSize = new PaperSize();
            customSize.Width = 80;
            customSize.Height = 200;
            printDocument1.DefaultPageSettings.PaperSize = customSize;

            using (FileStream stream = new FileStream(RECEIPT, FileMode.Open))
            using (StreamReader reader = new StreamReader(stream))
            {
                documentContents = reader.ReadToEnd();
            }
            stringToPrint = documentContents;
        }

        void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            int charactersOnPage = 0;
            int linesPerPage = 0;

            // Sets the value of charactersOnPage to the number of characters 
            // of stringToPrint that will fit within the bounds of the page.
            e.Graphics.MeasureString(stringToPrint, this.Font,
                e.MarginBounds.Size, StringFormat.GenericTypographic,
                out charactersOnPage, out linesPerPage);

            // Draws the string within the bounds of the page.
            e.Graphics.DrawString(stringToPrint, this.Font, Brushes.Black,
            e.MarginBounds, StringFormat.GenericTypographic);

            // Remove the portion of the string that has been printed.
            stringToPrint = stringToPrint.Substring(charactersOnPage);

            // Check to see if more pages are to be printed.
            e.HasMorePages = (stringToPrint.Length > 0);

            // If there are no more pages, reset the string to be printed.
            if (!e.HasMorePages)
                stringToPrint = documentContents;
        }

        List<string> itemList = new List<string>()
{
    "201", //fill from somewhere in your code
    "202"
};

        private void printPage(object sender, PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;

            Font regular = new Font(FontFamily.GenericSansSerif, 5f, FontStyle.Regular);
            Font bold = new Font(FontFamily.GenericSansSerif, 5f, FontStyle.Bold);

            //print header
            graphics.DrawString("==================", bold, Brushes.Black, 0, 0);
            graphics.DrawString("EXCLUSIVE GYM", bold, Brushes.Black, 10, 10);
            graphics.DrawLine(Pens.Black, 0, 20, 80, 20);
            graphics.DrawString("ประเภท          |          ราคา", bold, Brushes.Black, 0, 30);
            graphics.DrawString("รายวัน           70", regular, Brushes.Black, 0, 40);            
            graphics.DrawString($"วันที่", bold, Brushes.Black, 0, 70);
            graphics.DrawString($"{ DateTime.Now.ToString("dd/MM/yyy hh:mm:ss")}", regular, Brushes.Black, 0, 80);
          
            graphics.DrawLine(Pens.Black, 0, 90, 80, 90);

            //for (int i = 0; i < itemList.Count; i++)
            //{
            //    graphics.DrawString(itemList[i].ToString(), regular, Brushes.Black, 20, 150 + i * 20);
            //}

            //print footer
            //...

            regular.Dispose();
            bold.Dispose();

            // Check to see if more pages are to be printed.
            e.HasMorePages = (itemList.Count > 20);
        }
    }
}
