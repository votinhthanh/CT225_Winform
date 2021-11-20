
namespace CoffeeShopManager
{
    partial class fTableManager
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lsvBill = new System.Windows.Forms.ListView();
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.count = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.price = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pay = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel3 = new System.Windows.Forms.Panel();
            this.nmCount = new System.Windows.Forms.NumericUpDown();
            this.btnAddFood = new System.Windows.Forms.Button();
            this.cbFood = new System.Windows.Forms.ComboBox();
            this.cbCategoryFood = new System.Windows.Forms.ComboBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtTotalPriceVn = new System.Windows.Forms.TextBox();
            this.txtTotalPriceEn = new System.Windows.Forms.TextBox();
            this.btnCheckOut = new System.Windows.Forms.Button();
            this.btnDiscount = new System.Windows.Forms.Button();
            this.btnSwitchTable = new System.Windows.Forms.Button();
            this.nmDiscount = new System.Windows.Forms.NumericUpDown();
            this.cbSwitchTable = new System.Windows.Forms.ComboBox();
            this.flpTable = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmCount)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmDiscount)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminToolStripMenuItem,
            this.accountInformationToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(771, 29);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(74, 25);
            this.adminToolStripMenuItem.Text = "Admin";
            this.adminToolStripMenuItem.Click += new System.EventHandler(this.adminToolStripMenuItem_Click);
            // 
            // accountInformationToolStripMenuItem
            // 
            this.accountInformationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showInformationToolStripMenuItem,
            this.logoutToolStripMenuItem});
            this.accountInformationToolStripMenuItem.Name = "accountInformationToolStripMenuItem";
            this.accountInformationToolStripMenuItem.Size = new System.Drawing.Size(180, 25);
            this.accountInformationToolStripMenuItem.Text = "Account Information";
            // 
            // showInformationToolStripMenuItem
            // 
            this.showInformationToolStripMenuItem.Name = "showInformationToolStripMenuItem";
            this.showInformationToolStripMenuItem.Size = new System.Drawing.Size(148, 26);
            this.showInformationToolStripMenuItem.Text = "Show";
            this.showInformationToolStripMenuItem.Click += new System.EventHandler(this.showInformationToolStripMenuItem_Click);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(148, 26);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lsvBill);
            this.panel2.Location = new System.Drawing.Point(388, 108);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(371, 324);
            this.panel2.TabIndex = 2;
            // 
            // lsvBill
            // 
            this.lsvBill.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.name,
            this.count,
            this.price,
            this.pay});
            this.lsvBill.GridLines = true;
            this.lsvBill.HideSelection = false;
            this.lsvBill.Location = new System.Drawing.Point(3, 3);
            this.lsvBill.Name = "lsvBill";
            this.lsvBill.Size = new System.Drawing.Size(375, 318);
            this.lsvBill.TabIndex = 0;
            this.lsvBill.UseCompatibleStateImageBehavior = false;
            this.lsvBill.View = System.Windows.Forms.View.Details;
            // 
            // name
            // 
            this.name.Text = "Food Name";
            this.name.Width = 165;
            // 
            // count
            // 
            this.count.Text = "Count";
            this.count.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.count.Width = 48;
            // 
            // price
            // 
            this.price.Text = "Price";
            this.price.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.price.Width = 73;
            // 
            // pay
            // 
            this.pay.Text = "Pay";
            this.pay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.pay.Width = 77;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.nmCount);
            this.panel3.Controls.Add(this.btnAddFood);
            this.panel3.Controls.Add(this.cbFood);
            this.panel3.Controls.Add(this.cbCategoryFood);
            this.panel3.Location = new System.Drawing.Point(388, 32);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(378, 70);
            this.panel3.TabIndex = 3;
            // 
            // nmCount
            // 
            this.nmCount.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nmCount.Location = new System.Drawing.Point(306, 18);
            this.nmCount.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nmCount.Name = "nmCount";
            this.nmCount.Size = new System.Drawing.Size(69, 28);
            this.nmCount.TabIndex = 3;
            this.nmCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnAddFood
            // 
            this.btnAddFood.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddFood.Location = new System.Drawing.Point(190, 3);
            this.btnAddFood.Name = "btnAddFood";
            this.btnAddFood.Size = new System.Drawing.Size(110, 61);
            this.btnAddFood.TabIndex = 2;
            this.btnAddFood.Text = "Add Food";
            this.btnAddFood.UseVisualStyleBackColor = true;
            this.btnAddFood.Click += new System.EventHandler(this.btnAddFood_Click);
            // 
            // cbFood
            // 
            this.cbFood.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFood.FormattingEnabled = true;
            this.cbFood.Location = new System.Drawing.Point(3, 36);
            this.cbFood.Name = "cbFood";
            this.cbFood.Size = new System.Drawing.Size(181, 28);
            this.cbFood.TabIndex = 1;
            // 
            // cbCategoryFood
            // 
            this.cbCategoryFood.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCategoryFood.FormattingEnabled = true;
            this.cbCategoryFood.Location = new System.Drawing.Point(3, 3);
            this.cbCategoryFood.Name = "cbCategoryFood";
            this.cbCategoryFood.Size = new System.Drawing.Size(181, 28);
            this.cbCategoryFood.TabIndex = 0;
            this.cbCategoryFood.SelectedIndexChanged += new System.EventHandler(this.cbCategoryFood_SelectedIndexChanged);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txtTotalPriceVn);
            this.panel4.Controls.Add(this.txtTotalPriceEn);
            this.panel4.Controls.Add(this.btnCheckOut);
            this.panel4.Controls.Add(this.btnDiscount);
            this.panel4.Controls.Add(this.btnSwitchTable);
            this.panel4.Controls.Add(this.nmDiscount);
            this.panel4.Controls.Add(this.cbSwitchTable);
            this.panel4.Location = new System.Drawing.Point(388, 438);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(378, 69);
            this.panel4.TabIndex = 4;
            // 
            // txtTotalPriceVn
            // 
            this.txtTotalPriceVn.BackColor = System.Drawing.SystemColors.Menu;
            this.txtTotalPriceVn.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalPriceVn.ForeColor = System.Drawing.Color.Red;
            this.txtTotalPriceVn.Location = new System.Drawing.Point(203, 37);
            this.txtTotalPriceVn.Name = "txtTotalPriceVn";
            this.txtTotalPriceVn.Size = new System.Drawing.Size(100, 28);
            this.txtTotalPriceVn.TabIndex = 9;
            this.txtTotalPriceVn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotalPriceEn
            // 
            this.txtTotalPriceEn.BackColor = System.Drawing.SystemColors.Menu;
            this.txtTotalPriceEn.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalPriceEn.ForeColor = System.Drawing.Color.Red;
            this.txtTotalPriceEn.Location = new System.Drawing.Point(203, 4);
            this.txtTotalPriceEn.Name = "txtTotalPriceEn";
            this.txtTotalPriceEn.Size = new System.Drawing.Size(100, 28);
            this.txtTotalPriceEn.TabIndex = 8;
            this.txtTotalPriceEn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnCheckOut
            // 
            this.btnCheckOut.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckOut.Location = new System.Drawing.Point(306, 4);
            this.btnCheckOut.Name = "btnCheckOut";
            this.btnCheckOut.Size = new System.Drawing.Size(69, 61);
            this.btnCheckOut.TabIndex = 7;
            this.btnCheckOut.Text = "CHECK OUT";
            this.btnCheckOut.UseVisualStyleBackColor = true;
            this.btnCheckOut.Click += new System.EventHandler(this.btnCheckOut_Click);
            // 
            // btnDiscount
            // 
            this.btnDiscount.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDiscount.Location = new System.Drawing.Point(114, 4);
            this.btnDiscount.Name = "btnDiscount";
            this.btnDiscount.Size = new System.Drawing.Size(86, 28);
            this.btnDiscount.TabIndex = 6;
            this.btnDiscount.Text = "Discount";
            this.btnDiscount.UseVisualStyleBackColor = true;
            // 
            // btnSwitchTable
            // 
            this.btnSwitchTable.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSwitchTable.Location = new System.Drawing.Point(3, 4);
            this.btnSwitchTable.Name = "btnSwitchTable";
            this.btnSwitchTable.Size = new System.Drawing.Size(105, 28);
            this.btnSwitchTable.TabIndex = 5;
            this.btnSwitchTable.Text = "Switch Table";
            this.btnSwitchTable.UseVisualStyleBackColor = true;
            this.btnSwitchTable.Click += new System.EventHandler(this.btnSwitchTable_Click);
            // 
            // nmDiscount
            // 
            this.nmDiscount.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nmDiscount.Location = new System.Drawing.Point(117, 38);
            this.nmDiscount.Name = "nmDiscount";
            this.nmDiscount.Size = new System.Drawing.Size(83, 28);
            this.nmDiscount.TabIndex = 4;
            // 
            // cbSwitchTable
            // 
            this.cbSwitchTable.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSwitchTable.FormattingEnabled = true;
            this.cbSwitchTable.Location = new System.Drawing.Point(3, 38);
            this.cbSwitchTable.Name = "cbSwitchTable";
            this.cbSwitchTable.Size = new System.Drawing.Size(105, 28);
            this.cbSwitchTable.TabIndex = 1;
            // 
            // flpTable
            // 
            this.flpTable.Location = new System.Drawing.Point(12, 32);
            this.flpTable.Name = "flpTable";
            this.flpTable.Size = new System.Drawing.Size(373, 471);
            this.flpTable.TabIndex = 5;
            // 
            // fTableManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 521);
            this.Controls.Add(this.flpTable);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "fTableManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fAdmin";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nmCount)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmDiscount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountInformationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showInformationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox cbCategoryFood;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.NumericUpDown nmCount;
        private System.Windows.Forms.Button btnAddFood;
        private System.Windows.Forms.ComboBox cbFood;
        private System.Windows.Forms.Button btnCheckOut;
        private System.Windows.Forms.Button btnDiscount;
        private System.Windows.Forms.Button btnSwitchTable;
        private System.Windows.Forms.NumericUpDown nmDiscount;
        private System.Windows.Forms.ComboBox cbSwitchTable;
        private System.Windows.Forms.ListView lsvBill;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader count;
        private System.Windows.Forms.ColumnHeader price;
        private System.Windows.Forms.ColumnHeader pay;
        private System.Windows.Forms.TextBox txtTotalPriceEn;
        private System.Windows.Forms.TextBox txtTotalPriceVn;
        private System.Windows.Forms.FlowLayoutPanel flpTable;
    }
}