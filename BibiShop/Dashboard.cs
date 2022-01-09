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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }
        private void LoadChart()
        {
            chart1.Series[0].Points.Clear();
            chart1.ChartAreas["ChartArea1"].AxisX.Interval = 1;
            MainClass.con.Open();
            SqlCommand cmd = new SqlCommand("SELECT TOP 10 p.ProductName, Sum(Quantity) as QtySold FROM SalesInfo si inner join ProductsTable p on p.ProductID = si.ProductID GROUP BY ProductName ORDER BY SUM(Quantity) DESC", MainClass.con);
            SqlDataReader read = cmd.ExecuteReader();
            chart1.Series.Add("Pieces Sold");
            chart1.Series.RemoveAt(0);
            while (read.Read())
            {

                this.chart1.Series["Pieces Sold"].Points.AddXY(read["ProductName"], read["QtySold"]);

            }
            read.Close();
            MainClass.con.Close();
        }
        private void LoadCriticalItemCount()
        {
            MainClass.con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from ProductsTable p full outer join Inventory i on p.ProductID = i.ProductID where i.Qty < 0 or i.Qty is null or i.Qty < p.SafetyStock ", MainClass.con);

            int i = 0;
            string count = cmd.ExecuteScalar().ToString();
            MainClass.con.Close();
            lblLowStock.Text = count;
        }

        private void LoadSales()
        {
            string sdate = DateTime.Now.ToShortDateString();
            try
            {
                MainClass.con.Open();
                SqlCommand cmd = new SqlCommand("select sum(GrandTotal) from SalesTable st where st.SaleDate between '" + sdate + "' and  '" + sdate + "'", MainClass.con);
                label2.Text = cmd.ExecuteScalar().ToString();
                MainClass.con.Close();

            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            LoadChart();
            LoadCriticalItemCount();
            LoadSales();
        }

        private void guna2Panel1_Click(object sender, EventArgs e)
        {
            BibiPOS b = new BibiPOS();
            b.Show();
        }

        private void guna2Panel3_Click(object sender, EventArgs e)
        {
            PurchaseInvoice p = new PurchaseInvoice();
            p.Show();
        }

        private void guna2Panel11_Click(object sender, EventArgs e)
        {
            Inventory p = new Inventory();
            p.Show();
        }

        private void guna2ImageButton4_Click(object sender, EventArgs e)
        {
            BibiPOS b = new BibiPOS();
            b.Show();
        }

        private void guna2ImageButton5_Click(object sender, EventArgs e)
        {
            PurchaseInvoice p = new PurchaseInvoice();
            p.Show();
        }

        private void guna2ImageButton6_Click(object sender, EventArgs e)
        {
            Inventory p = new Inventory();
            p.Show();
        }
    }
}
