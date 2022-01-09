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
          //  QuantityForm qty2 = new QuantityForm(this);
           // qty2.ShowDialog();
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




        private void BibiPOS_Load(object sender, EventArgs e)
        {
            lblCashier.Text = LoginScreen.User_NAME.ToString();
            FindShopDefault();
            MainClass.FillProducts(cboProduct);
            MainClass.FillCustomer(cboCustomer);
            GetCategoryData();
            GetProductData();
            MainClass.RoundedButton(btnPurchases);
            MainClass.RoundedButton(btnRecentSales);
            MainClass.RoundedButton(btnAddCustomers);

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
                    gross += float.Parse(item.Cells[6].Value.ToString());
                }
                //txtGrandTotal.Text = gross.ToString();
                //txtPaying.Enabled = true;
                //txtWPaying.Enabled = true;
            }
            else
            {
                gross = 0;
                //txtGrandTotal.Text = gross.ToString();
                //txtPaying.Enabled = false;
                //txtWPaying.Enabled = false;
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
                    if (combosearch == 0)
                    {
                        cmd = new SqlCommand("select Qty from Inventory where Barcode = '" + txtSearhBarcode.Text + "' and WarehouseID = '"+shopwarehouse+"'", MainClass.con);
                    }
                    else
                    {
                        cmd = new SqlCommand("select Qty from Inventory where ProductID = '" + cboProduct.SelectedValue.ToString() + "' and WarehouseID = '" + shopwarehouse + "'", MainClass.con);
                    }
                    object ob = cmd.ExecuteScalar();
                    if (ob != null)
                    {
                        if (int.Parse(ob.ToString()) != 0 && float.Parse(QuantityForm.ControlID.TextData) < float.Parse(ob.ToString()))
                        {
                            proceed = 1;
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
                            proceed = 1;
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
                    DGVSaleCart.Rows.Add(Convert.ToInt32(ProductsData[0]), Convert.ToString(ProductsData[1]), Convert.ToString(ProductsData[4]), float.Parse(ProductsData[2]), float.Parse(ProductsData[3]), ProductsData[6], fqty, ProductsData[5], ptot);
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
                                DGVSaleCart.Rows.Add(Convert.ToInt32(ProductsData[0]), Convert.ToString(ProductsData[1]), Convert.ToString(ProductsData[4]), float.Parse(ProductsData[2]), float.Parse(ProductsData[3]), ProductsData[6], fqty, ProductsData[5], ptot);
                                break;
                            }
                        }
                    }
                }
                FindGrossTotal();
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
                    DGVSaleCart.Rows.Add(Convert.ToInt32(ProductsData[0]), Convert.ToString(ProductsData[1]), Convert.ToString(ProductsData[4]), float.Parse(ProductsData[2]), float.Parse(ProductsData[3]), ProductsData[6], fqty, ProductsData[5], ptot);
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
                                DGVSaleCart.Rows.Add(Convert.ToInt32(ProductsData[0]), Convert.ToString(ProductsData[1]), Convert.ToString(ProductsData[4]), float.Parse(ProductsData[2]), float.Parse(ProductsData[3]), ProductsData[6], fqty, ProductsData[5], ptot);
                                break;
                            }
                        }
                    }
                }
                FindGrossTotal();
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
                if (e.ColumnIndex == 10)
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
                    if (e.ColumnIndex == 9)
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

        }

        private void btnPurchases_Click(object sender, EventArgs e)
        {
            PurchaseInvoice p = new PurchaseInvoice();
            p.Show();
        }

        private void cboProduct_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
