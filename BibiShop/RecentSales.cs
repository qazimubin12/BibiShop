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
    public partial class RecentSales : Form
    {
        BibiPOS bp;
        int shopwarehouse = 0;
        public static int SAVED_SALES_ID = 0;
        public RecentSales()
        {
            InitializeComponent();
        }
        private void FindShopDefault()
        {
            MainClass.con.Open();
            SqlCommand cmd = new SqlCommand("select ShopDefaultWarehouse from StoreTable", MainClass.con);
            shopwarehouse = int.Parse(cmd.ExecuteScalar().ToString());
            MainClass.con.Close();
        }

        public RecentSales(BibiPOS s)
        {
            InitializeComponent();
            this.bp = s;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void RecentSales_Load(object sender, EventArgs e)
        {
            try
            {
                FindShopDefault();

                MainClass.con.Open();
                MainClass.FillOrderType(cboOrderStatus);
                cboOrderStatus.SelectedIndex = 0;
                MainClass.ShowRecentSales(DGVRecentSales, SaleIDGV, InvoiceNoGV, CustomerGV, SaleDateGV, SaleTimeGV, GrandTotalGV, cboOrderStatus.Text);
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }

        }

        private void cboOrderStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboOrderStatus.Text == "Remaining Payment")
            {
                ActionGV.Text = "PAYMENT";
                MainClass.ShowRecentSales(DGVRecentSales, SaleIDGV, InvoiceNoGV, CustomerGV, SaleDateGV, SaleTimeGV, GrandTotalGV, cboOrderStatus.Text);
            }

            else if(cboOrderStatus.Text == "Waiting for delivery")
            {
                ActionGV.Text = "DELIVERED";
                MainClass.ShowRecentSales(DGVRecentSales, SaleIDGV, InvoiceNoGV, CustomerGV, SaleDateGV, SaleTimeGV, GrandTotalGV, cboOrderStatus.Text);
            }
            else
            {
                ActionGV.Text = "VIEW RECEIPT";
                MainClass.ShowRecentSales(DGVRecentSales, SaleIDGV, InvoiceNoGV, CustomerGV, SaleDateGV, SaleTimeGV, GrandTotalGV, cboOrderStatus.Text);
            }

        }
       


        private void DGVRecentSales_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SqlCommand cmd = null;
            SqlDataReader dr;

            if (DGVRecentSales.Rows.Count != 0)
            {
                if (DGVRecentSales.SelectedRows.Count == 1)
                {
                    if (e.RowIndex != -1 && e.ColumnIndex != -1)
                    {
                        if (e.ColumnIndex == 0)
                        {
                            if (DGVRecentSales.CurrentRow.Cells[0].Value.ToString() == "PAYMENT")
                            {
                                if (e.ColumnIndex == 0)
                                {
                                    bp.lblInvoiceNo.Text = DGVRecentSales.CurrentRow.Cells["InvoiceNoGV"].Value.ToString();
                                    bp.lblSaleID.Text = DGVRecentSales.CurrentRow.Cells["SaleIDGV"].Value.ToString();
                                    bp.cboCustomer.Text = DGVRecentSales.CurrentRow.Cells["CustomerGV"].Value.ToString();

                                    try
                                    {
                                        MainClass.con.Open();
                                        cmd = new SqlCommand("selecT si.ProductID,p.ProductName,si.Unit,si.CostPrice,si.SalePrice,si.Color,si.Quantity,si.Size,si.TotalOfProduct from SalesTable st inner join SalesInfo si on si.Sales_ID = st.SaleID inner join ProductsTable p on p.ProductID = si.ProductID  where st.InvoiceNo = '" + DGVRecentSales.CurrentRow.Cells["InvoiceNoGV"].Value.ToString() + "'", MainClass.con);
                                        dr = cmd.ExecuteReader();
                                        while (dr.Read())
                                        {
                                            bp.DGVSaleCart.Rows.Add(dr["ProductID"].ToString(), dr["ProductName"].ToString(), dr["Unit"].ToString(), float.Parse(dr["CostPrice"].ToString()), float.Parse(dr["SalePrice"].ToString()), dr["Color"].ToString(), dr["Quantity"].ToString(), dr["Size"].ToString(), float.Parse(dr["TotalOfProduct"].ToString()));
                                        }
                                        MainClass.con.Close();


                                    }
                                    catch (Exception ex)
                                    {
                                        MainClass.con.Close();
                                        MessageBox.Show(ex.Message);
                                    } //Product getting
                                    try
                                    {
                                        MainClass.con.Open();
                                        cmd = new SqlCommand("select GrandTotal,Round(tax,2) as 'tax',Round((GrandTotal-tax),2) as 'Net',CouponType,CouponID from SalesTable  where InvoiceNo = '" + DGVRecentSales.CurrentRow.Cells["InvoiceNoGV"].Value.ToString() + "'", MainClass.con);
                                        dr = cmd.ExecuteReader();
                                        while (dr.Read())
                                        {
                                            bp.lblGrandTotal.Text = dr["GrandTotal"].ToString();
                                            bp.lblNetTotal.Text = dr["Net"].ToString();
                                            bp.lblTax.Text = dr["tax"].ToString();
                                            bp.lblCouponID.Text = dr["CouponID"].ToString();
                                            bp.lblCouponType.Text = dr["CouponType"].ToString();
                                        }
                                        MainClass.con.Close();


                                    }
                                    catch (Exception ex)
                                    {
                                        MainClass.con.Close();
                                        MessageBox.Show(ex.Message);
                                    } //Calculation getting and CouponGetting

                                    try
                                    {
                                        MainClass.con.Open();
                                        cmd = new SqlCommand("select CouponCode from CouponsTable where CouponID = '" + bp.lblCouponID.Text + "'", MainClass.con);
                                        dr = cmd.ExecuteReader();
                                        while (dr.Read())
                                        {
                                            bp.txtCouponCode.Text = dr["CouponCode"].ToString();
                                        }
                                        MainClass.con.Close();


                                    }
                                    catch (Exception ex)
                                    {
                                        MainClass.con.Close();
                                        MessageBox.Show(ex.Message);
                                    }

                                    bp.btnSaveSale.Text = "Update Sale";
                                    bp.btnSaveSale.FillColor = Color.Teal;
                                    bp.couponpanel.Visible = true;
                                    this.Close();

                                }
                            }
                            else if (DGVRecentSales.CurrentRow.Cells[0].Value.ToString() == "DELIVERED")
                            {
                                MainClass.con.Open();
                                cmd = new SqlCommand("update SalesTable set OrderStatus = @OrderStatus where SaleID = '" + DGVRecentSales.CurrentRow.Cells["SaleIDGV"].Value.ToString() + "' ", MainClass.con);
                                cmd.Parameters.AddWithValue("@OrderStatus", "Remaining Payment");
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Order Has been Delivered, Select Remaining Order to Complete Payment");
                                MainClass.con.Close();
                                cboOrderStatus.SelectedIndex = 1;
                            }
                            else
                            {
                                SAVED_SALES_ID = int.Parse(DGVRecentSales.CurrentRow.Cells["SaleIDGV"].Value.ToString());
                                SaleReceiptForm srf = new SaleReceiptForm();
                                srf.ShowDialog();
                            }
                        }
                    }
                }
            }
         

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            try
            {
                MainClass.con.Open();

                cmd = new SqlCommand("select si.ProductID,u.UnitID,si.Quantity,p.Barcode,si.SalePrice,p.SafetyStock from SalesInfo si inner join ProductsTable p on p.ProductID = si.ProductID inner join UnitsTable u on u.UnitID = p.UnitID where Sales_ID = '" + DGVRecentSales.CurrentRow.Cells["SaleIDGV"].Value.ToString() + "' ", MainClass.con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        cmd = new SqlCommand("insert into Inventory(ProductID,Unit,Qty,Barcode,Rate,SafetyStock,WarehouseID) values (@ProductID,@Unit,@Qty,@Barcode,@Rate,@SafetyStock,@WarehouseID)", MainClass.con);
                        cmd.Parameters.AddWithValue("@ProductID", dr[0].ToString());
                        cmd.Parameters.AddWithValue("@Unit", dr[1].ToString());
                        cmd.Parameters.AddWithValue("@Qty", dr[2].ToString());
                        cmd.Parameters.AddWithValue("@Barcode", dr[3].ToString());
                        cmd.Parameters.AddWithValue("@Rate", dr[4].ToString());
                        cmd.Parameters.AddWithValue("@SafetyStock", dr[5].ToString());
                        cmd.Parameters.AddWithValue("@WarehouseID", shopwarehouse);
                        cmd.ExecuteNonQuery();
                    }

                }
                dr.Close();




                cmd = new SqlCommand("delete from SalesInfo where Sales_ID = '" + DGVRecentSales.CurrentRow.Cells["SaleIDGV"].Value.ToString() + "'", MainClass.con);
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("delete from SalesTable where SaleID = '" + DGVRecentSales.CurrentRow.Cells["SaleIDGV"].Value.ToString() + "'", MainClass.con);
                cmd.ExecuteNonQuery();
                MainClass.con.Close();
                MessageBox.Show("Sale Deleted Successfully");
                MainClass.ShowRecentSales(DGVRecentSales, SaleIDGV, InvoiceNoGV, CustomerGV, SaleDateGV, SaleTimeGV, GrandTotalGV, cboOrderStatus.Text);
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void DGVRecentSales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
