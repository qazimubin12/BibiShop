using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BibiShop
{
    public partial class SaleReceiptForm : Form
    {
        POS p = new POS();
        ReportDocument rd = new ReportDocument();

        public SaleReceiptForm()
        {
            InitializeComponent();
        }

        private void SaleReceiptForm_Load(object sender, EventArgs e)
        {
            if (BibiPOS.SALES_ID != 0)
            {
                MainClass.ShowSaleRecieptSavedCustomer(rd, crystalReportViewer1, "SaleRecieptOfSavedCustomer", "@SaleID", POS.SALES_ID);
            }
            else if(RecentSales.SAVED_SALES_ID != 0)
            {
                MainClass.ShowSaleRecieptSavedCustomer(rd, crystalReportViewer1, "SaleRecieptOfSavedCustomer", "@SaleID", RecentSales.SAVED_SALES_ID);
            }
            else if(Reports.SALES_ID != 0)
            {
                MainClass.ShowSaleRecieptSavedCustomer(rd, crystalReportViewer1, "SaleRecieptOfSavedCustomer", "@SaleID", Reports.SALES_ID);
            }
        }

        private void SaleReceiptForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (rd != null)
            {
                rd.Close();
            }
        }
    }
}
