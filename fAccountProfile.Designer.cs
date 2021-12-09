
namespace CoffeeShopManager
{
    partial class fAccountProfile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fAccountProfile));
            this.pnlPass = new System.Windows.Forms.Panel();
            this.txtDisplayName = new System.Windows.Forms.TextBox();
            this.passWord = new System.Windows.Forms.Label();
            this.pnlUserName = new System.Windows.Forms.Panel();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.userName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnUpdateAccount = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtRetypeNewPass = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtNewPass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlPass.SuspendLayout();
            this.pnlUserName.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlPass
            // 
            this.pnlPass.Controls.Add(this.txtDisplayName);
            this.pnlPass.Controls.Add(this.passWord);
            this.pnlPass.Location = new System.Drawing.Point(37, 110);
            this.pnlPass.Name = "pnlPass";
            this.pnlPass.Size = new System.Drawing.Size(535, 58);
            this.pnlPass.TabIndex = 4;
            // 
            // txtDisplayName
            // 
            this.txtDisplayName.BackColor = System.Drawing.Color.Turquoise;
            this.txtDisplayName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDisplayName.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDisplayName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtDisplayName.Location = new System.Drawing.Point(181, 12);
            this.txtDisplayName.Name = "txtDisplayName";
            this.txtDisplayName.Size = new System.Drawing.Size(347, 34);
            this.txtDisplayName.TabIndex = 2;
            // 
            // passWord
            // 
            this.passWord.AutoSize = true;
            this.passWord.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passWord.Location = new System.Drawing.Point(3, 15);
            this.passWord.Name = "passWord";
            this.passWord.Size = new System.Drawing.Size(133, 27);
            this.passWord.TabIndex = 0;
            this.passWord.Text = "Tên hiển thị:";
            // 
            // pnlUserName
            // 
            this.pnlUserName.Controls.Add(this.txtUserName);
            this.pnlUserName.Controls.Add(this.userName);
            this.pnlUserName.Location = new System.Drawing.Point(37, 30);
            this.pnlUserName.Name = "pnlUserName";
            this.pnlUserName.Size = new System.Drawing.Size(535, 58);
            this.pnlUserName.TabIndex = 3;
            // 
            // txtUserName
            // 
            this.txtUserName.BackColor = System.Drawing.Color.Turquoise;
            this.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserName.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtUserName.Location = new System.Drawing.Point(181, 12);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.ReadOnly = true;
            this.txtUserName.Size = new System.Drawing.Size(347, 34);
            this.txtUserName.TabIndex = 1;
            // 
            // userName
            // 
            this.userName.AutoSize = true;
            this.userName.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userName.Location = new System.Drawing.Point(3, 15);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(160, 27);
            this.userName.TabIndex = 0;
            this.userName.Text = "Tên đăng nhập:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.btnUpdateAccount);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.pnlUserName);
            this.panel1.Controls.Add(this.pnlPass);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(611, 515);
            this.panel1.TabIndex = 5;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Red;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.SystemColors.Window;
            this.btnExit.Location = new System.Drawing.Point(435, 439);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(130, 48);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnUpdateAccount
            // 
            this.btnUpdateAccount.BackColor = System.Drawing.Color.SteelBlue;
            this.btnUpdateAccount.FlatAppearance.BorderSize = 0;
            this.btnUpdateAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateAccount.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateAccount.ForeColor = System.Drawing.SystemColors.Window;
            this.btnUpdateAccount.Location = new System.Drawing.Point(45, 439);
            this.btnUpdateAccount.Name = "btnUpdateAccount";
            this.btnUpdateAccount.Size = new System.Drawing.Size(384, 48);
            this.btnUpdateAccount.TabIndex = 6;
            this.btnUpdateAccount.Text = "Cập nhật";
            this.btnUpdateAccount.UseVisualStyleBackColor = false;
            this.btnUpdateAccount.Click += new System.EventHandler(this.btnUpdateAccount_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txtRetypeNewPass);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Location = new System.Drawing.Point(37, 350);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(535, 58);
            this.panel4.TabIndex = 7;
            // 
            // txtRetypeNewPass
            // 
            this.txtRetypeNewPass.BackColor = System.Drawing.Color.Turquoise;
            this.txtRetypeNewPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRetypeNewPass.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRetypeNewPass.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtRetypeNewPass.Location = new System.Drawing.Point(181, 12);
            this.txtRetypeNewPass.Name = "txtRetypeNewPass";
            this.txtRetypeNewPass.Size = new System.Drawing.Size(347, 34);
            this.txtRetypeNewPass.TabIndex = 5;
            this.txtRetypeNewPass.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 27);
            this.label3.TabIndex = 0;
            this.label3.Text = "Nhập lại";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtPassword);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(37, 190);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(535, 58);
            this.panel2.TabIndex = 5;
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.Turquoise;
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtPassword.Location = new System.Drawing.Point(181, 12);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(347, 34);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhập mật khẩu:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtNewPass);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(37, 270);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(535, 58);
            this.panel3.TabIndex = 6;
            // 
            // txtNewPass
            // 
            this.txtNewPass.BackColor = System.Drawing.Color.Turquoise;
            this.txtNewPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNewPass.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewPass.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtNewPass.Location = new System.Drawing.Point(181, 12);
            this.txtNewPass.Name = "txtNewPass";
            this.txtNewPass.Size = new System.Drawing.Size(347, 34);
            this.txtNewPass.TabIndex = 4;
            this.txtNewPass.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 27);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mật khẩu mới:";
            // 
            // fAccountProfile
            // 
            this.AcceptButton = this.btnUpdateAccount;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(635, 539);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fAccountProfile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông tin cá nhân";
            this.pnlPass.ResumeLayout(false);
            this.pnlPass.PerformLayout();
            this.pnlUserName.ResumeLayout(false);
            this.pnlUserName.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlPass;
        private System.Windows.Forms.TextBox txtDisplayName;
        private System.Windows.Forms.Label passWord;
        private System.Windows.Forms.Panel pnlUserName;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label userName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtNewPass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtRetypeNewPass;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnUpdateAccount;
    }
}