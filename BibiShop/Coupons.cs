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
    public partial class Coupons : Form
    {
        int uedit = 0;
        public Coupons()
        {
            InitializeComponent();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            MainClass.FillCouponTypes(cboCouponType);
            ShowCoupons(DGVCoupon, CouponIDGV, CouponNameGV, CouponsGeneratedGV, CouponCodeGV, CouponActivationDateGV, CouponExpiryDateGV, CouponUsageTypeGV, txtSearch.Text.ToString());
        }



        private void btnSave_Click(object sender, EventArgs e)
        {

            if (uedit == 0)
            {
                if (txtCouponName.Text == "" && txtNoofCoupons.Text == "")
                {
                    MessageBox.Show("Please Input Details");
                }
                else
                {
                    try
                    {
                        MainClass.con.Open();
                        SqlCommand cmd = new SqlCommand("insert into CouponsTable (CouponName,CouponsGenerated,CouponCode,CouponActivationDate,CouponExpirationDate,CouponUsageType,IsActive) values(@CouponName,@CouponsGenerated,@CouponCode,@CouponActivationDate,@CouponExpirationDate,@CouponUsageType,@IsActive)", MainClass.con);
                        cmd.Parameters.AddWithValue("@CouponName", txtCouponName.Text);
                        cmd.Parameters.AddWithValue("@CouponsGenerated", int.Parse(txtNoofCoupons.Text));
                        cmd.Parameters.AddWithValue("@CouponCode", txtCouponCode.Text);
                        cmd.Parameters.AddWithValue("@CouponActivationDate", dtActivation.Value.ToString());
                        cmd.Parameters.AddWithValue("@CouponExpirationDate", dtExpiry.Value.ToString());
                        cmd.Parameters.AddWithValue("@CouponUsageType", cboCouponType.SelectedValue.ToString());
                        if(ActiveCheckBox.Checked == true)
                        {
                            cmd.Parameters.AddWithValue("@IsActive", 1);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@IsActive", 0);
                        }

                        cmd.ExecuteNonQuery();
                        MainClass.con.Close();
                        MessageBox.Show("Coupon Inserted Successfully.");
                        Clear();
                        ShowCoupons(DGVCoupon, CouponIDGV, CouponNameGV, CouponsGeneratedGV, CouponCodeGV, CouponActivationDateGV, CouponExpiryDateGV, CouponUsageTypeGV, txtSearch.Text.ToString());
                    }
                    catch (Exception ex)
                    {
                        MainClass.con.Close();
                        MessageBox.Show(ex.Message);
                    }

                }
            }
            else
            {
                if (uedit == 1)
                {
                    try
                    {
                        MainClass.con.Open();
                        SqlCommand cmd = new SqlCommand("update CouponsTable set CouponName = @CouponName,CouponsGenerated=@CouponsGenerated,CouponCode=@CouponCode,CouponActivationDate=@CouponActivationDate,CouponExpirationDate=@CouponExpirationDate,CouponUsageType=@CouponUsageType, IsActive = @IsActive  where CouponID = @CouponID", MainClass.con);
                        cmd.Parameters.AddWithValue("@CouponID", lblID.Text);
                        cmd.Parameters.AddWithValue("@CouponName", txtCouponName.Text);
                        cmd.Parameters.AddWithValue("@CouponsGenerated", int.Parse(txtNoofCoupons.Text));
                        cmd.Parameters.AddWithValue("@CouponCode", txtCouponCode.Text);
                        cmd.Parameters.AddWithValue("@CouponActivationDate", dtActivation.Value.ToString());
                        cmd.Parameters.AddWithValue("@CouponExpirationDate", dtExpiry.Value.ToString());
                        cmd.Parameters.AddWithValue("@CouponUsageType", cboCouponType.SelectedValue.ToString());
                        if (ActiveCheckBox.Checked == true)
                        {
                            cmd.Parameters.AddWithValue("@IsActive", 1);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@IsActive", 0);
                        }
                        cmd.ExecuteNonQuery();
                        MainClass.con.Close();
                        MessageBox.Show("Coupon Updated Successfully.");
                        btnSave.Text = "SAVE";
                        btnSave.BackColor = Color.SteelBlue;
                        Clear();
                        ShowCoupons(DGVCoupon, CouponIDGV, CouponNameGV, CouponsGeneratedGV, CouponCodeGV, CouponActivationDateGV, CouponExpiryDateGV, CouponUsageTypeGV, txtSearch.Text.ToString());
                    }
                    catch (Exception ex)
                    {
                        MainClass.con.Close();
                        MessageBox.Show(ex.Message);
                    }

                }
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            uedit = 0;
            if (btnSave.BackColor == Color.Orange)
            {
                btnSave.Text = "SAVE";
                btnSave.BackColor = Color.SteelBlue;
                txtCouponName.Text = "";
                txtCouponName.Text = "";
            }
            else
            {
                if (txtCouponName.Text == "" && txtCouponName.Text == "")
                {
                    this.Dispose(); 
                }
                else
                {
                    txtCouponName.Text = "";
                    txtCouponName.Text = "";
                }
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uedit = 1;
            lblID.Text = DGVCoupon.CurrentRow.Cells[0].Value.ToString();
            txtCouponName.Text = DGVCoupon.CurrentRow.Cells[1].Value.ToString();
            txtNoofCoupons.Text = DGVCoupon.CurrentRow.Cells[2].Value.ToString();
            txtCouponCode.Text = DGVCoupon.CurrentRow.Cells[3].Value.ToString();
            dtActivation.Value = DateTime.Parse(DGVCoupon.CurrentRow.Cells[4].Value.ToString());
            dtExpiry.Value = DateTime.Parse(DGVCoupon.CurrentRow.Cells[5].Value.ToString());
            cboCouponType.Text = DGVCoupon.CurrentRow.Cells[6].Value.ToString();
            btnSave.Text = "UPDATE";
            btnSave.BackColor = Color.Orange;
        }



        private void ShowCoupons(DataGridView dgv, DataGridViewColumn ID, DataGridViewColumn Name, DataGridViewColumn NoOfCoupons, DataGridViewColumn Code, DataGridViewColumn Actvation, DataGridViewColumn Expiry, DataGridViewColumn Type, string data = null)
        {
            try
            {
                SqlCommand cmd = null;
                MainClass.con.Open();
                if (data != "")
                {
                    cmd = new SqlCommand("select ct.CouponID,ct.CouponName,ct.CouponsGenerated,ct.CouponCode,ct.CouponActivationDate,ct.CouponExpirationDate,cs.CouponType,ct.IsActive from COuponsTable ct inner join CouponsTypesTable cs on cs.CouponTypeID = ct.CouponUsageType  where ct.CouponName  like '%" + data + "%'", MainClass.con);
                }
                else
                {
                    cmd = new SqlCommand("select ct.CouponID,ct.CouponName,ct.CouponsGenerated,ct.CouponCode,ct.CouponActivationDate,ct.CouponExpirationDate,cs.CouponType,ct.IsActive from COuponsTable ct inner join CouponsTypesTable cs on cs.CouponTypeID = ct.CouponUsageType order by ct.CouponName", MainClass.con);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                ID.DataPropertyName = dt.Columns["CouponID"].ToString();
                Name.DataPropertyName = dt.Columns["CouponName"].ToString();
                NoOfCoupons.DataPropertyName = dt.Columns["CouponsGenerated"].ToString();
                Code.DataPropertyName = dt.Columns["CouponCode"].ToString();
                Actvation.DataPropertyName = dt.Columns["CouponActivationDate"].ToString();
                Expiry.DataPropertyName = dt.Columns["CouponExpirationDate"].ToString();
                Type.DataPropertyName = dt.Columns["CouponType"].ToString();
                dgv.DataSource = dt;
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }
        private void Units_Load(object sender, EventArgs e)
        {
            MainClass.FillCouponTypes(cboCouponType);
            ShowCoupons(DGVCoupon, CouponIDGV,CouponNameGV,CouponsGeneratedGV,CouponCodeGV,CouponActivationDateGV,CouponExpiryDateGV,CouponUsageTypeGV, txtSearch.Text.ToString());
        }

        private void Clear()
        {
            txtNoofCoupons.Text = "";
            txtCouponName.Text = "";
            txtCouponBenefit.Text = "";
            cboCouponType.SelectedIndex = 0;
            txtCouponCode.Text = "";
            dtActivation.Value = DateTime.Now;
            dtExpiry.Value = DateTime.Now;
        }
        private void deleteToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (DGVCoupon != null)
            {
                if (DGVCoupon.Rows.Count > 0)
                {
                    if (DGVCoupon.SelectedRows.Count == 1)
                    {
                        try
                        {
                            MainClass.con.Open();
                            SqlCommand cmd = new SqlCommand("delete from CouponsTable where CouponID = @CouponID", MainClass.con);
                            cmd.Parameters.AddWithValue("@CouponID", DGVCoupon.CurrentRow.Cells[0].Value.ToString());
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Coupon Deleted Successfully");
                            MainClass.con.Close();
                            ShowCoupons(DGVCoupon, CouponIDGV, CouponNameGV, CouponsGeneratedGV, CouponCodeGV, CouponActivationDateGV, CouponExpiryDateGV, CouponUsageTypeGV, txtSearch.Text.ToString());
                        }
                        catch (Exception ex)
                        {
                            MainClass.con.Close();
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose(); 
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            MainClass.FillCouponTypes(cboCouponType);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            CouponsTypes ct = new CouponsTypes();
            ct.Show();
        }

        private void cboCouponType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboCouponType.SelectedIndex != 0 )
            {
                MainClass.con.Open();
                SqlCommand cmd = new SqlCommand("select CouponBenefit from CouponsTypesTable where CouponType = '" + cboCouponType.Text + "'", MainClass.con);
                object ob = cmd.ExecuteScalar();
                if(ob == null)
                {
                    txtCouponBenefit.Text = "";
                }
                else
                {
                    txtCouponBenefit.Text = float.Parse(ob.ToString()).ToString();
                }
                MainClass.con.Close();
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            CouponsSettings cs = new CouponsSettings();
            cs.Show();
        }

        public static int Coupon_ID = 0;
        public static string Benefit = "";
        public static string Type = "";
        public static string Code = "";
        public static DateTime Expiry = DateTime.Now;
        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
          Coupon_ID =  int.Parse(DGVCoupon.CurrentRow.Cells["CouponIDGV"].Value.ToString());
            MainClass.con.Open();
            SqlCommand cmd = new SqlCommand("select c.CouponBenefit,ct.CouponCode,ct.CouponExpirationDate,c.CouponType from CouponsTable ct inner join CouponsTypesTable c on c.CouponTypeID = ct.CouponUsageType where ct.CouponID = '" + Coupon_ID + "' ", MainClass.con);
            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.HasRows)
            {
                while(dr.Read())
                {
                    if(dr[3].ToString() == "Free Merchandise Type")
                    {
                        Benefit = "Free Merchandise";
                    }
                    else if(dr[3].ToString() == "Five Percentage Reduction")
                    {
                        Benefit = dr[0].ToString() + "% Off";
                    }
                    else if(dr[3].ToString() == "Some Dollar Reduction")
                    {
                        Benefit = dr[0].ToString() + "$ Off";
                    }
                    else
                    {
                        Benefit = "";
                    }

                    Code = dr[1].ToString();
                    Expiry = DateTime.Parse(dr[2].ToString());
                    Type = dr[3].ToString();
                }
            }
            MainClass.con.Close();
            CouponPrinting c = new CouponPrinting();
            c.Show();
        }
    }
}

