using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tulpep.NotificationWindow;

namespace BibiShop
{
    public partial class BibiHomeScreen : Form
    {
        public BibiHomeScreen()
        {
            InitializeComponent();
        }
        int shopwarehouse = 0;

        private void FindShopDefault()
        {
            MainClass.con.Open();
            SqlCommand cmd = new SqlCommand("select ShopDefaultWarehouse from StoreTable", MainClass.con);
            shopwarehouse = int.Parse(cmd.ExecuteScalar().ToString());
            MainClass.con.Close();
        }



        public Image ConvertByteArraytoImage(byte[] data)
        {
            using (MemoryStream ms = new MemoryStream(data))
            {
                return Image.FromStream(ms);
            }
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginScreen ls = new LoginScreen();
            ls.Show();
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
      
        private void BibiHomeScreen_Load(object sender, EventArgs e)
        {
            lblRole.Text = LoginScreen.Role.ToString();
            btnDashboard_Click(sender, e);
            LoadLogo();
            NotifyCriticalItems();
        }

        public void NotifyCriticalItems()
        {
            string critical = "";
            MainClass.con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from ProductsTable p full outer join Inventory i on p.ProductID = i.ProductID where i.Qty < 0 or i.Qty is null or i.Qty < p.SafetyStock   and i.WareHouseID = '"+shopwarehouse+"'", MainClass.con);

            int i = 0;
            string count = cmd.ExecuteScalar().ToString();
            MainClass.con.Close();

            MainClass.con.Open();
            cmd = new SqlCommand("select p.ProductName from ProductsTable p full outer join Inventory i on p.ProductID = i.ProductID where i.Qty < 0 or i.Qty is null or i.Qty < p.SafetyStock   and i.WareHouseID = '" + shopwarehouse + "'", MainClass.con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                i++;
                critical += i + ".  " + dr["ProductName"].ToString() + Environment.NewLine;
            }
            dr.Close();
            MainClass.con.Close();
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.low_battery__1_;
            popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            //popup.ShowGrip = false;
            popup.HeaderHeight = 20;
            popup.TitlePadding = new Padding(3);
            popup.ContentPadding = new Padding(3);
            popup.ImagePadding = new Padding(8);
            popup.AnimationDuration = 1000;
            popup.AnimationInterval = 1;
            popup.HeaderColor = Color.FromArgb(252, 164, 2);
            popup.Scroll = true;
            popup.ShowCloseButton = false;
            popup.TitleText = "CRITICAL ITEM(S) : " + i.ToString();
            popup.ContentText = critical;
            popup.Popup();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            Dashboard b = new Dashboard();
            b.TopLevel = false;
            mainPanel.Controls.Add(b);
            b.BringToFront();
            b.Show();
        }

        private void ManageProductsButton_Click(object sender, EventArgs e)
        {
            Products b = new Products();
            b.TopLevel = false;
            mainPanel.Controls.Add(b);
            b.BringToFront();
            b.Show();
        }

        private void StocksButton_Click(object sender, EventArgs e)
        {
            PurchaseInvoice b = new PurchaseInvoice();
            b.TopLevel = false;
            mainPanel.Controls.Add(b);
            b.BringToFront();
            b.Show();
        }

        private void btnUnits_Click_1(object sender, EventArgs e)
        {
            Units b = new Units();
            b.TopLevel = false;
            mainPanel.Controls.Add(b);
            b.BringToFront();
            b.Show();
        }

        private void ManageCategoryButton_Click(object sender, EventArgs e)
        {
            Categories b = new Categories();
            b.TopLevel = false;
            mainPanel.Controls.Add(b);
            b.BringToFront();
            b.Show();
        }

        private void btnPersons_Click(object sender, EventArgs e)
        {
            Persons b = new Persons();
            b.TopLevel = false;
            mainPanel.Controls.Add(b);
            b.BringToFront();
            b.Show();
        }

        private void ManageBrandButton_Click(object sender, EventArgs e)
        {
            Brands b = new Brands();
            b.TopLevel = false;
            mainPanel.Controls.Add(b);
            b.BringToFront();
            b.Show();
        }

        private void RecordsButton_Click(object sender, EventArgs e)
        {
            Reports b = new Reports();
            b.TopLevel = false;
            mainPanel.Controls.Add(b);
            b.BringToFront();
            b.Show();
        }

        private void btnPOS_Click_1(object sender, EventArgs e)
        {
            BibiPOS b = new BibiPOS();
            
            b.Show();
        }

        private void btnSettings_Click_1(object sender, EventArgs e)
        {
            Settings b = new Settings();
            b.TopLevel = false;
            mainPanel.Controls.Add(b);
            b.BringToFront();
            b.Show();
        }

        private void btnLedgers_Click_1(object sender, EventArgs e)
        {
            Ledgers b = new Ledgers();
            b.TopLevel = false;
            mainPanel.Controls.Add(b);
            b.BringToFront();
            b.Show();
        }

        private void btnInventory_Click_1(object sender, EventArgs e)
        {
            Inventory b = new Inventory();
            b.TopLevel = false;
            mainPanel.Controls.Add(b);
            b.BringToFront();
            b.Show();
        }

        private void Logoutbtn_Click(object sender, EventArgs e)
        {
            this.Dispose();
            LoginScreen frm = new LoginScreen();
            frm.Show();
        }
    }
}
