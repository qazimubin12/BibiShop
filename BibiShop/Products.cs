using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BibiShop
{
    public partial class Products : Form
    {
        int show = 0;
        int pedit = 0;
        object language = MainClass.LanguageCheck();
        public Products()
        {
InitializeComponent(); MainClass.ChangeLanguage();
        }

        private void CheckMode()
        {
            int mode;
            try
            {
                MainClass.con.Open();
                SqlCommand cmd = new SqlCommand("select InventoryMode from ModeSwitching", MainClass.con);
                mode = int.Parse(cmd.ExecuteScalar().ToString());
                if (mode == 0)
                {
                    label2.Visible = false;
                    label6.Visible = false;
                 //   cbPackage.Visible = false;
                    DGVSomeProducts.Columns["CostSID"].Visible = false;
                    DGVSomeProducts.Columns["BarcodeSID"].Visible = false;
                    txtBarcode.Visible = false;
                    txtCostPrice.Visible = false;

                }
                else
                {
                    label2.Visible = true;
                    label6.Visible = true;
                //    cbPackage.Visible = true;
                    txtBarcode.Visible = true;
                    txtCostPrice.Visible = true;
                    DGVSomeProducts.Columns["CostSID"].Visible = true;
                    DGVSomeProducts.Columns["BarcodeSID"].Visible = true;


                }

                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }


        private void ShowProductSID(DataGridView dgv2, DataGridViewColumn ID, DataGridViewColumn Barcode, DataGridViewColumn Name, DataGridViewColumn Cat, DataGridViewColumn Brand, DataGridViewColumn Cost,
           DataGridViewColumn Sale, DataGridViewColumn Remarks, DataGridViewColumn Unit, DataGridViewColumn Color, DataGridViewColumn Size, string data = null)
        {
            try
            {
                SqlCommand cmd = null;
                MainClass.con.Open();

                if (data != "")
                {
                    cmd = new SqlCommand("select p.ProductID,p.Barcode,p.ProductName,c.Category,bt.Brand,u.Unit,p.CostPrice,p.SalePrice,p.Remarks,sz.Size,ct.Color from ProductsTable p inner join CategoriesTable c on c.CategoryID = p.CatID  join UnitsTable u on u.UnitID = p.UnitID inner join BrandsTable bt on bt.BrandID = p.BrandID inner join ColorsTable ct on ct.ColorID = p.ColorID inner join SizeTable sz on sz.SizeID = p.SizeID  where p.ProductName like '%" + data + "%'", MainClass.con);
                }
                else
                {
                    cmd = new SqlCommand("select p.ProductID,p.Barcode,p.ProductName,c.Category,bt.Brand,u.Unit,p.CostPrice,p.SalePrice,p.Remarks,sz.Size,ct.Color from ProductsTable p inner join CategoriesTable c on c.CategoryID = p.CatID  join UnitsTable u on u.UnitID = p.UnitID inner join BrandsTable bt on bt.BrandID = p.BrandID inner join ColorsTable ct on ct.ColorID = p.ColorID inner join SizeTable sz on sz.SizeID = p.SizeID  order by p.ProductName", MainClass.con);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                ID.DataPropertyName = dt.Columns["ProductID"].ToString();
                Name.DataPropertyName = dt.Columns["ProductName"].ToString();
                Barcode.DataPropertyName = dt.Columns["Barcode"].ToString();
                Brand.DataPropertyName = dt.Columns["Brand"].ToString();
                Cat.DataPropertyName = dt.Columns["Category"].ToString();
                Cost.DataPropertyName = dt.Columns["CostPrice"].ToString();
                Sale.DataPropertyName = dt.Columns["SalePrice"].ToString();
                Remarks.DataPropertyName = dt.Columns["Remarks"].ToString();
                Unit.DataPropertyName = dt.Columns["Unit"].ToString();
                Color.DataPropertyName = dt.Columns["Color"].ToString();
                Size.DataPropertyName = dt.Columns["Size"].ToString();
                dgv2.DataSource = dt;
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }


      

      

        private void Products_Load(object sender, EventArgs e)
        {
            CheckMode();
            MainClass.FillCategories(cboCategory);
            MainClass.FillUnits(cboUnits);
            MainClass.FillColors(cboColor);
            MainClass.FillSizes(cboSize);
            DGVSomeProducts.BringToFront();
            MainClass.FillBrands(cboBrand);
            ShowProductSID(DGVSomeProducts, ProSID, BarcodeSID, NameSID, CategorySID,BrandGV2, CostSID, SaleSID, RemarksSID, UnitSID,ColorGV,SizeGV ,txtSearch.Text.ToString());
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

            ShowProductSID(DGVSomeProducts, ProSID, BarcodeSID, NameSID, CategorySID, BrandGV2, CostSID, SaleSID, RemarksSID, UnitSID, ColorGV, SizeGV, txtSearch.Text.ToString());

        }


        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose(); 
        }

        private void Clear()
        {
            txtBarcode.Text = "";
            txtProductName.Text = "";
            txtCostPrice.Text = "";
            txtSalePrice.Text = "";
         
            txtRemarks.Text = "";
            cboUnits.SelectedIndex = 0;
            cboCategory.SelectedIndex = 0;
        }

        byte[] ConvertImageToBytes(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, ImageFormat.Png);
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = null;
            SqlDataReader dr;

            string catId = "";
            string unitid = "";
            string packunitid = "";

            MainClass.con.Open();

            //CatUnit
            cmd = new SqlCommand("select CategoryID from CategoriesTable where Category like N'" + cboCategory.Text + "'", MainClass.con);
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    catId = dr[0].ToString();
                }
            }
            dr.Close();

            
            //Unit
            cmd = new SqlCommand("select UnitID from UnitsTable where Unit like '" + cboUnits.Text + "'", MainClass.con);
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    unitid = dr[0].ToString();
                }
            }
            dr.Close();
            
      
            
            MainClass.con.Close();

            if (pedit == 0)
            {
                if (txtProductName.Text == "" || txtSalePrice.Text == "" || txtCostPrice.Text == "" ||
                    cboCategory.SelectedIndex == 0 || cboUnits.SelectedIndex == 0)
                {
                    MessageBox.Show("Please Input Details");
                }
                else
                {
                    try
                    {
                        MainClass.con.Open();
                        cmd = new SqlCommand("insert into ProductsTable (Barcode,ProductName,BrandID,CatID,UnitID,CostPrice,SalePrice,Remarks,Image,ColorID,SizeID,SafetyStock) values(@Barcode,@ProductName,@BrandID,@CatID,@UnitID,@CostPrice,@SalePrice,@Remarks,@Image,@ColorID,@SizeID,@SafetyStock)", MainClass.con);
                        cmd.Parameters.AddWithValue("@Barcode", txtBarcode.Text);
                        cmd.Parameters.AddWithValue("@ProductName", txtProductName.Text);
                        cmd.Parameters.AddWithValue("@BrandID", cboBrand.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@CatID", catId);
                        cmd.Parameters.AddWithValue("@UnitID", unitid);
                        cmd.Parameters.AddWithValue("@CostPrice", txtCostPrice.Text);
                        cmd.Parameters.AddWithValue("@SalePrice", txtSalePrice.Text);
                        cmd.Parameters.AddWithValue("@Remarks", txtRemarks.Text);
                        cmd.Parameters.AddWithValue("@SafetyStock",txtSafetyStock.Text);
                        if(pictureBox1.Image == null)
                        {
                            byte[] imageBT = null;
                            cmd.Parameters.AddWithValue("@Image", imageBT);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@Image", ConvertImageToBytes(pictureBox1.Image));
                        }
                        
                        cmd.Parameters.AddWithValue("@SizeID", cboSize.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@ColorID", cboColor.SelectedValue.ToString());

                        cmd.ExecuteNonQuery();
                        MainClass.con.Close();
                        MessageBox.Show("Product Inserted Successfully.");
                        Clear();
                        ShowProductSID(DGVSomeProducts, ProSID, BarcodeSID, NameSID, CategorySID, BrandGV2, CostSID, SaleSID, RemarksSID, UnitSID, ColorGV, SizeGV, txtSearch.Text.ToString());
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
                        cmd = new SqlCommand("UPDATE ProductsTable SET Barcode =@Barcode,Image=@Image,ProductName =@ProductName,SafetyStock = @SafetyStock,ColorID= @ColorID,SizeID = @SizeID,CatID =@CatID,UnitID =@UnitID,BrandID = @BrandID,CostPrice =@CostPrice,SalePrice =@SalePrice, Remarks =@Remarks where ProductID = @ProductID", MainClass.con);
                        cmd.Parameters.AddWithValue("@ProductID", lblID.Text);
                        cmd.Parameters.AddWithValue("@Barcode", txtBarcode.Text);
                        cmd.Parameters.AddWithValue("@ProductName", txtProductName.Text);
                        cmd.Parameters.AddWithValue("@BrandID", cboBrand.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@CatID", catId);
                        cmd.Parameters.AddWithValue("@UnitID", unitid);
                        cmd.Parameters.AddWithValue("@CostPrice", txtCostPrice.Text);
                        cmd.Parameters.AddWithValue("@SalePrice", txtSalePrice.Text);
                        cmd.Parameters.AddWithValue("@Remarks", txtRemarks.Text);
                        cmd.Parameters.AddWithValue("@SizeID", cboSize.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@ColorID", cboColor.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@SafetyStock", txtSafetyStock.Text);

                        if (pictureBox1.Image == null)
                        {
                            byte[] imageBT = null;
                            cmd.Parameters.AddWithValue("@Image", imageBT);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@Image", ConvertImageToBytes(pictureBox1.Image));
                        }

                        cmd.ExecuteNonQuery();
                        MainClass.con.Close();
                        MessageBox.Show("Product Updated Successfully.");
                        btnSave.Text = "SAVE";
                        btnSave.BackColor = Color.SteelBlue;
                        Clear();
                        ShowProductSID(DGVSomeProducts, ProSID, BarcodeSID, NameSID, CategorySID, BrandGV2, CostSID, SaleSID, RemarksSID, UnitSID, ColorGV, SizeGV, txtSearch.Text.ToString());
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
            pedit = 1;
            lblID.Text = DGVSomeProducts.CurrentRow.Cells[0].Value.ToString();
            txtBarcode.Text = DGVSomeProducts.CurrentRow.Cells[1].Value.ToString();
            txtProductName.Text = DGVSomeProducts.CurrentRow.Cells[2].Value.ToString();
            cboBrand.Text = DGVSomeProducts.CurrentRow.Cells[4].Value.ToString();
            cboCategory.Text = DGVSomeProducts.CurrentRow.Cells[3].Value.ToString();
            cboUnits.Text = DGVSomeProducts.CurrentRow.Cells[5].Value.ToString();
            txtCostPrice.Text = DGVSomeProducts.CurrentRow.Cells[6].Value.ToString();
            txtSalePrice.Text = DGVSomeProducts.CurrentRow.Cells[7].Value.ToString();
            txtRemarks.Text = DGVSomeProducts.CurrentRow.Cells[8].Value.ToString();
            cboSize.Text = DGVSomeProducts.CurrentRow.Cells[9].Value.ToString();
            cboColor.Text = DGVSomeProducts.CurrentRow.Cells[10].Value.ToString();
                        if(language.ToString() == "Chinese"){btnSave.Text = "更新";}else{btnSave.Text = "UPDATE";}
            btnSave.BackColor = Color.Orange;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DGVSomeProducts != null)
            {
                if (DGVSomeProducts.Rows.Count > 0)
                {
                    if (DGVSomeProducts.SelectedRows.Count == 1)
                    {
                        try
                        {
                            MainClass.con.Open();
                            SqlCommand cmd = new SqlCommand("delete from ProductsTable where ProductID = @ProductID", MainClass.con);
                            cmd.Parameters.AddWithValue("@ProductID", DGVSomeProducts.CurrentRow.Cells[0].Value.ToString());
                            cmd.ExecuteNonQuery();
                            if(language.ToString() == "English"){MessageBox.Show("Record Deleted Successfully");}else {MessageBox.Show("記錄刪除成功");}
                            MainClass.con.Close();
                            ShowProductSID(DGVSomeProducts, ProSID, BarcodeSID, NameSID, CategorySID, BrandGV2, CostSID, SaleSID, RemarksSID, UnitSID, ColorGV, SizeGV, txtSearch.Text.ToString());
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
            pedit = 0;
            if (btnSave.BackColor == Color.Orange)
            {
                if (language.ToString() == "English") { btnSave.Text = "SAVE"; } else { btnSave.Text = "保存"; }
                btnSave.BackColor = Color.SteelBlue;
                Clear();
            }
            else
            {
                if (txtBarcode.Text == "" &&
                txtProductName.Text == "" &&
                txtCostPrice.Text == "" &&
                txtSalePrice.Text == "" &&
               
                txtRemarks.Text == "" &&
                cboUnits.SelectedIndex == 0 &&
                cboCategory.SelectedIndex == 0 )
                {
                    this.Dispose(); BibiHomeScreen ds = new BibiHomeScreen();  
                }
                else
                {
                    Clear();
                }
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog odf = new OpenFileDialog())
            {
                odf.Filter = "";

                ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
                string sep = string.Empty;

                foreach (var c in codecs)
                {
                    string codecName = c.CodecName.Substring(8).Replace("Codec", "Files").Trim();
                    odf.Filter = String.Format("{0}{1}{2} ({3})|{3}", odf.Filter, sep, codecName, c.FilenameExtension);
                    sep = "|";
                }

                odf.Filter = String.Format("{0}{1}{2} ({3})|{3}", odf.Filter, sep, "All Files", "*.*");
                if (odf.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = Image.FromFile(odf.FileName);
                }
            }      
               
            
        }

        private void DGVSomeProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                if (DGVSomeProducts.SelectedRows.Count == 1)
                {
                    MainClass.con.Open();
                    try
                    {
                        SqlCommand cmd = new SqlCommand("select Image from ProductsTable where ProductID = '" + DGVSomeProducts.CurrentRow.Cells["ProSID"].Value.ToString() + "'", MainClass.con);
                        SqlDataReader dr = cmd.ExecuteReader();
                        dr.Read();
                        if (dr.HasRows)
                        {
                            pictureBox1.Image = ConvertByteArraytoImage((byte[])dr["Image"]);
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
                        MessageBox.Show("No Pic was Found");
                    }
                    MainClass.con.Close();
                }
            }
        }

        private void btnAddSize_Click(object sender, EventArgs e)
        {
            Sizes sz = new Sizes();
            sz.Show();
        }

        private void btnAddColor_Click(object sender, EventArgs e)
        {
            Colors col = new Colors();
            col.Show();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            MainClass.FillSizes(cboSize);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            MainClass.FillColors(cboColor);
        }
    }
}
