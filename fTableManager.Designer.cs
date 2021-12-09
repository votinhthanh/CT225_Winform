
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fTableManager));
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
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.nmCount = new System.Windows.Forms.NumericUpDown();
            this.btnAddFood = new System.Windows.Forms.Button();
            this.cbFood = new System.Windows.Forms.ComboBox();
            this.cbCategoryFood = new System.Windows.Forms.ComboBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cbChangeTable = new System.Windows.Forms.ComboBox();
            this.btnCheckOut = new System.Windows.Forms.Button();
            this.btnChangeTable = new System.Windows.Forms.Button();
            this.txtTotalPrice = new System.Windows.Forms.TextBox();
            this.nmDiscount = new System.Windows.Forms.NumericUpDown();
            this.none = new System.Windows.Forms.Button();
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
            this.menuStrip1.Size = new System.Drawing.Size(1262, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.BackColor = System.Drawing.Color.SteelBlue;
            this.adminToolStripMenuItem.Checked = true;
            this.adminToolStripMenuItem.CheckOnClick = true;
            this.adminToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.adminToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Window;
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(106, 29);
            this.adminToolStripMenuItem.Text = "Quản trị";
            this.adminToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.adminToolStripMenuItem.Click += new System.EventHandler(this.adminToolStripMenuItem_Click);
            // 
            // accountInformationToolStripMenuItem
            // 
            this.accountInformationToolStripMenuItem.BackColor = System.Drawing.Color.SteelBlue;
            this.accountInformationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showInformationToolStripMenuItem,
            this.logoutToolStripMenuItem});
            this.accountInformationToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accountInformationToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Window;
            this.accountInformationToolStripMenuItem.Name = "accountInformationToolStripMenuItem";
            this.accountInformationToolStripMenuItem.Size = new System.Drawing.Size(212, 29);
            this.accountInformationToolStripMenuItem.Text = "Thông tin tài khoản";
            // 
            // showInformationToolStripMenuItem
            // 
            this.showInformationToolStripMenuItem.BackColor = System.Drawing.Color.SkyBlue;
            this.showInformationToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showInformationToolStripMenuItem.Name = "showInformationToolStripMenuItem";
            this.showInformationToolStripMenuItem.Size = new System.Drawing.Size(224, 30);
            this.showInformationToolStripMenuItem.Text = "Xem thông tin";
            this.showInformationToolStripMenuItem.Click += new System.EventHandler(this.showInformationToolStripMenuItem_Click);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.BackColor = System.Drawing.Color.SkyBlue;
            this.logoutToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(224, 30);
            this.logoutToolStripMenuItem.Text = "Đăng xuất";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lsvBill);
            this.panel2.Location = new System.Drawing.Point(628, 123);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(622, 439);
            this.panel2.TabIndex = 2;
            // 
            // lsvBill
            // 
            this.lsvBill.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.name,
            this.count,
            this.price,
            this.pay});
            this.lsvBill.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsvBill.GridLines = true;
            this.lsvBill.HideSelection = false;
            this.lsvBill.Location = new System.Drawing.Point(9, 3);
            this.lsvBill.Name = "lsvBill";
            this.lsvBill.Size = new System.Drawing.Size(606, 433);
            this.lsvBill.TabIndex = 0;
            this.lsvBill.UseCompatibleStateImageBehavior = false;
            this.lsvBill.View = System.Windows.Forms.View.Details;
            // 
            // name
            // 
            this.name.Text = "Tên món ăn";
            this.name.Width = 221;
            // 
            // count
            // 
            this.count.Text = "Số lượng";
            this.count.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.count.Width = 76;
            // 
            // price
            // 
            this.price.Text = "Giá";
            this.price.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.price.Width = 126;
            // 
            // pay
            // 
            this.pay.Text = "Thành tiền";
            this.pay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.pay.Width = 177;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.button3);
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.nmCount);
            this.panel3.Controls.Add(this.btnAddFood);
            this.panel3.Controls.Add(this.cbFood);
            this.panel3.Controls.Add(this.cbCategoryFood);
            this.panel3.Location = new System.Drawing.Point(628, 38);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(622, 79);
            this.panel3.TabIndex = 3;
            // 
            // button3
            // 
            this.button3.AutoSize = true;
            this.button3.BackColor = System.Drawing.SystemColors.Control;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(9, 41);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(146, 33);
            this.button3.TabIndex = 9;
            this.button3.Text = "Chọn món ăn:";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.AutoSize = true;
            this.button2.BackColor = System.Drawing.SystemColors.Control;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(9, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(146, 33);
            this.button2.TabIndex = 8;
            this.button2.Text = "Chọn danh mục:";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(407, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 33);
            this.button1.TabIndex = 7;
            this.button1.Text = "Số lượng";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // nmCount
            // 
            this.nmCount.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nmCount.Location = new System.Drawing.Point(407, 42);
            this.nmCount.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nmCount.Name = "nmCount";
            this.nmCount.Size = new System.Drawing.Size(99, 33);
            this.nmCount.TabIndex = 3;
            this.nmCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nmCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmCount.ValueChanged += new System.EventHandler(this.nmCount_ValueChanged);
            // 
            // btnAddFood
            // 
            this.btnAddFood.BackColor = System.Drawing.Color.Turquoise;
            this.btnAddFood.FlatAppearance.BorderSize = 0;
            this.btnAddFood.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddFood.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddFood.Location = new System.Drawing.Point(512, 3);
            this.btnAddFood.Name = "btnAddFood";
            this.btnAddFood.Size = new System.Drawing.Size(103, 72);
            this.btnAddFood.TabIndex = 2;
            this.btnAddFood.Text = "Thêm món";
            this.btnAddFood.UseVisualStyleBackColor = false;
            this.btnAddFood.Click += new System.EventHandler(this.btnAddFood_Click);
            // 
            // cbFood
            // 
            this.cbFood.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbFood.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFood.FormattingEnabled = true;
            this.cbFood.Location = new System.Drawing.Point(159, 41);
            this.cbFood.Name = "cbFood";
            this.cbFood.Size = new System.Drawing.Size(239, 33);
            this.cbFood.TabIndex = 1;
            // 
            // cbCategoryFood
            // 
            this.cbCategoryFood.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbCategoryFood.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCategoryFood.FormattingEnabled = true;
            this.cbCategoryFood.Location = new System.Drawing.Point(159, 3);
            this.cbCategoryFood.Name = "cbCategoryFood";
            this.cbCategoryFood.Size = new System.Drawing.Size(239, 33);
            this.cbCategoryFood.TabIndex = 0;
            this.cbCategoryFood.UseWaitCursor = true;
            this.cbCategoryFood.SelectedIndexChanged += new System.EventHandler(this.cbCategoryFood_SelectedIndexChanged);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.cbChangeTable);
            this.panel4.Controls.Add(this.btnCheckOut);
            this.panel4.Controls.Add(this.btnChangeTable);
            this.panel4.Controls.Add(this.txtTotalPrice);
            this.panel4.Controls.Add(this.nmDiscount);
            this.panel4.Controls.Add(this.none);
            this.panel4.Location = new System.Drawing.Point(628, 568);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(622, 93);
            this.panel4.TabIndex = 4;
            // 
            // cbChangeTable
            // 
            this.cbChangeTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbChangeTable.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbChangeTable.FormattingEnabled = true;
            this.cbChangeTable.Location = new System.Drawing.Point(9, 58);
            this.cbChangeTable.Name = "cbChangeTable";
            this.cbChangeTable.Size = new System.Drawing.Size(122, 33);
            this.cbChangeTable.TabIndex = 10;
            // 
            // btnCheckOut
            // 
            this.btnCheckOut.BackColor = System.Drawing.Color.Turquoise;
            this.btnCheckOut.FlatAppearance.BorderSize = 0;
            this.btnCheckOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckOut.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckOut.Location = new System.Drawing.Point(137, 42);
            this.btnCheckOut.Name = "btnCheckOut";
            this.btnCheckOut.Size = new System.Drawing.Size(478, 49);
            this.btnCheckOut.TabIndex = 7;
            this.btnCheckOut.Text = "THANH TOÁN";
            this.btnCheckOut.UseVisualStyleBackColor = false;
            this.btnCheckOut.Click += new System.EventHandler(this.btnCheckOut_Click);
            // 
            // btnChangeTable
            // 
            this.btnChangeTable.BackColor = System.Drawing.Color.SteelBlue;
            this.btnChangeTable.FlatAppearance.BorderSize = 0;
            this.btnChangeTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangeTable.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangeTable.ForeColor = System.Drawing.SystemColors.Window;
            this.btnChangeTable.Location = new System.Drawing.Point(9, 3);
            this.btnChangeTable.Name = "btnChangeTable";
            this.btnChangeTable.Size = new System.Drawing.Size(122, 54);
            this.btnChangeTable.TabIndex = 8;
            this.btnChangeTable.Text = "Chuyển/gộp bàn ";
            this.btnChangeTable.UseVisualStyleBackColor = false;
            this.btnChangeTable.Click += new System.EventHandler(this.btnChangeTable_Click);
            // 
            // txtTotalPrice
            // 
            this.txtTotalPrice.BackColor = System.Drawing.SystemColors.Menu;
            this.txtTotalPrice.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalPrice.ForeColor = System.Drawing.Color.Red;
            this.txtTotalPrice.Location = new System.Drawing.Point(341, 4);
            this.txtTotalPrice.Name = "txtTotalPrice";
            this.txtTotalPrice.ReadOnly = true;
            this.txtTotalPrice.Size = new System.Drawing.Size(274, 34);
            this.txtTotalPrice.TabIndex = 8;
            this.txtTotalPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nmDiscount
            // 
            this.nmDiscount.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nmDiscount.Location = new System.Drawing.Point(237, 5);
            this.nmDiscount.Name = "nmDiscount";
            this.nmDiscount.Size = new System.Drawing.Size(98, 34);
            this.nmDiscount.TabIndex = 4;
            this.nmDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nmDiscount.ValueChanged += new System.EventHandler(this.nmDiscount_ValueChanged);
            // 
            // none
            // 
            this.none.BackColor = System.Drawing.Color.Salmon;
            this.none.FlatAppearance.BorderSize = 0;
            this.none.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.none.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.none.ForeColor = System.Drawing.SystemColors.Window;
            this.none.Location = new System.Drawing.Point(137, 4);
            this.none.Name = "none";
            this.none.Size = new System.Drawing.Size(94, 35);
            this.none.TabIndex = 6;
            this.none.Text = "Giảm giá";
            this.none.UseVisualStyleBackColor = false;
            // 
            // flpTable
            // 
            this.flpTable.Location = new System.Drawing.Point(22, 38);
            this.flpTable.Name = "flpTable";
            this.flpTable.Size = new System.Drawing.Size(600, 623);
            this.flpTable.TabIndex = 5;
            // 
            // fTableManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.flpTable);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "fTableManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý quán";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
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
        private System.Windows.Forms.Button none;
        private System.Windows.Forms.NumericUpDown nmDiscount;
        private System.Windows.Forms.ListView lsvBill;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader count;
        private System.Windows.Forms.ColumnHeader price;
        private System.Windows.Forms.ColumnHeader pay;
        private System.Windows.Forms.TextBox txtTotalPrice;
        private System.Windows.Forms.FlowLayoutPanel flpTable;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cbChangeTable;
        private System.Windows.Forms.Button btnChangeTable;
    }
}