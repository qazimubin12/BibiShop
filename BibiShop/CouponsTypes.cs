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
    public partial class CouponsTypes : Form
    {
        int uedit = 0;
        object language = MainClass.LanguageCheck();
        public CouponsTypes()
        {
InitializeComponent(); MainClass.ChangeLanguage();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ShowCouponTypes(DGVCouponTypes, CoupnTypeIDGV, CouponTypeGV, CouponBenefitGV, txtSearch.Text.ToString());
        }



        private void btnSave_Click(object sender, EventArgs e)
        {

                if (uedit == 0)
                {
                    if (txtCouponType.Text == "" && txtBenefit.Text == "")
                    {
                        MessageBox.Show("Please Input Details");
                    }
                    else
                    {
                    try
                    {
                        MainClass.con.Open();
                        SqlCommand cmd = new SqlCommand("insert into CouponsTypesTable (CouponType,CouponBenefit) values(@CouponType,@CouponBenefit)", MainClass.con);
                        cmd.Parameters.AddWithValue("@CouponType", txtCouponType.Text);
                        cmd.Parameters.AddWithValue("@CouponBenefit", float.Parse(txtBenefit.Text));

                        cmd.ExecuteNonQuery();
                        MainClass.con.Close();
                        MessageBox.Show("Coupon Type Inserted Successfully.");
                        Clear();
                        ShowCouponTypes(DGVCouponTypes, CoupnTypeIDGV, CouponTypeGV, CouponBenefitGV, txtSearch.Text.ToString());
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
                        SqlCommand cmd = new SqlCommand("update CouponsTypesTable set CouponType = @CouponType,CouponBenefit=@CouponBenefit  where CouponTypeID = @CouponTypeID", MainClass.con);
                        cmd.Parameters.AddWithValue("@CouponTypeID", lblID.Text);
                        cmd.Parameters.AddWithValue("@CouponType", txtCouponType.Text);
                        cmd.Parameters.AddWithValue("@CouponBenefit", float.Parse(txtBenefit.Text));
                        cmd.ExecuteNonQuery();
                        MainClass.con.Close();
                        MessageBox.Show("Coupon Type Updated Successfully.");
                        btnSave.Text = "SAVE";
                        btnSave.BackColor = Color.SteelBlue;
                        Clear();
                        ShowCouponTypes(DGVCouponTypes, CoupnTypeIDGV, CouponTypeGV, CouponBenefitGV, txtSearch.Text.ToString());
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
                txtCouponType.Text = "";
                txtCouponType.Text = "";
            }
            else
            {
                if (txtCouponType.Text == "" && txtCouponType.Text == "")
                {
                    this.Dispose(); 
                }
                else
                {
                    txtCouponType.Text = "";
                    txtCouponType.Text = "";
                }
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
             uedit = 1;
            lblID.Text = DGVCouponTypes.CurrentRow.Cells[0].Value.ToString();
            txtCouponType.Text = DGVCouponTypes.CurrentRow.Cells[1].Value.ToString();
            txtBenefit.Text = DGVCouponTypes.CurrentRow.Cells[2].Value.ToString();
            if(language.ToString() == "Chinese"){btnSave.Text = "更新";}else{btnSave.Text = "UPDATE";}
            btnSave.BackColor = Color.Orange;
        }



        private void ShowCouponTypes(DataGridView dgv, DataGridViewColumn ID, DataGridViewColumn Type, DataGridViewColumn Benefit, string data = null)
        {
            try
            {
                SqlCommand cmd = null;
                MainClass.con.Open();
                if (data != "")
                {
                    cmd = new SqlCommand("select * from CouponsTypesTable  where CouponType  like '%" + data + "%'", MainClass.con);
                }
                else
                {
                    cmd = new SqlCommand("select * from CouponsTypesTable order by CouponType", MainClass.con);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                ID.DataPropertyName = dt.Columns["CouponTypeID"].ToString();
                Type.DataPropertyName = dt.Columns["CouponType"].ToString();
                Benefit.DataPropertyName = dt.Columns["CouponBenefit"].ToString();
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
            ShowCouponTypes(DGVCouponTypes, CoupnTypeIDGV, CouponTypeGV,CouponBenefitGV, txtSearch.Text.ToString());
        }

        private void Clear()
        {
            txtBenefit.Text = "";
            txtCouponType.Text = "";
        }
        private void deleteToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (DGVCouponTypes != null)
            {
                if (DGVCouponTypes.Rows.Count > 0)
                {
                    if (DGVCouponTypes.SelectedRows.Count == 1)
                    {
                        try
                        {
                            MainClass.con.Open();
                            SqlCommand cmd = new SqlCommand("delete from CouponsTypesTable where CouponTypeID = @CouponTypeID", MainClass.con);
                            cmd.Parameters.AddWithValue("@CouponTypeID", DGVCouponTypes.CurrentRow.Cells[0].Value.ToString());
                            cmd.ExecuteNonQuery();
                                            if(language.ToString() == "English"){MessageBox.Show("Record Deleted Successfully");}else {MessageBox.Show("記錄刪除成功");}
                            MainClass.con.Close();
                            ShowCouponTypes(DGVCouponTypes, CoupnTypeIDGV, CouponTypeGV, CouponBenefitGV, txtSearch.Text.ToString());
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
    }
}

