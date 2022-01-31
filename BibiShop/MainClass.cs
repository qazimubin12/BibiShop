using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BibiShop
{
    class MainClass
    {

        //  private static string s = @"Data Source=DESKTOP-QHHLI3L\SQLEXPRESS;Initial Catalog=BibiShop;Integrated Security = True;MultipleActiveResultSets=true;";
        private static string s = @"Data Source=DESKTOP-E7EO3OH;Initial Catalog=BibiShop;Integrated Security = True;MultipleActiveResultSets=true;";
        public static SqlConnection con = new SqlConnection(s);

        public static void RoundedButton(Guna2Button button)
        {
            button.AutoRoundedCorners = true;
            button.BorderRadius = 10;
            button.BorderColor = Color.FromArgb(28, 35, 64);
            button.BorderThickness = 2;
            button.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
        }

        public static void ChangeLanguage()
        {
            try
            {
                MainClass.con.Open();
                SqlCommand cmd = new SqlCommand("select Language from StoreTable", MainClass.con);
                object language = cmd.ExecuteScalar();
                MainClass.con.Close();
                if (language.ToString() == "Chinese")
                {
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("zh-TW");
                }
                else
                {
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MainClass.con.Close();
            }
        }

        public static void DataGridViewButton(DataGridViewButtonCell button)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.Style.BackColor = Color.FromArgb(92, 137, 253);
            button.Style.ForeColor = Color.White;
           
        }

        public static string LanguageCheck()
        {
            MainClass.con.Open();
            SqlCommand cmd = new SqlCommand("select Language from StoreTable", MainClass.con);
            string language = cmd.ExecuteScalar().ToString();
            MainClass.con.Close();

            return language;
        }

      
        public static void HideAllTabsOnTabControl(TabControl theTabControl)
        {
            theTabControl.Appearance = TabAppearance.FlatButtons;
            theTabControl.ItemSize = new Size(0, 1);
            theTabControl.SizeMode = TabSizeMode.Fixed;
        }

        public static DataTable Retrieve(string query)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(query, MainClass.con);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public static void showWindow(Form OpenWin, Form clsWin, Form MDIWin)
        {
            clsWin.Close();
            OpenWin.MdiParent = MDIWin;
            OpenWin.WindowState = FormWindowState.Maximized;
            OpenWin.Show();
        }


        public static void showWindow(Form OpenWin, Form MDIWin)
        {
            OpenWin.MdiParent = MDIWin;
            OpenWin.WindowState = FormWindowState.Maximized;
            OpenWin.Show();
        }


        public static void FillCategories(ComboBox cmb)
        {
            DataTable dtCategoryName = new DataTable();
            dtCategoryName.Columns.Add("CategoryID");
            dtCategoryName.Columns.Add("Category");
            dtCategoryName.Rows.Add("0", "-----Select-----");
            try
            {
                DataTable dt = Retrieve("select CategoryID, Category from CategoriesTable");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow category in dt.Rows)
                        {
                            dtCategoryName.Rows.Add(category["CategoryID"], category["Category"]);
                        }
                    }

                }
                cmb.DisplayMember = "Category";
                cmb.ValueMember = "CategoryID";
                cmb.DataSource = dtCategoryName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                cmb.DataSource = dtCategoryName;
            }

        }


        public static void FillCouponTypes(ComboBox cmb)
        {
            DataTable dtcouponName = new DataTable();
            dtcouponName.Columns.Add("CouponTypeID");
            dtcouponName.Columns.Add("CouponType");
            dtcouponName.Rows.Add("0", "-----Select-----");
            try
            {
                DataTable dt = Retrieve("select CouponTypeID, CouponType from CouponsTypesTable");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow coupon in dt.Rows)
                        {
                            dtcouponName.Rows.Add(coupon["CouponTypeID"], coupon["CouponType"]);
                        }
                    }

                }
                cmb.DisplayMember = "CouponType";
                cmb.ValueMember = "CouponTypeID";
                cmb.DataSource = dtcouponName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                cmb.DataSource = dtcouponName;
            }

        }


        public static void FillDiscount(ComboBox cmb)
        {
            DataTable dtdiscountName = new DataTable();
            dtdiscountName.Columns.Add("DiscountOfferName");
            dtdiscountName.Rows.Add("-----Select-----");
            try
            {
                DataTable dt = Retrieve("selecT DiscountOfferName from DiscountOffers union Select PackagedDiscountName from PackagedDiscount");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow discount in dt.Rows)
                        {
                            dtdiscountName.Rows.Add(discount["DiscountOfferName"]);
                        }
                    }

                }
                cmb.DisplayMember = "DiscountOfferName";
                cmb.DataSource = dtdiscountName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                cmb.DataSource = dtdiscountName;
            }

        }


        public static void FillCoupons(ComboBox cmb)
        {
            DataTable dtcouponName = new DataTable();
            dtcouponName.Columns.Add("CouponID");
            dtcouponName.Columns.Add("CouponName");
            dtcouponName.Rows.Add("0", "-----Select-----");
            try
            {
                DataTable dt = Retrieve("select CouponID, CouponName from CouponsTable");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow coupon in dt.Rows)
                        {
                            dtcouponName.Rows.Add(coupon["CouponID"], coupon["CouponName"]);
                        }
                    }

                }
                cmb.DisplayMember = "CouponName";
                cmb.ValueMember = "CouponID";
                cmb.DataSource = dtcouponName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                cmb.DataSource = dtcouponName;
            }
        }

        public static void FillWarehouses(ComboBox cmb)
        {
            DataTable dtWarehouseName = new DataTable();
            dtWarehouseName.Columns.Add("WarehouseID");
            dtWarehouseName.Columns.Add("Warehouse");
            dtWarehouseName.Rows.Add("0", "-----Select-----");
            dtWarehouseName.Rows.Add("1", "REMOVE FROM INVENTORY");
            try
            {
                DataTable dt = Retrieve("select WarehouseID, Warehouse from WarehouseTable");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow Warehouse in dt.Rows)
                        {
                            dtWarehouseName.Rows.Add(Warehouse["WarehouseID"], Warehouse["Warehouse"]);
                        }
                    }

                }
                cmb.DisplayMember = "Warehouse";
                cmb.ValueMember = "WarehouseID";
                cmb.DataSource = dtWarehouseName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                cmb.DataSource = dtWarehouseName;
            }

        }

        public static void FillUnits(ComboBox cmb)
        {
            DataTable dgUnits = new DataTable();
            dgUnits.Columns.Add("UnitID");
            dgUnits.Columns.Add("Unit");
            dgUnits.Rows.Add("0", "-----Select-----");
            try
            {
                DataTable dt = Retrieve("select UnitID, Unit from UnitsTable");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow units in dt.Rows)
                        {
                            dgUnits.Rows.Add(units["UnitID"], units["Unit"]);
                        }
                    }

                }
                cmb.DisplayMember = "Unit";
                cmb.ValueMember = "UnitID";

                cmb.DataSource = dgUnits;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                cmb.DataSource = dgUnits;
            }
        }



        public static void FillColors(ComboBox cmb)
        {
            DataTable dgColors = new DataTable();
            dgColors.Columns.Add("ColorID");
            dgColors.Columns.Add("Color");
            dgColors.Rows.Add("0", "-----Select-----");
            try
            {
                DataTable dt = Retrieve("select ColorID, Color from ColorsTable");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow color in dt.Rows)
                        {
                            dgColors.Rows.Add(color["ColorID"], color["Color"]);
                        }
                    }

                }
                cmb.DisplayMember = "Color";
                cmb.ValueMember = "ColorID";

                cmb.DataSource = dgColors;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                cmb.DataSource = dgColors;
            }
        }


        public static void FillOrderType(ComboBox cmb)
        {
            object lang = LanguageCheck();
            if (lang.ToString() == "Chinese")
            {
                cmb.Items.Insert(0, "選擇");
                cmb.Items.Insert(1, "完全的");
                cmb.Items.Insert(2, "剩餘款項");
                cmb.Items.Insert(3, "等待發貨");
            }
            else
            {
                cmb.Items.Insert(0, "Select");
                cmb.Items.Insert(1, "Completed");
                cmb.Items.Insert(2, "Remaining Payment");
                cmb.Items.Insert(3, "Waiting for delivery");
            }

        }

        public static void FillORderTpy(ComboBox cmb)
        {
            object lang = LanguageCheck();
            if (lang.ToString() == "Chinese")
            {
                cmb.Items.Insert(0, "選擇");
                cmb.Items.Insert(1, "完全的");
                cmb.Items.Insert(2, "有存貨");
            }
            else
            {
                cmb.Items.Insert(0, "Select");
                cmb.Items.Insert(1, "Delivery");
                cmb.Items.Insert(2, "In Store");
            }

        }

       



        public static void FillSizes(ComboBox cmb)
        {
            DataTable dgSize = new DataTable();
            dgSize.Columns.Add("SizeID");
            dgSize.Columns.Add("Size");
            dgSize.Rows.Add("0", "-----Select-----");
            try
            {
                DataTable dt = Retrieve("select SizeID, Size from SizeTable");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow size in dt.Rows)
                        {
                            dgSize.Rows.Add(size["SizeID"], size["Size"]);
                        }
                    }

                }
                cmb.DisplayMember = "Size";
                cmb.ValueMember = "SizeID";

                cmb.DataSource = dgSize;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                cmb.DataSource = dgSize;
            }
        }


        public static void FillBrands(ComboBox cmb)
        {
            DataTable dgBrands = new DataTable();
            dgBrands.Columns.Add("BrandID");
            dgBrands.Columns.Add("Brand");
            dgBrands.Rows.Add("0", "-----Select-----");
            try
            {
                DataTable dt = Retrieve("select BrandID, Brand from BrandsTable");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow Brands in dt.Rows)
                        {
                            dgBrands.Rows.Add(Brands["BrandID"], Brands["Brand"]);
                        }
                    }

                }
                cmb.DisplayMember = "Brand";
                cmb.ValueMember = "BrandID";

                cmb.DataSource = dgBrands;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                cmb.DataSource = dgBrands;
            }
        }


        public static void FillSupplier(ComboBox cmb)
        {
            DataTable dgSupplier = new DataTable();
            dgSupplier.Columns.Add("PersonID");
            dgSupplier.Columns.Add("Name");
            dgSupplier.Rows.Add("0", "-----Select-----");
            try
            {
                DataTable dt = Retrieve("select PersonID, Name from PersonsTable where Type = 'Supplier'");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow supplier in dt.Rows)
                        {
                            dgSupplier.Rows.Add(supplier["PersonID"], supplier["Name"]);
                        }
                    }

                }
                cmb.DisplayMember = "Name";
                cmb.ValueMember = "PersonID";
                cmb.DataSource = dgSupplier;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                cmb.DataSource = dgSupplier;
            }
        }

        public static void FillCustomer(ComboBox cmb)
        {
            DataTable dgCustomer = new DataTable();
            dgCustomer.Columns.Add("PersonID");
            dgCustomer.Columns.Add("Name");
            dgCustomer.Rows.Add("0", "-----Select-----");
            try
            {
                DataTable dt = Retrieve("select PersonID, Name from PersonsTable where Type = 'Customer'");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow customer in dt.Rows)
                        {
                            dgCustomer.Rows.Add(customer["PersonID"], customer["Name"]);
                        }
                    }

                }
                cmb.DisplayMember = "Name";
                cmb.ValueMember = "PersonID";
                cmb.DataSource = dgCustomer;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                cmb.DataSource = dgCustomer;
            }
        }


        public static void ShowRecentSales(DataGridView dgv, DataGridViewColumn SaleID, DataGridViewColumn InvoiceNo, DataGridViewColumn CustomerName, DataGridViewColumn SaleDate, DataGridViewColumn SaleTime, DataGridViewColumn GrandTotal, string OrderStatus)
        {
            if (OrderStatus != "Select")
            {
                SqlCommand cmd = new SqlCommand("select st.SaleID,st.InvoiceNo,pt.Name,st.SaleDate,st.SaleTime,st.GrandTotal from SalesTable st inner join PersonsTable pt on pt.PersonID = st.Customer_ID where st.OrderStatus = '" + OrderStatus + "'", MainClass.con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                SaleID.DataPropertyName = dt.Columns["SaleID"].ToString();
                InvoiceNo.DataPropertyName = dt.Columns["InvoiceNo"].ToString();
                CustomerName.DataPropertyName = dt.Columns["Name"].ToString();
                SaleDate.DataPropertyName = dt.Columns["SaleDate"].ToString();
                SaleTime.DataPropertyName = dt.Columns["SaleTime"].ToString();
                GrandTotal.DataPropertyName = dt.Columns["GrandTotal"].ToString();
                dgv.DataSource = dt;
            }
        }
        public static void FillProducts(ComboBox cmb)
        {
            DataTable dgProducts = new DataTable();
            dgProducts.Columns.Add("ProductID");
            dgProducts.Columns.Add("ProductName");
            dgProducts.Rows.Add("0", "-----Select-----");
            try
            {
                DataTable dt = Retrieve("select ProductID, ProductName from ProductsTable");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow products in dt.Rows)
                        {
                            dgProducts.Rows.Add(products["ProductID"], products["ProductName"]);
                        }
                    }

                }
                cmb.DisplayMember = "ProductName";
                cmb.ValueMember = "ProductID";
                cmb.DataSource = dgProducts;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                cmb.DataSource = dgProducts;
            }
        }

        public static void FillPackagedDiscount(ComboBox cmb)
        {
            DataTable dgpackage = new DataTable();
            dgpackage.Columns.Add("PackagedDiscountID");
            dgpackage.Columns.Add("PackagedDiscountName");
            dgpackage.Rows.Add("0", "-----Select-----");
            try
            {
                DataTable dt = Retrieve("select PackagedDiscountID, PackagedDiscountName from PackagedDiscount");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow package in dt.Rows)
                        {
                            dgpackage.Rows.Add(package["PackagedDiscountID"], package["PackagedDiscountName"]);
                        }
                    }

                }
                cmb.DisplayMember = "PackagedDiscountName";
                cmb.ValueMember = "PackagedDiscountID";
                cmb.DataSource = dgpackage;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                cmb.DataSource = dgpackage;
            }
        }


        public static void FillProductsPOS(ComboBox cmb)
        {
            DataTable dgProducts = new DataTable();
            dgProducts.Columns.Add("ProductID");
            dgProducts.Columns.Add("ProductName");
            dgProducts.Rows.Add("0", "-----Select-----");
            try
            {
                DataTable dt = Retrieve("select p.ProductID, p.ProductName from ProductsTable p ");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow products in dt.Rows)
                        {
                            dgProducts.Rows.Add(products["ProductID"], products["ProductName"]);
                        }
                    }

                }
                cmb.DisplayMember = "ProductName";
                cmb.ValueMember = "ProductID";
                cmb.DataSource = dgProducts;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                cmb.DataSource = dgProducts;
            }
        }

        public static void ShowProducts(DataGridView dgv, DataGridViewColumn ID, DataGridViewColumn Product, DataGridViewColumn Qty, string data = null)
        {
            try
            {
                SqlCommand cmd = null;
                MainClass.con.Open();

                if (data != "")
                {
                    cmd = new SqlCommand("select p.ProductID, p.ProductName, i.Qty from ProductsTable p inner join Inventory i on i.ProductID = p.ProductID   where p.ProductName like '%" + data + "%' and  i.Qty > 0", MainClass.con);
                }
                else
                {
                    cmd = new SqlCommand("select p.ProductID, p.ProductName, i.Qty from ProductsTable p inner join Inventory i on i.ProductID = p.ProductID where i.Qty > 0", MainClass.con);
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                ID.DataPropertyName = dt.Columns["ProductID"].ToString();
                Product.DataPropertyName = dt.Columns["ProductName"].ToString();
                Qty.DataPropertyName = dt.Columns["Qty"].ToString();
                dgv.DataSource = dt;
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }

        public static void InsertSale(int CustomerID,string InvoiceNo,string StoreName,string StoreAddress,string SaleDate,string SaleTime,string OrderStatus,byte[] Logo, float Tax= 0,float Paying=0,float Change=0, float Discount = 0, float GrandTotal = 0,string coupontype ="", int couponID = 0,string SaleRemarks="")
        {
            try
            {
                SqlCommand cmd = new SqlCommand("insert into SalesTable (InvoiceNo,Customer_ID,Discount,GrandTotal,StoreName,StoreAddress,SaleDate,SaleTime,OrderStatus,Change,Paying,Tax,Logo,CouponType,CouponID,SaleRemarks) values (@InvoiceNo,@Customer_ID,@Discount,@GrandTotal,@StoreName,@StoreAddress,@SaleDate,@SaleTime,@OrderStatus,@Change,@Paying,@Tax,@Logo,@CouponType,@CouponID,@SaleRemarks)", con);
                cmd.Parameters.AddWithValue("@InvoiceNo", InvoiceNo);
                cmd.Parameters.AddWithValue("@Customer_ID", CustomerID);
                cmd.Parameters.AddWithValue("@Discount", Discount);
                cmd.Parameters.AddWithValue("@GrandTotal", GrandTotal);
                cmd.Parameters.AddWithValue("@StoreName", StoreName);
                cmd.Parameters.AddWithValue("@StoreAddress", StoreAddress);
                cmd.Parameters.AddWithValue("@SaleDate", SaleDate);
                cmd.Parameters.AddWithValue("@SaleTime", SaleTime);
                cmd.Parameters.AddWithValue("@OrderStatus", OrderStatus);
                cmd.Parameters.AddWithValue("@Change", Change);
                cmd.Parameters.AddWithValue("@Paying", Paying);
                cmd.Parameters.AddWithValue("@Tax", Math.Round(Tax,2));
                cmd.Parameters.AddWithValue("@Logo", Logo);
                cmd.Parameters.AddWithValue("@CouponType", coupontype);
                cmd.Parameters.AddWithValue("@CouponID", couponID); 
                cmd.Parameters.AddWithValue("@SaleRemarks", SaleRemarks);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }

        public static void UpdateSale(int SaleID,int CustomerID,string SaleDate, string SaleTime, string OrderStatus, float Tax = 0, float Paying = 0, float Change = 0, float Discount = 0, float GrandTotal = 0,int couponID=0, string CouponType="")
        {
            try
            {
                SqlCommand cmd = new SqlCommand("update SalesTable set Customer_ID=@Customer_ID, Discount = @Discount,GrandTotal=@GrandTotal,SaleDate=@SaleDate,SaleTime=@SaleTime,OrderStatus=@OrderStatus,Change=@Change,Paying=@Paying,Tax=@Tax where SaleID = @SaleID", con);
                cmd.Parameters.AddWithValue("@SaleID", SaleID);
                cmd.Parameters.AddWithValue("@Customer_ID", CustomerID);
                cmd.Parameters.AddWithValue("@Discount", Discount);
                cmd.Parameters.AddWithValue("@GrandTotal", GrandTotal);
                cmd.Parameters.AddWithValue("@SaleDate", SaleDate);
                cmd.Parameters.AddWithValue("@SaleTime", SaleTime);
                cmd.Parameters.AddWithValue("@OrderStatus", OrderStatus);
                cmd.Parameters.AddWithValue("@Change", Math.Round(Change, 2));
                cmd.Parameters.AddWithValue("@Paying", Math.Round(Paying, 2));
                cmd.Parameters.AddWithValue("@Tax", Math.Round(Tax, 2));
                cmd.Parameters.AddWithValue("@CouponType", CouponType);
                cmd.Parameters.AddWithValue("@CouponID", couponID);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }

        public static int FindLastSaleID()
        {
            int SALEID=0;
            SqlCommand cmd = new SqlCommand("select MAX (SaleID) from SalesTable",con);
            SALEID = int.Parse(cmd.ExecuteScalar().ToString());
            return SALEID;
        }

        public static void InsertSalesInfo(int SaleID, int ProductID, float Quantity, string Unit, string Color, string Size, float CostPrice, float SalePrice, float TotalofProducts)
        {
            SqlCommand cmd = new SqlCommand("insert into SalesInfo (Sales_ID,ProductID,Quantity,Unit,Color,Size,CostPrice,SalePrice,TotalOfProduct) values (@Sales_ID,@ProductID,@Quantity,@Unit,@Color,@Size,@CostPrice,@SalePrice,@TotalOfProduct)", con);
            cmd.Parameters.AddWithValue("@Sales_ID", SaleID);
            cmd.Parameters.AddWithValue("@ProductID", ProductID);
            cmd.Parameters.AddWithValue("@Quantity", Quantity);
            cmd.Parameters.AddWithValue("@Unit", Unit);
            cmd.Parameters.AddWithValue("@Color", Color);
            cmd.Parameters.AddWithValue("@Size", Size);
            cmd.Parameters.AddWithValue("@CostPrice", CostPrice);
            cmd.Parameters.AddWithValue("@SalePrice", SalePrice);
            cmd.Parameters.AddWithValue("@TotalOfProduct", TotalofProducts);
            cmd.ExecuteNonQuery();
        }

        public static void UpdateInventory(Int32 ProductID, float Qty, int WarehouseID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("update Inventory set Qty = @Qty where ProductID = @ProductID and WarehouseID = @WarehouseID ", MainClass.con);
                cmd.Parameters.AddWithValue("@ProductID", ProductID);
                cmd.Parameters.AddWithValue("@Qty", Qty);
                cmd.Parameters.AddWithValue("@WarehouseID", WarehouseID);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }

        public static void UpdateWarehouse(Int32 ProductID, int WarehouseID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("update Inventory set  WarehouseID = @WarehouseID where ProductID = @ProductID ", MainClass.con);
                cmd.Parameters.AddWithValue("@ProductID", ProductID);
                cmd.Parameters.AddWithValue("@WarehouseID", WarehouseID);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }

        public static void InsertIntoInventory(Int32 ProductID, float Qty, int WarehouseID,string Barcode, int Unit,int SafetyStock, float rate)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("insert into Inventory (ProductID,Unit,Qty,Barcode,Rate,SafetyStock,WarehouseID) values (@ProductID,@Unit,@Qty,@Barcode,@Rate,@SafetyStock,@WarehouseID) ", MainClass.con);
                cmd.Parameters.AddWithValue("@ProductID", ProductID);
                cmd.Parameters.AddWithValue("@Qty", Qty);
                cmd.Parameters.AddWithValue("@WarehouseID", WarehouseID);
                cmd.Parameters.AddWithValue("@Barcode", Barcode);
                cmd.Parameters.AddWithValue("@Unit", Unit);
                cmd.Parameters.AddWithValue("@Rate", rate);
                cmd.Parameters.AddWithValue("@SafetyStock", SafetyStock);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }


        //public static void ShowSaleReciept(ReportDocument rd, CrystalReportViewer crv, string proc, string param1 = "", object val1 = null)
        //{
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand(proc, MainClass.con);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        if (param1 != "")
        //        {
        //            cmd.Parameters.AddWithValue(param1, val1);
        //        }
        //        SqlDataAdapter da = new SqlDataAdapter(cmd);
        //        DataTable dt = new DataTable();
        //        da.Fill(dt);
        //        rd.Load(Application.StartupPath + "\\Reports\\SaleReciept.rpt");
        //        rd.SetDataSource(dt);
        //        crv.ReportSource = rd;
        //        crv.RefreshReport();

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}


        public static void ShowSaleRecieptSavedCustomer(ReportDocument rd, CrystalReportViewer crv, string proc, string param1 = "", object val1 = null)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(proc, MainClass.con);
                cmd.CommandType = CommandType.StoredProcedure;
                if (param1 != "")
                {
                    cmd.Parameters.AddWithValue(param1, val1);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                object lang = LanguageCheck();
                if (lang.ToString() == "English")
                {
                    rd.Load(Application.StartupPath + "\\Reports\\SaleReciept_SavedCustomer.rpt");
                }
                else
                {
                    rd.Load(Application.StartupPath + "\\Reports\\SaleReciept_SavedCustomerChinese.rpt");
                }
                rd.SetDataSource(dt);
                crv.ReportSource = rd;
                crv.RefreshReport();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public static void ShowPurchaseReceipt(ReportDocument rd, CrystalReportViewer crv, string proc, string param1 = "", object val1 = null)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(proc, MainClass.con);
                cmd.CommandType = CommandType.StoredProcedure;
                if (param1 != "")
                {
                    cmd.Parameters.AddWithValue(param1, val1);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                object lang = LanguageCheck();
                if (lang.ToString() == "English")
                {
                    rd.Load(Application.StartupPath + "\\Reports\\PurchaseReceipt.rpt");
                }
                else
                {
                    rd.Load(Application.StartupPath + "\\Reports\\PurchaseReceiptChinese.rpt");
                }
                rd.SetDataSource(dt);
                crv.ReportSource = rd;
                crv.RefreshReport();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public static void PrintCoupon(ReportDocument rd, CrystalReportViewer crv, string proc, string param1 = "", object val1 = null)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(proc, MainClass.con);
                cmd.CommandType = CommandType.StoredProcedure;
                if (param1 != "")
                {
                    cmd.Parameters.AddWithValue(param1, val1);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                rd.Load(Application.StartupPath + "\\Reports\\.rpt");
                rd.SetDataSource(dt);
                crv.ReportSource = rd;
                crv.RefreshReport();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
