
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
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
            this.DGVCoupon = new Guna.UI2.WinForms.Guna2DataGridView();
            this.CouponSettingsIDGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CouponNameGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MinimumBillGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductNameGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.dayspanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVCoupon)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(915, 73);
            this.panel1.TabIndex = 25;
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::BibiShop.Properties.Resources.cancel__2_;
            this.button1.Location = new System.Drawing.Point(880, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(35, 30);
            this.button1.TabIndex = 4;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtSearch
            // 
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
            this.txtSearch.Location = new System.Drawing.Point(378, 34);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(12);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PasswordChar = '\0';
            this.txtSearch.PlaceholderText = "Search Coupon";
            this.txtSearch.SelectedText = "";
            this.txtSearch.ShadowDecoration.Parent = this.txtSearch;
            this.txtSearch.Size = new System.Drawing.Size(314, 27);
            this.txtSearch.TabIndex = 3;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(300, 40);
            this.label1.TabIndex = 2;
            this.label1.Text = "Coupons Settings";
            // 
            // panel2
            // 
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
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 73);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(915, 676);
            this.panel2.TabIndex = 27;
            // 
            // dayspanel
            // 
            this.dayspanel.Controls.Add(this.TuesdayCB);
            this.dayspanel.Controls.Add(this.SaturdayCB);
            this.dayspanel.Controls.Add(this.MondayCB);
            this.dayspanel.Controls.Add(this.ThursdayCB);
            this.dayspanel.Controls.Add(this.WednesdayCB);
            this.dayspanel.Controls.Add(this.FridayCB);
            this.dayspanel.Controls.Add(this.SundayCB);
            this.dayspanel.Location = new System.Drawing.Point(16, 198);
            this.dayspanel.Name = "dayspanel";
            this.dayspanel.Size = new System.Drawing.Size(200, 100);
            this.dayspanel.TabIndex = 34;
            // 
            // TuesdayCB
            // 
            this.TuesdayCB.AutoSize = true;
            this.TuesdayCB.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TuesdayCB.CheckedState.BorderRadius = 2;
            this.TuesdayCB.CheckedState.BorderThickness = 0;
            this.TuesdayCB.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TuesdayCB.Location = new System.Drawing.Point(120, 6);
            this.TuesdayCB.Name = "TuesdayCB";
            this.TuesdayCB.Size = new System.Drawing.Size(67, 17);
            this.TuesdayCB.TabIndex = 33;
            this.TuesdayCB.Tag = "4";
            this.TuesdayCB.Text = "Tuesday";
            this.TuesdayCB.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.TuesdayCB.UncheckedState.BorderRadius = 2;
            this.TuesdayCB.UncheckedState.BorderThickness = 0;
            this.TuesdayCB.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.TuesdayCB.UseVisualStyleBackColor = true;
            // 
            // SaturdayCB
            // 
            this.SaturdayCB.AutoSize = true;
            this.SaturdayCB.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.SaturdayCB.CheckedState.BorderRadius = 2;
            this.SaturdayCB.CheckedState.BorderThickness = 0;
            this.SaturdayCB.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.SaturdayCB.Location = new System.Drawing.Point(120, 52);
            this.SaturdayCB.Name = "SaturdayCB";
            this.SaturdayCB.Size = new System.Drawing.Size(68, 17);
            this.SaturdayCB.TabIndex = 33;
            this.SaturdayCB.Tag = "64";
            this.SaturdayCB.Text = "Saturday";
            this.SaturdayCB.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.SaturdayCB.UncheckedState.BorderRadius = 2;
            this.SaturdayCB.UncheckedState.BorderThickness = 0;
            this.SaturdayCB.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.SaturdayCB.UseVisualStyleBackColor = true;
            // 
            // MondayCB
            // 
            this.MondayCB.AutoSize = true;
            this.MondayCB.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.MondayCB.CheckedState.BorderRadius = 2;
            this.MondayCB.CheckedState.BorderThickness = 0;
            this.MondayCB.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.MondayCB.Location = new System.Drawing.Point(8, 7);
            this.MondayCB.Name = "MondayCB";
            this.MondayCB.Size = new System.Drawing.Size(64, 17);
            this.MondayCB.TabIndex = 33;
            this.MondayCB.Tag = "2";
            this.MondayCB.Text = "Monday";
            this.MondayCB.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.MondayCB.UncheckedState.BorderRadius = 2;
            this.MondayCB.UncheckedState.BorderThickness = 0;
            this.MondayCB.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.MondayCB.UseVisualStyleBackColor = true;
            // 
            // ThursdayCB
            // 
            this.ThursdayCB.AutoSize = true;
            this.ThursdayCB.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ThursdayCB.CheckedState.BorderRadius = 2;
            this.ThursdayCB.CheckedState.BorderThickness = 0;
            this.ThursdayCB.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ThursdayCB.Location = new System.Drawing.Point(120, 29);
            this.ThursdayCB.Name = "ThursdayCB";
            this.ThursdayCB.Size = new System.Drawing.Size(70, 17);
            this.ThursdayCB.TabIndex = 33;
            this.ThursdayCB.Tag = "16";
            this.ThursdayCB.Text = "Thursday";
            this.ThursdayCB.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.ThursdayCB.UncheckedState.BorderRadius = 2;
            this.ThursdayCB.UncheckedState.BorderThickness = 0;
            this.ThursdayCB.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.ThursdayCB.UseVisualStyleBackColor = true;
            // 
            // WednesdayCB
            // 
            this.WednesdayCB.AutoSize = true;
            this.WednesdayCB.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.WednesdayCB.CheckedState.BorderRadius = 2;
            this.WednesdayCB.CheckedState.BorderThickness = 0;
            this.WednesdayCB.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.WednesdayCB.Location = new System.Drawing.Point(8, 30);
            this.WednesdayCB.Name = "WednesdayCB";
            this.WednesdayCB.Size = new System.Drawing.Size(83, 17);
            this.WednesdayCB.TabIndex = 33;
            this.WednesdayCB.Tag = "8";
            this.WednesdayCB.Text = "Wednesday";
            this.WednesdayCB.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.WednesdayCB.UncheckedState.BorderRadius = 2;
            this.WednesdayCB.UncheckedState.BorderThickness = 0;
            this.WednesdayCB.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.WednesdayCB.UseVisualStyleBackColor = true;
            // 
            // FridayCB
            // 
            this.FridayCB.AutoSize = true;
            this.FridayCB.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.FridayCB.CheckedState.BorderRadius = 2;
            this.FridayCB.CheckedState.BorderThickness = 0;
            this.FridayCB.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.FridayCB.Location = new System.Drawing.Point(8, 53);
            this.FridayCB.Name = "FridayCB";
            this.FridayCB.Size = new System.Drawing.Size(54, 17);
            this.FridayCB.TabIndex = 33;
            this.FridayCB.Tag = "32";
            this.FridayCB.Text = "Friday";
            this.FridayCB.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.FridayCB.UncheckedState.BorderRadius = 2;
            this.FridayCB.UncheckedState.BorderThickness = 0;
            this.FridayCB.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.FridayCB.UseVisualStyleBackColor = true;
            // 
            // SundayCB
            // 
            this.SundayCB.AutoSize = true;
            this.SundayCB.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.SundayCB.CheckedState.BorderRadius = 2;
            this.SundayCB.CheckedState.BorderThickness = 0;
            this.SundayCB.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.SundayCB.Location = new System.Drawing.Point(8, 76);
            this.SundayCB.Name = "SundayCB";
            this.SundayCB.Size = new System.Drawing.Size(62, 17);
            this.SundayCB.TabIndex = 33;
            this.SundayCB.Tag = "1";
            this.SundayCB.Text = "Sunday";
            this.SundayCB.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.SundayCB.UncheckedState.BorderRadius = 2;
            this.SundayCB.UncheckedState.BorderThickness = 0;
            this.SundayCB.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.SundayCB.UseVisualStyleBackColor = true;
            // 
            // txtMinimumBill
            // 
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
            this.txtMinimumBill.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMinimumBill.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMinimumBill.HoverState.Parent = this.txtMinimumBill;
            this.txtMinimumBill.Location = new System.Drawing.Point(16, 114);
            this.txtMinimumBill.Margin = new System.Windows.Forms.Padding(4);
            this.txtMinimumBill.Name = "txtMinimumBill";
            this.txtMinimumBill.PasswordChar = '\0';
            this.txtMinimumBill.PlaceholderText = "";
            this.txtMinimumBill.SelectedText = "";
            this.txtMinimumBill.ShadowDecoration.Parent = this.txtMinimumBill;
            this.txtMinimumBill.Size = new System.Drawing.Size(100, 27);
            this.txtMinimumBill.TabIndex = 32;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Firebrick;
            this.btnCancel.FlatAppearance.BorderSize = 2;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(5, 328);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 42);
            this.btnCancel.TabIndex = 30;
            this.btnCancel.Text = "&CANCEL";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnSave.FlatAppearance.BorderSize = 2;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(98, 328);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(149, 42);
            this.btnSave.TabIndex = 31;
            this.btnSave.Text = "&SAVE";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(15, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "Minimum Bill";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(16, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Select Coupon";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(12, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 19);
            this.label4.TabIndex = 3;
            this.label4.Text = "Select Product";
            // 
            // cboCoupon
            // 
            this.cboCoupon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCoupon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboCoupon.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCoupon.FormattingEnabled = true;
            this.cboCoupon.Location = new System.Drawing.Point(16, 167);
            this.cboCoupon.Name = "cboCoupon";
            this.cboCoupon.Size = new System.Drawing.Size(231, 25);
            this.cboCoupon.TabIndex = 0;
            // 
            // cboProducts
            // 
            this.cboProducts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProducts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboProducts.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboProducts.FormattingEnabled = true;
            this.cboProducts.Location = new System.Drawing.Point(12, 63);
            this.cboProducts.Name = "cboProducts";
            this.cboProducts.Size = new System.Drawing.Size(231, 25);
            this.cboProducts.TabIndex = 0;
            // 
            // DGVCoupon
            // 
            this.DGVCoupon.AllowUserToAddRows = false;
            this.DGVCoupon.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(223)))), ((int)(((byte)(251)))));
            this.DGVCoupon.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.DGVCoupon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVCoupon.BackgroundColor = System.Drawing.Color.White;
            this.DGVCoupon.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DGVCoupon.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DGVCoupon.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(242)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVCoupon.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.DGVCoupon.ColumnHeadersHeight = 50;
            this.DGVCoupon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CouponSettingsIDGV,
            this.CouponNameGV,
            this.MinimumBillGV,
            this.ProductNameGV});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(233)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(185)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVCoupon.DefaultCellStyle = dataGridViewCellStyle6;
            this.DGVCoupon.Dock = System.Windows.Forms.DockStyle.Right;
            this.DGVCoupon.EnableHeadersVisualStyles = false;
            this.DGVCoupon.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(222)))), ((int)(((byte)(251)))));
            this.DGVCoupon.Location = new System.Drawing.Point(278, 0);
            this.DGVCoupon.Name = "DGVCoupon";
            this.DGVCoupon.ReadOnly = true;
            this.DGVCoupon.RowHeadersVisible = false;
            this.DGVCoupon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVCoupon.Size = new System.Drawing.Size(637, 676);
            this.DGVCoupon.TabIndex = 35;
            this.DGVCoupon.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Blue;
            this.DGVCoupon.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(223)))), ((int)(((byte)(251)))));
            this.DGVCoupon.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.DGVCoupon.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.DGVCoupon.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.DGVCoupon.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.DGVCoupon.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.DGVCoupon.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(222)))), ((int)(((byte)(251)))));
            this.DGVCoupon.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(242)))));
            this.DGVCoupon.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DGVCoupon.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.DGVCoupon.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.DGVCoupon.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.DGVCoupon.ThemeStyle.HeaderStyle.Height = 50;
            this.DGVCoupon.ThemeStyle.ReadOnly = true;
            this.DGVCoupon.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(233)))), ((int)(((byte)(252)))));
            this.DGVCoupon.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DGVCoupon.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.DGVCoupon.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.DGVCoupon.ThemeStyle.RowsStyle.Height = 22;
            this.DGVCoupon.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(185)))), ((int)(((byte)(246)))));
            this.DGVCoupon.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            // 
            // CouponSettingsIDGV
            // 
            this.CouponSettingsIDGV.HeaderText = "CouponSettingsID";
            this.CouponSettingsIDGV.Name = "CouponSettingsIDGV";
            this.CouponSettingsIDGV.ReadOnly = true;
            this.CouponSettingsIDGV.Visible = false;
            // 
            // CouponNameGV
            // 
            this.CouponNameGV.HeaderText = "Coupon";
            this.CouponNameGV.Name = "CouponNameGV";
            this.CouponNameGV.ReadOnly = true;
            // 
            // MinimumBillGV
            // 
            this.MinimumBillGV.HeaderText = "Minimum Bill";
            this.MinimumBillGV.Name = "MinimumBillGV";
            this.MinimumBillGV.ReadOnly = true;
            // 
            // ProductNameGV
            // 
            this.ProductNameGV.HeaderText = "Product ";
            this.ProductNameGV.Name = "ProductNameGV";
            this.ProductNameGV.ReadOnly = true;
            // 
            // CouponsSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(915, 749);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CouponsSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CouponsSettings";
            this.Load += new System.EventHandler(this.CouponsSettings_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.dayspanel.ResumeLayout(false);
            this.dayspanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVCoupon)).EndInit();
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