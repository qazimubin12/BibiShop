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
    public partial class DiscountOffers : Form
    {
        int uedit = 0;
        object language = MainClass.LanguageCheck();

        public DiscountOffers()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void DiscountOffers_Load(object sender, EventArgs e)
        {
            ShowDiscountOffer(DGVCoupon, DiscountOfferIDGV, NameGV, BenefitGV, MinimumBillGV, txtSearch.Text.ToString());
        }

        private void ShowDiscountOffer(DataGridView dgv, DataGridViewColumn ID, DataGridViewColumn Name, DataGridViewColumn Benefit, DataGridViewColumn MinimumBill, string data = null)
        {
            try
            {
                SqlCommand cmd = null;
                MainClass.con.Open();
                if (data != "")
                {
                    cmd = new SqlCommand("select  DiscountOfferID,	DiscountOfferName,	DiscountBenefit,	MinimumBill	from DiscountOffers  where DiscountOfferName  like '%" + data + "%'", MainClass.con);
                }
                else
                {
                    cmd = new SqlCommand("select  DiscountOfferID,	DiscountOfferName,	DiscountBenefit,	MinimumBill	from DiscountOffers order by DiscountOfferName", MainClass.con);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                ID.DataPropertyName = dt.Columns["DiscountOfferID"].ToString();
                Name.DataPropertyName = dt.Columns["DiscountOfferName"].ToString();
                Benefit.DataPropertyName = dt.Columns["DiscountBenefit"].ToString();
                MinimumBill.DataPropertyName = dt.Columns["MinimumBill"].ToString();
               
                dgv.DataSource = dt;
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }


        private void Clear()
        {
            txtOfferName.Text = "";
            txtSearch.Text = "";
            txtMinimumBill.Text = "";
            txtBenefit.Text = "";
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (uedit == 0)
            {
                if (txtOfferName.Text == "" && txtBenefit.Text == "")
                {
                    MessageBox.Show("Please Input Details");
                }
                else
                {
                    try
                    {
                        MainClass.con.Open();
                        SqlCommand cmd = new SqlCommand("insert into DiscountOffers (DiscountOfferName,DiscountBenefit,MinimumBill,IsActive) values(@DiscountOfferName,@DiscountBenefit,@MinimumBill,@IsActive)", MainClass.con);
                        cmd.Parameters.AddWithValue("@DiscountOfferName", txtOfferName.Text);
                        cmd.Parameters.AddWithValue("@DiscountBenefit", float.Parse(txtBenefit.Text));
                        cmd.Parameters.AddWithValue("@MinimumBill", float.Parse(txtMinimumBill.Text));
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
                        MessageBox.Show("Discount Offer Inserted Successfully.");
                        Clear();
                        ShowDiscountOffer(DGVCoupon, DiscountOfferIDGV, NameGV, BenefitGV, MinimumBillGV,txtSearch.Text.ToString());
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
                        SqlCommand cmd = new SqlCommand("update DiscountOffers set DiscountOfferName = @DiscountOfferName,DiscountBenefit=@DiscountBenefit,MinimumBill=@MinimumBill, IsActive = @IsActive  where DiscountOfferID = @DiscountOfferID", MainClass.con);
                        cmd.Parameters.AddWithValue("@DiscountOfferID", lblID.Text);
                        cmd.Parameters.AddWithValue("@DiscountOfferName", txtOfferName.Text);
                        cmd.Parameters.AddWithValue("@DiscountBenefit", float.Parse(txtBenefit.Text));
                        cmd.Parameters.AddWithValue("@MinimumBill", float.Parse(txtMinimumBill.Text));
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
                        MessageBox.Show("Offer Updated Successfully.");
                        btnSave.Text = "SAVE";
                        btnSave.BackColor = Color.SteelBlue;
                        Clear();
                        ShowDiscountOffer(DGVCoupon, DiscountOfferIDGV, NameGV, BenefitGV, MinimumBillGV, txtSearch.Text.ToString());
                    }
                    catch (Exception ex)
                    {
                        MainClass.con.Close();
                        MessageBox.Show(ex.Message);
                    }

                }
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uedit = 1;
            lblID.Text = DGVCoupon.CurrentRow.Cells[0].Value.ToString();
            txtOfferName.Text = DGVCoupon.CurrentRow.Cells[1].Value.ToString();
            txtBenefit.Text = DGVCoupon.CurrentRow.Cells[2].Value.ToString();
            txtMinimumBill.Text = DGVCoupon.CurrentRow.Cells[3].Value.ToString();
                        if(language.ToString() == "Chinese"){btnSave.Text = "更新";}else{btnSave.Text = "UPDATE";}
            btnSave.BackColor = Color.Orange;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ShowDiscountOffer(DGVCoupon, DiscountOfferIDGV, NameGV, BenefitGV, MinimumBillGV, txtSearch.Text.ToString());
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            PackagedDiscount pd = new PackagedDiscount();
            pd.Show();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
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
                            SqlCommand cmd = new SqlCommand("delete from DiscountOffers where DiscountOfferID = @DiscountOfferID", MainClass.con);
                            cmd.Parameters.AddWithValue("@DiscountOfferID", DGVCoupon.CurrentRow.Cells[0].Value.ToString());
                            cmd.ExecuteNonQuery();
                                            if(language.ToString() == "English"){MessageBox.Show("Record Deleted Successfully");}else {MessageBox.Show("記錄刪除成功");}
                            MainClass.con.Close();
                            ShowDiscountOffer(DGVCoupon, DiscountOfferIDGV, NameGV, BenefitGV, MinimumBillGV, txtSearch.Text.ToString());
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
    }
}
