
namespace BibiShop
{
    partial class Trasnfer
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblID = new System.Windows.Forms.Label();
            this.DGVInventory = new Guna.UI2.WinForms.Guna2DataGridView();
            this.cboWarehouseFrom = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnTrasnfer = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cboWarehouseTo = new System.Windows.Forms.ComboBox();
            this.ProductGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuantityGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RateGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVInventory)).BeginInit();
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 40);
            this.label1.TabIndex = 2;
            this.label1.Text = "TRANSFER";
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
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
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
            this.txtSearch.Location = new System.Drawing.Point(423, 34);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(12);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PasswordChar = '\0';
            this.txtSearch.PlaceholderText = "Search Color";
            this.txtSearch.SelectedText = "";
            this.txtSearch.ShadowDecoration.Parent = this.txtSearch;
            this.txtSearch.Size = new System.Drawing.Size(418, 27);
            this.txtSearch.TabIndex = 3;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnTrasnfer);
            this.panel2.Controls.Add(this.cboWarehouseTo);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.cboWarehouseFrom);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.DGVInventory);
            this.panel2.Controls.Add(this.lblID);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 73);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(915, 676);
            this.panel2.TabIndex = 26;
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
            // DGVInventory
            // 
            this.DGVInventory.AllowUserToAddRows = false;
            this.DGVInventory.AllowUserToDeleteRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(223)))), ((int)(((byte)(251)))));
            this.DGVInventory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.DGVInventory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVInventory.BackgroundColor = System.Drawing.Color.White;
            this.DGVInventory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DGVInventory.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DGVInventory.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(242)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Century Gothic", 10F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVInventory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.DGVInventory.ColumnHeadersHeight = 30;
            this.DGVInventory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductGV,
            this.UnitGV,
            this.QuantityGV,
            this.RateGV,
            this.Select});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(233)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Century Gothic", 10F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(185)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVInventory.DefaultCellStyle = dataGridViewCellStyle9;
            this.DGVInventory.EnableHeadersVisualStyles = false;
            this.DGVInventory.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(222)))), ((int)(((byte)(251)))));
            this.DGVInventory.Location = new System.Drawing.Point(272, 3);
            this.DGVInventory.Name = "DGVInventory";
            this.DGVInventory.RowHeadersVisible = false;
            this.DGVInventory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVInventory.Size = new System.Drawing.Size(638, 565);
            this.DGVInventory.TabIndex = 27;
            this.DGVInventory.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Blue;
            this.DGVInventory.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(223)))), ((int)(((byte)(251)))));
            this.DGVInventory.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.DGVInventory.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.DGVInventory.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.DGVInventory.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.DGVInventory.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.DGVInventory.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(222)))), ((int)(((byte)(251)))));
            this.DGVInventory.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(242)))));
            this.DGVInventory.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DGVInventory.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.DGVInventory.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.DGVInventory.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.DGVInventory.ThemeStyle.HeaderStyle.Height = 30;
            this.DGVInventory.ThemeStyle.ReadOnly = false;
            this.DGVInventory.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(233)))), ((int)(((byte)(252)))));
            this.DGVInventory.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DGVInventory.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.DGVInventory.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.DGVInventory.ThemeStyle.RowsStyle.Height = 22;
            this.DGVInventory.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(185)))), ((int)(((byte)(246)))));
            this.DGVInventory.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.DGVInventory.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVInventory_CellClick);
            this.DGVInventory.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVInventory_CellContentClick);
            // 
            // cboWarehouseFrom
            // 
            this.cboWarehouseFrom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboWarehouseFrom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboWarehouseFrom.FormattingEnabled = true;
            this.cboWarehouseFrom.Location = new System.Drawing.Point(6, 57);
            this.cboWarehouseFrom.Name = "cboWarehouseFrom";
            this.cboWarehouseFrom.Size = new System.Drawing.Size(208, 21);
            this.cboWarehouseFrom.TabIndex = 30;
            this.cboWarehouseFrom.SelectedIndexChanged += new System.EventHandler(this.cboWarehouseFrom_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(3, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(245, 23);
            this.label2.TabIndex = 29;
            this.label2.Text = "Select Warehouse From:";
            // 
            // btnTrasnfer
            // 
            this.btnTrasnfer.BackColor = System.Drawing.Color.SteelBlue;
            this.btnTrasnfer.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnTrasnfer.FlatAppearance.BorderSize = 2;
            this.btnTrasnfer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTrasnfer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnTrasnfer.ForeColor = System.Drawing.Color.White;
            this.btnTrasnfer.Location = new System.Drawing.Point(4, 158);
            this.btnTrasnfer.Name = "btnTrasnfer";
            this.btnTrasnfer.Size = new System.Drawing.Size(212, 42);
            this.btnTrasnfer.TabIndex = 31;
            this.btnTrasnfer.Text = "&TRANSFER";
            this.btnTrasnfer.UseVisualStyleBackColor = false;
            this.btnTrasnfer.Click += new System.EventHandler(this.btnTrasnfer_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(0, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(218, 23);
            this.label3.TabIndex = 29;
            this.label3.Text = "Select Warehouse To:";
            // 
            // cboWarehouseTo
            // 
            this.cboWarehouseTo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboWarehouseTo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboWarehouseTo.FormattingEnabled = true;
            this.cboWarehouseTo.Location = new System.Drawing.Point(3, 131);
            this.cboWarehouseTo.Name = "cboWarehouseTo";
            this.cboWarehouseTo.Size = new System.Drawing.Size(208, 21);
            this.cboWarehouseTo.TabIndex = 30;
            // 
            // ProductGV
            // 
            this.ProductGV.HeaderText = "Product";
            this.ProductGV.Name = "ProductGV";
            this.ProductGV.ReadOnly = true;
            // 
            // UnitGV
            // 
            this.UnitGV.HeaderText = "Unit";
            this.UnitGV.Name = "UnitGV";
            this.UnitGV.ReadOnly = true;
            // 
            // QuantityGV
            // 
            this.QuantityGV.HeaderText = "Quantity";
            this.QuantityGV.Name = "QuantityGV";
            this.QuantityGV.ReadOnly = true;
            // 
            // RateGV
            // 
            this.RateGV.HeaderText = "Rate";
            this.RateGV.Name = "RateGV";
            this.RateGV.ReadOnly = true;
            // 
            // Select
            // 
            this.Select.HeaderText = "Select";
            this.Select.Name = "Select";
            // 
            // Trasnfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(915, 749);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Trasnfer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trasnfer";
            this.Load += new System.EventHandler(this.Trasnfer_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVInventory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblID;
        private Guna.UI2.WinForms.Guna2DataGridView DGVInventory;
        private System.Windows.Forms.ComboBox cboWarehouseFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnTrasnfer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboWarehouseTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuantityGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn RateGV;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Select;
    }
}