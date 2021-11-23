
namespace CoffeeShopManager
{
    partial class fChangeTable
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
            this.btnSwitchTable = new System.Windows.Forms.Button();
            this.btnMergeTable = new System.Windows.Forms.Button();
            this.txtChangeTable = new System.Windows.Forms.TextBox();
            this.btnExits = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSwitchTable
            // 
            this.btnSwitchTable.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSwitchTable.Location = new System.Drawing.Point(68, 144);
            this.btnSwitchTable.Name = "btnSwitchTable";
            this.btnSwitchTable.Size = new System.Drawing.Size(105, 45);
            this.btnSwitchTable.TabIndex = 0;
            this.btnSwitchTable.Text = "CHUYỂN BÀN";
            this.btnSwitchTable.UseVisualStyleBackColor = true;
            this.btnSwitchTable.Click += new System.EventHandler(this.btnSwitchTable_Click);
            // 
            // btnMergeTable
            // 
            this.btnMergeTable.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMergeTable.Location = new System.Drawing.Point(203, 144);
            this.btnMergeTable.Name = "btnMergeTable";
            this.btnMergeTable.Size = new System.Drawing.Size(105, 45);
            this.btnMergeTable.TabIndex = 1;
            this.btnMergeTable.Text = "GỘP BÀN";
            this.btnMergeTable.UseVisualStyleBackColor = true;
            this.btnMergeTable.Click += new System.EventHandler(this.btnMergeTable_Click);
            // 
            // txtChangeTable
            // 
            this.txtChangeTable.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChangeTable.Location = new System.Drawing.Point(33, 85);
            this.txtChangeTable.Name = "txtChangeTable";
            this.txtChangeTable.ReadOnly = true;
            this.txtChangeTable.Size = new System.Drawing.Size(447, 33);
            this.txtChangeTable.TabIndex = 2;
            this.txtChangeTable.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnExits
            // 
            this.btnExits.BackColor = System.Drawing.Color.Salmon;
            this.btnExits.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExits.Location = new System.Drawing.Point(339, 144);
            this.btnExits.Name = "btnExits";
            this.btnExits.Size = new System.Drawing.Size(105, 45);
            this.btnExits.TabIndex = 3;
            this.btnExits.Text = "THOÁT";
            this.btnExits.UseVisualStyleBackColor = false;
            this.btnExits.Click += new System.EventHandler(this.btnExits_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightSeaGreen;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.button1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(174, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(162, 38);
            this.button1.TabIndex = 4;
            this.button1.Text = "THAY ĐỔI BÀN";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // fChangeTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 211);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnExits);
            this.Controls.Add(this.txtChangeTable);
            this.Controls.Add(this.btnMergeTable);
            this.Controls.Add(this.btnSwitchTable);
            this.Name = "fChangeTable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thay đổi bàn";
            this.Load += new System.EventHandler(this.fChangeTable_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSwitchTable;
        private System.Windows.Forms.Button btnMergeTable;
        private System.Windows.Forms.TextBox txtChangeTable;
        private System.Windows.Forms.Button btnExits;
        private System.Windows.Forms.Button button1;
    }
}