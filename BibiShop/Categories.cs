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
    public partial class Categories : Form
    {
        int cedit = 0;
        object language = null;

        public Categories()
        {
            InitializeComponent();
        }

        private void ShowCategorys(DataGridView dgv, DataGridViewColumn ID, DataGridViewColumn Category, string data = null)
        {
            try
            {
                SqlCommand cmd = null;
                MainClass.con.Open();
                if (data != "")
                {
                    cmd = new SqlCommand("select * from CategoriesTable  where Category  like N'%" + data + "%'", MainClass.con);
                }
                else
                {
                    cmd = new SqlCommand("select * from CategoriesTable order by Category", MainClass.con);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                Category.DataPropertyName = dt.Columns["Category"].ToString();
                ID.DataPropertyName = dt.Columns["CategoryID"].ToString();
                dgv.DataSource = dt;
                MainClass.con.Close();
                language = MainClass.LanguageCheck();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }
        private void Categorys_Load(object sender, EventArgs e)
        {
            ShowCategorys(DgvCategory, CatIDGV, CategoryGV);
        }

        private void Clear()
        {
            txtCategory.Text = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cedit == 0)
            {
                if (txtCategory.Text == "")
                {
                    if(language.ToString() == "English")
                    {
                        MessageBox.Show("Please Input Details");
                    }
                    else
                    {
                        MessageBox.Show("請輸入詳細信息");

                    }
                }
                else
                {
                    try
                    {
                        MainClass.con.Open();
                        SqlCommand cmd = new SqlCommand("insert into CategoriesTable (Category) values(@Category)", MainClass.con);
                        cmd.Parameters.AddWithValue("@Category", txtCategory.Text);

                        cmd.ExecuteNonQuery();
                        MainClass.con.Close();
                        if (language.ToString() == "English")
                        {
                            MessageBox.Show("Category Inserted Successfully.");
                        }
                        else
                        {
                            MessageBox.Show("類別插入成功");
                        }
                        Clear();
                        ShowCategorys(DgvCategory, CatIDGV, CategoryGV);
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
                if (cedit == 1)
                {
                    try
                    {
                        MainClass.con.Open();
                        SqlCommand cmd = new SqlCommand("update CategoriesTable set Category = @Category where CategoryID = @CategoryID", MainClass.con);
                        cmd.Parameters.AddWithValue("@CategoryID", lblID.Text);
                        cmd.Parameters.AddWithValue("@Category", txtCategory.Text);
                        cmd.ExecuteNonQuery();
                        MainClass.con.Close();
                        if (language.ToString() == "English")
                        {
                            MessageBox.Show("Category Updated Successfully.");
                        }
                        else
                        {
                            MessageBox.Show("類別更新成功.");
                        }
                        btnSave.Text = "SAVE";
                        btnSave.BackColor = Color.SteelBlue;
                        Clear();
                        ShowCategorys(DgvCategory, CatIDGV, CategoryGV);
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
            cedit = 1;
            lblID.Text = DgvCategory.CurrentRow.Cells[0].Value.ToString();
            txtCategory.Text = DgvCategory.CurrentRow.Cells[1].Value.ToString();
            if (language.ToString() == "Chinese")
            {
                btnSave.Text = "更新";
            }
            else
            {
               btnSave.Text = "UPDATE";
            }
            btnSave.BackColor = Color.Orange;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DgvCategory != null)
            {
                if (DgvCategory.Rows.Count > 0)
                {
                    if (DgvCategory.SelectedRows.Count == 1)
                    {
                        try
                        {
                            MainClass.con.Open();
                            SqlCommand cmd = new SqlCommand("delete from CategoriesTable where CategoryID = @CategoryID", MainClass.con);
                            cmd.Parameters.AddWithValue("@CategoryID", DgvCategory.CurrentRow.Cells[0].Value.ToString());
                            cmd.ExecuteNonQuery();
                            if (language.ToString() == "English")
                            {
                               MessageBox.Show("Record Deleted Successfully");
                            }
                            else
                            {
                                MessageBox.Show("記錄刪除成功");
                            }
                            MainClass.con.Close();
                            ShowCategorys(DgvCategory, CatIDGV, CategoryGV);
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

        private void btnCancelB_Click(object sender, EventArgs e)
        {
            cedit = 0;
            if (btnSave.BackColor == Color.Orange)
            {
                if (language.ToString() == "English")
                {
                    btnSave.Text = "SAVE";
                }
                else
                {
                    btnSave.Text = "保存";
                }
                btnSave.BackColor = Color.SteelBlue;
                txtCategory.Text = "";
            }
            else
            {
                if (txtCategory.Text == "")
                {
                    this.Dispose(); BibiHomeScreen ds = new BibiHomeScreen();  
                     
                }
                else
                {
                    txtCategory.Text = "";
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ShowCategorys(DgvCategory, CatIDGV, CategoryGV, txtSearch.Text.ToString());

        }

        private void DgvCategory_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DgvCategory.ClearSelection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose(); BibiHomeScreen ds = new BibiHomeScreen();  
           
        }
    }
}

