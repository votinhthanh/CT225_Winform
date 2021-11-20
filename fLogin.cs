using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShopManager
{
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
            this.txtPassWord.Text = "1";
            this.txtUserName.Text = "Admin";
        }
        #region Methods
            /*TẠO HÀM BĂM MẬT KHẨU ĐỂ KIỂM TRA ĐĂNG NHẬP*/
            public string EncodingPassword(string pass_input)
            {
                byte[] temp = ASCIIEncoding.ASCII.GetBytes(pass_input);
                byte[] hasData = new MD5CryptoServiceProvider().ComputeHash(temp);

                String pass = "";

                foreach (byte item in hasData)
                {
                    pass += item;
                }

                char[] arr = pass.ToCharArray(); // chuỗi thành mảng ký tự
                Array.Reverse(arr); // đảo ngược mảng
                return new string(arr);
            }

            /*TẠO HÀM LẤY RA TÀI KHOẢN BẰNG TÊN ĐĂNG NHẬP*/
            public Account getAccountByUserName(string username)
            {
                string connectSTR = @"Data Source=.\sqlexpress;Initial Catalog=Coffee_Shop_Manager;Integrated Security=True";

                SqlConnection connection = new SqlConnection(connectSTR);

                connection.Open();

                string query = "select * from Account where UserName = N'" + username + "'";
                SqlCommand command = new SqlCommand(query, connection);

                DataTable data = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(data);

                connection.Close();

                foreach (DataRow item in data.Rows)
                {
                    return new Account(item);
                }
                return null;
            }

            /*TẠO HÀM KIỂM TRA ĐIỀU KIỆN ĐĂNG NHẬP*/
            bool Login(string username, string password)
            {
                string connectSTR = @"Data Source=.\sqlexpress;Initial Catalog=Coffee_Shop_Manager;Integrated Security=True";

                SqlConnection connection = new SqlConnection(connectSTR);

                connection.Open();

                string query = "EXEC USP_CheckLogin @userName = N'" + username + "', @password=N'" + password + "'";
                SqlCommand command = new SqlCommand(query, connection);

                DataTable data = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(data);

                connection.Close();

                return data.Rows.Count > 0;
            }
        #endregion
        #region Events
            /*SỰ KIÊN ẤN BUTTON "EXIT"*/
            private void btnExit_Click(object sender, EventArgs e)
            {
                Application.Exit();
            }
            /*SỰ KIÊN ĐÓNG FORM*/
            private void Login_FormClosing(object sender, FormClosingEventArgs e)
            {
                if(MessageBox.Show("Do you really want to exit?", "Alert !", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
                {
                    e.Cancel = true;
                }
            }
            /*SỰ KIÊN ÂN BUTTON "LOGIN"*/
            private void btnLogin_Click(object sender, EventArgs e)
            {
                string username = txtUserName.Text;
                string password = EncodingPassword(txtPassWord.Text);

                if (Login(username, password)){
                    Account loginAccount = getAccountByUserName(username);
                    fTableManager f = new fTableManager(loginAccount);
                    this.Hide();
                    f.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Failed to login !!!");
                }
            
            }            
        #endregion

    }
}
