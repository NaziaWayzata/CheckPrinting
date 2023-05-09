using System.Windows.Forms;
using System.Threading.Tasks;
using PdfSharp.Pdf;
using PrintCheck.BLL;
using PdfSharp.Drawing;
using Cheque_Printing;
using System.Data;

namespace PdfPrinting
{
         public partial class Form1 : Form
          {
              public Form1()
              {
                  InitializeComponent();
              }
              private int count = 0;
              private static ClassBLL objbll = new ClassBLL();
              private DataTable dt = objbll.GetData();

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            PdfDocument doc = new PdfDocument();
            doc.Info.Title = "Created with PDF";
            PdfPage page = doc.AddPage();
            XFont font = new XFont("Arial", 20);

            Rectangle pageArea = e.PageBounds;
            NumberToWords nw = new NumberToWords();
            if (count == 0)
            {
                ClassBLL objbll = new ClassBLL();
                DataTable dt = objbll.GetData();
                count++;
            }

            if (dt.Rows.Count >= 1)
            {
                foreach (DataRow row in dt.Rows)
                {
                    string IslamicCenter = "Islamic Center of Minnesota\r\n1401 GARDENA AVE NE\r\nFRIDLEY, MN 55432-5815\r\nTAX ID (EIN)\r\n41-6104145  ";
                    String bank = "Wells Fargo Bank \r\nhttps://www.wellsfargo.com/";
                    e.Graphics.DrawString(IslamicCenter, new System.Drawing.Font("Book Antiqua", 10, FontStyle.Regular), Brushes.Black, 25, 60);
                    e.Graphics.DrawString(bank, new System.Drawing.Font("Book Antiqua", 10, FontStyle.Regular), Brushes.Black, 355, 60);

                    e.Graphics.DrawString("PAY", new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(28, 190));
                    e.Graphics.DrawString("TO THE ORDER OF", new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(28, 240));
                    e.Graphics.DrawString("MEMO", new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(28, 290));
                    e.Graphics.DrawString("CHECK DATE", new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(594, 60));
                    e.Graphics.DrawString("CHECK AMOUNT", new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(594, 130));
                    e.Graphics.DrawString("CATEGORY", new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(594, 200));

                    e.Graphics.DrawString("$ " + nw.ConvertAmount(double.Parse(row["AMOUNT"].ToString())), new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(81, 190));
                    e.Graphics.DrawString(row["NAME"].ToString(), new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(204, 240));
                    e.Graphics.DrawString(row["TRANCOMMENT"].ToString().Length < 20 ? row["TRANCOMMENT"].ToString() : row["TRANCOMMENT"].ToString().Substring(0, 20), new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(138, 290));
                    e.Graphics.DrawString(((DateTime)row["CheckDate"]).ToShortDateString(), new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(733, 60));
                    e.Graphics.DrawString("$ " + row["AMOUNT"].ToString(), new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(733, 130));
                    e.Graphics.DrawString("$ " + nw.ConvertNumeralsToArabic(row["AMOUNT"].ToString()), new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(733, 154));

                    e.Graphics.DrawString(":1235468790:", new Font("OCR A Extended", 14, FontStyle.Regular), Brushes.Black, new Point(28, 320));
                    dt.Rows.Remove(row);

                    if (dt.Rows.Count == 0)
                    {
                        e.HasMorePages = false;
                        count = 0;
                        if (objbll.UpdateCheckPrintingStatus() > 0)
                        {
                            MessageBox.Show("Updated");
                        }
                    }
                    else
                    {
                        e.HasMorePages = true;
                    }
                    return;
                }
            }
        }

              private void button1_Click(object sender, EventArgs e)
              {
                  if (dt.Rows.Count > 0)
                  {
                      PrintDialog printdialog1 = new PrintDialog();
                      printdialog1.Document = printDocument1;
                      DialogResult result = printdialog1.ShowDialog();
                      if (result == DialogResult.OK)
                      {
                          printDocument1.Print();
                      }
                  }
                  else
                  {
                      MessageBox.Show("All The Checks Are Printed.");
                  }
              }
          }
        
   
}