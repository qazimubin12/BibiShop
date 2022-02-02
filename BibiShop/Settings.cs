using System;

using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Globalization;
using System.IO;

using System.Windows.Forms;
namespace BibiShop
{
    public partial class Settings : Form
    {
        int edit = 0;
        int mode = 0;
        object language = MainClass.LanguageCheck();
        public Settings()
        {
InitializeComponent(); MainClass.ChangeLanguage();
        }

        private void LoadLogo()
        {
            MainClass.con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("select Logo from StoreTable", MainClass.con);
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    pictureBox1.Image = ConvertByteArraytoImage((byte[])dr["Logo"]);
                }
                else
                {
                    pictureBox1.Image = null;
                }
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
            MainClass.con.Close();
        }
        private void ShowUsers(DataGridView dgv, DataGridViewColumn NameGV, DataGridViewColumn UsernameGV, DataGridViewColumn PasswordGV, DataGridViewColumn RoleGv)
        {
            try
            {
                MainClass.con.Open();
                SqlCommand cmd = new SqlCommand("select * from UsersTable order by Name", MainClass.con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                NameGV.DataPropertyName = dt.Columns["Name"].ToString();
                UsernameGV.DataPropertyName = dt.Columns["Username"].ToString();
                PasswordGV.DataPropertyName = dt.Columns["Password"].ToString();
                RoleGv.DataPropertyName = dt.Columns["Role"].ToString();
                dgv.DataSource = dt;
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }



        private void CheckMode()
        {
            try
            {
                MainClass.con.Open();
                SqlCommand cmd = new SqlCommand("select InventoryMode from ModeSwitching", MainClass.con);
                mode = int.Parse(cmd.ExecuteScalar().ToString());
                MainClass.con.Close();

                if(mode == 0)
                {
                    modetoggle.Checked = false;
                }
                else
                {
                    modetoggle.Checked = true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MainClass.con.Close();
            }
        }



        private void ShowStore()
        {
            LoadLogo();
            MainClass.con.Open();
            SqlCommand cmd = new SqlCommand("select * from StoreTable ", MainClass.con);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {

                txtStoreName.Text = dr["StoreName"].ToString();
                txtStoreAddress.Text = dr["StoreAddress"].ToString();
                cboWarehouse.SelectedValue = dr["ShopDefaultWarehouse"].ToString();
                txtTax.Text = dr["Tax"].ToString();
                cboLanguage.Text = dr["Language"].ToString();
            }
            else
            {
                txtStoreName.Text = "";
                txtStoreAddress.Text = "";
                cboWarehouse.Text= "";
                txtTax.Text = "";
            }
           
            dr.Close();
            MainClass.con.Close();
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (edit == 0)
            {
                if (txtName.Text == "" && txtUsername.Text == "" && txtPasword.Text == "" && cboRole.SelectedIndex == 0)
                {
                    MessageBox.Show("Please Input Details");
                }
                else
                {
                    if (txtPasword.Text != txtConfimPassword.Text)
                    {
                        MessageBox.Show("Password Mismatched");
                    }
                    else
                    {
                        try
                        {
                            MainClass.con.Open();
                            SqlCommand cmd = new SqlCommand("insert into UsersTable (Name,Username,Password,Role) values(@Name,@Username,@Password,@Role)", MainClass.con);
                            cmd.Parameters.AddWithValue("@Name", txtName.Text);
                            cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                            cmd.Parameters.AddWithValue("@Password", txtConfimPassword.Text);
                            cmd.Parameters.AddWithValue("@Role", cboRole.SelectedItem);
                            cmd.ExecuteNonQuery();
                            MainClass.con.Close();
                            MessageBox.Show("User Updated Successfully.");
                            Clear();
                            ShowUsers(DgvUsers, NameGV, UserNameGV, PasswordGV, RoleGV);
                        }
                        catch (Exception ex)
                        {
                            MainClass.con.Close();
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
            else
            {
                if (edit == 1)
                {
                    if (txtPasword.Text != txtConfimPassword.Text)
                    {
                        MessageBox.Show("Password Mismatched");
                    }
                    else
                    {
                        try
                        {
                            MainClass.con.Open();
                            SqlCommand cmd = new SqlCommand("update UsersTable set Name = @Name, @Password = @Password, Role = @Role where Username = @Username", MainClass.con);
                            cmd.Parameters.AddWithValue("@Name", txtName.Text);
                            cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                            cmd.Parameters.AddWithValue("@Password", txtConfimPassword.Text);
                            cmd.Parameters.AddWithValue("@Role", cboRole.SelectedItem);
                            cmd.ExecuteNonQuery();
                            MainClass.con.Close();
                            MessageBox.Show("User Updated Successfully.");
                            Clear();
                            ShowUsers(DgvUsers, NameGV, UserNameGV, PasswordGV, RoleGV);
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" || txtUsername.Text != "" || txtPasword.Text != "" || cboRole.SelectedIndex != 0 || txtConfimPassword.Text != "")
            {
                Clear();
                edit = 0;
            }
            else
            {
                this.Dispose(); BibiHomeScreen ds = new BibiHomeScreen();  
            }
        }
        void Clear()
        {
            txtName.Text = "";
            txtUsername.Text = "";
            txtPasword.Text = "";
            txtConfimPassword.Text = "";
            cboRole.SelectedIndex = 0;
        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            edit = 1;
            txtName.Text = DgvUsers.CurrentRow.Cells[1].Value.ToString();
            txtUsername.Text = DgvUsers.CurrentRow.Cells[0].Value.ToString();
            txtPasword.Text = DgvUsers.CurrentRow.Cells[2].Value.ToString();
            txtConfimPassword.Text = DgvUsers.CurrentRow.Cells[2].Value.ToString();
            cboRole.SelectedItem = DgvUsers.CurrentRow.Cells[3].Value.ToString();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DgvUsers != null)
            {
                if (DgvUsers.Rows.Count > 0)
                {
                    if (DgvUsers.SelectedRows.Count == 1)
                    {
                        try
                        {
                            MainClass.con.Open();
                            SqlCommand cmd = new SqlCommand("delete from Users where Username = @Username", MainClass.con);
                            cmd.Parameters.AddWithValue("@Username", DgvUsers.CurrentRow.Cells[0].Value.ToString());
                            cmd.ExecuteNonQuery();
                            if(language.ToString() == "English"){MessageBox.Show("Record Deleted Successfully");}else {MessageBox.Show("記錄刪除成功");}
                            MainClass.con.Close();
                            ShowUsers(DgvUsers, NameGV, UserNameGV, PasswordGV, RoleGV);
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

        private void Settings_Load(object sender, EventArgs e)
        {
            ShowUsers(DgvUsers, NameGV, UserNameGV, PasswordGV, RoleGV);
            MainClass.HideAllTabsOnTabControl(tabControl1);
            tabControl1.SelectedIndex = 0;

            MainClass.FillWarehouses(cboWarehouse);
            CheckMode();
            ShowStore();
        }

        private void btnUserSettings_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void btnDatabaseSettings_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose(); BibiHomeScreen ds = new BibiHomeScreen();  
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            String Database = MainClass.con.Database.ToString();
            try
            {
                MainClass.con.Open();
                if (txtBackup.Text == "")
                {
                    MessageBox.Show("Please Locate The Backup File", "Error", MessageBoxButtons.OK);
                    return;
                }
                else
                {
                    string q = "BACKUP DATABASE[" + Database + "] TO DISK = '" + txtBackup.Text + "\\" + "Database" + "-" + DateTime.Now.ToString("yyyy-MM-dd--HH-mm-ss") + ".bak'";
                    SqlCommand cmd = new SqlCommand(q, MainClass.con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Backup Success", "Success", MessageBoxButtons.OK);
                }
                MainClass.con.Close();
            }

            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }

        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            MainClass.con.Open();
            String Database = MainClass.con.Database.ToString();
            try
            {
                string sql1 = string.Format("ALTER DATABASE [" + Database + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
                SqlCommand cmd = new SqlCommand(sql1, MainClass.con);
                cmd.ExecuteNonQuery();

                string sql2 = string.Format("USE MASTER RESTORE DATABASE [" + Database + "] FROM DISK='" + txtRestore.Text + "' WITH REPLACE;");
                SqlCommand cmd2 = new SqlCommand(sql2, MainClass.con);
                cmd2.ExecuteNonQuery();

                string sql3 = string.Format("ALTER DATABASE [" + Database + "] SET MULTI_USER");
                SqlCommand cmd3 = new SqlCommand(sql3, MainClass.con);
                cmd3.ExecuteNonQuery();

                MessageBox.Show("Database Restored successfully", "Restore Database successs", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { MainClass.con.Close(); }

        }

        private void btnRestoreBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "SQL SERVER database backup files|*.bak";
            ofd.Title = "Database Restore";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtRestore.Text = ofd.FileName;
                btnRestore.Enabled = true;
            }
        }

        private void btnBackupBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                txtBackup.Text = fbd.SelectedPath;
                btnBackupBrowse.Enabled = true;
            }
        }

        private void btnSaveMode_Click(object sender, EventArgs e)
        {
            MainClass.con.Open();
            SqlCommand cmd = new SqlCommand("update ModeSwitching set InventoryMode = @InventoryMode", MainClass.con);
            if(modetoggle.Checked == false)
            {
                cmd.Parameters.AddWithValue("@InventoryMode", 0);
            }
            else
            {
                cmd.Parameters.AddWithValue("@InventoryMode", 1);

            }
            cmd.ExecuteNonQuery();
            MessageBox.Show("Settings Updated Successfully");
            MainClass.con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
            if(txtStoreName.Text != "")
            {
                btnSaveStore.Enabled = false;
                btnUpdateStore.Enabled = true;
            }
            else
            {
                btnSaveStore.Enabled = true;
                btnUpdateStore.Enabled = false;
            }
        }

        private void btnSaveStore_Click(object sender, EventArgs e)
        {
            MainClass.con.Open();
            SqlCommand cmd = new SqlCommand("insert into StoreTable (StoreName,StoreAddress,ShopDefaultWarehouse,Tax,Logo,Language) values (@StoreName,@StoreAddress,@ShopDefaultWarehouse,@Tax,@Logo,@Language) ", MainClass.con);
            cmd.Parameters.AddWithValue("@StoreName", txtStoreName.Text);
            cmd.Parameters.AddWithValue("@StoreAddress", txtStoreAddress.Text);
            cmd.Parameters.AddWithValue("@ShopDefaultWarehouse", cboWarehouse.SelectedValue);
            cmd.Parameters.AddWithValue("@Logo", ConvertImageToBytes(pictureBox1.Image));
            cmd.Parameters.AddWithValue("@Tax", float.Parse(txtTax.Text));
            cmd.Parameters.AddWithValue("@Language", cboLanguage.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Store Saved Successfully");
            MainClass.con.Close();
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
        private void btnUpdateStore_Click(object sender, EventArgs e)
        {
            MainClass.con.Open();
            SqlCommand cmd = new SqlCommand("update StoreTable set StoreName = @StoreName,Language = @Language, StoreAddress= @StoreAddress ,Tax= @Tax, ShopDefaultWarehouse = @ShopDefaultWarehouse, Logo = @Logo ", MainClass.con);
            cmd.Parameters.AddWithValue("@StoreName", txtStoreName.Text);
            cmd.Parameters.AddWithValue("@StoreAddress", txtStoreAddress.Text);
            cmd.Parameters.AddWithValue("@ShopDefaultWarehouse", cboWarehouse.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@Logo", ConvertImageToBytes(pictureBox1.Image));
            cmd.Parameters.AddWithValue("@Tax", float.Parse(txtTax.Text));
            cmd.Parameters.AddWithValue("@Language", cboLanguage.Text);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Store Updated Successfully");
            MainClass.con.Close();
            ShowStore();
            MainClass.ChangeLanguage();
            Application.Restart();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog odf = new OpenFileDialog() { Filter = "Image files(*.jpg;*.jpeg)|*.jpg;*jpeg", Multiselect = false })
                if (odf.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = Image.FromFile(odf.FileName);
                }

        }

        public static DataTable GetDataTabletFromCSVFile(string csv_file_path)
        {
            DataTable csvData = new DataTable();
            try
            {
                if (csv_file_path.EndsWith(".csv"))
                {
                    using (Microsoft.VisualBasic.FileIO.TextFieldParser csvReader = new Microsoft.VisualBasic.FileIO.TextFieldParser(csv_file_path))
                    {
                        csvReader.SetDelimiters(new string[] { "," });
                        csvReader.HasFieldsEnclosedInQuotes = true;
                        //read column
                        string[] colFields = csvReader.ReadFields();
                        foreach (string column in colFields)
                        {
                            DataColumn datecolumn = new DataColumn(column);
                            datecolumn.AllowDBNull = true;
                            csvData.Columns.Add(datecolumn);
                        }
                        while (!csvReader.EndOfData)
                        {
                            string[] fieldData = csvReader.ReadFields();
                            for (int i = 0; i < fieldData.Length; i++)
                            {
                                if (fieldData[i] == "")
                                {
                                    fieldData[i] = null;
                                }
                            }
                            csvData.Rows.Add(fieldData);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return csvData;
        }


        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.ShowDialog();
                int ImportedRecord = 0, inValidItem = 0;
                string SourceURl = "";

                if (dialog.FileName != "")
                {
                    if (dialog.FileName.EndsWith(".csv"))
                    {
                        DataTable dtNew = new DataTable();
                        dtNew = GetDataTabletFromCSVFile(dialog.FileName);
                        if (Convert.ToString(dtNew.Columns[0]) != "ProductName")
                        {
                            MessageBox.Show("Invalid Items File");
                            btnImport.Enabled = false;
                            return;
                        }
                        txtBrowse.Text = dialog.SafeFileName;
                        SourceURl = dialog.FileName;
                        if (dtNew.Rows != null && dtNew.Rows.ToString() != String.Empty)
                        {
                            dataGridView1.DataSource = dtNew;
                        }
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (Convert.ToString(row.Cells["ProductName"].Value) == "" || row.Cells["ProductName"].Value == null)
                            {
                                row.DefaultCellStyle.BackColor = Color.Red;
                                inValidItem += 1;
                            }
                            else
                            {
                                ImportedRecord += 1;
                            }
                        }
                        if (dataGridView1.Rows.Count == 0)
                        {
                            btnImport.Enabled = false;
                            MessageBox.Show("There is no data in this file", "__", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Selected File is Invalid, Please Select valid csv file.", "____", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            btnImport.Enabled = true;
        }

        byte[] ReadFile(string sPath)
        {
            //Initialize byte array with a null value initially.
            byte[] data = null;

            //Use FileInfo object to get file size.
            FileInfo fInfo = new FileInfo(sPath);
            long numBytes = fInfo.Length;

            //Open FileStream to read file
            FileStream fStream = new FileStream(sPath, FileMode.Open, FileAccess.Read);

            //Use BinaryReader to read file stream into byte array.
            BinaryReader br = new BinaryReader(fStream);

            //When you use BinaryReader, you need to supply number of bytes 
            //to read from file.
            //In this case we want to read entire file. 
            //So supplying total number of bytes.
            data = br.ReadBytes((int)numBytes);

            return data;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (txtBrowse.Text == "")
            {
                MessageBox.Show("Please Select File First");
                return;
            }
            MainClass.con.Open();
            try
            {
                SqlCommand cmd = null;
                DataTable dtItem = (DataTable)(dataGridView1.DataSource);
                string ProductName;
                string Remarks;
                string barcode;
                float costprice;
                float saleprice;
                object categoryID, UnitID, brandID,SizeID,ColorID;
                String ProfilePicture = String.Empty;
                String filename = String.Empty;



                int count = 0;

                foreach (DataRow dr in dtItem.Rows)
                {
                    ProfilePicture = dr["Image"].ToString();
                  
                    byte[] imageData = ReadFile(ProfilePicture);


                    ProductName = Convert.ToString(dr["ProductName"].ToString());
                    cmd = new SqlCommand("select ProductName from ProductsTable where ProductName N= '" + ProductName + "'", MainClass.con);
                    object ob = cmd.ExecuteScalar();
                    if (ob == null)
                    {

                        barcode = Convert.ToString(dr["Barcode"].ToString());
                        cmd = new SqlCommand("select CategoryID from CategoriesTable where Category like N'%" + dr["Category"] + "%'", MainClass.con);
                        categoryID = cmd.ExecuteScalar();
                        if (categoryID ==null)
                        {
                            cmd = new SqlCommand("insert into CategoriesTable (Category) values (@Category)", MainClass.con);
                            cmd.Parameters.AddWithValue("@Category", dr["Category"]);
                            cmd.ExecuteNonQuery();

                            cmd = new SqlCommand("select CategoryID from CategoriesTable where Category like N'%" + dr["Category"] + "%'", MainClass.con);
                            categoryID = cmd.ExecuteScalar();
                        }


                        cmd = new SqlCommand("select BrandID from BrandsTable where Brand like '%" + dr["Brand"] + "%'",MainClass.con);
                        brandID = cmd.ExecuteScalar();
                        if (brandID == null)
                        {
                            cmd = new SqlCommand("insert into BrandsTable (Brand) values (@Brand)", MainClass.con);
                            cmd.Parameters.AddWithValue("@Brand", dr["Brand"]);
                            cmd.ExecuteNonQuery();

                            cmd = new SqlCommand("select BrandID from BrandsTable where Brand like '%" + dr["Brand"] + "%'",MainClass.con);
                            brandID = cmd.ExecuteScalar();
                        }


                        cmd = new SqlCommand("select ColorID from ColorsTable where Color like '%" + dr["Color"] + "%'", MainClass.con);
                        ColorID = cmd.ExecuteScalar();
                        if (ColorID == null)
                        {
                            cmd = new SqlCommand("insert into ColorsTable (Color) values (@Color)", MainClass.con);
                            cmd.Parameters.AddWithValue("@Color", dr["Color"]);
                            cmd.ExecuteNonQuery();

                            cmd = new SqlCommand("select ColorID from ColorsTable where Color like '%" + dr["Color"] + "%'", MainClass.con);
                            ColorID = cmd.ExecuteScalar();
                        }


                        cmd = new SqlCommand("select SizeID from SizeTable where Size like '%" + dr["Size"] + "%'", MainClass.con);
                        SizeID = cmd.ExecuteScalar();
                        if (SizeID == null)
                        {
                            cmd = new SqlCommand("insert into SizeTable (Size) values (@Size)", MainClass.con);
                            cmd.Parameters.AddWithValue("@Size", dr["Size"]);
                            cmd.ExecuteNonQuery();

                            cmd = new SqlCommand("select SizeID from SizeTable where Size like '%" + dr["Size"] + "%'", MainClass.con);
                            SizeID = cmd.ExecuteScalar();
                        }





                        cmd = new SqlCommand("select UnitID from UnitsTable where Unit like '%" + dr["Unit"] + "%'",MainClass.con);
                        UnitID = cmd.ExecuteScalar();
                        if (UnitID == null)
                        {
                            cmd = new SqlCommand("insert into UnitsTable (Unit) values (@Unit)", MainClass.con);
                            cmd.Parameters.AddWithValue("@Unit", dr["Unit"]);
                            cmd.ExecuteNonQuery();

                            cmd = new SqlCommand("select UnitID from UnitsTable where Unit like '%" + dr["Unit"] + "%'",MainClass.con);
                            UnitID = cmd.ExecuteScalar();
                        }



                        costprice = float.Parse(dr["CostPrice"].ToString());
                        saleprice = float.Parse(dr["SalePrice"].ToString());
                        Remarks = dr["Remarks"].ToString();
                        cmd = new SqlCommand("insert into ProductsTable (Barcode,ProductName,BrandID,CatID,UnitID,CostPrice,SalePrice,Remarks,ColorID,SizeID,Image) values(@Barcode,@ProductName,@BrandID,@CatID,@UnitID,@CostPrice,@SalePrice,@Remarks,@ColorID,@SizeID,@Image)", MainClass.con);
                        cmd.Parameters.AddWithValue("@Barcode", barcode);
                        cmd.Parameters.AddWithValue("@ProductName", ProductName);
                        cmd.Parameters.AddWithValue("@BrandID", brandID.ToString());
                        cmd.Parameters.AddWithValue("@CatID", categoryID.ToString());
                        cmd.Parameters.AddWithValue("@UnitID", UnitID.ToString());
                        cmd.Parameters.AddWithValue("@CostPrice", costprice);
                        cmd.Parameters.AddWithValue("@SalePrice", saleprice);
                        cmd.Parameters.AddWithValue("@Remarks", Remarks);
                        cmd.Parameters.AddWithValue("@SizeID", SizeID.ToString());
                        cmd.Parameters.AddWithValue("@ColorID", ColorID.ToString());
                        cmd.Parameters.AddWithValue("@Image", imageData);
                        cmd.ExecuteNonQuery();
                        count++;

                    }
                    else
                    {
                        continue;
                    }
                    
                }
              
                MainClass.con.Close();
                MessageBox.Show(count.ToString() +" Item Imported Successfully Duplicate Name Skipped", "_____", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MainClass.con.Close();
            }
        }

        private void btnPersonBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.ShowDialog();
                int ImportedRecord = 0, inValidItem = 0;
                string SourceURl = "";

                if (dialog.FileName != "")
                {
                    if (dialog.FileName.EndsWith(".csv"))
                    {
                        DataTable dtNew = new DataTable();
                        dtNew = GetDataTabletFromCSVFile(dialog.FileName);
                        if (Convert.ToString(dtNew.Columns[1]) != "Name")
                        {
                            MessageBox.Show("Invalid Items File");
                            btnImport.Enabled = false;
                            return;
                        }
                        txtBrowse.Text = dialog.SafeFileName;
                        SourceURl = dialog.FileName;
                        if (dtNew.Rows != null && dtNew.Rows.ToString() != String.Empty)
                        {
                            dataGridView1.DataSource = dtNew;
                        }
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (Convert.ToString(row.Cells["Name"].Value) == "" || row.Cells["Name"].Value == null)
                            {
                                row.DefaultCellStyle.BackColor = Color.Red;
                                inValidItem += 1;
                            }
                            else
                            {
                                ImportedRecord += 1;
                            }
                        }
                        if (dataGridView1.Rows.Count == 0)
                        {
                            btnImport.Enabled = false;
                            MessageBox.Show("There is no data in this file", "__", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Selected File is Invalid, Please Select valid csv file.", "____", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            btnPersonImportt.Enabled = true;

        }

        private void btnPersonImportt_Click(object sender, EventArgs e)
        {
            if (txtBrowse.Text == "")
            {
                MessageBox.Show("Please Select File First");
                return;
            }
            MainClass.con.Open();
            try
            {
                SqlCommand cmd = null;
                DataTable dtItem = (DataTable)(dataGridView1.DataSource);
                string Name;
                string Type;
                string Contact;
                string Address;
                String PersonImage = String.Empty;
                String filename = String.Empty;
                string Birthday = "";


                int count = 0;

                foreach (DataRow dr in dtItem.Rows)
                {
                    byte[] imageData = null;
                    PersonImage = dr["PersonImage"].ToString();
                    if (dr["PersonImage"].ToString() != "")
                    {
                        imageData = ReadFile(PersonImage);
                    }


                    Name = Convert.ToString(dr["Name"].ToString());
                    cmd = new SqlCommand("select Name from PersonsTable where Name = N'" +Name+ "'", MainClass.con);
                    object ob = cmd.ExecuteScalar();
                    if (ob == null)
                    {

                        Type = Convert.ToString(dr["Type"].ToString());
                        Contact = dr["Contact"].ToString();
                        Address = dr["Address"].ToString();
                        string birthday = dr["Birthday"].ToString();
                        if (birthday != "NULL")
                        {
                            Birthday = birthday;
                        }
                        else
                        {
                            Birthday = "";
                        }



                        cmd = new SqlCommand("insert into PersonsTable (Type,Name,Contact,Address,Birthday,PersonImage) values(@Type,@Name,@Contact,@Address,@Birthday,@PersonImage)", MainClass.con);
                        cmd.Parameters.AddWithValue("@Type", Type);
                        cmd.Parameters.AddWithValue("@Name", Name);
                        cmd.Parameters.AddWithValue("@Contact", Contact);
                        cmd.Parameters.AddWithValue("@Address", Address);
                        cmd.Parameters.AddWithValue("@Birthday", Birthday);
                        cmd.Parameters.AddWithValue("@PersonImage", imageData);
                        cmd.ExecuteNonQuery();
                        count++;

                    }
                    else
                    {
                        continue;
                    }

                }

                MainClass.con.Close();
                MessageBox.Show(count.ToString() + " Person Imported Imported Successfully Duplicate Name Skipped", "_____", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MainClass.con.Close();
            }
        }
    }
}
