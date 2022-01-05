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
    public partial class LoginScreen : Form
    {

        SqlDataReader dr;
        public static object User_NAME = "";
        public static object Role = "";
        public LoginScreen()
        {
            InitializeComponent();
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2ControlBox2_Click(object sender, EventArgs e)
        {
            MinimizeBox = true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                bool found = false;
                object count = 0;
                MainClass.con.Open();
                SqlCommand cmd = new SqlCommand("select * from UsersTable where Username = @Username and Password = @Password ", MainClass.con);
                cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    found = true;
                    User_NAME = dr["Name"].ToString();
                    Role = dr["Role"].ToString();
                }
                else
                {
                    found = false;
                    MessageBox.Show("Invalid Details", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Clear();
                    txtUsername.Focus();
                }
                dr.Close();
                MainClass.con.Close();
                if (found == true)
                {
                    if (Role.ToString() == "Admin")
                    {

                        try
                        {
                            MainClass.con.Open();
                            SqlCommand cmd1 = new SqlCommand("select * from ModeSwitching", MainClass.con);
                            count = cmd1.ExecuteScalar();
                            MainClass.con.Close();
                        }
                        catch (Exception ex)
                        {
                            MainClass.con.Close();
                            MessageBox.Show(ex.Message);
                        }

                        if (count == null)
                        {
                            try
                            {
                                MainClass.con.Open();
                                SqlCommand cmd1 = new SqlCommand("insert into ModeSwitching (InventoryMode)  values ('" + 1 + "')", MainClass.con);
                                cmd1.ExecuteNonQuery();
                                MainClass.con.Close();

                            }
                            catch (Exception ex)
                            {
                                MainClass.con.Close();
                                MessageBox.Show(ex.Message);
                            }
                        }

                        MessageBox.Show("Welcome " + User_NAME);
                        this.Hide();
                        BibiHomeScreen das = new BibiHomeScreen();
                        das.Show();
                     //   this.Dispose(); BibiHomeScreen ds = new BibiHomeScreen();  
                    }
                    else
                    {
                        MessageBox.Show("Welcome " + User_NAME);
                        this.Hide();
                        BibiPOS das = new BibiPOS();
                        das.Show();
                     //   this.Dispose(); BibiHomeScreen ds = new BibiHomeScreen();  
                    }
                }
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void Clear()
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
        }

        private void toggle_CheckedChanged(object sender, EventArgs e)
        {
            if (toggle.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }
        public Image ConvertByteArraytoImage(byte[] data)
        {
            using (MemoryStream ms = new MemoryStream(data))
            {
                return Image.FromStream(ms);
            }
        }
        private void LoginScreen_Load(object sender, EventArgs e)
        {
            MainClass.con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("select Logo from StoreTable", MainClass.con);
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    LogoPic.Image = ConvertByteArraytoImage((byte[])dr["Logo"]);
                }
                else
                {
                    LogoPic.Image = null;
                }
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
            MainClass.con.Close();
        }
    }
}
