using Guna.UI2.WinForms;
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
    public partial class CouponsSettings : Form
    {
        public CouponsSettings()
        {
InitializeComponent(); MainClass.ChangeLanguage();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CouponsSettings_Load(object sender, EventArgs e)
        {
            MainClass.FillProducts(cboProducts);
            MainClass.FillCoupons(cboCoupon);
            ShowCouponSettings(DGVCoupon, CouponSettingsIDGV, CouponNameGV, MinimumBillGV, ProductNameGV,txtSearch.Text);
        }


        private void ShowCouponSettings(DataGridView dgv, DataGridViewColumn ID, DataGridViewColumn Name, DataGridViewColumn Bill, DataGridViewColumn Product, string data = null)
        {
            try
            {
                SqlCommand cmd = null;
                MainClass.con.Open();
                if (data != "")
                {
                    cmd = new SqlCommand("select cst.CouponSettingsID,ct.CouponName,cst.MinimumBill,p.ProductName  from CouponsSettingsTable cst inner join CouponsTable ct on ct.CouponID = cst.CouponID inner join ProductsTable p on p.ProductID = cst.ProductID  where ct.CouponName  like '%" + data + "%'", MainClass.con);
                }
                else
                {
                    cmd = new SqlCommand("select cst.CouponSettingsID,ct.CouponName,cst.MinimumBill,p.ProductName  from CouponsSettingsTable cst inner join CouponsTable ct on ct.CouponID = cst.CouponID inner join ProductsTable p on p.ProductID = cst.ProductID order by ct.CouponName", MainClass.con);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                ID.DataPropertyName = dt.Columns["CouponSettingsID"].ToString();
                Name.DataPropertyName = dt.Columns["CouponName"].ToString();
                Bill.DataPropertyName = dt.Columns["MinimumBill"].ToString();
                Product.DataPropertyName = dt.Columns["ProductName"].ToString();
                dgv.DataSource = dt;
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int daysvalue = 0;
                foreach (Control ctrl in dayspanel.Controls)
                {
                    if (ctrl is Guna2CheckBox)
                    {
                        Guna2CheckBox tempCheckBox = ctrl as Guna2CheckBox;
                        if (tempCheckBox.Checked == true)
                        {
                            daysvalue += int.Parse(tempCheckBox.Tag.ToString());
                        }
                       
                    }
                }




                SqlCommand cmd = null;
                MainClass.con.Open();
                cmd = new SqlCommand("insert into CouponsSettingsTable(CouponID,MinimumBill,ProductID,Days) values(@CouponID,@MinimumBill,@ProductID,@Days)", MainClass.con);
                if (cboCoupon.SelectedValue.ToString() == "0")
                {
                    cmd.Parameters.AddWithValue("@CouponID", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@CouponID", cboCoupon.SelectedValue.ToString());
                }
                cmd.Parameters.AddWithValue("@MinimumBill", float.Parse(txtMinimumBill.Text));
                cmd.Parameters.AddWithValue("@ProductID", cboProducts.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@Days", daysvalue);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Coupon Setting Saved Successfully ");
                MainClass.con.Close();
                ShowCouponSettings(DGVCoupon, CouponSettingsIDGV, CouponNameGV, MinimumBillGV, ProductNameGV, txtSearch.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MainClass.con.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (cboCoupon.SelectedIndex == 0 && cboProducts.SelectedIndex == 0)
            {
                this.Dispose();
            }
            else
            {
                cboCoupon.SelectedIndex =0;
                cboProducts.SelectedIndex = 0;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ShowCouponSettings(DGVCoupon, CouponSettingsIDGV, CouponNameGV, MinimumBillGV, ProductNameGV, txtSearch.Text);
        }
    }
}
