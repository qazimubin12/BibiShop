using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BibiShop
{
    public partial class BibiPOS : Form
    {

      

        private Guna2Button categoryButton;
        private Guna2Button categoryaddButton;
        private Guna2Button ViewAllCategoryButton;


        private Guna2Button ProductPic;
        private Guna2Button productaddButton;
        private Guna2Button ViewAllProductButton;
        private Guna2HtmlLabel ProductPrice;



        int combosearch = 0;
        float fqty = 0;
        int error = 0;
        int proceed = 1;
        int mode2 = 0;
        float ptot = 0;
        int shopwarehouse = 0;

        int couponId = 0;
        string coupontype = "";
        public BibiPOS()
        {
            InitializeComponent();
        }
        
        private void FindShopDefault()
        {
            MainClass.con.Open();
            SqlCommand cmd = new SqlCommand("select ShopDefaultWarehouse from StoreTable", MainClass.con);
            shopwarehouse = int.Parse(cmd.ExecuteScalar().ToString());
            MainClass.con.Close();
        }


        private void GetProductData(string search = null, string catID = null)
        {
            fpProducts.Controls.Clear();

            SqlCommand cmd = null;
            SqlDataReader dr;
            try
            {
                MainClass.con.Open();
                if (search == "" || search == null)
                {
                    if (catID == "" || catID == null)
                    {
                        cmd = new SqlCommand("select Image,ProductID,ProductName,SalePrice from ProductsTable", MainClass.con);
                    }
                    else
                    {
                        cmd = new SqlCommand("select Image,ProductID,ProductName,SalePrice from ProductsTable where CatID = '" + catID + "'", MainClass.con);

                    }
                }
                else
                {
                    cmd = new SqlCommand("select Image,ProductID,ProductName,SalePrice from ProductsTable where ProductName like '%" + search + "%'", MainClass.con);
                }
                dr = cmd.ExecuteReader();
                productaddButton = new Guna2Button();
                productaddButton.Width = 85;
                productaddButton.Height = 85;
                productaddButton.Font = new Font("Arial", 35);
                productaddButton.AutoRoundedCorners = true;
                productaddButton.FillColor = Color.FromArgb(165, 197, 56);
                productaddButton.BackgroundImageLayout = ImageLayout.Stretch;
                productaddButton.Text = "+";
                productaddButton.ForeColor = Color.White;
                productaddButton.TextAlign = HorizontalAlignment.Center;
                productaddButton.BorderRadius = 10;
                productaddButton.Tag = "ADD";
                fpProducts.Controls.Add(productaddButton);
                productaddButton.Click += ProductaddButton_Click;

                ViewAllProductButton = new Guna2Button();
                ViewAllProductButton.Width = 85;
                ViewAllProductButton.Height = 85;
                ViewAllProductButton.Font = new Font("Arial", 15);
                ViewAllProductButton.AutoRoundedCorners = true;
                ViewAllProductButton.FillColor = Color.FromArgb(165, 197, 56);
                ViewAllProductButton.BackgroundImageLayout = ImageLayout.Stretch;
                ViewAllProductButton.Text = "VIEW ALL";
                ViewAllProductButton.ForeColor = Color.White;
                ViewAllProductButton.TextAlign = HorizontalAlignment.Center;
                ViewAllProductButton.BorderRadius = 10;
                fpProducts.Controls.Add(ViewAllProductButton);
                ViewAllProductButton.Click += ViewAllProductButton_Click;
           


                while (dr.Read())
                {
               

                    long len = dr.GetBytes(0, 0, null, 0, 0);
                    byte[] array = new byte[Convert.ToInt32(len) + 1];
                    dr.GetBytes(0, 0, array, 0, Convert.ToInt32(len));
                    ProductPic = new Guna2Button();
                    ProductPic.Width = 85;
                    ProductPic.Height = 85;
                    ProductPic.BackColor = Color.FromArgb(233, 246, 250);
                    ProductPic.AutoRoundedCorners = true;
                    ProductPic.BorderRadius = 10;
                    ProductPic.BorderThickness = 2;
                    ProductPic.FillColor = Color.Transparent;
                    ProductPic.Click += ProductPic_Click;
                    ProductPic.Tag = dr["ProductID"].ToString();




                    ProductPrice = new Guna2HtmlLabel();
                    ProductPrice.Text = "Rs. " + dr["SalePrice"].ToString();
                    ProductPrice.Font = new Font("Berlin Sans FB", 13);
                    ProductPrice.ForeColor = Color.Black;
                    
                    
                    ProductPrice.TextAlignment = ContentAlignment.MiddleCenter;
                    ProductPrice.Dock = DockStyle.Bottom;
                    ProductPrice.BackColor = Color.LightSteelBlue;
                    ProductPrice.ForeColor = Color.Black;
                    ProductPrice.Width = 100;





                    MemoryStream ms = new MemoryStream(array);
                    Bitmap bitmap = new Bitmap(ms);
                    ProductPic.BackgroundImage = bitmap;
                    ProductPic.BackgroundImageLayout = ImageLayout.Center;
                    ProductPic.BorderColor = Color.SteelBlue;

                
                    fpProducts.Controls.Add(ProductPic);
                    ProductPic.Controls.Add(ProductPrice);
                }
               

                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MainClass.con.Close();
            }
        }

        private void ProductPic_Click(object sender, EventArgs e)
        {
            string tag = ((Guna2Button)sender).Tag.ToString();
            try
            {
                MainClass.con.Open();
                SqlCommand cmd = null;
                cmd = new SqlCommand("select ProductID,ProductName from ProductsTable where ProductID = '" + tag + "'", MainClass.con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ProductsData[0] = dr[0].ToString(); // pro id
                        ProductsData[1] = dr[1].ToString(); // Pro Nmae
                    }
                }
                else
                {
                    Array.Clear(ProductsData, 0, ProductsData.Length);
                }
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            } //Get Product Info
   
            combosearch = 1;
            ProductPicClick(tag);
            cboProduct.SelectedIndex = 0;
            txtSearhBarcode.Focus();
            combosearch = 0;
        }

        private void ProductaddButton_Click(object sender, EventArgs e)
        {
            Products c = new Products();
            c.Show();
        }

        private void ViewAllProductButton_Click(object sender, EventArgs e)
        {
            GetProductData(null, null);
        }

        private void GetCategoryData()
        {
            fpCategories.Controls.Clear();
            fpCategories.WrapContents = false;
         
            SqlCommand cmd = null;
            SqlDataReader dr;
            try
            {
                MainClass.con.Open();
                cmd = new SqlCommand("select CategoryID,Category from CategoriesTable", MainClass.con);
                dr = cmd.ExecuteReader();
                categoryaddButton = new Guna2Button();
                categoryaddButton.Width = 72;
                categoryaddButton.Height = 72;
                categoryaddButton.Font = new Font("Arial", 35);
                categoryaddButton.AutoRoundedCorners = true;
                categoryaddButton.FillColor = Color.FromArgb(165, 197, 56);
                categoryaddButton.BackgroundImageLayout = ImageLayout.Stretch;
                categoryaddButton.Text = "+";
                categoryaddButton.ForeColor = Color.White;
                categoryaddButton.TextAlign = HorizontalAlignment.Center;
                categoryaddButton.BorderRadius = 10;
                categoryaddButton.Tag = "ADD";
                fpCategories.Controls.Add(categoryaddButton);
                categoryaddButton.Click += new EventHandler(OnCategoryAddButtonClick);

                ViewAllCategoryButton = new Guna2Button();
                ViewAllCategoryButton.Width = 72;
                ViewAllCategoryButton.Height = 72;
                ViewAllCategoryButton.Font = new Font("Arial", 15);
                ViewAllCategoryButton.AutoRoundedCorners = true;
                ViewAllCategoryButton.FillColor = Color.FromArgb(165, 197, 56);
                ViewAllCategoryButton.BackgroundImageLayout = ImageLayout.Stretch;
                ViewAllCategoryButton.Text = "VIEW ALL";
                ViewAllCategoryButton.ForeColor = Color.White;
                ViewAllCategoryButton.TextAlign = HorizontalAlignment.Center;
                ViewAllCategoryButton.BorderRadius = 10;
                fpCategories.Controls.Add(ViewAllCategoryButton);
                ViewAllCategoryButton.Click += new EventHandler(OnCategoryViewAllClick);



                while (dr.Read())
                {
                    categoryButton = new Guna2Button();
                    categoryButton.Width = 72;
                    categoryButton.Height = 72;
                    categoryButton.Font = new Font("Arial", 12);
                    categoryButton.AutoRoundedCorners = true;
                    categoryButton.FillColor = Color.FromArgb(73, 155, 192);
                    categoryButton.BackgroundImageLayout = ImageLayout.Stretch;
                    categoryButton.Text = dr["Category"].ToString();
                    categoryButton.BorderRadius = 10;
                    categoryButton.ForeColor = Color.White;
                    categoryButton.Tag = dr["CategoryID"].ToString();
                    fpCategories.Controls.Add(categoryButton);
                    categoryButton.Click += new EventHandler(OnCategoryButtonClick);

                }

                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MainClass.con.Close();
            }
        }

        private void OnCategoryViewAllClick(object sender, EventArgs e)
        {
            GetProductData(null, null);
            GetCategoryData();
        }

        private void OnCategoryAddButtonClick(object sender, EventArgs e)
        {
            Categories c = new Categories();
            c.Show();
            
        }

     

        private void OnCategoryButtonClick(object sender, EventArgs e)
        {
            string tag = ((Guna2Button)sender).Tag.ToString();
            GetProductData(null, tag);
        }



        private void GenerateInvoiceNo()
        {
            try
            {
                MainClass.con.Open();
                SqlDataAdapter da = new SqlDataAdapter("select InvoiceNo from SaleInvoiceNo order by InvoiceNo desc", MainClass.con);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtInvoiceNo.Text = (int.Parse(ds.Tables[0].Rows[0][0].ToString()) + 1).ToString();
                }
                else
                {
                    txtInvoiceNo.Text = "1";
                }
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }
        private void BibiPOS_Load(object sender, EventArgs e)
        {
            lblCashier.Text = LoginScreen.User_NAME.ToString();
           
            FindShopDefault();
            MainClass.FillProducts(cboProduct);
            MainClass.FillCustomer(cboCustomer);
            GetCategoryData();
            GetProductData();
            MainClass.RoundedButton(btnPurchases);
            MainClass.RoundedButton(btnCoupons);
            MainClass.RoundedButton(btnRecentSales);
            MainClass.RoundedButton(btnAddCustomers);
            MainClass.RoundedButton(btnDiscount);
            MainClass.RoundedButton(btnInventory);
            MainClass.RoundedButton(btnFinalize);
            MainClass.RoundedButton(btnNewSale);
            MainClass.RoundedButton(btnPay);
            MainClass.RoundedButton(btnSaveSale);
            MainClass.RoundedButton(btnReset);
            GenerateInvoiceNo();
            ShowStore();
           

        }


        public Image ConvertByteArraytoImage(byte[] data)
        {
            using (MemoryStream ms = new MemoryStream(data))
            {
                return Image.FromStream(ms);
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
        private void ShowStore()
        {
            MainClass.con.Open();
            SqlCommand cmd = new SqlCommand("select * from StoreTable ", MainClass.con);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {

                lblStoreName.Text = dr["StoreName"].ToString();
                lblStoreAddress.Text = dr["StoreAddress"].ToString();
                pictureBox1.Image = ConvertByteArraytoImage((byte[])dr["Logo"]);

            }
            else
            {
                lblStoreName.Text = "";
                lblStoreAddress.Text = "";
            }

            dr.Close();
            MainClass.con.Close();
        }



        private string[] ProductsData = new string[10];
        private void cboProduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                SearchProducts sp = new SearchProducts(this);
                sp.ShowDialog();
            }
            else
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SqlCommand cmd = null;
                    if (cboProduct.Text != "" && cboProduct.SelectedIndex != 0)
                    {
                        try
                        {
                            MainClass.con.Open();
                            cmd = new SqlCommand("select ProductID,ProductName from ProductsTable where ProductName = '" + cboProduct.Text + "'", MainClass.con);
                            SqlDataReader dr = cmd.ExecuteReader();
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    ProductsData[0] = dr[0].ToString(); // pro id
                                    ProductsData[1] = dr[1].ToString(); // Pro Nmae
                                }
                            }
                            else
                            {
                                Array.Clear(ProductsData, 0, ProductsData.Length);
                            }
                            MainClass.con.Close();
                        }
                        catch (Exception ex)
                        {
                            MainClass.con.Close();
                            MessageBox.Show(ex.Message);
                        } //Get Product Info
                        QuantityForm qty2 = new QuantityForm(this);
                        qty2.ShowDialog();
                        combosearch = 1;
                        btnAdd_Click(sender, e);
                        cboProduct.SelectedIndex = 0;
                        combosearch = 0;
                        txtSearhBarcode.Focus();
                        
                    }
                    else
                    {
                        MessageBox.Show("Please Select Any Item");
                        return;
                    }
                }

            }
        }


        private void CheckTotal()
        {
            ptot = 0;
            ptot = float.Parse(ProductsData[3]) * fqty;


        }

    
        private void FindGrossTotal()
        {
            float gross = 0;

            if (DGVSaleCart.Rows.Count > 0)
            {
                foreach (DataGridViewRow item in DGVSaleCart.Rows)
                {
                    gross += float.Parse(item.Cells[8].Value.ToString());
                }
                lblGrandTotal.Text = gross.ToString();
                lblNetTotal.Text = gross.ToString();


                SqlCommand cmd = null;

                MainClass.con.Open();
                cmd = new SqlCommand("select Tax from StoreTable", MainClass.con);
                object TAX = cmd.ExecuteScalar();
                if (TAX != null)
                {
                    TAX = float.Parse(TAX.ToString()) / 100;
                    lblTax.Text = TAX.ToString();

                    float finalTotal = float.Parse(lblGrandTotal.Text) * float.Parse(TAX.ToString());
                    lblTax.Text = finalTotal.ToString();
                    float total = float.Parse(lblGrandTotal.Text);
                    total += finalTotal;

                    lblGrandTotal.Text = Math.Round(total, 0).ToString();

                }
                else
                {
                    float finalTotal = float.Parse(lblGrandTotal.Text) * 1;
                    lblGrandTotal.Text = finalTotal.ToString();
                }


                MainClass.con.Close();



            }
            else
            {
                gross = 0;
        
            }
        }





        private void GatheringData()
        {
            SqlCommand cmd = null;
            fqty = 0;
            fqty = float.Parse(QuantityForm.ControlID.TextData);
            error = 0;

            try
            {
                MainClass.con.Open();
                cmd = new SqlCommand("select InventoryMode from ModeSwitching", MainClass.con);
                mode2 = int.Parse(cmd.ExecuteScalar().ToString());
                MainClass.con.Close();


            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            } //Mode Checking



            if (mode2 == 1)
            {
               
                try
                {
                    if (combosearch == 0)
                    {
                        cmd = new SqlCommand("select Qty from Inventory where Barcode = '" + txtSearhBarcode.Text + "' and WarehouseID = '"+shopwarehouse+"'", MainClass.con);
                    }
                    else
                    {
                        CheckTheProductStock(int.Parse(cboProduct.SelectedValue.ToString()));
                        cmd = new SqlCommand("select Qty from Inventory where ProductID = '" + cboProduct.SelectedValue.ToString() + "' and WarehouseID = '" + shopwarehouse + "'", MainClass.con);
                    }
                    MainClass.con.Open();
                    object ob = cmd.ExecuteScalar();

                    if (ob != null)
                    {
                        if (int.Parse(ob.ToString()) != 0 && float.Parse(QuantityForm.ControlID.TextData) <= float.Parse(ob.ToString()))
                        {
                            if(float.Parse(ob.ToString()) > stockin)
                            {
                                MessageBox.Show("NO STOCKS");
                                proceed = 0;
                                MainClass.con.Close();
                                return;
                            }
                            else
                            {
                                proceed = 1;
                            }
                        }
                        else
                        {
                            MessageBox.Show("NO STOCKS");
                            proceed = 0;
                            MainClass.con.Close();
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("NO STOCKS");
                        proceed = 0;
                        MainClass.con.Close();
                        return;
                    }
                    MainClass.con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    MainClass.con.Close();
                } //checking qty
            }

            if (proceed == 1)
            {

                if (combosearch == 0)
                {
                    if (error == 0)
                    {
                        try
                        {
                            MainClass.con.Open();
                            cmd = new SqlCommand("select u.Unit from ProductsTable p inner join UnitsTable u on u.UnitID = p.UnitID where p.Barcode = '" + txtSearhBarcode.Text + "'", MainClass.con);
                            object ob = cmd.ExecuteScalar();
                            if (ob != null)
                            {
                                ProductsData[4] = ob.ToString();
                            }
                            MainClass.con.Close();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            MainClass.con.Close();
                        } //Unit
                        try
                        {
                            MainClass.con.Open();
                            cmd = new SqlCommand("select CostPrice,SalePrice from ProductsTable  where Barcode = '" + txtSearhBarcode.Text + "'", MainClass.con);
                            SqlDataReader dr = cmd.ExecuteReader();
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    ProductsData[2] = dr[0].ToString();
                                    ProductsData[3] = dr[1].ToString();
                                }
                            }
                            MainClass.con.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            MainClass.con.Close();
                        } //FindingRAtes
                        try
                        {
                            MainClass.con.Open();
                            cmd = new SqlCommand("select u.Size from ProductsTable p inner join SizeTable u on u.SizeID = p.SizeID where p.Barcode = '" + txtSearhBarcode.Text + "'", MainClass.con);
                            object ob = cmd.ExecuteScalar();
                            if (ob != null)
                            {
                                ProductsData[5] = ob.ToString();
                            }
                            MainClass.con.Close();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            MainClass.con.Close();
                        } //Size
                        try
                        {
                            MainClass.con.Open();
                            cmd = new SqlCommand("select u.Color from ProductsTable p inner join ColorsTable u on u.ColorID = p.ColorID where p.Barcode = '" + txtSearhBarcode.Text + "'", MainClass.con);
                            object ob = cmd.ExecuteScalar();
                            if (ob != null)
                            {
                                ProductsData[6] = ob.ToString();
                            }
                            MainClass.con.Close();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            MainClass.con.Close();
                        } //Color

                    }


                }
                else
                {

                    try
                    {
                        MainClass.con.Open();
                        cmd = new SqlCommand("select u.Unit from ProductsTable p inner join UnitsTable u on u.UnitID = p.UnitID where p.ProductName = '" + cboProduct.Text + "'", MainClass.con);
                        object ob = cmd.ExecuteScalar();
                        if (ob != null)
                        {
                            ProductsData[4] = ob.ToString();
                        }
                        MainClass.con.Close();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        MainClass.con.Close();
                    } //Unit
                    try
                    {
                        MainClass.con.Open();
                        cmd = new SqlCommand("select CostPrice,SalePrice from ProductsTable  where ProductName = '" + cboProduct.Text + "'", MainClass.con);
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ProductsData[2] = dr[0].ToString();
                                ProductsData[3] = dr[1].ToString();
                            }
                        }
                        MainClass.con.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        MainClass.con.Close();
                    } //FindingRAtes
                    try
                    {
                        MainClass.con.Open();
                        cmd = new SqlCommand("select u.Size from ProductsTable p inner join SizeTable u on u.SizeID = p.SizeID where p.ProductName = '" + cboProduct.Text + "'", MainClass.con);
                        object ob = cmd.ExecuteScalar();
                        if (ob != null)
                        {
                            ProductsData[5] = ob.ToString();
                        }
                        MainClass.con.Close();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        MainClass.con.Close();
                    } //Size
                    try
                    {
                        MainClass.con.Open();
                        cmd = new SqlCommand("select u.Color from ProductsTable p inner join ColorsTable u on u.ColorID = p.ColorID where p.ProductName = '" + cboProduct.Text + "'", MainClass.con);
                        object ob = cmd.ExecuteScalar();
                        if (ob != null)
                        {
                            ProductsData[6] = ob.ToString();
                        }
                        MainClass.con.Close();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        MainClass.con.Close();
                    } //Color
                }



            }


            if (ProductsData[3] == "0" && error == 1)
            {
                GatheringData();
            }
            
        }

        private void GatheringDataProductPic(string tag)
        {
            SqlCommand cmd = null;
            fqty = 0;
            fqty = 1;//float.Parse(QuantityForm.ControlID.TextData);
            error = 0;

            try
            {
                MainClass.con.Open();
                cmd = new SqlCommand("select InventoryMode from ModeSwitching", MainClass.con);
                mode2 = int.Parse(cmd.ExecuteScalar().ToString());

                
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            } //Mode Checking



            if (mode2 == 1)
            {
                try
                {
                    MainClass.con.Open();
                    cmd = new SqlCommand("select Qty from Inventory where ProductID = '" + tag + "' and WarehouseID = '"+shopwarehouse+"'", MainClass.con);
                    object ob = cmd.ExecuteScalar();
                    if (ob != null)
                    {
                        if (int.Parse(ob.ToString()) != 0 &&  1 < float.Parse(ob.ToString()))
                        {
                            if (DGVSaleCart.Rows.Count > 0)
                            {
                                foreach (DataGridViewRow item in DGVSaleCart.Rows)
                                {
                                    if (item.Cells[0].Value.ToString() == tag)
                                    {
                                        float addingqty = float.Parse(item.Cells["QuantityGV"].Value.ToString());
                                        addingqty++;
                                        if (addingqty <= float.Parse(ob.ToString()))
                                        {
                                            proceed = 1;
                                        }
                                        else
                                        {
                                            proceed = 0;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                proceed = 1;
                            }
                        }
                        else
                        {
                            MessageBox.Show("NO STOCKS");
                            proceed = 0;
                            MainClass.con.Close();
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("NO STOCKS");
                        proceed = 0;
                        MainClass.con.Close();
                        return;
                    }
                    MainClass.con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    MainClass.con.Close();
                } //checking qty
            }

            if (proceed == 1)
            {

                if (combosearch == 0)
                {
                    if (error == 0)
                    {
                        try
                        {
                            MainClass.con.Open();
                            cmd = new SqlCommand("select u.Unit from ProductsTable p inner join UnitsTable u on u.UnitID = p.UnitID where p.ProductID = '" + tag + "'", MainClass.con);
                            object ob = cmd.ExecuteScalar();
                            if (ob != null)
                            {
                                ProductsData[4] = ob.ToString();
                            }
                            MainClass.con.Close();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            MainClass.con.Close();
                        } //Unit
                        try
                        {
                            MainClass.con.Open();
                            cmd = new SqlCommand("select u.Size from ProductsTable p inner join SizeTable u on u.SizeID = p.UnitID where p.ProductID = '" + tag + "'", MainClass.con);
                            object ob = cmd.ExecuteScalar();
                            if (ob != null)
                            {
                                ProductsData[5] = ob.ToString();
                            }
                            MainClass.con.Close();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            MainClass.con.Close();
                        } //Size
                        try
                        {
                            MainClass.con.Open();
                            cmd = new SqlCommand("selecT s.Color from ProductsTable p inner join ColorsTable s on s.ColorID = p.ColorID  where p.ProductID = '" + tag + "'", MainClass.con);
                            object ob = cmd.ExecuteScalar();
                            if (ob != null)
                            {
                                ProductsData[6] = ob.ToString();
                            }
                            MainClass.con.Close();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            MainClass.con.Close();
                        } //Color
                        try
                        {
                            MainClass.con.Open();
                            cmd = new SqlCommand("select CostPrice,SalePrice from ProductsTable  where p.ProductID = '" + tag + "'", MainClass.con);
                            SqlDataReader dr = cmd.ExecuteReader();
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    ProductsData[2] = dr[0].ToString();
                                    ProductsData[3] = dr[1].ToString();
                                }
                            }
                            MainClass.con.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            MainClass.con.Close();
                        } //FindingRAtes
                    }


                }
                else
                {

                    try
                    {
                        MainClass.con.Open();
                        cmd = new SqlCommand("select u.Unit from ProductsTable p inner join UnitsTable u on u.UnitID = p.UnitID where p.ProductID = '" + tag + "'", MainClass.con);
                        object ob = cmd.ExecuteScalar();
                        if (ob != null)
                        {
                            ProductsData[4] = ob.ToString();
                        }
                        MainClass.con.Close();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        MainClass.con.Close();
                    } //Unit
                    try
                    {
                        MainClass.con.Open();
                        cmd = new SqlCommand("select CostPrice,SalePrice from ProductsTable  where ProductID = '" + tag + "'", MainClass.con);
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ProductsData[2] = dr[0].ToString();
                                ProductsData[3] = dr[1].ToString();
                            }
                        }
                        MainClass.con.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        MainClass.con.Close();
                    } //FindingRAtes
                    try
                    {
                        MainClass.con.Open();
                        cmd = new SqlCommand("select s.Size from ProductsTable p inner join SizeTable s on s.SizeID = p.SizeID  where p.ProductID = '" + tag + "'", MainClass.con);
                        object ob = cmd.ExecuteScalar();
                        if (ob != null)
                        {
                            ProductsData[5] = ob.ToString();
                        }
                        MainClass.con.Close();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        MainClass.con.Close();
                    } //Size
                    try
                    {
                        MainClass.con.Open();
                        cmd = new SqlCommand("selecT s.Color from ProductsTable p inner join ColorsTable s on s.ColorID = p.ColorID  where p.ProductID = '" + tag + "'", MainClass.con);
                        object ob = cmd.ExecuteScalar();
                        if (ob != null)
                        {
                            ProductsData[6] = ob.ToString();
                        }
                        MainClass.con.Close();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        MainClass.con.Close();
                    } //Color
                }



            }
            else
            {
                MessageBox.Show("NO STOCKS");
                proceed = 0;
                MainClass.con.Close();
                return;
            }
           
        }


        private void ProductPicClick(string tag)
        {
            bool productcheck = false;
            GatheringDataProductPic(tag);
            if (proceed == 1)
            {
                CheckTotal();

                if (DGVSaleCart.Rows.Count == 0)
                {
                    DGVSaleCart.Rows.Add(Convert.ToInt32(ProductsData[0]), Convert.ToString(ProductsData[1]), Convert.ToString(ProductsData[4]), float.Parse(ProductsData[2]), float.Parse(ProductsData[3]), ProductsData[6], fqty, ProductsData[5], ptot,"");
                }
                else
                {
                    foreach (DataGridViewRow item in DGVSaleCart.Rows)
                    {
                        if (Convert.ToInt32(ProductsData[0]) == int.Parse(item.Cells[0].Value.ToString())
                           && (Convert.ToString(ProductsData[4]) == Convert.ToString(item.Cells[2].Value)))
                        {
                            productcheck = true;
                            break;
                        }
                        else
                        {
                            productcheck = false;

                        }
                    }

                    foreach (DataGridViewRow item in DGVSaleCart.Rows)
                    {
                        if (productcheck == true)
                        {
                            if (Convert.ToInt32(ProductsData[0]) == int.Parse(item.Cells[0].Value.ToString())
                                && (Convert.ToString(ProductsData[4]) == Convert.ToString(item.Cells[2].Value)))
                            {

                                fqty += float.Parse(item.Cells[6].Value.ToString());
                                CheckTotal();
                                item.Cells[6].Value = fqty.ToString();
                                item.Cells[8].Value = ptot.ToString();
                                break;

                            }
                        }
                        else
                        {
                            if (productcheck == false)
                            {
                                DGVSaleCart.Rows.Add(Convert.ToInt32(ProductsData[0]), Convert.ToString(ProductsData[1]), Convert.ToString(ProductsData[4]), float.Parse(ProductsData[2]), float.Parse(ProductsData[3]), ProductsData[6], fqty, ProductsData[5], ptot, "");
                                break;
                            }
                        }
                    }
                }
                FindGrossTotal();
                if (DGVSaleCart.Rows.Count == 0)
                {
                    txtPayAmount.Enabled = false;
                }
                else
                {
                    txtPayAmount.Enabled = true;
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool productcheck = false;
            GatheringData();
            if (proceed == 1)
            {
                CheckTotal();

                if (DGVSaleCart.Rows.Count == 0)
                {
                    DGVSaleCart.Rows.Add(Convert.ToInt32(ProductsData[0]), Convert.ToString(ProductsData[1]), Convert.ToString(ProductsData[4]), float.Parse(ProductsData[2]), float.Parse(ProductsData[3]), ProductsData[6], fqty, ProductsData[5], ptot, "");
                }
                else
                {
                    foreach (DataGridViewRow item in DGVSaleCart.Rows)
                    {
                        if (Convert.ToInt32(ProductsData[0]) == int.Parse(item.Cells[0].Value.ToString())
                           && (Convert.ToString(ProductsData[4]) == Convert.ToString(item.Cells[2].Value)))
                        {
                            productcheck = true;
                            break;
                        }
                        else
                        {
                            productcheck = false;

                        }
                    }

                    foreach (DataGridViewRow item in DGVSaleCart.Rows)
                    {
                        if (productcheck == true)
                        {
                            if (Convert.ToInt32(ProductsData[0]) == int.Parse(item.Cells[0].Value.ToString())
                                && (Convert.ToString(ProductsData[4]) == Convert.ToString(item.Cells[2].Value)))
                            {

                                fqty += float.Parse(item.Cells[6].Value.ToString());
                                CheckTotal();
                                item.Cells[6].Value = fqty.ToString();
                                item.Cells[8].Value = ptot.ToString();
                                break;

                            }
                        }
                        else
                        {
                            if (productcheck == false)
                            {
                                DGVSaleCart.Rows.Add(Convert.ToInt32(ProductsData[0]), Convert.ToString(ProductsData[1]), Convert.ToString(ProductsData[4]), float.Parse(ProductsData[2]), float.Parse(ProductsData[3]), ProductsData[6], fqty, ProductsData[5], ptot, "");
                                break;
                            }
                        }
                    }
                }
                FindGrossTotal();
                if (DGVSaleCart.Rows.Count == 0)
                {
                    txtPayAmount.Enabled = false;
                }
                else
                {
                    txtPayAmount.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("NO STOCKS");
                proceed = 0;
                MainClass.con.Close();
                return;
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (lblCashier.Text == "Administrator")
            {
                this.Dispose();
            }
            else
            {
                this.Dispose();
                LoginScreen ls = new LoginScreen();
                ls.Show();

            }
        }
        float stockin;
        private void CheckTheProductStock(int productID)
        {
            MainClass.con.Open();
            SqlCommand cmd = new SqlCommand("select Qty from Inventory where ProductID = '" + productID + "' and WarehouseID = '" + shopwarehouse + "'",MainClass.con);
            stockin = float.Parse(cmd.ExecuteScalar().ToString());
            MainClass.con.Close();
        }

        private void DGVSaleCart_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                if (e.ColumnIndex == 11)
                {
                    float qty = 0;
                    float ptot = 0;
                    qty = float.Parse(DGVSaleCart.CurrentRow.Cells[6].Value.ToString());
                    if (qty == 1)
                    {
                        DGVSaleCart.Rows.RemoveAt(DGVSaleCart.CurrentRow.Index);
                    }
                    else
                    {
                        qty -= 1;
                    }

                    if (DGVSaleCart.Rows.Count != 0)
                    {
                        DGVSaleCart.CurrentRow.Cells[6].Value = qty.ToString();
                        ptot = qty * float.Parse(DGVSaleCart.CurrentRow.Cells[4].Value.ToString());
                        DGVSaleCart.CurrentRow.Cells[8].Value = ptot.ToString();
                    }


                }
                else
                {
                    if (e.ColumnIndex == 10)
                    {
                        CheckTheProductStock(int.Parse(DGVSaleCart.CurrentRow.Cells["ProductIDGV"].Value.ToString()));
                        
                        float qty = 0;
                        float ptot = 0;
                        qty = float.Parse(DGVSaleCart.CurrentRow.Cells[6].Value.ToString());
                        qty += 1;
                        if (stockin < qty)
                        {
                            MessageBox.Show("Not Enough Stock");
                            return;
                        }
                        else
                        {
                            DGVSaleCart.CurrentRow.Cells[6].Value = qty.ToString();
                            ptot = qty * float.Parse(DGVSaleCart.CurrentRow.Cells[4].Value.ToString());
                            DGVSaleCart.CurrentRow.Cells[8].Value = ptot.ToString();
                        }
                    }
                }

            }
            FindGrossTotal();
        }

        private void txtSearhBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SqlCommand cmd = null;
                SqlDataReader dr = null;
                if (txtSearhBarcode.Text != "")
                {
                    try
                    {
                        MainClass.con.Open();
                        cmd = new SqlCommand("select * from ProductsTable where Barcode = '" + txtSearhBarcode.Text + "'", MainClass.con);
                        dr = cmd.ExecuteReader();
                        if (dr.HasRows)
                        {
                            MainClass.con.Close();
                            try
                            {
                                MainClass.con.Open();
                                cmd = new SqlCommand("select ProductID,ProductName from ProductsTable where Barcode = '" + txtSearhBarcode.Text + "'", MainClass.con);
                                dr = cmd.ExecuteReader();
                                if (dr.HasRows)
                                {
                                    while (dr.Read())
                                    {
                                        ProductsData[0] = dr[0].ToString(); // pro id
                                        ProductsData[1] = dr[1].ToString(); // Pro Nmae
                                    }
                                }

                                else
                                {
                                    Array.Clear(ProductsData, 0, ProductsData.Length);
                                }
                                MainClass.con.Close();
                            }
                            catch (Exception ex)
                            {
                                MainClass.con.Close();
                                MessageBox.Show(ex.Message);
                            }//Get Product Info
                            QuantityForm qty2 = new QuantityForm(this);
                            qty2.ShowDialog();
                            btnAdd_Click(sender, e);
                            txtSearhBarcode.Text = "";
                            txtSearhBarcode.Focus();
                            combosearch = 0;
                        }
                        else
                        {
                            MainClass.con.Close();
                            MessageBox.Show("No Product Found");
                            return;
                        }

                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                        MainClass.con.Close();
                    }

                }
                else
                {
                    MessageBox.Show("Please Enter Barcode First");
                    return;
                }
            }

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Persons p = new Persons();
            p.Show();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            MainClass.FillCustomer(cboCustomer);
            MainClass.FillProducts(cboProduct);
        }

        private void btnAddCustomers_Click(object sender, EventArgs e)
        {
            Persons p = new Persons();
            p.Show();
        }

        private void btnRecentSales_Click(object sender, EventArgs e)
        {
            RecentSales vs = new RecentSales(this);
            vs.Show();
        }

        private void btnPurchases_Click(object sender, EventArgs e)
        {
           PurchaseInvoice p = new PurchaseInvoice();
            p.Show();
        }

        private void cboProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProduct.SelectedIndex != 0)
            {
                try
                {
                    MainClass.con.Open();
                    SqlCommand cmd = new SqlCommand("select Qty from Inventory where ProductID = '" + cboProduct.SelectedValue.ToString() + "'and WarehouseID = '" + shopwarehouse + "'", MainClass.con);
                    object ob = cmd.ExecuteScalar();
                    if (ob != null)
                    {
                        txtInHandQty.Text = ob.ToString();
                    }
                    else
                    {
                        txtInHandQty.Text = "0";
                    }
                    MainClass.con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    MainClass.con.Close();
                }
            }
            else
            {
                txtInHandQty.Text = "";
            }
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            Inventory i = new Inventory();
            i.Show();
        }

        private void CompleteClear()
        {
            DGVSaleCart.Rows.Clear();
            
            txtPayAmount.Text = "";
            txtChange.Text = "";
            paymentpanel.Visible = false;
            lblGrandTotal.Text = "0.00";
            lblNetTotal.Text = "0.00";
            lblTax.Text = "0.00";
            btnApply.Enabled = true;
            button2.Enabled = true;
            txtCouponCode.Text = "";
            btnApply.Text = "APPLY";
            couponpanel.Visible = false;
            lblSaleID.Text = "";
            lblInvoiceNo.Text = "";
            btnSaveSale.Text = "SAVE SALE";
            btnSaveSale.FillColor = Color.SlateBlue;
            cboProduct.SelectedIndex = 0;
            cboCustomer.SelectedIndex = 0;
            txtSaleRemarks.Text = "";
            btnApplyDiscount.Text = "APPLY";
            btnApplyDiscount.Enabled = true;
            btnCloseDiscountPanel.Enabled = true;
            discountpanel.Visible = false;
        }

        private void btnSaveSale_Click(object sender, EventArgs e)
        {
            if (btnSaveSale.Text != "Update Sale")
            {
                try
                {
                    MainClass.con.Open();
                    string invoiceNo = "SAL" + txtInvoiceNo.Text;
                    string saletime = "";
                    float discount = 0;
                    int couponId = 0;
                    string coupontype = "";
                    SqlCommand cmd = new SqlCommand("SELECT CONVERT(varchar(15),  CAST(GETDATE() AS TIME), 100) as SaleTime", MainClass.con);
                    saletime = cmd.ExecuteScalar().ToString();
                    if(lblDiscount.Text == "DISCOUNT")
                    {
                        discount = 0;
                    }
                    else
                    {
                        discount = float.Parse(lblDiscount.Text);
                    }
                    if(lblCouponID.Text == "CouponID" && lblCouponType.Text == "CouponType")
                    {
                        couponId = 0;
                        coupontype = "";
                    }
                    else
                    {
                        couponId = int.Parse(lblCouponID.Text);
                        coupontype = lblCouponType.Text;
                    }
                    
                    MainClass.InsertSale(int.Parse(cboCustomer.SelectedValue.ToString()), invoiceNo, lblStoreName.Text, lblStoreAddress.Text, DateTime.Now.ToShortDateString(), saletime, "Remaining Payment", ConvertImageToBytes(pictureBox1.Image), float.Parse(lblTax.Text), 0, 0,discount, float.Parse(lblGrandTotal.Text),coupontype,couponId,txtSaleRemarks.Text);
                    int SALEID = MainClass.FindLastSaleID();

                    foreach (DataGridViewRow item in DGVSaleCart.Rows)
                    {

                        cmd = new SqlCommand("selecT Qty from Inventory where WareHouseID = '" + shopwarehouse + "' and ProductID = '" + item.Cells[0].Value.ToString() + "'", MainClass.con);
                        float stock = float.Parse(cmd.ExecuteScalar().ToString());

                        int ProductID = int.Parse(item.Cells[0].Value.ToString());
                        string productname = item.Cells[1].Value.ToString();
                        string unit = item.Cells[2].Value.ToString();
                        float costprice = float.Parse(item.Cells[3].Value.ToString());
                        float saleprice = float.Parse(item.Cells[4].Value.ToString());
                        string color = item.Cells[5].Value.ToString();
                        float qty = float.Parse(item.Cells[6].Value.ToString());
                        string size = item.Cells[7].Value.ToString();
                        float total = float.Parse(item.Cells[8].Value.ToString());
                        MainClass.InsertSalesInfo(SALEID, ProductID, qty, unit, color, size, costprice, saleprice, total);

                        stock -= qty;
                        MainClass.UpdateInventory(ProductID, stock, shopwarehouse);
                    }            
                    MainClass.con.Close();
                    btnGenerate_Click(sender, e);
                    MessageBox.Show("SALE SAVED SUCCESSFULLY");
                    CompleteClear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    MainClass.con.Close();
                } //SAve Sale
            }
            else
            {
                try
                {
                    MainClass.con.Open();
                    float discount;
                   
                    if (lblDiscount.Text == "DISCOUNT")
                    {
                        discount = 0;
                    }
                    else
                    {
                        discount = float.Parse(lblDiscount.Text);
                    }
                    SqlCommand cmd = new SqlCommand("SELECT CONVERT(varchar(15),  CAST(GETDATE() AS TIME), 100) as SaleTime", MainClass.con);
                    string saletime = cmd.ExecuteScalar().ToString();
                    MainClass.UpdateSale(int.Parse(lblSaleID.Text), int.Parse(cboCustomer.SelectedValue.ToString()), DateTime.Now.ToShortDateString(), saletime, "Remaining Payment", float.Parse(lblTax.Text), 0, 0, discount, float.Parse(lblGrandTotal.Text),int.Parse(lblCouponID.Text),lblCouponType.Text);

                    cmd = new SqlCommand("select si.ProductID,u.UnitID,si.Quantity,p.Barcode,si.SalePrice,p.SafetyStock from SalesInfo si inner join ProductsTable p on p.ProductID = si.ProductID inner join UnitsTable u on u.UnitID = p.UnitID where Sales_ID = '" + lblSaleID.Text + "' ", MainClass.con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            cmd = new SqlCommand("insert into Inventory(ProductID,Unit,Qty,Barcode,Rate,SafetyStock,WarehouseID) values (@ProductID,@Unit,@Qty,@Barcode,@Rate,@SafetyStock,@WarehouseID)", MainClass.con);
                            cmd.Parameters.AddWithValue("@ProductID", dr[0].ToString());
                            cmd.Parameters.AddWithValue("@Unit", dr[1].ToString());
                            cmd.Parameters.AddWithValue("@Qty", dr[2].ToString());
                            cmd.Parameters.AddWithValue("@Barcode", dr[3].ToString());
                            cmd.Parameters.AddWithValue("@Rate", dr[4].ToString());
                            cmd.Parameters.AddWithValue("@SafetyStock", dr[5].ToString());
                            cmd.Parameters.AddWithValue("@WarehouseID", shopwarehouse);
                            cmd.ExecuteNonQuery();
                        }

                    }
                    dr.Close();

                    cmd = new SqlCommand("delete from SalesInfo where Sales_ID = '" + lblSaleID.Text + "'", MainClass.con);
                    cmd.ExecuteNonQuery();




                    foreach (DataGridViewRow item in DGVSaleCart.Rows)
                    {
                        cmd = new SqlCommand("selecT Qty from Inventory where WareHouseID = '" + shopwarehouse + "' and ProductID = '" + item.Cells[0].Value.ToString() + "'", MainClass.con);
                        float stock = float.Parse(cmd.ExecuteScalar().ToString());

                        int ProductID = int.Parse(item.Cells[0].Value.ToString());
                        string unit = item.Cells[2].Value.ToString();
                        float costprice = float.Parse(item.Cells[3].Value.ToString());
                        float saleprice = float.Parse(item.Cells[4].Value.ToString());
                        string color = item.Cells[5].Value.ToString();
                        float qty = float.Parse(item.Cells[6].Value.ToString());
                        string size = item.Cells[7].Value.ToString();
                        float total = float.Parse(item.Cells[8].Value.ToString());
                        MainClass.InsertSalesInfo(int.Parse(lblSaleID.Text), ProductID, qty, unit, color, size, costprice, saleprice, total);

                        stock -= qty;
                        MainClass.UpdateInventory(ProductID, stock, shopwarehouse);
                    }

                    MainClass.con.Close();
                    btnGenerate_Click(sender, e);
                    MessageBox.Show("SALE UPDATED SUCCESSFULLY");
                    CompleteClear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    MainClass.con.Close();
                }//Update Sale
            }
        }


        private void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                MainClass.con.Open();
                SqlCommand cmd = new SqlCommand("insert into SaleInvoiceNo (InvoiceNo) values ('" + txtInvoiceNo.Text + "')", MainClass.con);
                cmd.ExecuteNonQuery();
                MainClass.con.Close();
                GenerateInvoiceNo();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNewSale_Click(object sender, EventArgs e)
        {
            CompleteClear();
            btnGenerate_Click(sender, e);
            txtSearhBarcode.Focus();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            CompleteClear();
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            if (lblGrandTotal.Text != "0.00")
            {
                paymentpanel.Visible = true;
            }
            else
            {
                paymentpanel.Visible = false;
            }
        }

        private void txtPayAmount_TextChanged(object sender, EventArgs e)
        {
            if (txtPayAmount.Text == "" && txtPayAmount.Text == "0" && float.Parse(txtPayAmount.Text) > float.Parse(lblGrandTotal.Text))
            {
                txtChange.Text = "0";
                btnFinalize.Enabled = false;
            }
            else
            {
                btnFinalize.Enabled = true;
                float paying = float.Parse(txtPayAmount.Text);
                float total = float.Parse(lblGrandTotal.Text);
                txtChange.Text = (paying - total).ToString();
            }

        }

        private void btnFinalize_Click(object sender, EventArgs e)
        {
            if (lblSaleID.Text == "SaleID")
            {
                try
                {
                    MainClass.con.Open();
                    string invoiceNo = "SAL" + txtInvoiceNo.Text;
                    string saletime = "";
                    float discount = 0;
                  
                    if (lblCouponID.Text == "CouponID" && lblCouponType.Text == "CouponType")
                    {
                        couponId = 0;
                        coupontype = "";
                    }
                    else
                    {
                        couponId = int.Parse(lblCouponID.Text);
                        coupontype = lblCouponType.Text;
                    }

                    if (lblDiscount.Text == "DISCOUNT")
                    {
                        discount = 0;
                    }
                    else
                    {
                        discount = float.Parse(lblDiscount.Text);
                    }
                    SqlCommand cmd = new SqlCommand("SELECT CONVERT(varchar(15),  CAST(GETDATE() AS TIME), 100) as SaleTime", MainClass.con);
                    saletime = cmd.ExecuteScalar().ToString();

                    MainClass.InsertSale(int.Parse(cboCustomer.SelectedValue.ToString()), invoiceNo, lblStoreName.Text, lblStoreAddress.Text, DateTime.Now.ToShortDateString(), saletime, "Completed", ConvertImageToBytes(pictureBox1.Image), float.Parse(lblTax.Text), float.Parse(txtPayAmount.Text), float.Parse(txtChange.Text), discount, float.Parse(lblGrandTotal.Text), coupontype, couponId,txtSaleRemarks.t);
                    int SALEID = MainClass.FindLastSaleID();

                    foreach (DataGridViewRow item in DGVSaleCart.Rows)
                    {
                        int ProductID = int.Parse(item.Cells[0].Value.ToString());
                        string productname = item.Cells[1].Value.ToString();
                        string unit = item.Cells[2].Value.ToString();
                        float costprice = float.Parse(item.Cells[3].Value.ToString());
                        float saleprice = float.Parse(item.Cells[4].Value.ToString());
                        string color = item.Cells[5].Value.ToString();
                        float qty = float.Parse(item.Cells[6].Value.ToString());
                        string size = item.Cells[7].Value.ToString();
                        float total = float.Parse(item.Cells[8].Value.ToString());
                        MainClass.InsertSalesInfo(SALEID, ProductID, qty, unit, color, size, costprice, saleprice, total);
                    }
                    MainClass.con.Close();
                    btnGenerate_Click(sender, e);
                    MessageBox.Show("SALE FINALIZED SUCCESSFULLY");
                    CompleteClear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    MainClass.con.Close();
                }//FINALIZE SALES
            }
            else
            {
                try
                {
                    MainClass.con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT CONVERT(varchar(15),  CAST(GETDATE() AS TIME), 100) as SaleTime", MainClass.con);
                    string saletime = cmd.ExecuteScalar().ToString();
                    MainClass.UpdateSale(int.Parse(lblSaleID.Text), int.Parse(cboCustomer.SelectedValue.ToString()), DateTime.Now.ToShortDateString(), saletime, "Completed", float.Parse(lblTax.Text), float.Parse(txtPayAmount.Text), float.Parse(txtChange.Text), 0,float.Parse(lblGrandTotal.Text),int.Parse(lblCouponID.Text),lblCouponType.Text);
                    cmd = new SqlCommand("delete from SalesInfo where Sales_ID = '" + lblSaleID.Text + "'", MainClass.con);
                    cmd.ExecuteNonQuery();
                    foreach (DataGridViewRow item in DGVSaleCart.Rows)
                    {
                        int ProductID = int.Parse(item.Cells[0].Value.ToString());
                        string unit = item.Cells[2].Value.ToString();
                        float costprice = float.Parse(item.Cells[3].Value.ToString());
                        float saleprice = float.Parse(item.Cells[4].Value.ToString());
                        string color = item.Cells[5].Value.ToString();
                        float qty = float.Parse(item.Cells[6].Value.ToString());
                        string size = item.Cells[7].Value.ToString();
                        float total = float.Parse(item.Cells[8].Value.ToString());
                        MainClass.InsertSalesInfo(int.Parse(lblSaleID.Text), ProductID, qty, unit, color, size, costprice, saleprice, total);
                    }

                    MainClass.con.Close();
                    btnGenerate_Click(sender, e);
                    MessageBox.Show("SALE FINALIZED SUCCESSFULLY");
                    CompleteClear();
                }
                catch (Exception ex)
                {
                    MainClass.con.Close();
                    MessageBox.Show(ex.Message);
                } //Finalize Updated Sales
            }
        }

        private void btnCoupons_Click(object sender, EventArgs e)
        {
            Coupons c = new Coupons();
            c.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            couponpanel.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            couponpanel.Visible = false;
        }

        private void cboCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCustomer.SelectedIndex == 0)
            {
                fpProducts.Enabled = false;
                cboProduct.Enabled = false;
                txtSearhBarcode.Enabled = false;
                btnPay.Enabled = false;
                fpCategories.Enabled = false;
                btnSaveSale.Enabled = false;
            }
            else
            {
                fpProducts.Enabled = true;
                cboProduct.Enabled = true;
                txtSearhBarcode.Enabled = true;
                btnPay.Enabled = true;
                fpCategories.Enabled = true;
                btnSaveSale.Enabled = true;
            }
        }


        private void btnCancelCoupon_Click(object sender, EventArgs e)
        {
            if (btnSaveSale.Text == "Update Sale")
            {
                SqlCommand cmd = null;

                MainClass.con.Open();
                int couponID = int.Parse(lblCouponID.Text);

                cmd = new SqlCommand("select CouponBenefit from CouponsTypesTable where CouponType = '" + lblCouponType.Text + "'", MainClass.con);
                float benefit = float.Parse(cmd.ExecuteScalar().ToString());

                if (lblCouponType.Text == "Five Percentage Reduction")
                {
                    cmd = new SqlCommand("select MinimumBill from CouponsSettingsTable where CouponID = '" + couponID + "' ", MainClass.con);
                    float minimumbill = float.Parse(cmd.ExecuteScalar().ToString());

                    cmd = new SqlCommand("select ProductID from CouponsSettingsTable where CouponID = '" + couponID + "' ", MainClass.con);
                    int couponproduct = int.Parse(cmd.ExecuteScalar().ToString());

                    foreach (DataGridViewRow item in DGVSaleCart.Rows)
                    {
                        if (int.Parse(item.Cells["ProductIDGV"].Value.ToString()) == couponproduct)
                        {
                            float qty = float.Parse(item.Cells["QuantityGV"].Value.ToString());
                            float cost = float.Parse(item.Cells["SalePriceGV"].Value.ToString());
                            float actualtotal = qty * cost;
                            item.Cells["TotalOfProductGV"].Value = actualtotal.ToString();
                            item.Cells["RemarksGV"].Value = "";
                            btnApply.Text = "APPLY";
                            cmd = new SqlCommand("update CouponsTable set CouponsGenerated  = CouponsGenerated + 1 where CouponID  = '" + couponID + "'  ", MainClass.con);
                            cmd.ExecuteNonQuery();

                            cmd = new SqlCommand("update SalesTable set CouponType = @CouponType, CouponID = @CouponID where SaleID = '" + lblSaleID.Text + "'", MainClass.con);
                            cmd.Parameters.AddWithValue("@CouponType", DBNull.Value);
                            cmd.Parameters.AddWithValue("@CouponID", 0);
                            cmd.ExecuteNonQuery();

                            btnApply.Enabled = true;
                            button2.Enabled = true;
                        }
                    }

                }
                else if (lblCouponType.Text == "Some Dollar Reduction")
                {
                    cmd = new SqlCommand("select MinimumBill from CouponsSettingsTable where CouponID = '" + couponID + "' ", MainClass.con);
                    float minimumbill = float.Parse(cmd.ExecuteScalar().ToString());

                    if (float.Parse(lblGrandTotal.Text) > minimumbill)
                    {
                        foreach (DataGridViewRow item in DGVSaleCart.Rows)
                        {
                            float actualtotal = float.Parse(item.Cells["TotalOfProductGV"].Value.ToString());
                            actualtotal += benefit;
                            item.Cells["TotalOfProductGV"].Value = actualtotal.ToString();
                            item.Cells["RemarksGV"].Value = "";
                            btnApply.Text = "APPLY";
                            cmd = new SqlCommand("update CouponsTable set CouponsGenerated  = CouponsGenerated + 1 where CouponID  = '" + couponID + "'  ", MainClass.con);
                            cmd.ExecuteNonQuery();
                            btnApply.Enabled = true;
                            button2.Enabled = true;
                        }
                    }

                }
                else if (lblCouponType.Text == "Free Merchandise Type")
                {
                    cmd = new SqlCommand("select MinimumBill from CouponsSettingsTable where CouponID = '" + couponID + "' ", MainClass.con);
                    float minimumbill = float.Parse(cmd.ExecuteScalar().ToString());

                    cmd = new SqlCommand("select ProductID from CouponsSettingsTable where CouponID = '" + couponID + "' ", MainClass.con);
                    int couponproduct = int.Parse(cmd.ExecuteScalar().ToString());

                    foreach (DataGridViewRow item in DGVSaleCart.Rows)
                    {
                        if (int.Parse(item.Cells["ProductIDGV"].Value.ToString()) == couponproduct)
                        {
                            float qty = float.Parse(item.Cells["QuantityGV"].Value.ToString());
                            float cost = float.Parse(item.Cells["SalePriceGV"].Value.ToString());
                            float actualtotal = qty * cost;
                            item.Cells["TotalOfProductGV"].Value = actualtotal.ToString();
                            item.Cells["RemarksGV"].Value = "";
                            btnApply.Text = "APPLY";
                            cmd = new SqlCommand("update CouponsTable set CouponsGenerated  = CouponsGenerated + 1 where CouponID  = '" + couponID + "'  ", MainClass.con);
                            cmd.ExecuteNonQuery();

                            cmd = new SqlCommand("update SalesTable set CouponType = @CouponType, CouponID = @CouponID where SaleID = '" + lblSaleID.Text + "'", MainClass.con);
                            cmd.Parameters.AddWithValue("@CouponType", DBNull.Value);
                            cmd.Parameters.AddWithValue("@CouponID", 0);
                            cmd.ExecuteNonQuery();

                            btnApply.Enabled = true;
                            button2.Enabled = true;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Or Expired Coupon", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MainClass.con.Close();

            }
            FindGrossTotal();
        }
        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                bool isActive = false;
                bool found = false;
                object CouponsGenerated = 0;
                int coupontype = 0;
                int couponID = 0;
                MainClass.con.Open();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand("select * from CouponsTable where CouponCode = @CouponCode ", MainClass.con);
                cmd.Parameters.AddWithValue("@CouponCode", txtCouponCode.Text);
                dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    found = true;
                    isActive = bool.Parse(dr["IsActive"].ToString());
                    CouponsGenerated = dr["CouponsGenerated"].ToString();
                    coupontype = int.Parse(dr["CouponUsageType"].ToString());
                    couponID = int.Parse(dr["CouponID"].ToString());
                }
                else
                {
                    found = false;
                    MessageBox.Show("Invalid Or Expired Coupon", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                dr.Close();
                MainClass.con.Close();
                if (found == true)
                {
                    DayOfWeek today = DateTime.Today.DayOfWeek;
                    int daysvaluesplus = 0;
                    if (today == DayOfWeek.Sunday)
                    {
                        daysvaluesplus = 1;
                    }
                    else if (today == DayOfWeek.Monday)
                    {
                        daysvaluesplus = 2;
                    }
                    else if (today == DayOfWeek.Tuesday)
                    {
                        daysvaluesplus = 4;
                    }
                    else if (today == DayOfWeek.Wednesday)
                    {
                        daysvaluesplus = 8;
                    }
                    else if (today == DayOfWeek.Thursday)
                    {
                        daysvaluesplus = 16;
                    }
                    else if (today == DayOfWeek.Friday)
                    {
                        daysvaluesplus = 32;
                    }
                    else if (today == DayOfWeek.Saturday)
                    {
                        daysvaluesplus = 64;
                    }
                    else
                    {
                        daysvaluesplus = 0;
                    }



                    MainClass.con.Open();
                    cmd = new SqlCommand("select * from CouponsSettingsTable where (days & "+daysvaluesplus+") > 0 ", MainClass.con);
                    object ob = cmd.ExecuteScalar();
                    MainClass.con.Close();
                    if (ob != null)
                    {
                        if (isActive != false)
                        {
                            MainClass.con.Open();
                            cmd = new SqlCommand("select CouponBenefit from CouponsTypesTable where CouponTypeID = '" + coupontype + "'", MainClass.con);
                            float benefit = float.Parse(cmd.ExecuteScalar().ToString());
                            lblDiscount.Text = benefit.ToString();
                            lblCouponID.Text = couponID.ToString();

                            cmd = new SqlCommand("select CouponType from CouponsTypesTable where CouponTypeID = '" + coupontype + "'", MainClass.con);
                            object type = cmd.ExecuteScalar();
                            lblCouponType.Text = type.ToString();

                            if (type.ToString() == "Five Percentage Reduction")
                            {
                                cmd = new SqlCommand("select MinimumBill from CouponsSettingsTable where CouponID = '" + couponID + "' ", MainClass.con);
                                float minimumbill = float.Parse(cmd.ExecuteScalar().ToString());

                                cmd = new SqlCommand("select ProductID from CouponsSettingsTable where CouponID = '" + couponID + "' ", MainClass.con);
                                int couponproduct = int.Parse(cmd.ExecuteScalar().ToString());
                                if (float.Parse(lblGrandTotal.Text) > minimumbill)
                                {
                                    foreach (DataGridViewRow item in DGVSaleCart.Rows)
                                    {
                                        if (int.Parse(item.Cells["ProductIDGV"].Value.ToString()) == couponproduct)
                                        {
                                            float actualtotal = float.Parse(item.Cells["TotalOfProductGV"].Value.ToString());
                                            float tot = float.Parse(item.Cells["TotalOfProductGV"].Value.ToString());
                                            tot /= 100;
                                            tot *= benefit;
                                            actualtotal -= tot;
                                            lblDiscount.Text = tot.ToString();
                                            item.Cells["TotalOfProductGV"].Value = actualtotal.ToString();
                                            item.Cells["RemarksGV"].Value = "Coupon Applied";
                                            btnApply.Text = "APPLIED";
                                            cmd = new SqlCommand("update CouponsTable set CouponsGenerated  = CouponsGenerated - 1 where CouponID  = '" + couponID + "'  ", MainClass.con);
                                            cmd.ExecuteNonQuery();
                                            btnApply.Enabled = false;
                                            button2.Enabled = false;
                                        }
                                    }
                                }
                                else
                                {

                                    MessageBox.Show("Current Bill is not fulfilling the criteria of using this coupon");
                                    return;
                                }


                            }       //Type Percentage 
                            else if (type.ToString() == "Some Dollar Reduction")
                            {
                                cmd = new SqlCommand("select MinimumBill from CouponsSettingsTable where CouponID = '" + couponID + "' ", MainClass.con);
                                float minimumbill = float.Parse(cmd.ExecuteScalar().ToString());

                                if (float.Parse(lblGrandTotal.Text) > minimumbill)
                                {
                                    foreach (DataGridViewRow item in DGVSaleCart.Rows)
                                    {
                                        float actualtotal = float.Parse(item.Cells["TotalOfProductGV"].Value.ToString());
                                        actualtotal -= benefit;
                                        lblDiscount.Text = benefit.ToString();

                                        item.Cells["TotalOfProductGV"].Value = actualtotal.ToString();
                                        item.Cells["RemarksGV"].Value = "Coupon Applied";
                                        btnApply.Text = "APPLIED";
                                        cmd = new SqlCommand("update CouponsTable set CouponsGenerated  = CouponsGenerated - 1 where CouponID  = '" + couponID + "'  ", MainClass.con);
                                        cmd.ExecuteNonQuery();
                                        btnApply.Enabled = false;
                                        button2.Enabled = false;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Current Bill is not fulfilling the criteria of using this coupon");
                                    return;
                                }

                            }       // Type Dollar 
                            else if (type.ToString() == "Free Merchandise Type")
                            {
                                cmd = new SqlCommand("select MinimumBill from CouponsSettingsTable where CouponID = '" + couponID + "' ", MainClass.con);
                                float minimumbill = float.Parse(cmd.ExecuteScalar().ToString());

                                if (float.Parse(lblGrandTotal.Text) > minimumbill)
                                {
                                    foreach (DataGridViewRow item in DGVSaleCart.Rows)
                                    {
                                        float actualtotal = float.Parse(item.Cells["TotalOfProductGV"].Value.ToString());
                                        actualtotal = 0;

                                        item.Cells["TotalOfProductGV"].Value = actualtotal.ToString();
                                        item.Cells["RemarksGV"].Value = "Coupon Applied";
                                        btnApply.Text = "APPLIED";
                                        cmd = new SqlCommand("update CouponsTable set CouponsGenerated  = CouponsGenerated - 1 where CouponID  = '" + couponID + "'  ", MainClass.con);
                                        cmd.ExecuteNonQuery();
                                        btnApply.Enabled = false;
                                        button2.Enabled = false;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Invalid Or Expired Coupon", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                                MainClass.con.Close();
                            }       // Type Free Merch
                            else
                            {
                                MessageBox.Show("Invalid Or Expired Coupon", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Not Active Coupon", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Not Accessible Today", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
            FindGrossTotal();


        }

        private void DGVSaleCart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDiscount_Click(object sender, EventArgs e)
        {
            DiscountOffers d = new DiscountOffers();
            d.Show();
        }

        private void btnSelectDiscount_Click(object sender, EventArgs e)
        {
            discountpanel.Visible = true;
            MainClass.FillDiscount(cboApplyDiscount);
        }

        private void btnCloseDiscountPanel_Click(object sender, EventArgs e)
        {
            discountpanel.Visible = false;
        }

        private void btnApplyDiscount_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = null;
            string offername = cboApplyDiscount.Text;
            bool isActive = false;
            float minimumbill, benefit = 0;
            if(offername == "Dollar Reduction" || offername == "Percentage Reduction")
            {
                MainClass.con.Open();
                cmd = new SqlCommand("select IsActive from DiscountOffers where DiscountOfferName = '"+ offername+ "'", MainClass.con);
                isActive = bool.Parse(cmd.ExecuteScalar().ToString());

                if(isActive == true)
                {
                    cmd = new SqlCommand("select MinimumBill from DiscountOffers  where DiscountOfferName = '" + offername + "'", MainClass.con);
                    minimumbill = float.Parse(cmd.ExecuteScalar().ToString());

                    cmd = new SqlCommand("select DiscountBenefit from DiscountOffers  where DiscountOfferName = '" + offername + "'", MainClass.con);
                    benefit = float.Parse(cmd.ExecuteScalar().ToString());

                    if (float.Parse(lblNetTotal.Text) > minimumbill)
                    {
                        if (offername == "Percentage Reduction")
                        {
                            float actualtotal = float.Parse(lblNetTotal.Text);
                            float tot = float.Parse(lblNetTotal.Text);
                            tot /= 100;
                            tot *= benefit;
                            actualtotal -= tot;
                            lblDiscount.Text = tot.ToString();
                            lblNetTotal.Text = actualtotal.ToString();
                        }
                        else
                        {
                            float actualtotal = float.Parse(lblNetTotal.Text);
                            actualtotal -= benefit;
                            lblDiscount.Text = benefit.ToString();
                            lblNetTotal.Text = actualtotal.ToString();
                        }
                        txtSaleRemarks.Text = offername + " Applied Successfully";
                        btnApplyDiscount.Text = "APPLIED";
                        btnApplyDiscount.Enabled = false;
                        btnCloseDiscountPanel.Enabled = false;
                    }
                }

                MainClass.con.Close();
            }
            else
            {

            }

            FindGrossTotal();
        }
    }
}
