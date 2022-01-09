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
    public partial class Trasnfer : Form
    {
        public Trasnfer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Trasnfer_Load(object sender, EventArgs e)
        {
            MainClass.FillWarehouses(cboWarehouseFrom);
            MainClass.FillWarehouses(cboWarehouseTo);
            ShowStocks(DGVInventory, ProductGV, UnitGV, QuantityGV, RateGV);
        }

        private void ShowStocks(DataGridView dgv, DataGridViewColumn Product,DataGridViewColumn Unit, DataGridViewColumn Qty, DataGridViewColumn Rate, string data = null)
        {
            try
            {
                SqlCommand cmd = null;
                if (data != null)
                {
                    cmd = new SqlCommand("select p.ProductName,u.Unit,i.Qty,i.Rate from Inventory i inner join ProductsTable p on p.ProductID = i.ProductID inner join UnitsTable u on u.UnitID = i.Unit where WarehouseID = '" + cboWarehouseFrom.SelectedValue.ToString() + "'  and p.ProductName like '%" + data + "%'", MainClass.con);
                }
                else
                {
                    cmd = new SqlCommand("select p.ProductName,u.Unit,i.Qty,i.Rate from Inventory i inner join ProductsTable p on p.ProductID = i.ProductID inner join UnitsTable u on u.UnitID = i.Unit where WarehouseID = '" + cboWarehouseFrom.SelectedValue.ToString() + "'", MainClass.con);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                Product.DataPropertyName = dt.Columns["ProductName"].ToString();
                Unit.DataPropertyName = dt.Columns["Unit"].ToString();
                Qty.DataPropertyName = dt.Columns["Qty"].ToString();
                Rate.DataPropertyName = dt.Columns["Rate"].ToString();
                dgv.DataSource = dt;
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void cboWarehouseFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowStocks(DGVInventory, ProductGV, UnitGV, QuantityGV, RateGV);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ShowStocks(DGVInventory, ProductGV, UnitGV, QuantityGV, RateGV,txtSearch.Text.ToString());

        }
    }
}
