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
    public partial class Units : Form
    {
        int uedit = 0;
        object language = MainClass.LanguageCheck();
        public Units()
        {
            InitializeComponent();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ShowUnits(DgvUnits, UNITIDDGV, UnitGV, txtSearch.Text.ToString());
        }

       

        private void btnSave_Click(object sender, EventArgs e)
        {

                if (uedit == 0)
                {
                    if (txtUnit.Text == "")
                    {
                        MessageBox.Show("Please Input Details");
                    }
                    else
                    {
                        try
                        {
                            MainClass.con.Open();
                            SqlCommand cmd = new SqlCommand("insert into UnitsTable (Unit) values(@Unit)", MainClass.con);
                            cmd.Parameters.AddWithValue("@Unit", txtUnit.Text);

                            cmd.ExecuteNonQuery();
                            MainClass.con.Close();
                            MessageBox.Show("Unit Inserted Successfully.");
                            Clear();
                            ShowUnits(DgvUnits, UNITIDDGV, UnitGV);
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
                            SqlCommand cmd = new SqlCommand("update UnitsTable set Unit = @Unit where UnitID = @UnitID", MainClass.con);
                            cmd.Parameters.AddWithValue("@UnitID", lblID.Text);
                            cmd.Parameters.AddWithValue("@Unit", txtUnit.Text);
                            cmd.ExecuteNonQuery();
                            MainClass.con.Close();
                            MessageBox.Show("Unit Updated Successfully.");
                            btnSave.Text = "SAVE";
                            btnSave.BackColor = Color.SteelBlue;
                            Clear();
                            ShowUnits(DgvUnits, UNITIDDGV, UnitGV);
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
                if (language.ToString() == "English") { btnSave.Text = "SAVE"; } else { btnSave.Text = "保存"; }
                btnSave.BackColor = Color.SteelBlue;
                txtUnit.Text = "";
            }
            else
            {
                if (txtUnit.Text == "")
                {
                    this.Dispose(); BibiHomeScreen ds = new BibiHomeScreen();  
                }
                else
                {
                    txtUnit.Text = "";
                }
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
             uedit = 1;
            lblID.Text = DgvUnits.CurrentRow.Cells[0].Value.ToString();
            txtUnit.Text = DgvUnits.CurrentRow.Cells[1].Value.ToString();
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
                    cmd = new SqlCommand("select * from UnitsTable  where Unit  like '%" + data + "%'", MainClass.con);
                }
                else
                {
                    cmd = new SqlCommand("select * from UnitsTable order by Unit", MainClass.con);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                Unit.DataPropertyName = dt.Columns["Unit"].ToString();
                ID.DataPropertyName = dt.Columns["UnitID"].ToString();
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
            ShowUnits(DgvUnits, UNITIDDGV, UnitGV);
        }

        private void Clear()
        {
            txtUnit.Text = "";
        }
        private void deleteToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (DgvUnits != null)
            {
                if (DgvUnits.Rows.Count > 0)
                {
                    if (DgvUnits.SelectedRows.Count == 1)
                    {
                        try
                        {
                            MainClass.con.Open();
                            SqlCommand cmd = new SqlCommand("delete from UnitsTable where UnitID = @UnitID", MainClass.con);
                            cmd.Parameters.AddWithValue("@UnitID", DgvUnits.CurrentRow.Cells[0].Value.ToString());
                            cmd.ExecuteNonQuery();
                                            if(language.ToString() == "English"){MessageBox.Show("Record Deleted Successfully");}else {MessageBox.Show("記錄刪除成功");}
                            MainClass.con.Close();
                            ShowUnits(DgvUnits, UNITIDDGV, UnitGV);
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

