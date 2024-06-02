using Microsoft.Identity.Client.NativeInterop;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Licenta
{
    public partial class InvoicePreview : Form
    {
        public InvoicePreview(string firstname, string lastname, DateTime date, string consultType, decimal amount)
        {
            InitializeComponent();

            lastnamelb.Text = lastname;
            firstnamelb.Text = firstname;
            datelb.Text = date.ToString("dd/MM/yyyy");
            consultTypelb.Text = consultType;
            amountlb.Text = amount.ToString("C2", CultureInfo.GetCultureInfo("ro-RO"));
        }

        private void printBtn_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(printBtn, "Print");
        }

        private void Print(Panel p1)
        {
            PrinterSettings ps = new PrinterSettings();
            panel2 = p1;
            getprintarea(p1);
            printPreviewDialog1.Document = printDocument1;
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            printPreviewDialog1.ShowDialog();
        }


        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Rectangle pagearea = e.PageBounds;
            float scaleX = (float)pagearea.Width / (float)memoryimg.Width;
            float scaleY = (float)pagearea.Height / (float)memoryimg.Height;
            float scale = Math.Min(scaleX, scaleY);

            int scaledWidth = (int)(memoryimg.Width * scale);
            int scaledHeight = (int)(memoryimg.Height * scale);

            e.Graphics.DrawImage(memoryimg, new Rectangle(0, 0, scaledWidth, scaledHeight));

        }

        private Bitmap memoryimg;

        private void getprintarea(Panel p1)
        {
            memoryimg = new Bitmap(p1.Width, p1.Height);
            p1.DrawToBitmap(memoryimg, new Rectangle(0, 0, p1.Width, p1.Height));
        }


        private void printBtn_Click(object sender, EventArgs e)
        {
            Print(this.panel2);
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
