
namespace BibiShop
{
    partial class RecentSales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecentSales));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboOrderStatus = new System.Windows.Forms.ComboBox();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.DGVRecentSales = new Guna.UI2.WinForms.Guna2DataGridView();
            this.SaleIDGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceNoGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaleDateGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaleTimeGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GrandTotalGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActionGV = new System.Windows.Forms.DataGridViewButtonColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVRecentSales)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.cboOrderStatus);
            this.panel1.Controls.Add(this.guna2HtmlLabel2);
            this.panel1.Controls.Add(this.guna2HtmlLabel1);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Name = "panel1";
            // 
            // cboOrderStatus
            // 
            resources.ApplyResources(this.cboOrderStatus, "cboOrderStatus");
            this.cboOrderStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOrderStatus.FormattingEnabled = true;
            this.cboOrderStatus.Name = "cboOrderStatus";
            this.cboOrderStatus.SelectedIndexChanged += new System.EventHandler(this.cboOrderStatus_SelectedIndexChanged);
            // 
            // guna2HtmlLabel2
            // 
            resources.ApplyResources(this.guna2HtmlLabel2, "guna2HtmlLabel2");
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.ForeColor = System.Drawing.Color.White;
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            // 
            // guna2HtmlLabel1
            // 
            resources.ApplyResources(this.guna2HtmlLabel1, "guna2HtmlLabel1");
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.White;
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            // 
            // button3
            // 
            resources.ApplyResources(this.button3, "button3");
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.Image = global::BibiShop.Properties.Resources.cancel__2_;
            this.button3.Name = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.Image = global::BibiShop.Properties.Resources.cancel__2_;
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Name = "label1";
            // 
            // DGVRecentSales
            // 
            resources.ApplyResources(this.DGVRecentSales, "DGVRecentSales");
            this.DGVRecentSales.AllowUserToAddRows = false;
            this.DGVRecentSales.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.DGVRecentSales.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVRecentSales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVRecentSales.BackgroundColor = System.Drawing.Color.White;
            this.DGVRecentSales.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DGVRecentSales.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DGVRecentSales.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVRecentSales.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DGVRecentSales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SaleIDGV,
            this.InvoiceNoGV,
            this.CustomerGV,
            this.SaleDateGV,
            this.SaleTimeGV,
            this.GrandTotalGV,
            this.ActionGV});
            this.DGVRecentSales.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVRecentSales.DefaultCellStyle = dataGridViewCellStyle3;
            this.DGVRecentSales.EnableHeadersVisualStyles = false;
            this.DGVRecentSales.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DGVRecentSales.Name = "DGVRecentSales";
            this.DGVRecentSales.ReadOnly = true;
            this.DGVRecentSales.RowHeadersVisible = false;
            this.DGVRecentSales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVRecentSales.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.DGVRecentSales.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.DGVRecentSales.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.DGVRecentSales.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.DGVRecentSales.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.DGVRecentSales.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.DGVRecentSales.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.DGVRecentSales.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DGVRecentSales.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.DGVRecentSales.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DGVRecentSales.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.DGVRecentSales.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.DGVRecentSales.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.DGVRecentSales.ThemeStyle.HeaderStyle.Height = 40;
            this.DGVRecentSales.ThemeStyle.ReadOnly = true;
            this.DGVRecentSales.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.DGVRecentSales.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DGVRecentSales.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.DGVRecentSales.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.DGVRecentSales.ThemeStyle.RowsStyle.Height = 22;
            this.DGVRecentSales.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DGVRecentSales.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.DGVRecentSales.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVRecentSales_CellClick);
            this.DGVRecentSales.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVRecentSales_CellContentClick);
            // 
            // SaleIDGV
            // 
            resources.ApplyResources(this.SaleIDGV, "SaleIDGV");
            this.SaleIDGV.Name = "SaleIDGV";
            this.SaleIDGV.ReadOnly = true;
            // 
            // InvoiceNoGV
            // 
            resources.ApplyResources(this.InvoiceNoGV, "InvoiceNoGV");
            this.InvoiceNoGV.Name = "InvoiceNoGV";
            this.InvoiceNoGV.ReadOnly = true;
            // 
            // CustomerGV
            // 
            resources.ApplyResources(this.CustomerGV, "CustomerGV");
            this.CustomerGV.Name = "CustomerGV";
            this.CustomerGV.ReadOnly = true;
            // 
            // SaleDateGV
            // 
            resources.ApplyResources(this.SaleDateGV, "SaleDateGV");
            this.SaleDateGV.Name = "SaleDateGV";
            this.SaleDateGV.ReadOnly = true;
            // 
            // SaleTimeGV
            // 
            resources.ApplyResources(this.SaleTimeGV, "SaleTimeGV");
            this.SaleTimeGV.Name = "SaleTimeGV";
            this.SaleTimeGV.ReadOnly = true;
            // 
            // GrandTotalGV
            // 
            resources.ApplyResources(this.GrandTotalGV, "GrandTotalGV");
            this.GrandTotalGV.Name = "GrandTotalGV";
            this.GrandTotalGV.ReadOnly = true;
            // 
            // ActionGV
            // 
            resources.ApplyResources(this.ActionGV, "ActionGV");
            this.ActionGV.Name = "ActionGV";
            this.ActionGV.ReadOnly = true;
            this.ActionGV.Text = "PAYMENT";
            this.ActionGV.UseColumnTextForButtonValue = true;
            // 
            // contextMenuStrip1
            // 
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            // 
            // deleteToolStripMenuItem
            // 
            resources.ApplyResources(this.deleteToolStripMenuItem, "deleteToolStripMenuItem");
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // RecentSales
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DGVRecentSales);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RecentSales";
            this.Load += new System.EventHandler(this.RecentSales_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVRecentSales)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2DataGridView DGVRecentSales;
        private System.Windows.Forms.ComboBox cboOrderStatus;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaleIDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceNoGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaleDateGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaleTimeGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn GrandTotalGV;
        private System.Windows.Forms.DataGridViewButtonColumn ActionGV;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
    }
}