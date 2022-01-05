﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BibiShop
{
    public partial class QuantityForm : Form
    {
        POS p;
        BibiPOS bp;
        public QuantityForm()
        {
            InitializeComponent();
        }

        public QuantityForm(POS ps)
        {
            InitializeComponent();
            p = ps;
        }

        public QuantityForm(BibiPOS ps)
        {
            InitializeComponent();
            bp = ps;
        }


        private void QuantityForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            
        }

        public static class ControlID
        {
            public static string TextData { get; set; }
        }

        private void txtQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtQty.Text != "")
                {
                    ControlID.TextData = txtQty.Text;
                    if (e.KeyCode == Keys.Enter)
                    {
                        this.Dispose();  
                    }
                }
                else
                {
                    MessageBox.Show("Please Enter Quantity");
                    return;
                }
            }
        }

        private void QuantityForm_Load(object sender, EventArgs e)
        {

        }
    }
}
