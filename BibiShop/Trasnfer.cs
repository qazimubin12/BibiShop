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

        private void DGVInventory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in DGVInventory.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].EditedFormattedValue))
                {
                    row.Cells[3].ReadOnly = false;
                }
                else
                {
                    row.Cells[3].ReadOnly = true;

                }
            }
        }

        private void DGVInventory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void CLear()
        {
            cboWarehouseFrom.SelectedIndex = 0;
            cboWarehouseTo.SelectedIndex = 0;
        }

        private void btnTrasnfer_Click(object sender, EventArgs e)
        {
            if (cboWarehouseFrom.SelectedIndex != 0 && cboWarehouseTo.SelectedIndex != 0)
            {
                SqlCommand cmd = null;
                int productID = 0;
                string barcode = "";
                int UnitID = 0;
                int SafetyStock = 0;
                float rate = 0;
                object currentwarehousetoqty = 0;
                object ifnull;
                object currentwarehousefromqty = 0;
                int warehousetoID = int.Parse(cboWarehouseTo.SelectedValue.ToString());
                int warehousefromID = int.Parse(cboWarehouseFrom.SelectedValue.ToString());
                try
                {
                    MainClass.con.Open();
                    foreach (DataGridViewRow item in DGVInventory.Rows)
                    {
                        if (Convert.ToBoolean(item.Cells[0].EditedFormattedValue))
                        {
                            cmd = new SqlCommand("select ProductID from ProductsTable where ProductName N= '" + item.Cells[1].Value.ToString() + "'", MainClass.con);
                            productID = int.Parse(cmd.ExecuteScalar().ToString());

                            cmd = new SqlCommand("select Barcode from ProductsTable where ProductName N= '" + item.Cells[1].Value.ToString() + "'", MainClass.con);
                            barcode = cmd.ExecuteScalar().ToString();

                            cmd = new SqlCommand("select SalePrice from ProductsTable where ProductName N= '" + item.Cells[1].Value.ToString() + "'", MainClass.con);
                            rate = float.Parse(cmd.ExecuteScalar().ToString());

                            cmd = new SqlCommand("select UnitID from ProductsTable where ProductName N= '" + item.Cells[1].Value.ToString() + "'", MainClass.con);
                            UnitID = int.Parse(cmd.ExecuteScalar().ToString());

                            cmd = new SqlCommand("select SafetyStock from ProductsTable where ProductName N= '" + item.Cells[1].Value.ToString() + "'", MainClass.con);
                            SafetyStock = int.Parse(cmd.ExecuteScalar().ToString());


                            cmd = new SqlCommand("select Qty from Inventory where ProductID = '" + productID + "' and WarehouseID = '" + cboWarehouseFrom.SelectedValue.ToString() + "'", MainClass.con);
                            currentwarehousefromqty = cmd.ExecuteScalar();


                            cmd = new SqlCommand("select Qty from Inventory where ProductID = '" + productID + "' and WarehouseID = '" + cboWarehouseTo.SelectedValue.ToString() + "'", MainClass.con);
                            currentwarehousetoqty = cmd.ExecuteScalar();

                            if (currentwarehousetoqty == null)
                            {
                                currentwarehousetoqty = 0;
                            }

                            int warehousechanged = 0;
                            float fromqty = float.Parse(currentwarehousefromqty.ToString()); //current inventory
                            fromqty -= float.Parse(item.Cells[3].Value.ToString());


                            if (cboWarehouseTo.SelectedIndex == 1)
                            {
                                MainClass.UpdateInventory(productID, fromqty, warehousefromID);
                            }
                            else
                            {

                                float toqty = float.Parse(currentwarehousetoqty.ToString()); //to transferred inventory
                                toqty += float.Parse(item.Cells[3].Value.ToString());
                                if (fromqty == 0)
                                {
                                    warehousechanged = 1;
                                    MainClass.UpdateWarehouse(productID, warehousetoID);
                                }
                                else
                                {
                                    MainClass.UpdateInventory(productID, fromqty, warehousefromID);
                                }

                                cmd = new SqlCommand("select Qty from Inventory where ProductID = '" + productID + "' and WarehouseID = '" + cboWarehouseTo.SelectedValue.ToString() + "'", MainClass.con);
                                ifnull = cmd.ExecuteScalar();
                                if (ifnull == null)
                                {
                                    MainClass.InsertIntoInventory(productID, toqty, warehousetoID, barcode, UnitID, SafetyStock, rate);
                                }
                                else
                                {
                                    if (warehousechanged != 1)
                                    {
                                        MainClass.UpdateInventory(productID, toqty, warehousetoID);
                                    }


                                }
                            }



                        }
                    }
                    MainClass.con.Close();
                    MessageBox.Show("Transfer Completed");
                    CLear();
                }
                catch (Exception ex)
                {
                    MainClass.con.Close();
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Select Warehouses");
                return;
            }
        }
    }
}
