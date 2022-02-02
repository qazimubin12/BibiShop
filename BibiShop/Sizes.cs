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
    public partial class Sizes : Form
    {
        int uedit = 0;
        object language = MainClass.LanguageCheck();

        public Sizes()
        {
InitializeComponent(); MainClass.ChangeLanguage();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ShowUnits(DgvSize, SizeIDGV, SizeGV, txtSearch.Text.ToString());
        }

       

        private void btnSave_Click(object sender, EventArgs e)
        {

                if (uedit == 0)
                {
                    if (txtSize.Text == "")
                    {
                        MessageBox.Show("Please Input Details");
                    }
                    else
                    {
                    try
                    {
                        MainClass.con.Open();
                        SqlCommand cmd = new SqlCommand("insert into SizeTable (Size) values(@Size)", MainClass.con);
                        cmd.Parameters.AddWithValue("@Size", txtSize.Text);

                        cmd.ExecuteNonQuery();
                        MainClass.con.Close();
                        MessageBox.Show("Size Inserted Successfully.");
                        Clear();
                        ShowUnits(DgvSize, SizeIDGV, SizeGV, txtSearch.Text.ToString());
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
                        SqlCommand cmd = new SqlCommand("update SizeTable set Size = @Size where SizeID = @SizeID", MainClass.con);
                        cmd.Parameters.AddWithValue("@SizeID", lblID.Text);
                        cmd.Parameters.AddWithValue("@Size", txtSize.Text);
                        cmd.ExecuteNonQuery();
                        MainClass.con.Close();
                        MessageBox.Show("Size Updated Successfully.");
                        btnSave.Text = "SAVE";
                        btnSave.BackColor = Color.SteelBlue;
                        Clear();
                        ShowUnits(DgvSize, SizeIDGV, SizeGV, txtSearch.Text.ToString());
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
                txtSize.Text = "";
            }
            else
            {
                if (txtSize.Text == "")
                {
                    this.Dispose(); BibiHomeScreen ds = new BibiHomeScreen();  
                }
                else
                {
                    txtSize.Text = "";
                }
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
             uedit = 1;
            lblID.Text = DgvSize.CurrentRow.Cells[0].Value.ToString();
            txtSize.Text = DgvSize.CurrentRow.Cells[1].Value.ToString();
                        if(language.ToString() == "Chinese"){btnSave.Text = "更新";}else{btnSave.Text = "UPDATE";}
            btnSave.BackColor = Color.Orange;
        }



        private void ShowUnits(DataGridView dgv, DataGridViewColumn ID, DataGridViewColumn Unit, string data = null)
        {
            try
            {
                SqlCommand cmd = null;
                MainClass.con.Open();
                if (data != "")
                {
                    cmd = new SqlCommand("select * from SizeTable  where Size  like '%" + data + "%'", MainClass.con);
                }
                else
                {
                    cmd = new SqlCommand("select * from SizeTable order by Size", MainClass.con);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                Unit.DataPropertyName = dt.Columns["Size"].ToString();
                ID.DataPropertyName = dt.Columns["SizeID"].ToString();
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
            ShowUnits(DgvSize, SizeIDGV, SizeGV, txtSearch.Text.ToString());
        }

        private void Clear()
        {
            txtSize.Text = "";
        }
        private void deleteToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (DgvSize != null)
            {
                if (DgvSize.Rows.Count > 0)
                {
                    if (DgvSize.SelectedRows.Count == 1)
                    {
                        try
                        {
                            MainClass.con.Open();
                            SqlCommand cmd = new SqlCommand("delete from SizeTable where SizeID = @SizeID", MainClass.con);
                            cmd.Parameters.AddWithValue("@SizeID", DgvSize.CurrentRow.Cells[0].Value.ToString());
                            cmd.ExecuteNonQuery();
                                            if(language.ToString() == "English"){MessageBox.Show("Record Deleted Successfully");}else {MessageBox.Show("記錄刪除成功");}
                            MainClass.con.Close();
                            ShowUnits(DgvSize, SizeIDGV, SizeGV, txtSearch.Text.ToString());
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

            this.Dispose(); BibiHomeScreen ds = new BibiHomeScreen();  
        }
    }
}

