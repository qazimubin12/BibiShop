using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BibiShop
{
    public partial class Persons : Form
    {
        int pedit = 0; 
        object language = MainClass.LanguageCheck();

        public Persons()
        {
InitializeComponent(); MainClass.ChangeLanguage();
        }

        private void ShowPersons(DataGridView dgv, DataGridViewColumn ID, DataGridViewColumn Name, DataGridViewColumn Type, DataGridViewColumn Contact, DataGridViewColumn Address,DataGridViewColumn Birthday ,string data = null)
        {
            try
            {
                SqlCommand cmd = null;
                MainClass.con.Open();
                if (data != "")
                {
                    cmd = new SqlCommand("select PersonID,Name,Type,Contact,Address,Birthday from PersonsTable  where Name  like N'%" + data + "%' or Type like '%" + data + "%'", MainClass.con);
                }
                else
                {
                    cmd = new SqlCommand("select PersonID,Name,Type,Contact,Address,Birthday from PersonsTable order by Name", MainClass.con);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                Name.DataPropertyName = dt.Columns["Name"].ToString();
                ID.DataPropertyName = dt.Columns["PersonID"].ToString();
                Type.DataPropertyName = dt.Columns["Type"].ToString();
                Contact.DataPropertyName = dt.Columns["Contact"].ToString();
                Address.DataPropertyName = dt.Columns["Address"].ToString();
                Birthday.DataPropertyName = dt.Columns["Birthday"].ToString();
                dgv.DataSource = dt;
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void Persons_Load(object sender, EventArgs e)
        {
            ShowPersons(DGVPersons, PersonIDGV, NameGV, TypeGV, ContactGV, AddressGV,BdayGV);
        }

        private void Clear()
        {
            txtContact.Text = "";
            txtAddress.Text = "";
            txtName.Text = "";
            txtSearch.Text = "";
            cboType.SelectedIndex = 0;
            lblBirthday.Text = "DD-MM-YYYY";
            pictureBox1.Image = null;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (pedit == 0)
            {
                if (txtName.Text == "" || cboType.Text == "")
                {
                    MessageBox.Show("Please Input Details");
                }
                else
                {
                    try
                    {
                        MainClass.con.Open();
                        SqlCommand cmd = new SqlCommand("insert into PersonsTable (Name,Type,Contact,Address,PersonImage,Birthday) values(@Name,@Type,@Contact,@Address,@PersonImage,@Birthday)", MainClass.con);
                        cmd.Parameters.AddWithValue("@Name", txtName.Text);
                        cmd.Parameters.AddWithValue("@Type", cboType.Text);
                        cmd.Parameters.AddWithValue("@Contact", txtContact.Text);
                        cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                        cmd.Parameters.AddWithValue("@PersonImage", ConvertImageToBytes(pictureBox1.Image));
                        cmd.Parameters.AddWithValue("@Birthday", BDay.Value.ToShortDateString());
                        cmd.ExecuteNonQuery();
                        MainClass.con.Close();
                        MessageBox.Show("Person Inserted Successfully.");
                        Clear();
                        ShowPersons(DGVPersons, PersonIDGV, NameGV, TypeGV, ContactGV, AddressGV, BdayGV);
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
                if (pedit == 1)
                {
                    try
                    {
                        MainClass.con.Open();
                        SqlCommand cmd = new SqlCommand("update PersonsTable set Name = @Name, Birthday= @Birthday,Type = @Type ,PersonImage = @PersonImage,Contact= @Contact, Address = @Address where PersonID = @PersonID", MainClass.con);
                        cmd.Parameters.AddWithValue("@PersonID", lblID.Text);
                        cmd.Parameters.AddWithValue("@Name", txtName.Text);
                        cmd.Parameters.AddWithValue("@Type", cboType.Text);
                        cmd.Parameters.AddWithValue("@Contact", txtContact.Text);
                        cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                        cmd.Parameters.AddWithValue("@PersonImage", ConvertImageToBytes(pictureBox1.Image));
                        cmd.Parameters.AddWithValue("@Birthday", BDay.Value.ToShortDateString());

                        cmd.ExecuteNonQuery();
                        MainClass.con.Close();
                        MessageBox.Show("Person Updated Successfully.");
                        btnSave.Text = "SAVE";
                        btnSave.BackColor = Color.SteelBlue;
                        Clear();
                        ShowPersons(DGVPersons, PersonIDGV, NameGV, TypeGV, ContactGV, AddressGV, BdayGV);
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
            pedit = 0;
            if (btnSave.BackColor == Color.Orange)
            {
                btnSave.Text = "SAVE";
                btnSave.BackColor = Color.SteelBlue;
                Clear();
            }
            else
            {
                if (txtContact.Text == "" &&  txtAddress.Text == "" && txtName.Text == "")
                {
                    this.Dispose(); 
                }
                else
                {
                    Clear();
                }
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pedit = 1;
            lblID.Text = DGVPersons.CurrentRow.Cells[0].Value.ToString();
            txtName.Text = DGVPersons.CurrentRow.Cells[1].Value.ToString();
            cboType.Text = DGVPersons.CurrentRow.Cells[2].Value.ToString();
            txtContact.Text = DGVPersons.CurrentRow.Cells[3].Value.ToString();
            txtAddress.Text = DGVPersons.CurrentRow.Cells[4].Value.ToString();
            lblBirthday.Text = DGVPersons.CurrentRow.Cells[5].Value.ToString();
                        if(language.ToString() == "Chinese"){btnSave.Text = "更新";}else{btnSave.Text = "UPDATE";}
            btnSave.BackColor = Color.Orange;
        }


        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DGVPersons != null)
            {
                if (DGVPersons.Rows.Count > 0)
                {
                    if (DGVPersons.SelectedRows.Count == 1)
                    {
                        try
                        {
                            MainClass.con.Open();
                            SqlCommand cmd = new SqlCommand("delete from PersonsTable where PersonID = @PersonID", MainClass.con);
                            cmd.Parameters.AddWithValue("@PersonID", DGVPersons.CurrentRow.Cells[0].Value.ToString());
                            cmd.ExecuteNonQuery();
                                           if(language.ToString() == "English"){MessageBox.Show("Record Deleted Successfully");}else {MessageBox.Show("記錄刪除成功");}
                            MainClass.con.Close();
                            ShowPersons(DGVPersons, PersonIDGV, NameGV, TypeGV, ContactGV, AddressGV, BdayGV);
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

        byte[] ConvertImageToBytes(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }

        public Image ConvertByteArraytoImage(byte[] data)
        {
            using (MemoryStream ms = new MemoryStream(data))
            {
                return Image.FromStream(ms);
            }
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ShowPersons(DGVPersons, PersonIDGV, NameGV, TypeGV, ContactGV, AddressGV, BdayGV,txtSearch.Text.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose(); BibiHomeScreen ds = new BibiHomeScreen();  
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog odf = new OpenFileDialog() { Filter = "Image files(*.jpg;*.jpeg)|*.jpg;*jpeg", Multiselect = false })
                if (odf.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = Image.FromFile(odf.FileName);
                }

        }

        private void DGVPersons_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void DGVPersons_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                if (DGVPersons.SelectedRows.Count == 1)
                {
                    MainClass.con.Open();
                    try
                    {
                        SqlCommand cmd = new SqlCommand("select PersonImage from PersonsTable where PersonID = '" + DGVPersons.CurrentRow.Cells["PersonIDGV"].Value.ToString() + "'", MainClass.con);
                        SqlDataReader dr = cmd.ExecuteReader();
                        dr.Read();
                        if (dr.HasRows)
                        {
                            pictureBox1.Image = ConvertByteArraytoImage((byte[])dr["PersonImage"]);
                        }
                        else
                        {
                            pictureBox1.Image = null;
                        }
                    }
                    catch (Exception)
                    {
                        MainClass.con.Close();
                        MessageBox.Show("No Pic Was Found");
                    }
                    MainClass.con.Close();
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }
    }
}
