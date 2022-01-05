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
        private void Dashboard_Load(object sender, EventArgs e)
        {
            LoadChart();
        }
    }
}
