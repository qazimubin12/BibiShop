
namespace BibiShop
{
    partial class BibiPOS
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblCashier = new System.Windows.Forms.Label();
            this.btnLogout = new Guna.UI2.WinForms.Guna2CircleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.cboCustomer = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboProduct = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.DGVSaleCart = new Guna.UI2.WinForms.Guna2DataGridView();
            this.ProductIDGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CostPriceGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SalePriceGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuantityGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalOfProductGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActionAddGV = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ActionRemoveGV = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.fpProducts = new System.Windows.Forms.FlowLayoutPanel();
            this.fpCategories = new System.Windows.Forms.FlowLayoutPanel();
            this.txtSearhBarcode = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button3 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button4 = new Guna.UI2.WinForms.Guna2Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVSaleCart)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.panel1.Controls.Add(this.lblCashier);
            this.panel1.Controls.Add(this.btnLogout);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1200, 37);
            this.panel1.TabIndex = 0;
            // 
            // lblCashier
            // 
            this.lblCashier.AutoSize = true;
            this.lblCashier.BackColor = System.Drawing.Color.Transparent;
            this.lblCashier.Font = new System.Drawing.Font("OCR A Extended", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCashier.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(212)))), ((int)(((byte)(80)))));
            this.lblCashier.Location = new System.Drawing.Point(836, 9);
            this.lblCashier.Name = "lblCashier";
            this.lblCashier.Size = new System.Drawing.Size(68, 17);
            this.lblCashier.TabIndex = 2;
            this.lblCashier.Text = "label2";
            // 
            // btnLogout
            // 
            this.btnLogout.CheckedState.Parent = this.btnLogout;
            this.btnLogout.CustomImages.Parent = this.btnLogout;
            this.btnLogout.FillColor = System.Drawing.Color.Transparent;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.HoverState.FillColor = System.Drawing.Color.SteelBlue;
            this.btnLogout.HoverState.Parent = this.btnLogout;
            this.btnLogout.Image = global::BibiShop.Properties.Resources.log_out;
            this.btnLogout.ImageSize = new System.Drawing.Size(40, 40);
            this.btnLogout.Location = new System.Drawing.Point(1169, 4);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnLogout.ShadowDecoration.Parent = this.btnLogout;
            this.btnLogout.Size = new System.Drawing.Size(31, 31);
            this.btnLogout.TabIndex = 1;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Old English Text MT", 18F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "CSS POS";
            // 
            // cboCustomer
            // 
            this.cboCustomer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboCustomer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCustomer.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboCustomer.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.cboCustomer.FormattingEnabled = true;
            this.cboCustomer.Location = new System.Drawing.Point(16, 69);
            this.cboCustomer.Name = "cboCustomer";
            this.cboCustomer.Size = new System.Drawing.Size(136, 25);
            this.cboCustomer.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Select Customer";
            // 
            // cboProduct
            // 
            this.cboProduct.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboProduct.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboProduct.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboProduct.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.cboProduct.FormattingEnabled = true;
            this.cboProduct.Location = new System.Drawing.Point(158, 69);
            this.cboProduct.Name = "cboProduct";
            this.cboProduct.Size = new System.Drawing.Size(136, 25);
            this.cboProduct.TabIndex = 5;
            this.cboProduct.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboProduct_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(155, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Select Product";
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.SteelBlue;
            this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnAdd.FlatAppearance.BorderSize = 2;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(300, 62);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(81, 32);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "&ADD";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Visible = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // DGVSaleCart
            // 
            this.DGVSaleCart.AllowUserToAddRows = false;
            this.DGVSaleCart.AllowUserToDeleteRows = false;
            dataGridViewCellStyle28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(229)))), ((int)(((byte)(251)))));
            this.DGVSaleCart.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle28;
            this.DGVSaleCart.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVSaleCart.BackgroundColor = System.Drawing.Color.White;
            this.DGVSaleCart.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DGVSaleCart.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DGVSaleCart.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle29.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(169)))), ((int)(((byte)(243)))));
            dataGridViewCellStyle29.Font = new System.Drawing.Font("Century Gothic", 10F);
            dataGridViewCellStyle29.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle29.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle29.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle29.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVSaleCart.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle29;
            this.DGVSaleCart.ColumnHeadersHeight = 30;
            this.DGVSaleCart.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductIDGV,
            this.ProductGV,
            this.UnitGV,
            this.CostPriceGV,
            this.SalePriceGV,
            this.QuantityGV,
            this.TotalOfProductGV,
            this.ActionAddGV,
            this.ActionRemoveGV});
            dataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle30.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(237)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle30.Font = new System.Drawing.Font("Century Gothic", 10F);
            dataGridViewCellStyle30.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle30.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(197)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle30.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle30.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVSaleCart.DefaultCellStyle = dataGridViewCellStyle30;
            this.DGVSaleCart.EnableHeadersVisualStyles = false;
            this.DGVSaleCart.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.DGVSaleCart.Location = new System.Drawing.Point(12, 161);
            this.DGVSaleCart.Name = "DGVSaleCart";
            this.DGVSaleCart.ReadOnly = true;
            this.DGVSaleCart.RowHeadersVisible = false;
            this.DGVSaleCart.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVSaleCart.Size = new System.Drawing.Size(561, 304);
            this.DGVSaleCart.TabIndex = 11;
            this.DGVSaleCart.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.LightBlue;
            this.DGVSaleCart.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(229)))), ((int)(((byte)(251)))));
            this.DGVSaleCart.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.DGVSaleCart.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.DGVSaleCart.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.DGVSaleCart.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.DGVSaleCart.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.DGVSaleCart.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(230)))), ((int)(((byte)(251)))));
            this.DGVSaleCart.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(169)))), ((int)(((byte)(243)))));
            this.DGVSaleCart.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DGVSaleCart.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.DGVSaleCart.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.DGVSaleCart.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.DGVSaleCart.ThemeStyle.HeaderStyle.Height = 30;
            this.DGVSaleCart.ThemeStyle.ReadOnly = true;
            this.DGVSaleCart.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(237)))), ((int)(((byte)(252)))));
            this.DGVSaleCart.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DGVSaleCart.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.DGVSaleCart.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.DGVSaleCart.ThemeStyle.RowsStyle.Height = 22;
            this.DGVSaleCart.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(197)))), ((int)(((byte)(247)))));
            this.DGVSaleCart.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.DGVSaleCart.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVSaleCart_CellClick);
            // 
            // ProductIDGV
            // 
            this.ProductIDGV.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ProductIDGV.HeaderText = "ProductID";
            this.ProductIDGV.Name = "ProductIDGV";
            this.ProductIDGV.ReadOnly = true;
            this.ProductIDGV.Visible = false;
            // 
            // ProductGV
            // 
            this.ProductGV.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ProductGV.FillWeight = 146.2518F;
            this.ProductGV.HeaderText = "Product";
            this.ProductGV.Name = "ProductGV";
            this.ProductGV.ReadOnly = true;
            // 
            // UnitGV
            // 
            this.UnitGV.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.UnitGV.FillWeight = 71.66336F;
            this.UnitGV.HeaderText = "Unit";
            this.UnitGV.Name = "UnitGV";
            this.UnitGV.ReadOnly = true;
            // 
            // CostPriceGV
            // 
            this.CostPriceGV.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CostPriceGV.HeaderText = "CostPrice";
            this.CostPriceGV.Name = "CostPriceGV";
            this.CostPriceGV.ReadOnly = true;
            this.CostPriceGV.Visible = false;
            // 
            // SalePriceGV
            // 
            this.SalePriceGV.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SalePriceGV.FillWeight = 71.66336F;
            this.SalePriceGV.HeaderText = "Price";
            this.SalePriceGV.Name = "SalePriceGV";
            this.SalePriceGV.ReadOnly = true;
            // 
            // QuantityGV
            // 
            this.QuantityGV.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.QuantityGV.FillWeight = 71.66336F;
            this.QuantityGV.HeaderText = "Qty";
            this.QuantityGV.Name = "QuantityGV";
            this.QuantityGV.ReadOnly = true;
            // 
            // TotalOfProductGV
            // 
            this.TotalOfProductGV.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TotalOfProductGV.FillWeight = 195.4315F;
            this.TotalOfProductGV.HeaderText = "Total";
            this.TotalOfProductGV.Name = "TotalOfProductGV";
            this.TotalOfProductGV.ReadOnly = true;
            // 
            // ActionAddGV
            // 
            this.ActionAddGV.FillWeight = 71.66336F;
            this.ActionAddGV.HeaderText = "";
            this.ActionAddGV.Name = "ActionAddGV";
            this.ActionAddGV.ReadOnly = true;
            this.ActionAddGV.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ActionAddGV.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ActionAddGV.Text = "+";
            this.ActionAddGV.UseColumnTextForButtonValue = true;
            // 
            // ActionRemoveGV
            // 
            this.ActionRemoveGV.FillWeight = 71.66336F;
            this.ActionRemoveGV.HeaderText = "";
            this.ActionRemoveGV.Name = "ActionRemoveGV";
            this.ActionRemoveGV.ReadOnly = true;
            this.ActionRemoveGV.Text = "-";
            this.ActionRemoveGV.UseColumnTextForButtonValue = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.guna2Button1);
            this.panel2.Controls.Add(this.guna2Button3);
            this.panel2.Controls.Add(this.guna2Button2);
            this.panel2.Controls.Add(this.fpProducts);
            this.panel2.Controls.Add(this.fpCategories);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(600, 37);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(600, 751);
            this.panel2.TabIndex = 13;
            // 
            // fpProducts
            // 
            this.fpProducts.AutoScroll = true;
            this.fpProducts.Dock = System.Windows.Forms.DockStyle.Top;
            this.fpProducts.Location = new System.Drawing.Point(0, 96);
            this.fpProducts.Name = "fpProducts";
            this.fpProducts.Size = new System.Drawing.Size(600, 185);
            this.fpProducts.TabIndex = 1;
            // 
            // fpCategories
            // 
            this.fpCategories.AutoScroll = true;
            this.fpCategories.Dock = System.Windows.Forms.DockStyle.Top;
            this.fpCategories.Location = new System.Drawing.Point(0, 0);
            this.fpCategories.Name = "fpCategories";
            this.fpCategories.Size = new System.Drawing.Size(600, 96);
            this.fpCategories.TabIndex = 0;
            this.fpCategories.WrapContents = false;
            // 
            // txtSearhBarcode
            // 
            this.txtSearhBarcode.AutoRoundedCorners = true;
            this.txtSearhBarcode.BorderRadius = 14;
            this.txtSearhBarcode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearhBarcode.DefaultText = "";
            this.txtSearhBarcode.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearhBarcode.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearhBarcode.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearhBarcode.DisabledState.Parent = this.txtSearhBarcode;
            this.txtSearhBarcode.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearhBarcode.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearhBarcode.FocusedState.Parent = this.txtSearhBarcode;
            this.txtSearhBarcode.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearhBarcode.HoverState.Parent = this.txtSearhBarcode;
            this.txtSearhBarcode.IconLeft = global::BibiShop.Properties.Resources.icons8_search_50px;
            this.txtSearhBarcode.IconLeftOffset = new System.Drawing.Point(5, 0);
            this.txtSearhBarcode.Location = new System.Drawing.Point(16, 103);
            this.txtSearhBarcode.Margin = new System.Windows.Forms.Padding(49, 46, 49, 46);
            this.txtSearhBarcode.Name = "txtSearhBarcode";
            this.txtSearhBarcode.PasswordChar = '\0';
            this.txtSearhBarcode.PlaceholderText = "Enter Barcode";
            this.txtSearhBarcode.SelectedText = "";
            this.txtSearhBarcode.ShadowDecoration.Parent = this.txtSearhBarcode;
            this.txtSearhBarcode.Size = new System.Drawing.Size(365, 30);
            this.txtSearhBarcode.TabIndex = 12;
            this.txtSearhBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearhBarcode_KeyDown);
            // 
            // guna2Button1
            // 
            this.guna2Button1.AutoRoundedCorners = true;
            this.guna2Button1.BackColor = System.Drawing.Color.White;
            this.guna2Button1.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.guna2Button1.BorderRadius = 41;
            this.guna2Button1.BorderThickness = 2;
            this.guna2Button1.CheckedState.Parent = this.guna2Button1;
            this.guna2Button1.CustomImages.Parent = this.guna2Button1;
            this.guna2Button1.FillColor = System.Drawing.Color.SteelBlue;
            this.guna2Button1.Font = new System.Drawing.Font("Berlin Sans FB", 10F);
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.HoverState.Parent = this.guna2Button1;
            this.guna2Button1.Location = new System.Drawing.Point(20, 287);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.ShadowDecoration.Parent = this.guna2Button1;
            this.guna2Button1.Size = new System.Drawing.Size(85, 85);
            this.guna2Button1.TabIndex = 6;
            this.guna2Button1.Text = "SHOW PURCHASES";
            // 
            // guna2Button2
            // 
            this.guna2Button2.AutoRoundedCorners = true;
            this.guna2Button2.BackColor = System.Drawing.Color.White;
            this.guna2Button2.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.guna2Button2.BorderRadius = 41;
            this.guna2Button2.BorderThickness = 2;
            this.guna2Button2.CheckedState.Parent = this.guna2Button2;
            this.guna2Button2.CustomImages.Parent = this.guna2Button2;
            this.guna2Button2.FillColor = System.Drawing.Color.SteelBlue;
            this.guna2Button2.Font = new System.Drawing.Font("Berlin Sans FB", 10F);
            this.guna2Button2.ForeColor = System.Drawing.Color.White;
            this.guna2Button2.HoverState.Parent = this.guna2Button2;
            this.guna2Button2.Location = new System.Drawing.Point(111, 287);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.ShadowDecoration.Parent = this.guna2Button2;
            this.guna2Button2.Size = new System.Drawing.Size(85, 85);
            this.guna2Button2.TabIndex = 7;
            this.guna2Button2.Text = "RECENT SALES";
            // 
            // guna2Button3
            // 
            this.guna2Button3.AutoRoundedCorners = true;
            this.guna2Button3.BackColor = System.Drawing.Color.White;
            this.guna2Button3.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.guna2Button3.BorderRadius = 41;
            this.guna2Button3.BorderThickness = 2;
            this.guna2Button3.CheckedState.Parent = this.guna2Button3;
            this.guna2Button3.CustomImages.Parent = this.guna2Button3;
            this.guna2Button3.FillColor = System.Drawing.Color.SteelBlue;
            this.guna2Button3.Font = new System.Drawing.Font("Berlin Sans FB", 10F);
            this.guna2Button3.ForeColor = System.Drawing.Color.White;
            this.guna2Button3.HoverState.Parent = this.guna2Button3;
            this.guna2Button3.Location = new System.Drawing.Point(202, 287);
            this.guna2Button3.Name = "guna2Button3";
            this.guna2Button3.ShadowDecoration.Parent = this.guna2Button3;
            this.guna2Button3.Size = new System.Drawing.Size(85, 85);
            this.guna2Button3.TabIndex = 7;
            this.guna2Button3.Text = "ADD CUSTOMERS";
            this.guna2Button3.Click += new System.EventHandler(this.guna2Button3_Click);
            // 
            // guna2Button4
            // 
            this.guna2Button4.AutoRoundedCorners = true;
            this.guna2Button4.BackColor = System.Drawing.Color.White;
            this.guna2Button4.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.guna2Button4.BorderRadius = 15;
            this.guna2Button4.BorderThickness = 2;
            this.guna2Button4.CheckedState.Parent = this.guna2Button4;
            this.guna2Button4.CustomImages.Parent = this.guna2Button4;
            this.guna2Button4.FillColor = System.Drawing.Color.SteelBlue;
            this.guna2Button4.Font = new System.Drawing.Font("Berlin Sans FB", 10F);
            this.guna2Button4.ForeColor = System.Drawing.Color.White;
            this.guna2Button4.HoverState.Parent = this.guna2Button4;
            this.guna2Button4.Location = new System.Drawing.Point(300, 62);
            this.guna2Button4.Name = "guna2Button4";
            this.guna2Button4.ShadowDecoration.Parent = this.guna2Button4;
            this.guna2Button4.Size = new System.Drawing.Size(33, 34);
            this.guna2Button4.TabIndex = 7;
            this.guna2Button4.Text = "R";
            this.guna2Button4.Click += new System.EventHandler(this.guna2Button4_Click);
            // 
            // BibiPOS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1200, 788);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.guna2Button4);
            this.Controls.Add(this.txtSearhBarcode);
            this.Controls.Add(this.DGVSaleCart);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboProduct);
            this.Controls.Add(this.cboCustomer);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BibiPOS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BibiPOS";
            this.Load += new System.EventHandler(this.BibiPOS_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVSaleCart)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2CircleButton btnLogout;
        public System.Windows.Forms.Label lblCashier;
        public System.Windows.Forms.ComboBox cboCustomer;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox cboProduct;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAdd;
        private Guna.UI2.WinForms.Guna2DataGridView DGVSaleCart;
        public Guna.UI2.WinForms.Guna2TextBox txtSearhBarcode;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductIDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn CostPriceGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn SalePriceGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuantityGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalOfProductGV;
        private System.Windows.Forms.DataGridViewButtonColumn ActionAddGV;
        private System.Windows.Forms.DataGridViewButtonColumn ActionRemoveGV;
        private System.Windows.Forms.FlowLayoutPanel fpCategories;
        private System.Windows.Forms.FlowLayoutPanel fpProducts;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private Guna.UI2.WinForms.Guna2Button guna2Button3;
        private Guna.UI2.WinForms.Guna2Button guna2Button4;
    }
}