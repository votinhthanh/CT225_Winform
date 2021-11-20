
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
            this.pnlPass.Location = new System.Drawing.Point(37, 108);
            this.pnlPass.Name = "pnlPass";
            this.pnlPass.Size = new System.Drawing.Size(535, 58);
            this.pnlPass.TabIndex = 4;
            // 
            // txtDisplayName
            // 
            this.txtDisplayName.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDisplayName.Location = new System.Drawing.Point(195, 18);
            this.txtDisplayName.Name = "txtDisplayName";
            this.txtDisplayName.Size = new System.Drawing.Size(333, 28);
            this.txtDisplayName.TabIndex = 2;
            // 
            // passWord
            // 
            this.passWord.AutoSize = true;
            this.passWord.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passWord.Location = new System.Drawing.Point(26, 21);
            this.passWord.Name = "passWord";
            this.passWord.Size = new System.Drawing.Size(114, 21);
            this.passWord.TabIndex = 0;
            this.passWord.Text = "Display name:";
            // 
            // pnlUserName
            // 
            this.pnlUserName.Controls.Add(this.txtUserName);
            this.pnlUserName.Controls.Add(this.userName);
            this.pnlUserName.Location = new System.Drawing.Point(37, 32);
            this.pnlUserName.Name = "pnlUserName";
            this.pnlUserName.Size = new System.Drawing.Size(535, 58);
            this.pnlUserName.TabIndex = 3;
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.Location = new System.Drawing.Point(195, 18);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(333, 28);
            this.txtUserName.TabIndex = 1;
            // 
            // userName
            // 
            this.userName.AutoSize = true;
            this.userName.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userName.Location = new System.Drawing.Point(26, 21);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(88, 21);
            this.userName.TabIndex = 0;
            this.userName.Text = "Username:";
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
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(435, 439);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(109, 48);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnUpdateAccount
            // 
            this.btnUpdateAccount.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateAccount.Location = new System.Drawing.Point(272, 439);
            this.btnUpdateAccount.Name = "btnUpdateAccount";
            this.btnUpdateAccount.Size = new System.Drawing.Size(109, 48);
            this.btnUpdateAccount.TabIndex = 6;
            this.btnUpdateAccount.Text = "Update";
            this.btnUpdateAccount.UseVisualStyleBackColor = true;
            this.btnUpdateAccount.Click += new System.EventHandler(this.btnUpdateAccount_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txtRetypeNewPass);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Location = new System.Drawing.Point(37, 340);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(535, 58);
            this.panel4.TabIndex = 7;
            // 
            // txtRetypeNewPass
            // 
            this.txtRetypeNewPass.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRetypeNewPass.Location = new System.Drawing.Point(195, 18);
            this.txtRetypeNewPass.Name = "txtRetypeNewPass";
            this.txtRetypeNewPass.Size = new System.Drawing.Size(333, 28);
            this.txtRetypeNewPass.TabIndex = 5;
            this.txtRetypeNewPass.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 21);
            this.label3.TabIndex = 0;
            this.label3.Text = "Retype:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtPassword);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(37, 187);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(535, 58);
            this.panel2.TabIndex = 5;
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(195, 18);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(333, 28);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Password:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtNewPass);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(37, 263);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(535, 58);
            this.panel3.TabIndex = 6;
            // 
            // txtNewPass
            // 
            this.txtNewPass.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewPass.Location = new System.Drawing.Point(195, 18);
            this.txtNewPass.Name = "txtNewPass";
            this.txtNewPass.Size = new System.Drawing.Size(333, 28);
            this.txtNewPass.TabIndex = 4;
            this.txtNewPass.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "New password:";
            // 
            // fAccountProfile
            // 
            this.AcceptButton = this.btnUpdateAccount;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(635, 539);
            this.Controls.Add(this.panel1);
            this.Name = "fAccountProfile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fAccountProfile";
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