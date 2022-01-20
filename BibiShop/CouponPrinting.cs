using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BibiShop
{
    public partial class CouponPrinting : Form
    {
        ReportDocument rd = new ReportDocument();
        public CouponPrinting()
        {
            InitializeComponent();
        }

        private void CouponPrinting_Load(object sender, EventArgs e)
        {

        }

        private void CouponPrinting_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (rd != null)
            {
                rd.Close();
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printDocument1.DefaultPageSettings.PaperSize = new PaperSize("Custom", 800, 400);
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            using (Image logo = BibiShop.Properties.Resources.Free_Blank_Birthday_Coupon_Template)
            {
                e.Graphics.DrawImage(logo, new Point(0, 0));
                using (Font fnt1 = new Font("Arial", 12f, FontStyle.Bold))
                {
                    using (Font fnt2 = new Font("Arial", 8f, FontStyle.Regular))
                    {
                        e.Graphics.DrawString(Coupons.Type, new Font("Edwardian Script ITC", 20, FontStyle.Regular), Brushes.DeepPink, new Point(455, 218));
                        e.Graphics.DrawString(Coupons.Benefit, new Font("Edwardian Script ITC", 25, FontStyle.Regular), Brushes.DeepPink, new Point(130, 230));
                        e.Graphics.DrawString(Coupons.Code, new Font("Segoe Script,", 12, FontStyle.Regular), Brushes.DeepPink, new Point(340, 300));
                        e.Graphics.DrawString(Convert.ToString(Coupons.Expiry.ToShortDateString()), new Font("Segoe Script", 12, FontStyle.Regular), Brushes.DeepPink, new Point(650, 300));
                    }
                }
            }

        }
    }
}
