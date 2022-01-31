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
    public partial class Colors : Form
    {
        object language = MainClass.LanguageCheck();
        int uedit = 0;
        public Colors()
        {
            InitializeComponent();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ShowUnits(DgvColors, ColorIDGV, ColorGV, txtSearch.Text.ToString());
        }

       

        private void btnSave_Click(object sender, EventArgs e)
        {

                if (uedit == 0)
                {
                if (txtColor.Text == "")
                {
                    if (language.ToString() == "English")
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
                        SqlCommand cmd = new SqlCommand("insert into ColorsTable (Color) values(@Color)", MainClass.con);
                        cmd.Parameters.AddWithValue("@Color", txtColor.Text);

                        cmd.ExecuteNonQuery();
                        MainClass.con.Close();
                        if (language.ToString() == "English")
                        {
                            MessageBox.Show("Color Inserted Successfully");
                        }
                        else
                        {
                            MessageBox.Show("顏色插入成功");
                        }
                        Clear();
                        ShowUnits(DgvColors, ColorIDGV, ColorGV, txtSearch.Text.ToString());
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
                        SqlCommand cmd = new SqlCommand("update ColorsTable set Color = @Color where ColorID = @ColorID", MainClass.con);
                        cmd.Parameters.AddWithValue("@ColorID", lblID.Text);
                        cmd.Parameters.AddWithValue("@Color", txtColor.Text);
                        cmd.ExecuteNonQuery();
                        MainClass.con.Close();
                        MessageBox.Show("Color Updated Successfully.");
                        if (language.ToString() == "English")
                        {
                            btnSave.Text = "SAVE";
                        }
                        else
                        {
                            btnSave.Text = "保存";
                        }
                        btnSave.BackColor = Color.SteelBlue;
                        Clear();
                        ShowUnits(DgvColors, ColorIDGV, ColorGV, txtSearch.Text.ToString());
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
                if(language.ToString() == "English"){btnSave.Text = "SAVE";} else{ btnSave.Text = "保存"; }
                btnSave.BackColor = Color.SteelBlue;
                txtColor.Text = "";
            }
            else
            {
                if (txtColor.Text == "")
                {
                    this.Dispose();
                }
                else
                {
                    txtColor.Text = "";
                }
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
             uedit = 1;
            lblID.Text = DgvColors.CurrentRow.Cells[0].Value.ToString();
            txtColor.Text = DgvColors.CurrentRow.Cells[1].Value.ToString();
            if (language.ToString() == "English")
            {
                            if(language.ToString() == "Chinese"){btnSave.Text = "更新";}else{btnSave.Text = "UPDATE";}
            }
            else
            {
                btnSave.Text = "更新";
            }
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
                    cmd = new SqlCommand("select * from ColorsTable  where Color  like N'%" + data + "%'", MainClass.con);
                }
                else
                {
                    cmd = new SqlCommand("select * from ColorsTable order by Color", MainClass.con);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                Unit.DataPropertyName = dt.Columns["Color"].ToString();
                ID.DataPropertyName = dt.Columns["ColorID"].ToString();
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
            ShowUnits(DgvColors, ColorIDGV, ColorGV, txtSearch.Text.ToString());
        }

        private void Clear()
        {
            txtColor.Text = "";
        }
        private void deleteToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (DgvColors != null)
            {
                if (DgvColors.Rows.Count > 0)
                {
                    if (DgvColors.SelectedRows.Count == 1)
                    {
                        try
                        {
                            MainClass.con.Open();
                            SqlCommand cmd = new SqlCommand("delete from ColorsTable where ColorID = @ColorID", MainClass.con);
                            cmd.Parameters.AddWithValue("@ColorID", DgvColors.CurrentRow.Cells[0].Value.ToString());
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
                            ShowUnits(DgvColors, ColorIDGV, ColorGV, txtSearch.Text.ToString());
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

