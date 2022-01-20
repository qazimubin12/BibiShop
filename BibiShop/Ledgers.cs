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
    public partial class Ledgers : Form
    {
        public Ledgers()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose(); BibiHomeScreen ds = new BibiHomeScreen();  

        }

        private void ShowSupplierLedgers(DataGridView dgv, DataGridViewColumn ID, DataGridViewColumn Name, DataGridViewColumn No,
            DataGridViewColumn Date, DataGridViewColumn Total, DataGridViewColumn Paid, DataGridViewColumn Balance,string data = null)
        {
            try
            {
                SqlCommand cmd = null;
                MainClass.con.Open();
                if (data != "")
                {
                    cmd = new SqlCommand("select sl.SupplerLedgerID,p.Name,sl.InvoiceNo,sl.InvoiceDate,sl.TotalAmount,sl.PaidAmount,sl.Balance from SupplierLedgersTable sl inner join PersonsTable p on p.PersonID = sl.Supplier_ID where sl.Balance > 0 and  Name  like '%" + data + "%' ", MainClass.con);
                }
                else
                {
                    cmd = new SqlCommand("select sl.SupplerLedgerID,p.Name,sl.InvoiceNo,sl.InvoiceDate,sl.TotalAmount,sl.PaidAmount,sl.Balance from SupplierLedgersTable sl inner join PersonsTable p on p.PersonID = sl.Supplier_ID where sl.Balance > 0", MainClass.con);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                Name.DataPropertyName = dt.Columns["Name"].ToString();
                ID.DataPropertyName = dt.Columns["SupplerLedgerID"].ToString();
                No.DataPropertyName = dt.Columns["InvoiceNo"].ToString();
                Date.DataPropertyName = dt.Columns["InvoiceDate"].ToString();
                Total.DataPropertyName = dt.Columns["TotalAmount"].ToString();
                Paid.DataPropertyName = dt.Columns["PaidAmount"].ToString();
                Balance.DataPropertyName = dt.Columns["Balance"].ToString();
                dgv.DataSource = dt;
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }


        private void Ledgers_Load(object sender, EventArgs e)
        {
            ShowSupplierLedgers(DGVSupplierLedger, IDGV, NameGV, InvoiceNoGV, InvoiceDateGV, TotalAmountGV, PaidAmountGV, BalanceGV);
        }


        private void Clear()
        {
            txtBalance.Text = "";
            txtPayingNow.Text = "";
            txtPaidAmount.Text = "";
            txtInvoiceNo.Text = "";
            txtName.Text = "";
            txtTotalAmount.Text = "";
            lblID.Text = "ID";
        }
        private void DGVSupplierLedger_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(DGVSupplierLedger.SelectedRows.Count == 1)
            {
                if(e.RowIndex != -1 && e.ColumnIndex != -1)
                {
                    if(e.ColumnIndex == 0)
                    {
                        lblID.Text = DGVSupplierLedger.CurrentRow.Cells[1].Value.ToString();
                        txtName.Text = DGVSupplierLedger.CurrentRow.Cells[2].Value.ToString();
                        txtInvoiceNo.Text = DGVSupplierLedger.CurrentRow.Cells[3].Value.ToString();
                        txtTotalAmount.Text = DGVSupplierLedger.CurrentRow.Cells[5].Value.ToString();
                        txtPaidAmount.Text = DGVSupplierLedger.CurrentRow.Cells[6].Value.ToString();
                        txtBalance.Text = DGVSupplierLedger.CurrentRow.Cells[7].Value.ToString();
                        lblPreviousBalance.Text = DGVSupplierLedger.CurrentRow.Cells[7].Value.ToString();
                        txtPayingNow.Enabled = true;
                        GBPayment.Text = "PAYMENT MODE";
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
            txtPayingNow.Enabled = false;

            GBPayment.Text = "PAYMENT INFO";
            this.Dispose(); BibiHomeScreen ds = new BibiHomeScreen();  
        }

        float paidprev;
        float previousbalance;
        float paying;
        float tot;
        float newbalance;
        float totpaying;
        private void txtPayingNow_TextChanged(object sender, EventArgs e)
        {
             paidprev = float.Parse(txtPaidAmount.Text);
             previousbalance = float.Parse(lblPreviousBalance.Text);
            if(txtPayingNow.Text == "" || txtPayingNow.Text == "0")
            {
                txtBalance.Text = previousbalance.ToString();
            }
            else
            {
                paying = float.Parse(txtPayingNow.Text);
                tot = float.Parse(txtTotalAmount.Text);
                totpaying = paying + paidprev;
                newbalance = tot - totpaying;
                txtBalance.Text = newbalance.ToString();
            }
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = null;
            DateTime TodaysDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            if (txtInvoiceNo.Text == "")
            {
                MessageBox.Show("Please Enter the Pay button in the field");
                return;
            }
            else
            {

                try
                {
                    MainClass.con.Open();
                    cmd = new SqlCommand("select PersonID from PersonsTable where Name N= '" + txtName.Text + "' ", MainClass.con);
                    int SupplierID = int.Parse(cmd.ExecuteScalar().ToString());


                    cmd = new SqlCommand("insert into SupplierLedgersInfoTable (SupplierLedger_ID,Supplier_ID,PayingDate,InvoiceNo,TotalAmount,PreviousPaid,TodayPaid,NewBalance) values (@SupplierLedger_ID,@Supplier_ID,@PayingDate,@InvoiceNo,@TotalAmount,@PreviousPaid,@TodayPaid,@NewBalance)", MainClass.con);
                    cmd.Parameters.AddWithValue("@SupplierLedger_ID", lblID.Text);
                    cmd.Parameters.AddWithValue("@Supplier_ID", SupplierID);
                    cmd.Parameters.AddWithValue("@PayingDate", TodaysDate);
                    cmd.Parameters.AddWithValue("@InvoiceNo", txtInvoiceNo.Text);
                    cmd.Parameters.AddWithValue("@TotalAmount", txtTotalAmount.Text);
                    cmd.Parameters.AddWithValue("@PreviousPaid", txtPaidAmount.Text);
                    cmd.Parameters.AddWithValue("@TodayPaid", txtPayingNow.Text);
                    cmd.Parameters.AddWithValue("@NewBalance", txtBalance.Text);
                    cmd.ExecuteNonQuery();


                    cmd = new SqlCommand("update SupplierLedgersTable set PaidAmount = @PaidAmount , Balance = @Balance where SupplerLedgerID = @SupplerLedgerID", MainClass.con);
                    cmd.Parameters.AddWithValue("@PaidAmount", totpaying);
                    cmd.Parameters.AddWithValue("@Balance", newbalance);
                    cmd.Parameters.AddWithValue("@SupplerLedgerID", lblID.Text);
                    cmd.ExecuteNonQuery();
                    MainClass.con.Close();
                }


                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    MainClass.con.Close();
                } //Supplier Ledgers

            }
            
            
           

            MessageBox.Show("Payment Successful");
            ShowSupplierLedgers(DGVSupplierLedger, IDGV, NameGV, InvoiceNoGV, InvoiceDateGV, TotalAmountGV, PaidAmountGV, BalanceGV);
            Clear();
        }


        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ShowSupplierLedgers(DGVSupplierLedger, IDGV, NameGV, InvoiceNoGV, InvoiceDateGV, TotalAmountGV, PaidAmountGV, BalanceGV, txtSearch.Text);
        }
    }
}
