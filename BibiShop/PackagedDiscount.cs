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
    public partial class PackagedDiscount : Form
    {
        int uedit = 0;
        object language = MainClass.LanguageCheck();

        public PackagedDiscount()
        {
            InitializeComponent();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ShowPackagedDiscounts(DGVCouponTypes, PackagedDiscountIDGV, PackagedDiscountNameGV, RateGV, txtSearch.Text.ToString());
        }



        private void btnSave_Click(object sender, EventArgs e)
        {

                if (uedit == 0)
                {
                    if (txtPackagedDiscountName.Text == "" && txtRate.Text == "")
                    {
                        MessageBox.Show("Please Input Details");
                    }
                    else
                    {
                    try
                    {
                        MainClass.con.Open();
                        SqlCommand cmd = new SqlCommand("insert into PackagedDiscount (PackagedDiscountName,PackagedDiscountRate,IsActive) values(@PackagedDiscountName,@PackagedDiscountRate,@IsActive)", MainClass.con);
                        cmd.Parameters.AddWithValue("@PackagedDiscountName", txtPackagedDiscountName.Text);
                        cmd.Parameters.AddWithValue("@PackagedDiscountRate", float.Parse(txtRate.Text));
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
                        MessageBox.Show("Packaged Discount Inserted Successfully.");
                        Clear();
                        ShowPackagedDiscounts(DGVCouponTypes, PackagedDiscountIDGV, PackagedDiscountNameGV, RateGV, txtSearch.Text.ToString());
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
                        SqlCommand cmd = new SqlCommand("update CouponsTypesTable set PackagedDiscountName = @PackagedDiscountName,PackagedDiscountRate=@PackagedDiscountRate  where PackagedDiscountID = @PackagedDiscountID", MainClass.con);
                        cmd.Parameters.AddWithValue("@PackagedDiscountID", lblID.Text);
                        cmd.Parameters.AddWithValue("@PackagedDiscountName", txtPackagedDiscountName.Text);
                        cmd.Parameters.AddWithValue("@PackagedDiscountRate", float.Parse(txtRate.Text));
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
                        MessageBox.Show("Packaged Discount Updated Successfully.");
                        btnSave.Text = "SAVE";
                        btnSave.BackColor = Color.SteelBlue;
                        Clear();
                        ShowPackagedDiscounts(DGVCouponTypes, PackagedDiscountIDGV, PackagedDiscountNameGV, RateGV, txtSearch.Text.ToString());
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
                txtPackagedDiscountName.Text = "";
                txtPackagedDiscountName.Text = "";
            }
            else
            {
                if (txtPackagedDiscountName.Text == "" && txtPackagedDiscountName.Text == "")
                {
                    this.Dispose(); 
                }
                else
                {
                    txtPackagedDiscountName.Text = "";
                    txtPackagedDiscountName.Text = "";
                }
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uedit = 1;
            lblID.Text = DGVCouponTypes.CurrentRow.Cells[0].Value.ToString();
            txtPackagedDiscountName.Text = DGVCouponTypes.CurrentRow.Cells[1].Value.ToString();
            txtRate.Text = DGVCouponTypes.CurrentRow.Cells[2].Value.ToString();
                        if(language.ToString() == "Chinese"){btnSave.Text = "更新";}else{btnSave.Text = "UPDATE";}
            btnSave.BackColor = Color.Orange;
        }



        private void ShowPackagedDiscounts(DataGridView dgv, DataGridViewColumn ID, DataGridViewColumn Name, DataGridViewColumn Rate, string data = null)
        {
            try
            {
                SqlCommand cmd = null;
                MainClass.con.Open();
                if (data != "")
                {
                    cmd = new SqlCommand("selecT PackagedDiscountID,	PackagedDiscountName,	PackagedDiscountRate from PackagedDiscount  where PackagedDiscountName  like '%" + data + "%'", MainClass.con);
                }
                else
                {
                    cmd = new SqlCommand("selecT PackagedDiscountID,	PackagedDiscountName,	PackagedDiscountRate from PackagedDiscount order by PackagedDiscountName", MainClass.con);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                ID.DataPropertyName = dt.Columns["PackagedDiscountID"].ToString();
                Name.DataPropertyName = dt.Columns["PackagedDiscountName"].ToString();
                Rate.DataPropertyName = dt.Columns["PackagedDiscountRate"].ToString();
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
            ShowPackagedDiscounts(DGVCouponTypes, PackagedDiscountIDGV, PackagedDiscountNameGV,RateGV, txtSearch.Text.ToString());
        }

        private void Clear()
        {
            txtRate.Text = "";
            txtPackagedDiscountName.Text = "";
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
                            SqlCommand cmd = new SqlCommand("delete from PackagedDiscount where PackagedDiscountID = @PackagedDiscountID", MainClass.con);
                            cmd.Parameters.AddWithValue("@PackagedDiscountID", DGVCouponTypes.CurrentRow.Cells[0].Value.ToString());
                            cmd.ExecuteNonQuery();
                                            if(language.ToString() == "English"){MessageBox.Show("Record Deleted Successfully");}else {MessageBox.Show("記錄刪除成功");}
                            MainClass.con.Close();
                            ShowPackagedDiscounts(DGVCouponTypes, PackagedDiscountIDGV, PackagedDiscountNameGV, RateGV, txtSearch.Text.ToString());
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

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            PackagedDiscountItems pdi = new PackagedDiscountItems();
            pdi.Show();
        }
    }
}

