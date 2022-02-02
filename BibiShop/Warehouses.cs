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
    public partial class Warehouses : Form
    {
        int uedit = 0;
        object language = MainClass.LanguageCheck();
        public Warehouses()
        {
InitializeComponent(); MainClass.ChangeLanguage();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ShowUnits(DgvWarehouse, WarehouseIDGV, WarehouseGV, txtSearch.Text.ToString());
        }

       

        private void btnSave_Click(object sender, EventArgs e)
        {

                if (uedit == 0)
                {
                    if (txtWarehouse.Text == "")
                    {
                        MessageBox.Show("Please Input Details");
                    }
                    else
                    {
                    try
                    {
                        MainClass.con.Open();
                        SqlCommand cmd = new SqlCommand("insert into WarehouseTable (Warehouse) values(@Warehouse)", MainClass.con);
                        cmd.Parameters.AddWithValue("@Warehouse", txtWarehouse.Text);

                        cmd.ExecuteNonQuery();
                        MainClass.con.Close();
                        MessageBox.Show("Warehouse Inserted Successfully.");
                        Clear();
                        ShowUnits(DgvWarehouse, WarehouseIDGV, WarehouseGV, txtSearch.Text.ToString());
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
                        SqlCommand cmd = new SqlCommand("update WarehouseTable set Warehouse = @Warehouse where WarehouseID = @WarehouseID", MainClass.con);
                        cmd.Parameters.AddWithValue("@WarehouseID", lblID.Text);
                        cmd.Parameters.AddWithValue("@Warehouse", txtWarehouse.Text);
                        cmd.ExecuteNonQuery();
                        MainClass.con.Close();
                        MessageBox.Show("Warehouse Updated Successfully.");
                        btnSave.Text = "SAVE";
                        btnSave.BackColor = Color.SteelBlue;
                        Clear();
                        ShowUnits(DgvWarehouse, WarehouseIDGV, WarehouseGV, txtSearch.Text.ToString());
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
                txtWarehouse.Text = "";
            }
            else
            {
                if (txtWarehouse.Text == "")
                {
                    this.Dispose(); BibiHomeScreen ds = new BibiHomeScreen();  
                }
                else
                {
                    txtWarehouse.Text = "";
                }
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
             uedit = 1;
            lblID.Text = DgvWarehouse.CurrentRow.Cells[0].Value.ToString();
            txtWarehouse.Text = DgvWarehouse.CurrentRow.Cells[1].Value.ToString();
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
                    cmd = new SqlCommand("select * from WarehouseTable  where Warehouse  like '%" + data + "%'", MainClass.con);
                }
                else
                {
                    cmd = new SqlCommand("select * from WarehouseTable order by Warehouse", MainClass.con);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                Unit.DataPropertyName = dt.Columns["Warehouse"].ToString();
                ID.DataPropertyName = dt.Columns["WarehouseID"].ToString();
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
            ShowUnits(DgvWarehouse, WarehouseIDGV, WarehouseGV, txtSearch.Text.ToString());
        }

        private void Clear()
        {
            txtWarehouse.Text = "";
        }
        private void deleteToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (DgvWarehouse != null)
            {
                if (DgvWarehouse.Rows.Count > 0)
                {
                    if (DgvWarehouse.SelectedRows.Count == 1)
                    {
                        try
                        {
                            MainClass.con.Open();
                            SqlCommand cmd = new SqlCommand("delete from WarehouseTable where WarehouseID = @WarehouseID", MainClass.con);
                            cmd.Parameters.AddWithValue("@WarehouseID", DgvWarehouse.CurrentRow.Cells[0].Value.ToString());
                            cmd.ExecuteNonQuery();
                            if(language.ToString() == "English"){MessageBox.Show("Record Deleted Successfully");}else {MessageBox.Show("記錄刪除成功");}
                            MainClass.con.Close();
                            ShowUnits(DgvWarehouse, WarehouseIDGV, WarehouseGV, txtSearch.Text.ToString());
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

