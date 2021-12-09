
namespace CoffeeShopManager
{
    partial class fLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fLogin));
            this.pnlLogin = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.pnlPass = new System.Windows.Forms.Panel();
            this.txtPassWord = new System.Windows.Forms.TextBox();
            this.passWord = new System.Windows.Forms.Label();
            this.pnlUserName = new System.Windows.Forms.Panel();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.userName = new System.Windows.Forms.Label();
            this.pnlLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlPass.SuspendLayout();
            this.pnlUserName.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLogin
            // 
            this.pnlLogin.Controls.Add(this.pictureBox1);
            this.pnlLogin.Controls.Add(this.btnExit);
            this.pnlLogin.Controls.Add(this.btnLogin);
            this.pnlLogin.Controls.Add(this.pnlPass);
            this.pnlLogin.Controls.Add(this.pnlUserName);
            this.pnlLogin.Location = new System.Drawing.Point(45, 12);
            this.pnlLogin.Name = "pnlLogin";
            this.pnlLogin.Size = new System.Drawing.Size(648, 390);
            this.pnlLogin.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CoffeeShopManager.Properties.Resources.label_login;
            this.pictureBox1.Location = new System.Drawing.Point(255, 38);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(155, 49);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // btnExit
            // 
            this.btnExit.AutoEllipsis = true;
            this.btnExit.BackColor = System.Drawing.Color.Red;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.SystemColors.Window;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.SystemColors.Window;
            this.btnExit.Location = new System.Drawing.Point(394, 327);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(97, 40);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.AutoEllipsis = true;
            this.btnLogin.BackColor = System.Drawing.Color.DarkTurquoise;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Location = new System.Drawing.Point(158, 327);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(230, 40);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "Đăng nhập";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // pnlPass
            // 
            this.pnlPass.Controls.Add(this.txtPassWord);
            this.pnlPass.Controls.Add(this.passWord);
            this.pnlPass.Location = new System.Drawing.Point(151, 222);
            this.pnlPass.Name = "pnlPass";
            this.pnlPass.Size = new System.Drawing.Size(350, 80);
            this.pnlPass.TabIndex = 2;
            // 
            // txtPassWord
            // 
            this.txtPassWord.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassWord.Location = new System.Drawing.Point(7, 43);
            this.txtPassWord.Name = "txtPassWord";
            this.txtPassWord.Size = new System.Drawing.Size(333, 34);
            this.txtPassWord.TabIndex = 2;
            this.txtPassWord.UseSystemPasswordChar = true;
            // 
            // passWord
            // 
            this.passWord.AutoSize = true;
            this.passWord.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passWord.Location = new System.Drawing.Point(3, 16);
            this.passWord.Name = "passWord";
            this.passWord.Size = new System.Drawing.Size(83, 21);
            this.passWord.TabIndex = 0;
            this.passWord.Text = "Mật khẩu:";
            // 
            // pnlUserName
            // 
            this.pnlUserName.Controls.Add(this.txtUserName);
            this.pnlUserName.Controls.Add(this.userName);
            this.pnlUserName.Location = new System.Drawing.Point(151, 136);
            this.pnlUserName.Name = "pnlUserName";
            this.pnlUserName.Size = new System.Drawing.Size(350, 80);
            this.pnlUserName.TabIndex = 0;
            // 
            // txtUserName
            // 
            this.txtUserName.CausesValidation = false;
            this.txtUserName.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.Location = new System.Drawing.Point(7, 43);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(333, 34);
            this.txtUserName.TabIndex = 2;
            // 
            // userName
            // 
            this.userName.AutoSize = true;
            this.userName.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userName.Location = new System.Drawing.Point(3, 15);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(125, 21);
            this.userName.TabIndex = 0;
            this.userName.Text = "Tên đăng nhập:";
            // 
            // fLogin
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(739, 414);
            this.Controls.Add(this.pnlLogin);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Login_FormClosing);
            this.pnlLogin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlPass.ResumeLayout(false);
            this.pnlPass.PerformLayout();
            this.pnlUserName.ResumeLayout(false);
            this.pnlUserName.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLogin;
        private System.Windows.Forms.Panel pnlUserName;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label userName;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Panel pnlPass;
        private System.Windows.Forms.TextBox txtPassWord;
        private System.Windows.Forms.Label passWord;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

