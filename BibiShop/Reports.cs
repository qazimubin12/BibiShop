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
    public partial class Reports : Form
    {
        int saledate = 0;
        int purchasedate = 0;
        public Reports()
        {
            InitializeComponent();
        }

        private void btnPurchaseReports_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void Reports_Load(object sender, EventArgs e)
        {
            MainClass.HideAllTabsOnTabControl(tabControl1);
            ShowPurchases(DGVPurchases,IDGV, SupplierInvoiceIDGV, PaymentTypeGV, InvoiceNoGv, InvoiceDateGV, SupplierNameGV, GrandTotalGV);
            ShowSales(DGVSales, SaleIDCC, InvoiceNoGVC, InvoiceDateGVC, DiscountGVC, GrandTotalGVC);
            ShowSalesforPrint(DGVSalePrintingAll);
           

        }

        private void ShowPurchases(DataGridView dgv, DataGridViewColumn ID, DataGridViewColumn SupplierInvoiceID,DataGridViewColumn PaymentType, DataGridViewColumn InvoiceNo, DataGridViewColumn InvoiceDate, DataGridViewColumn PersonName, DataGridViewColumn GrandTotal )
        {
            MainClass.con.Open();
            SqlCommand cmd = null;
            if(purchasedate == 1)
            {
                cmd = new SqlCommand("select pp.PurchaseID, st.SupplierInvoiceID,st.PaymentType,pp.InvoiceNo,format(st.InvoiceDate, 'dd/MM/yyyy') as 'Date',pt.Name,pp.GrandTotal from PurchasesInfo p inner join PurchasesTable pp on pp.PurchaseID = p.Purchase_ID  inner join PersonsTable pt on pt.PersonID = pp.Supplier_ID inner join SupplierInvoicesTable st on st.SupplierInvoiceID = pp.SupplierInvoice_ID where st.InvoiceDate between '" + dtPurchase1.Value.ToShortDateString() + "' and '" + dtPurchase2.Value.ToShortDateString() + "'", MainClass.con);
            }
            else
            {
                cmd = new SqlCommand("select pp.PurchaseID,st.SupplierInvoiceID,st.PaymentType,pp.InvoiceNo,format(st.InvoiceDate, 'dd/MM/yyyy') as 'Date',pt.Name,pp.GrandTotal from PurchasesInfo p inner join PurchasesTable pp on pp.PurchaseID = p.Purchase_ID  inner join PersonsTable pt on pt.PersonID = pp.Supplier_ID inner join SupplierInvoicesTable st on st.SupplierInvoiceID = pp.SupplierInvoice_ID", MainClass.con);
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ID.DataPropertyName = dt.Columns["PurchaseID"].ToString();
            SupplierInvoiceID.DataPropertyName = dt.Columns["SupplierInvoiceID"].ToString();
            PaymentType.DataPropertyName = dt.Columns["PaymentType"].ToString();
            InvoiceNo.DataPropertyName = dt.Columns["InvoiceNo"].ToString();
            InvoiceDate.DataPropertyName = dt.Columns["Date"].ToString();
            PersonName.DataPropertyName = dt.Columns["Name"].ToString();
            GrandTotal.DataPropertyName = dt.Columns["GrandTotal"].ToString();
            dgv.DataSource = dt;
            MainClass.con.Close();
        }

        private void ShowSales(DataGridView dgv, DataGridViewColumn SaleID, DataGridViewColumn InvoiceNo, DataGridViewColumn InvoiceDate, DataGridViewColumn Discount, DataGridViewColumn GrandTotal)
        {
            MainClass.con.Open();
            SqlCommand cmd = null;
            if(saledate == 1)
            {
                cmd = new SqlCommand("select SaleID,InvoiceNo,format(SaleDate, 'dd/MM/yyyy') as 'Date',Discount,GrandTotal from SalesTable where SaleDate between '" + dtSale1.Value.ToShortDateString() + "' and '" + dtSale2.Value.ToShortDateString() + "' ", MainClass.con);
            }
            else
            {
                cmd = new SqlCommand("select SaleID,InvoiceNo,format(SaleDate, 'dd/MM/yyyy') as 'Date',Discount,GrandTotal from SalesTable", MainClass.con);
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            SaleID.DataPropertyName = dt.Columns["SaleID"].ToString();
            InvoiceNo.DataPropertyName = dt.Columns["InvoiceNo"].ToString();
            InvoiceDate.DataPropertyName = dt.Columns["Date"].ToString();
            Discount.DataPropertyName = dt.Columns["Discount"].ToString();
            GrandTotal.DataPropertyName = dt.Columns["GrandTotal"].ToString();
            dgv.DataSource = dt;
            MainClass.con.Close();
        }



        private void btnSaleReports_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;

        }

        private void btnLedgerReports_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 3;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 4;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose(); BibiHomeScreen ds = new BibiHomeScreen();  
        }

        private void txtSearchPurhcaseInvoice_TextChanged(object sender, EventArgs e)
        {
            ShowPurchasesSearched(DGVPurchases,IDGV, SupplierInvoiceIDGV, PaymentTypeGV, InvoiceNoGv, InvoiceDateGV, SupplierNameGV, GrandTotalGV);
        }


        private void ShowPurchasesSearched(DataGridView dgv, DataGridViewColumn ID, DataGridViewColumn SupplierInvoiceID, DataGridViewColumn PaymentType, DataGridViewColumn InvoiceNo, DataGridViewColumn InvoiceDate, DataGridViewColumn PersonName, DataGridViewColumn GrandTotal)
        {
            MainClass.con.Open();
            SqlCommand cmd = null;
            if (txtSearchPurhcaseInvoice.Text == "")
            {
                cmd = new SqlCommand("select pp.PurchaseID, st.SupplierInvoiceID,st.PaymentType,pp.InvoiceNo,format(st.InvoiceDate, 'dd/MM/yyyy') as 'Date',pt.Name,pp.GrandTotal from PurchasesInfo p inner join PurchasesTable pp on pp.PurchaseID = p.Purchase_ID  inner join PersonsTable pt on pt.PersonID = pp.Supplier_ID inner join SupplierInvoicesTable st on st.SupplierInvoiceID = pp.SupplierInvoice_ID", MainClass.con);
            }
            else
            {
                cmd = new SqlCommand("select pp.PurchaseID st.SupplierInvoiceID,st.PaymentType,pp.InvoiceNo,format(st.InvoiceDate, 'dd/MM/yyyy') as 'Date',pt.Name,pp.GrandTotal from PurchasesInfo p inner join PurchasesTable pp on pp.PurchaseID = p.Purchase_ID  inner join PersonsTable pt on pt.PersonID = pp.Supplier_ID inner join SupplierInvoicesTable st on st.SupplierInvoiceID = pp.SupplierInvoice_ID where pp.InvoiceNo like '%" + txtSearchPurhcaseInvoice.Text + "%' ", MainClass.con);
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ID.DataPropertyName = dt.Columns["PurchaseID"].ToString();
            SupplierInvoiceID.DataPropertyName = dt.Columns["SupplierInvoiceID"].ToString();
            PaymentType.DataPropertyName = dt.Columns["PaymentType"].ToString();
            InvoiceNo.DataPropertyName = dt.Columns["InvoiceNo"].ToString();
            InvoiceDate.DataPropertyName = dt.Columns["Date"].ToString();
            PersonName.DataPropertyName = dt.Columns["Name"].ToString();
            GrandTotal.DataPropertyName = dt.Columns["GrandTotal"].ToString();
            dgv.DataSource = dt;
            MainClass.con.Close();
        }

        private void ShowSalesSearched(DataGridView dgv, DataGridViewColumn SaleID, DataGridViewColumn InvoiceNo, DataGridViewColumn InvoiceDate, DataGridViewColumn Discount, DataGridViewColumn GrandTotal)
        {
            MainClass.con.Open();
            SqlCommand cmd = null;
            if(txtSearchSaleInvoice.Text != "")
            {
                cmd = new SqlCommand("select SaleID,InvoiceNo,format(SaleDate, 'dd/MM/yyyy') as 'Date',Discount,GrandTotal from SalesTable where InvoiceNo  like '%" + txtSearchSaleInvoice.Text + "%'", MainClass.con);
            }
            else
            {
                cmd = new SqlCommand("select SaleID,InvoiceNo,format(SaleDate, 'dd/MM/yyyy') as 'Date',Discount,GrandTotal from SalesTable", MainClass.con);
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            SaleID.DataPropertyName = dt.Columns["SaleID"].ToString();
            InvoiceNo.DataPropertyName = dt.Columns["InvoiceNo"].ToString();
            InvoiceDate.DataPropertyName = dt.Columns["Date"].ToString();
            Discount.DataPropertyName = dt.Columns["Discount"].ToString();
            GrandTotal.DataPropertyName = dt.Columns["GrandTotal"].ToString();
            dgv.DataSource = dt;
            MainClass.con.Close();
        }


        private void button11_Click(object sender, EventArgs e)
        {
            ShowPurchases(DGVPurchases, IDGV, SupplierInvoiceIDGV, PaymentTypeGV, InvoiceNoGv, InvoiceDateGV, SupplierNameGV, GrandTotalGV);
        }

        private void PurchaseDate(object sender, EventArgs e)
        {
            if (dtPurchase1.Value == DateTime.Now && dtPurchase2.Value == DateTime.Now)
            {
                purchasedate = 0;

            }
            else
            {
                purchasedate = 1;

            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            purchasedate = 0;
            dtPurchase1.Value = DateTime.Now;
            dtPurchase2.Value = DateTime.Now;
            ShowPurchases(DGVPurchases, IDGV, SupplierInvoiceIDGV, PaymentTypeGV, InvoiceNoGv, InvoiceDateGV, SupplierNameGV, GrandTotalGV);

        }

        private void SaleDate(object sender, EventArgs e)
        {
            if (dtSale2.Value == DateTime.Now && dtSale1.Value == DateTime.Now)
            {
                saledate = 0;

            }
            else
            {
                saledate = 1;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ShowSales(DGVSales, SaleIDCC, InvoiceNoGVC, InvoiceDateGVC, DiscountGVC, GrandTotalGVC);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            saledate = 0;
            dtSale1.Value = DateTime.Now;
            dtSale2.Value = DateTime.Now;
            ShowSales(DGVSales, SaleIDCC, InvoiceNoGVC, InvoiceDateGVC, DiscountGVC, GrandTotalGVC);
        }

        private void txtSearchSaleInvoice_TextChanged(object sender, EventArgs e)
        {
            ShowSalesSearched(DGVSales, SaleIDCC, InvoiceNoGVC, InvoiceDateGVC, DiscountGVC, GrandTotalGVC);
        }

        public static int SALES_ID = 0;
        private void DGVSales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 || e.ColumnIndex != -1)
            {
                if(e.ColumnIndex == 0)
                {
                    SALES_ID = int.Parse(DGVSales.CurrentRow.Cells["SaleIDCC"].Value.ToString());
                    SaleReceiptForm s = new SaleReceiptForm();
                    s.ShowDialog();
                    SALES_ID = 0;

                }
            }
        }

        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowPersons(DGVPersons, PersonIDGV, NameGV, TypeGV, ContactGV, AddressGV, BdayGV,cboType.Text);
        }

        private void ShowSalesforPrint(DataGridView dgv)
        {
            try
            {
                SqlCommand cmd = null;
                MainClass.con.Open();

                cmd = new SqlCommand("selecT st.SaleID,st.InvoiceNo,p.Name,p.Contact,st.Discount,st.GrandTotal,st.Change,st.Paying,st.Tax,st.SaleDate,st.SaleTime,st.OrderStatus,c.CouponName,st.CouponType from SalesTable st inner join PersonsTable p on p.PersonID = st.Customer_ID  left join CouponsTable c on c.CouponID = st.CouponID", MainClass.con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

         
                dgv.DataSource = dt;
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }


        private void ShowPersons(DataGridView dgv, DataGridViewColumn ID, DataGridViewColumn Name, DataGridViewColumn Type, DataGridViewColumn Contact, DataGridViewColumn Address, DataGridViewColumn Birthday, string data = null)
        {
            try
            {
                SqlCommand cmd = null;
                MainClass.con.Open();

                cmd = new SqlCommand("select PersonID,Name,Type,Contact,Address,Birthday from PersonsTable  where Type = '" + data + "'", MainClass.con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                Name.DataPropertyName = dt.Columns["Name"].ToString();
                ID.DataPropertyName = dt.Columns["PersonID"].ToString();
                Type.DataPropertyName = dt.Columns["Type"].ToString();
                Contact.DataPropertyName = dt.Columns["Contact"].ToString();
                Address.DataPropertyName = dt.Columns["Address"].ToString();
                Birthday.DataPropertyName = dt.Columns["Birthday"].ToString();
                dgv.DataSource = dt;
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            // creating new WorkBook within Excel application  
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            // creating new Excelsheet in workbook  
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            // see the excel sheet behind the program  
            app.Visible = true;
            // get the reference of first sheet. By default its name is Sheet1.  
            // store its reference to worksheet  
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            // changing the name of active sheet  
            worksheet.Name = "Exported from gridview";
            // storing header part in Excel  
            for (int i = 1; i < DGVPersons.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = DGVPersons.Columns[i - 1].HeaderText;
            }
            // storing Each row and column value to excel sheet  
            for (int i = 0; i < DGVPersons.Rows.Count - 1; i++)
            {
                for (int j = 0; j < DGVPersons.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = DGVPersons.Rows[i].Cells[j].Value.ToString();
                }
            }
            // save the application  
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            // creating new WorkBook within Excel application  
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            // creating new Excelsheet in workbook  
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            // see the excel sheet behind the program  
            app.Visible = true;
            // get the reference of first sheet. By default its name is Sheet1.  
            // store its reference to worksheet  
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            // changing the name of active sheet  
            worksheet.Name = "Exported from gridview";
            // storing header part in Excel  
            for (int i = 1; i < DGVSalePrintingAll.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = DGVSalePrintingAll.Columns[i - 1].HeaderText;
            }
            // storing Each row and column value to excel sheet  
            for (int i = 0; i < DGVSalePrintingAll.Rows.Count - 1; i++)
            {
                for (int j = 0; j < DGVSalePrintingAll.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = DGVSalePrintingAll.Rows[i].Cells[j].Value.ToString();
                }
            }
        }

        private void DGVSales_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public static int Purchase_ID = 0;
        private void DGVPurchases_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 || e.ColumnIndex != -1)
            {
                if (e.ColumnIndex == 0)
                {
                    Purchase_ID = int.Parse(DGVPurchases.CurrentRow.Cells["IDGV"].Value.ToString());
                    PurchaseReceiptForm s = new PurchaseReceiptForm();
                    s.ShowDialog();
                    Purchase_ID = 0;

                }
            }
        }
    }
}
