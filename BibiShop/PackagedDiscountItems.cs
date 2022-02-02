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
    public partial class PackagedDiscountItems : Form
    {
        public PackagedDiscountItems()
        {
InitializeComponent(); MainClass.ChangeLanguage();
        }

        private void PackagedDiscountItems_Load(object sender, EventArgs e)
        {
            MainClass.FillProducts(cboProduct);
            MainClass.FillPackagedDiscount(cboPackagedDiscount);
            if(cboPackagedDiscount.SelectedIndex == 0)
            {
                btnUpdate.Enabled = false;
            }
       
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(cboProduct.SelectedIndex == 0 || txtQuantity.Text == "" || float.Parse(txtQuantity.Text) < 0)
            {
                MessageBox.Show("Please Fill the Details");
                return;
            }
            else
            {
                DGVItems.Rows.Add(lblProductID.Text, cboProduct.Text, txtQuantity.Text);
            }
        }

        private void cboProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
           lblProductID.Text =  cboProduct.SelectedValue.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = null;
            try
            {
                MainClass.con.Open();
                foreach (DataGridViewRow item in DGVItems.Rows)
                {
                    cmd = new SqlCommand("insert into PackagedDiscountItems(PackagedDiscount_ID,ProductID,ProductQty) values (@PackagedDiscount_ID,@ProductID,@ProductQty)", MainClass.con);
                    cmd.Parameters.AddWithValue("@PackagedDiscount_ID", cboPackagedDiscount.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@ProductID", item.Cells["ProductIDGV"].Value.ToString());
                    cmd.Parameters.AddWithValue("@ProductQty", float.Parse(item.Cells["QtyGV"].Value.ToString()));
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Packaged Discount Items Saved Successfully");
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MainClass.con.Close();
            }
        }

        private void cboPackagedDiscount_SelectedIndexChanged(object sender, EventArgs e)
        {
            DGVItems.Rows.Clear();
            if (cboPackagedDiscount.SelectedIndex == 0)
            {
                btnUpdate.Enabled = false;
            }
            else
            {
                btnUpdate.Enabled = true;
            }
            SqlCommand cmd = null;
            int ID = 0;
            int productID = 0;
            string productName = "";
            float qty = 0;
            try
            {
                if (cboPackagedDiscount.SelectedIndex != 0)
                {
                    MainClass.con.Open();
                    cmd = new SqlCommand("select pdi.PackagedDiscount_ID,pdi.ProductID,p.ProductName,pdi.ProductQty  from PackagedDiscountItems pdi inner join ProductsTable p on p.ProductID = pdi.ProductID ", MainClass.con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if(dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            ID = int.Parse(dr["PackagedDiscount_ID"].ToString());
                            productID = int.Parse(dr["ProductID"].ToString());
                            productName = dr["ProductName"].ToString();
                            qty = float.Parse(dr["ProductQty"].ToString());

                            DGVItems.Rows.Add(productID, productName, qty);
                        }
                    }
                    MainClass.con.Close();
                    lblID.Text = ID.ToString();


                }
                else
                {
                    DGVItems.Rows.Clear();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                MainClass.con.Close();

            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = null;
            try
            {
                MainClass.con.Open();
                cmd = new SqlCommand("delete from PackagedDiscountItems where PackagedDiscount_ID = '" + cboPackagedDiscount.SelectedValue + "'", MainClass.con);
                cmd.ExecuteNonQuery();

                foreach (DataGridViewRow item in DGVItems.Rows)
                {
                    cmd = new SqlCommand("insert into PackagedDiscountItems(PackagedDiscount_ID,ProductID,ProductQty) values (@PackagedDiscount_ID,@ProductID,@ProductQty)", MainClass.con);
                    cmd.Parameters.AddWithValue("@PackagedDiscount_ID", cboPackagedDiscount.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@ProductID", item.Cells["ProductIDGV"].Value.ToString());
                    cmd.Parameters.AddWithValue("@ProductQty", float.Parse(item.Cells["QtyGV"].Value.ToString()));
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Packaged Discount Items Updated Successfully");

                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void DGVItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                if (e.ColumnIndex == 3)
                {
                    DGVItems.Rows.RemoveAt(DGVItems.CurrentRow.Index);
                }
            }
        }
    }
}
