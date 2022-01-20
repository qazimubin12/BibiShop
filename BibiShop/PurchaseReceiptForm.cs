using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BibiShop
{
    public partial class PurchaseReceiptForm : Form
    {
        PurchaseInvoice p = new PurchaseInvoice();
        ReportDocument rd = new ReportDocument();
        public PurchaseReceiptForm()
        {
            InitializeComponent();
        }

        private void PurchaseReceiptForm_Load(object sender, EventArgs e)
        {
            if (PurchaseInvoice.Purchase_ID != 0)
            {
                MainClass.ShowPurchaseReceipt(rd, crystalReportViewer1, "PurchaseBill", "@PurchaseID", PurchaseInvoice.Purchase_ID);
            }

            else
            {
                MainClass.ShowPurchaseReceipt(rd, crystalReportViewer1, "PurchaseBill", "@PurchaseID", Reports.Purchase_ID);
            }
        }
    }
}
