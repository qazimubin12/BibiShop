
namespace BibiShop
{
    partial class CouponsSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CouponsSettings));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.DGVCoupon = new Guna.UI2.WinForms.Guna2DataGridView();
            this.CouponSettingsIDGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CouponNameGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MinimumBillGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductNameGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dayspanel = new System.Windows.Forms.Panel();
            this.TuesdayCB = new Guna.UI2.WinForms.Guna2CheckBox();
            this.SaturdayCB = new Guna.UI2.WinForms.Guna2CheckBox();
            this.MondayCB = new Guna.UI2.WinForms.Guna2CheckBox();
            this.ThursdayCB = new Guna.UI2.WinForms.Guna2CheckBox();
            this.WednesdayCB = new Guna.UI2.WinForms.Guna2CheckBox();
            this.FridayCB = new Guna.UI2.WinForms.Guna2CheckBox();
            this.SundayCB = new Guna.UI2.WinForms.Guna2CheckBox();
            this.txtMinimumBill = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboCoupon = new System.Windows.Forms.ComboBox();
            this.cboProducts = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVCoupon)).BeginInit();
            this.dayspanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Name = "panel1";
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.Image = global::BibiShop.Properties.Resources.cancel__2_;
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtSearch
            // 
            resources.ApplyResources(this.txtSearch, "txtSearch");
            this.txtSearch.AutoRoundedCorners = true;
            this.txtSearch.BorderRadius = 12;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DefaultText = "";
            this.txtSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.DisabledState.Parent = this.txtSearch;
            this.txtSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearch.FocusedState.Parent = this.txtSearch;
            this.txtSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearch.HoverState.Parent = this.txtSearch;
            this.txtSearch.IconLeft = global::BibiShop.Properties.Resources.icons8_search_50px;
            this.txtSearch.IconLeftOffset = new System.Drawing.Point(5, 0);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PasswordChar = '\0';
            this.txtSearch.PlaceholderText = "搜索優惠券設置";
            this.txtSearch.SelectedText = "";
            this.txtSearch.ShadowDecoration.Parent = this.txtSearch;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Name = "label1";
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Controls.Add(this.DGVCoupon);
            this.panel2.Controls.Add(this.dayspanel);
            this.panel2.Controls.Add(this.txtMinimumBill);
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.cboCoupon);
            this.panel2.Controls.Add(this.cboProducts);
            this.panel2.Name = "panel2";
            // 
            // DGVCoupon
            // 
            resources.ApplyResources(this.DGVCoupon, "DGVCoupon");
            this.DGVCoupon.AllowUserToAddRows = false;
            this.DGVCoupon.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.DGVCoupon.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVCoupon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVCoupon.BackgroundColor = System.Drawing.Color.White;
            this.DGVCoupon.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DGVCoupon.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DGVCoupon.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVCoupon.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DGVCoupon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CouponSettingsIDGV,
            this.CouponNameGV,
            this.MinimumBillGV,
            this.ProductNameGV});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVCoupon.DefaultCellStyle = dataGridViewCellStyle3;
            this.DGVCoupon.EnableHeadersVisualStyles = false;
            this.DGVCoupon.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DGVCoupon.Name = "DGVCoupon";
            this.DGVCoupon.ReadOnly = true;
            this.DGVCoupon.RowHeadersVisible = false;
            this.DGVCoupon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVCoupon.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.DGVCoupon.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.DGVCoupon.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.DGVCoupon.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.DGVCoupon.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.DGVCoupon.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.DGVCoupon.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.DGVCoupon.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DGVCoupon.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.DGVCoupon.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DGVCoupon.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.DGVCoupon.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.DGVCoupon.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.DGVCoupon.ThemeStyle.HeaderStyle.Height = 50;
            this.DGVCoupon.ThemeStyle.ReadOnly = true;
            this.DGVCoupon.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.DGVCoupon.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DGVCoupon.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.DGVCoupon.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.DGVCoupon.ThemeStyle.RowsStyle.Height = 22;
            this.DGVCoupon.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DGVCoupon.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // CouponSettingsIDGV
            // 
            resources.ApplyResources(this.CouponSettingsIDGV, "CouponSettingsIDGV");
            this.CouponSettingsIDGV.Name = "CouponSettingsIDGV";
            this.CouponSettingsIDGV.ReadOnly = true;
            // 
            // CouponNameGV
            // 
            resources.ApplyResources(this.CouponNameGV, "CouponNameGV");
            this.CouponNameGV.Name = "CouponNameGV";
            this.CouponNameGV.ReadOnly = true;
            // 
            // MinimumBillGV
            // 
            resources.ApplyResources(this.MinimumBillGV, "MinimumBillGV");
            this.MinimumBillGV.Name = "MinimumBillGV";
            this.MinimumBillGV.ReadOnly = true;
            // 
            // ProductNameGV
            // 
            resources.ApplyResources(this.ProductNameGV, "ProductNameGV");
            this.ProductNameGV.Name = "ProductNameGV";
            this.ProductNameGV.ReadOnly = true;
            // 
            // dayspanel
            // 
            resources.ApplyResources(this.dayspanel, "dayspanel");
            this.dayspanel.Controls.Add(this.TuesdayCB);
            this.dayspanel.Controls.Add(this.SaturdayCB);
            this.dayspanel.Controls.Add(this.MondayCB);
            this.dayspanel.Controls.Add(this.ThursdayCB);
            this.dayspanel.Controls.Add(this.WednesdayCB);
            this.dayspanel.Controls.Add(this.FridayCB);
            this.dayspanel.Controls.Add(this.SundayCB);
            this.dayspanel.Name = "dayspanel";
            // 
            // TuesdayCB
            // 
            resources.ApplyResources(this.TuesdayCB, "TuesdayCB");
            this.TuesdayCB.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TuesdayCB.CheckedState.BorderRadius = 2;
            this.TuesdayCB.CheckedState.BorderThickness = 0;
            this.TuesdayCB.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TuesdayCB.Name = "TuesdayCB";
            this.TuesdayCB.Tag = "4";
            this.TuesdayCB.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.TuesdayCB.UncheckedState.BorderRadius = 2;
            this.TuesdayCB.UncheckedState.BorderThickness = 0;
            this.TuesdayCB.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.TuesdayCB.UseVisualStyleBackColor = true;
            // 
            // SaturdayCB
            // 
            resources.ApplyResources(this.SaturdayCB, "SaturdayCB");
            this.SaturdayCB.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.SaturdayCB.CheckedState.BorderRadius = 2;
            this.SaturdayCB.CheckedState.BorderThickness = 0;
            this.SaturdayCB.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.SaturdayCB.Name = "SaturdayCB";
            this.SaturdayCB.Tag = "64";
            this.SaturdayCB.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.SaturdayCB.UncheckedState.BorderRadius = 2;
            this.SaturdayCB.UncheckedState.BorderThickness = 0;
            this.SaturdayCB.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.SaturdayCB.UseVisualStyleBackColor = true;
            // 
            // MondayCB
            // 
            resources.ApplyResources(this.MondayCB, "MondayCB");
            this.MondayCB.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.MondayCB.CheckedState.BorderRadius = 2;
            this.MondayCB.CheckedState.BorderThickness = 0;
            this.MondayCB.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.MondayCB.Name = "MondayCB";
            this.MondayCB.Tag = "2";
            this.MondayCB.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.MondayCB.UncheckedState.BorderRadius = 2;
            this.MondayCB.UncheckedState.BorderThickness = 0;
            this.MondayCB.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.MondayCB.UseVisualStyleBackColor = true;
            // 
            // ThursdayCB
            // 
            resources.ApplyResources(this.ThursdayCB, "ThursdayCB");
            this.ThursdayCB.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ThursdayCB.CheckedState.BorderRadius = 2;
            this.ThursdayCB.CheckedState.BorderThickness = 0;
            this.ThursdayCB.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ThursdayCB.Name = "ThursdayCB";
            this.ThursdayCB.Tag = "16";
            this.ThursdayCB.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.ThursdayCB.UncheckedState.BorderRadius = 2;
            this.ThursdayCB.UncheckedState.BorderThickness = 0;
            this.ThursdayCB.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.ThursdayCB.UseVisualStyleBackColor = true;
            // 
            // WednesdayCB
            // 
            resources.ApplyResources(this.WednesdayCB, "WednesdayCB");
            this.WednesdayCB.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.WednesdayCB.CheckedState.BorderRadius = 2;
            this.WednesdayCB.CheckedState.BorderThickness = 0;
            this.WednesdayCB.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.WednesdayCB.Name = "WednesdayCB";
            this.WednesdayCB.Tag = "8";
            this.WednesdayCB.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.WednesdayCB.UncheckedState.BorderRadius = 2;
            this.WednesdayCB.UncheckedState.BorderThickness = 0;
            this.WednesdayCB.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.WednesdayCB.UseVisualStyleBackColor = true;
            // 
            // FridayCB
            // 
            resources.ApplyResources(this.FridayCB, "FridayCB");
            this.FridayCB.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.FridayCB.CheckedState.BorderRadius = 2;
            this.FridayCB.CheckedState.BorderThickness = 0;
            this.FridayCB.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.FridayCB.Name = "FridayCB";
            this.FridayCB.Tag = "32";
            this.FridayCB.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.FridayCB.UncheckedState.BorderRadius = 2;
            this.FridayCB.UncheckedState.BorderThickness = 0;
            this.FridayCB.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.FridayCB.UseVisualStyleBackColor = true;
            // 
            // SundayCB
            // 
            resources.ApplyResources(this.SundayCB, "SundayCB");
            this.SundayCB.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.SundayCB.CheckedState.BorderRadius = 2;
            this.SundayCB.CheckedState.BorderThickness = 0;
            this.SundayCB.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.SundayCB.Name = "SundayCB";
            this.SundayCB.Tag = "1";
            this.SundayCB.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.SundayCB.UncheckedState.BorderRadius = 2;
            this.SundayCB.UncheckedState.BorderThickness = 0;
            this.SundayCB.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.SundayCB.UseVisualStyleBackColor = true;
            // 
            // txtMinimumBill
            // 
            resources.ApplyResources(this.txtMinimumBill, "txtMinimumBill");
            this.txtMinimumBill.AutoRoundedCorners = true;
            this.txtMinimumBill.BorderRadius = 12;
            this.txtMinimumBill.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMinimumBill.DefaultText = "";
            this.txtMinimumBill.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtMinimumBill.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMinimumBill.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMinimumBill.DisabledState.Parent = this.txtMinimumBill;
            this.txtMinimumBill.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMinimumBill.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMinimumBill.FocusedState.Parent = this.txtMinimumBill;
            this.txtMinimumBill.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMinimumBill.HoverState.Parent = this.txtMinimumBill;
            this.txtMinimumBill.Name = "txtMinimumBill";
            this.txtMinimumBill.PasswordChar = '\0';
            this.txtMinimumBill.PlaceholderText = "";
            this.txtMinimumBill.SelectedText = "";
            this.txtMinimumBill.ShadowDecoration.Parent = this.txtMinimumBill;
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Firebrick;
            this.btnCancel.FlatAppearance.BorderSize = 2;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnSave.FlatAppearance.BorderSize = 2;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Name = "btnSave";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Name = "label2";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Name = "label4";
            // 
            // cboCoupon
            // 
            resources.ApplyResources(this.cboCoupon, "cboCoupon");
            this.cboCoupon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCoupon.FormattingEnabled = true;
            this.cboCoupon.Name = "cboCoupon";
            // 
            // cboProducts
            // 
            resources.ApplyResources(this.cboProducts, "cboProducts");
            this.cboProducts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProducts.FormattingEnabled = true;
            this.cboProducts.Name = "cboProducts";
            // 
            // CouponsSettings
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CouponsSettings";
            this.Load += new System.EventHandler(this.CouponsSettings_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVCoupon)).EndInit();
            this.dayspanel.ResumeLayout(false);
            this.dayspanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cboProducts;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboCoupon;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2TextBox txtMinimumBill;
        private Guna.UI2.WinForms.Guna2CheckBox SaturdayCB;
        private Guna.UI2.WinForms.Guna2CheckBox ThursdayCB;
        private Guna.UI2.WinForms.Guna2CheckBox TuesdayCB;
        private Guna.UI2.WinForms.Guna2CheckBox SundayCB;
        private Guna.UI2.WinForms.Guna2CheckBox FridayCB;
        private Guna.UI2.WinForms.Guna2CheckBox WednesdayCB;
        private Guna.UI2.WinForms.Guna2CheckBox MondayCB;
        private System.Windows.Forms.Panel dayspanel;
        private Guna.UI2.WinForms.Guna2DataGridView DGVCoupon;
        private System.Windows.Forms.DataGridViewTextBoxColumn CouponSettingsIDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn CouponNameGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn MinimumBillGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductNameGV;
    }
}