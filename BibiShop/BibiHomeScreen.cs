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

namespace BibiShop
{
    public partial class BibiHomeScreen : Form
    {
        public BibiHomeScreen()
        {
            InitializeComponent();
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
