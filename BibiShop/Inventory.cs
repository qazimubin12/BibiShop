using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace BibiShop
{
    public partial class Inventory : Form
    {
        private void ShowStocks(DataGridView dgv, DataGridViewColumn Product, DataGridViewColumn Barcode, DataGridViewColumn Unit, DataGridViewColumn Qty, DataGridViewColumn Rate, DataGridViewColumn SafetyStock, string data = null)
        {
            try
            {
                SqlCommand cmd = null;
                if (data != null)
                {
                    cmd = new SqlCommand("select p.ProductName,i.Barcode,u.Unit,i.Qty,i.Rate,i.SafetyStock from Inventory i inner join ProductsTable p on p.ProductID = i.ProductID inner join UnitsTable u on u.UnitID = i.Unit where WarehouseID = '"+cboWarehouse.SelectedValue.ToString()+"'  and p.ProductName like '%" + data + "%'", MainClass.con);
                }
                else
                {
                    cmd = new SqlCommand("select p.ProductName,i.Barcode,u.Unit,i.Qty,i.Rate,i.SafetyStock from Inventory i inner join ProductsTable p on p.ProductID = i.ProductID inner join UnitsTable u on u.UnitID = i.Unit where WarehouseID = '" + cboWarehouse.SelectedValue.ToString() + "'", MainClass.con);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                Product.DataPropertyName = dt.Columns["ProductName"].ToString();
                Barcode.DataPropertyName = dt.Columns["Barcode"].ToString();
                Unit.DataPropertyName = dt.Columns["Unit"].ToString();
                Qty.DataPropertyName = dt.Columns["Qty"].ToString();
                Rate.DataPropertyName = dt.Columns["Rate"].ToString();
                SafetyStock.DataPropertyName = dt.Columns["SafetyStock"].ToString();
                dgv.DataSource = dt;
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }
        public Inventory()
        {
            InitializeComponent();
        }

        private void Inventory_Load(object sender, EventArgs e)
        {
            MainClass.FillWarehouses(cboWarehouse);
            ShowStocks(DGVInventory, ProductGV, BarcodeGV, UnitGV, QuantityGV, RateGV,SafetyStockGV);
            MainClass.RoundedButton(btnTrasnfer);
            btnTrasnfer.BorderColor = Color.White;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ShowStocks(DGVInventory, ProductGV, BarcodeGV, UnitGV, QuantityGV, RateGV, SafetyStockGV, txtSearch.Text.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose(); 
        }

        private void DGVInventory_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DGVInventory.ClearSelection();
        }

        private void cboWarehouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(txtSearch.Text == "")
            {
                ShowStocks(DGVInventory, ProductGV, BarcodeGV, UnitGV, QuantityGV, RateGV, SafetyStockGV);
            }
            else
            {
                ShowStocks(DGVInventory, ProductGV, BarcodeGV, UnitGV, QuantityGV, RateGV, SafetyStockGV, txtSearch.Text.ToString());
            }
        }

        private void btnTrasnfer_Click(object sender, EventArgs e)
        {
            Trasnfer t = new Trasnfer();
            t.Show();
        }
    }
}
