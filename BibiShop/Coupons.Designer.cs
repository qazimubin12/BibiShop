
namespace BibiShop
{
    partial class Coupons
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ActiveCheckBox = new Guna.UI2.WinForms.Guna2CheckBox();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button4 = new Guna.UI2.WinForms.Guna2Button();
            this.cboCouponType = new System.Windows.Forms.ComboBox();
            this.dtExpiry = new System.Windows.Forms.DateTimePicker();
            this.dtActivation = new System.Windows.Forms.DateTimePicker();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblID = new System.Windows.Forms.Label();
            this.txtCouponBenefit = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtCouponCode = new Guna.UI2.WinForms.Guna2TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNoofCoupons = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCouponName = new Guna.UI2.WinForms.Guna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.DGVCoupon = new Guna.UI2.WinForms.Guna2DataGridView();
            this.CouponIDGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CouponNameGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CouponsGeneratedGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CouponCodeGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CouponActivationDateGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CouponExpiryDateGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CouponUsageTypeGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVCoupon)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
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
            this.panel1.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 40);
            this.label1.TabIndex = 2;
            this.label1.Text = "Coupons";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.ActiveCheckBox);
            this.panel2.Controls.Add(this.guna2Button2);
            this.panel2.Controls.Add(this.guna2Button1);
            this.panel2.Controls.Add(this.guna2Button4);
            this.panel2.Controls.Add(this.cboCouponType);
            this.panel2.Controls.Add(this.dtExpiry);
            this.panel2.Controls.Add(this.dtActivation);
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.lblID);
            this.panel2.Controls.Add(this.txtCouponBenefit);
            this.panel2.Controls.Add(this.txtCouponCode);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtNoofCoupons);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtCouponName);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 73);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(278, 676);
            this.panel2.TabIndex = 25;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // ActiveCheckBox
            // 
            this.ActiveCheckBox.AutoSize = true;
            this.ActiveCheckBox.Checked = true;
            this.ActiveCheckBox.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ActiveCheckBox.CheckedState.BorderRadius = 2;
            this.ActiveCheckBox.CheckedState.BorderThickness = 0;
            this.ActiveCheckBox.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ActiveCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ActiveCheckBox.Location = new System.Drawing.Point(22, 429);
            this.ActiveCheckBox.Name = "ActiveCheckBox";
            this.ActiveCheckBox.Size = new System.Drawing.Size(67, 17);
            this.ActiveCheckBox.TabIndex = 33;
            this.ActiveCheckBox.Text = "Is Active";
            this.ActiveCheckBox.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.ActiveCheckBox.UncheckedState.BorderRadius = 2;
            this.ActiveCheckBox.UncheckedState.BorderThickness = 0;
            this.ActiveCheckBox.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.ActiveCheckBox.UseVisualStyleBackColor = true;
            // 
            // guna2Button1
            // 
            this.guna2Button1.AutoRoundedCorners = true;
            this.guna2Button1.BackColor = System.Drawing.Color.White;
            this.guna2Button1.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.guna2Button1.BorderRadius = 15;
            this.guna2Button1.BorderThickness = 2;
            this.guna2Button1.CheckedState.Parent = this.guna2Button1;
            this.guna2Button1.CustomImages.Parent = this.guna2Button1;
            this.guna2Button1.FillColor = System.Drawing.Color.SteelBlue;
            this.guna2Button1.Font = new System.Drawing.Font("Berlin Sans FB", 9F);
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.HoverState.Parent = this.guna2Button1;
            this.guna2Button1.Location = new System.Drawing.Point(130, 246);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.ShadowDecoration.Parent = this.guna2Button1;
            this.guna2Button1.Size = new System.Drawing.Size(33, 34);
            this.guna2Button1.TabIndex = 32;
            this.guna2Button1.Text = "ADD";
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
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
            this.guna2Button4.Location = new System.Drawing.Point(167, 246);
            this.guna2Button4.Name = "guna2Button4";
            this.guna2Button4.ShadowDecoration.Parent = this.guna2Button4;
            this.guna2Button4.Size = new System.Drawing.Size(33, 34);
            this.guna2Button4.TabIndex = 32;
            this.guna2Button4.Text = "R";
            this.guna2Button4.Click += new System.EventHandler(this.guna2Button4_Click);
            // 
            // cboCouponType
            // 
            this.cboCouponType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCouponType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboCouponType.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.cboCouponType.FormattingEnabled = true;
            this.cboCouponType.Location = new System.Drawing.Point(22, 284);
            this.cboCouponType.Name = "cboCouponType";
            this.cboCouponType.Size = new System.Drawing.Size(178, 25);
            this.cboCouponType.TabIndex = 31;
            this.cboCouponType.SelectedIndexChanged += new System.EventHandler(this.cboCouponType_SelectedIndexChanged);
            // 
            // dtExpiry
            // 
            this.dtExpiry.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dtExpiry.Location = new System.Drawing.Point(20, 399);
            this.dtExpiry.Name = "dtExpiry";
            this.dtExpiry.Size = new System.Drawing.Size(240, 23);
            this.dtExpiry.TabIndex = 30;
            // 
            // dtActivation
            // 
            this.dtActivation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dtActivation.Location = new System.Drawing.Point(22, 341);
            this.dtActivation.Name = "dtActivation";
            this.dtActivation.Size = new System.Drawing.Size(240, 23);
            this.dtActivation.TabIndex = 30;
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
            this.btnCancel.Location = new System.Drawing.Point(20, 483);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 42);
            this.btnCancel.TabIndex = 28;
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
            this.btnSave.Location = new System.Drawing.Point(113, 483);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(149, 42);
            this.btnSave.TabIndex = 29;
            this.btnSave.Text = "&SAVE";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(3, 3);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(18, 13);
            this.lblID.TabIndex = 13;
            this.lblID.Text = "ID";
            this.lblID.Visible = false;
            // 
            // txtCouponBenefit
            // 
            this.txtCouponBenefit.AutoRoundedCorners = true;
            this.txtCouponBenefit.BorderRadius = 12;
            this.txtCouponBenefit.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCouponBenefit.DefaultText = "";
            this.txtCouponBenefit.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtCouponBenefit.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtCouponBenefit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCouponBenefit.DisabledState.Parent = this.txtCouponBenefit;
            this.txtCouponBenefit.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCouponBenefit.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCouponBenefit.FocusedState.Parent = this.txtCouponBenefit;
            this.txtCouponBenefit.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCouponBenefit.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCouponBenefit.HoverState.Parent = this.txtCouponBenefit;
            this.txtCouponBenefit.Location = new System.Drawing.Point(207, 284);
            this.txtCouponBenefit.Margin = new System.Windows.Forms.Padding(4);
            this.txtCouponBenefit.Name = "txtCouponBenefit";
            this.txtCouponBenefit.PasswordChar = '\0';
            this.txtCouponBenefit.PlaceholderText = "";
            this.txtCouponBenefit.SelectedText = "";
            this.txtCouponBenefit.ShadowDecoration.Parent = this.txtCouponBenefit;
            this.txtCouponBenefit.Size = new System.Drawing.Size(55, 27);
            this.txtCouponBenefit.TabIndex = 4;
            // 
            // txtCouponCode
            // 
            this.txtCouponCode.AutoRoundedCorners = true;
            this.txtCouponCode.BorderRadius = 12;
            this.txtCouponCode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCouponCode.DefaultText = "";
            this.txtCouponCode.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtCouponCode.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtCouponCode.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCouponCode.DisabledState.Parent = this.txtCouponCode;
            this.txtCouponCode.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCouponCode.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCouponCode.FocusedState.Parent = this.txtCouponCode;
            this.txtCouponCode.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCouponCode.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCouponCode.HoverState.Parent = this.txtCouponCode;
            this.txtCouponCode.Location = new System.Drawing.Point(20, 191);
            this.txtCouponCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtCouponCode.Name = "txtCouponCode";
            this.txtCouponCode.PasswordChar = '\0';
            this.txtCouponCode.PlaceholderText = "";
            this.txtCouponCode.SelectedText = "";
            this.txtCouponCode.ShadowDecoration.Parent = this.txtCouponCode;
            this.txtCouponCode.Size = new System.Drawing.Size(241, 27);
            this.txtCouponCode.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(17, 377);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(152, 19);
            this.label6.TabIndex = 2;
            this.label6.Text = "Coupon Expiry Date:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(18, 318);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(182, 19);
            this.label5.TabIndex = 2;
            this.label5.Text = "Coupon Activation Date:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(203, 261);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 19);
            this.label8.TabIndex = 2;
            this.label8.Text = "Benefit:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(18, 261);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 19);
            this.label7.TabIndex = 2;
            this.label7.Text = "Coupon Type:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(16, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Coupon Code";
            // 
            // txtNoofCoupons
            // 
            this.txtNoofCoupons.AutoRoundedCorners = true;
            this.txtNoofCoupons.BorderRadius = 12;
            this.txtNoofCoupons.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNoofCoupons.DefaultText = "";
            this.txtNoofCoupons.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtNoofCoupons.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtNoofCoupons.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNoofCoupons.DisabledState.Parent = this.txtNoofCoupons;
            this.txtNoofCoupons.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNoofCoupons.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNoofCoupons.FocusedState.Parent = this.txtNoofCoupons;
            this.txtNoofCoupons.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoofCoupons.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNoofCoupons.HoverState.Parent = this.txtNoofCoupons;
            this.txtNoofCoupons.Location = new System.Drawing.Point(20, 131);
            this.txtNoofCoupons.Margin = new System.Windows.Forms.Padding(4);
            this.txtNoofCoupons.Name = "txtNoofCoupons";
            this.txtNoofCoupons.PasswordChar = '\0';
            this.txtNoofCoupons.PlaceholderText = "";
            this.txtNoofCoupons.SelectedText = "";
            this.txtNoofCoupons.ShadowDecoration.Parent = this.txtNoofCoupons;
            this.txtNoofCoupons.Size = new System.Drawing.Size(241, 27);
            this.txtNoofCoupons.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(16, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Number of Coupons";
            // 
            // txtCouponName
            // 
            this.txtCouponName.AutoRoundedCorners = true;
            this.txtCouponName.BorderRadius = 12;
            this.txtCouponName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCouponName.DefaultText = "";
            this.txtCouponName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtCouponName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtCouponName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCouponName.DisabledState.Parent = this.txtCouponName;
            this.txtCouponName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCouponName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCouponName.FocusedState.Parent = this.txtCouponName;
            this.txtCouponName.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCouponName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCouponName.HoverState.Parent = this.txtCouponName;
            this.txtCouponName.Location = new System.Drawing.Point(19, 77);
            this.txtCouponName.Margin = new System.Windows.Forms.Padding(4);
            this.txtCouponName.Name = "txtCouponName";
            this.txtCouponName.PasswordChar = '\0';
            this.txtCouponName.PlaceholderText = "";
            this.txtCouponName.SelectedText = "";
            this.txtCouponName.ShadowDecoration.Parent = this.txtCouponName;
            this.txtCouponName.Size = new System.Drawing.Size(241, 27);
            this.txtCouponName.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(16, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 19);
            this.label4.TabIndex = 2;
            this.label4.Text = "Enter Coupon Name:";
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
            this.CouponIDGV,
            this.CouponNameGV,
            this.CouponsGeneratedGV,
            this.CouponCodeGV,
            this.CouponActivationDateGV,
            this.CouponExpiryDateGV,
            this.CouponUsageTypeGV});
            this.DGVCoupon.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(233)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(185)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVCoupon.DefaultCellStyle = dataGridViewCellStyle6;
            this.DGVCoupon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVCoupon.EnableHeadersVisualStyles = false;
            this.DGVCoupon.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(222)))), ((int)(((byte)(251)))));
            this.DGVCoupon.Location = new System.Drawing.Point(278, 73);
            this.DGVCoupon.Name = "DGVCoupon";
            this.DGVCoupon.ReadOnly = true;
            this.DGVCoupon.RowHeadersVisible = false;
            this.DGVCoupon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVCoupon.Size = new System.Drawing.Size(637, 676);
            this.DGVCoupon.TabIndex = 27;
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
            // CouponIDGV
            // 
            this.CouponIDGV.HeaderText = "Coupon ID";
            this.CouponIDGV.Name = "CouponIDGV";
            this.CouponIDGV.ReadOnly = true;
            this.CouponIDGV.Visible = false;
            // 
            // CouponNameGV
            // 
            this.CouponNameGV.HeaderText = "Coupon Name";
            this.CouponNameGV.Name = "CouponNameGV";
            this.CouponNameGV.ReadOnly = true;
            // 
            // CouponsGeneratedGV
            // 
            this.CouponsGeneratedGV.HeaderText = "Coupons Generated";
            this.CouponsGeneratedGV.Name = "CouponsGeneratedGV";
            this.CouponsGeneratedGV.ReadOnly = true;
            // 
            // CouponCodeGV
            // 
            this.CouponCodeGV.HeaderText = "Coupon Code";
            this.CouponCodeGV.Name = "CouponCodeGV";
            this.CouponCodeGV.ReadOnly = true;
            // 
            // CouponActivationDateGV
            // 
            this.CouponActivationDateGV.HeaderText = "Coupon Activation Date";
            this.CouponActivationDateGV.Name = "CouponActivationDateGV";
            this.CouponActivationDateGV.ReadOnly = true;
            // 
            // CouponExpiryDateGV
            // 
            this.CouponExpiryDateGV.HeaderText = "Coupon Expiry Date";
            this.CouponExpiryDateGV.Name = "CouponExpiryDateGV";
            this.CouponExpiryDateGV.ReadOnly = true;
            // 
            // CouponUsageTypeGV
            // 
            this.CouponUsageTypeGV.HeaderText = "Coupon Usage Type";
            this.CouponUsageTypeGV.Name = "CouponUsageTypeGV";
            this.CouponUsageTypeGV.ReadOnly = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(108, 48);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click_1);
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
            this.txtSearch.Location = new System.Drawing.Point(278, 31);
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
            // guna2Button2
            // 
            this.guna2Button2.AutoRoundedCorners = true;
            this.guna2Button2.BackColor = System.Drawing.Color.White;
            this.guna2Button2.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.guna2Button2.BorderRadius = 16;
            this.guna2Button2.BorderThickness = 2;
            this.guna2Button2.CheckedState.Parent = this.guna2Button2;
            this.guna2Button2.CustomImages.Parent = this.guna2Button2;
            this.guna2Button2.FillColor = System.Drawing.Color.SteelBlue;
            this.guna2Button2.Font = new System.Drawing.Font("Berlin Sans FB", 9F);
            this.guna2Button2.ForeColor = System.Drawing.Color.White;
            this.guna2Button2.HoverState.Parent = this.guna2Button2;
            this.guna2Button2.Location = new System.Drawing.Point(205, 5);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.ShadowDecoration.Parent = this.guna2Button2;
            this.guna2Button2.Size = new System.Drawing.Size(66, 34);
            this.guna2Button2.TabIndex = 32;
            this.guna2Button2.Text = "SETTINGS";
            this.guna2Button2.Click += new System.EventHandler(this.guna2Button2_Click);
            // 
            // Coupons
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(915, 749);
            this.ControlBox = false;
            this.Controls.Add(this.DGVCoupon);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Coupons";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Coupons";
            this.Load += new System.EventHandler(this.Units_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVCoupon)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2DataGridView DGVCoupon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private Guna.UI2.WinForms.Guna2TextBox txtNoofCoupons;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2TextBox txtCouponName;
        private Guna.UI2.WinForms.Guna2TextBox txtCouponCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtExpiry;
        private System.Windows.Forms.DateTimePicker dtActivation;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboCouponType;
        private Guna.UI2.WinForms.Guna2TextBox txtCouponBenefit;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn CouponIDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn CouponNameGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn CouponsGeneratedGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn CouponCodeGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn CouponActivationDateGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn CouponExpiryDateGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn CouponUsageTypeGV;
        private Guna.UI2.WinForms.Guna2Button guna2Button4;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2CheckBox ActiveCheckBox;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
    }
}