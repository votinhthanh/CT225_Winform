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
    public partial class fAccountProfile : Form
    {
        private Account loginAccount;


        public Account LoginAccount
        {
            get { return loginAccount; }
            set
            {
                loginAccount = value;
            }
        }
        public fAccountProfile(Account acc)
        {
            InitializeComponent();
            LoginAccount = acc;
            LoadAccount();
        }
        #region Methods
        Account getAccount(string username)
        {
            string connectSTR = @"Data Source=.\sqlexpress;Initial Catalog=Coffee_Shop_Manager;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectSTR);
            connection.Open();
            string query = "SELECT * FROM Account WHERE UserName = N'" + username + "'";
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
        public bool UpdateAccount(string username, string displayName, string password, string newpass)
        {
            string connectSTR = @"Data Source=.\sqlexpress;Initial Catalog=Coffee_Shop_Manager;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectSTR);

            connection.Open();
            string query = "";
            if (newpass.Equals(""))
            {
                query += "UPDATE Account SET DisplayName = N'" + displayName + "' WHERE UserName = N'" + username + "' AND PassWord = N'" + password + "'";
            }
            else query = "UPDATE Account SET DisplayName = N'"+ displayName+"', PassWord = N'"+ newpass + "' WHERE UserName = N'" + username + "' AND PassWord = N'" + password + "'";
            SqlCommand command = new SqlCommand(query, connection);
            int result = 0;

            result = (int)command.ExecuteNonQuery();

            connection.Close();

            return result > 0;
        }
        void LoadAccount()
        {
            txtUserName.Text = LoginAccount.UserName;
            txtDisplayName.Text = LoginAccount.DisplayName;
        }
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
        #endregion

        #region Events
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private event EventHandler<AccountEvent> updateAccountEvent;
        public event EventHandler<AccountEvent> UpdateAccountEvent
        {
            add { updateAccountEvent += value; }
            remove { updateAccountEvent -= value; }
        }
        private void btnUpdateAccount_Click(object sender, EventArgs e)
        {
            string display_name = txtDisplayName.Text;
            string current_password = EncodingPassword(txtPassword.Text);
            string new_password = txtNewPass.Text;
            string reTypingPassword = txtRetypeNewPass.Text;
            string username = txtUserName.Text;
            if (!reTypingPassword.Equals(new_password))
            {
                new_password = reTypingPassword = null;
                MessageBox.Show("Xác thực mật khẩu mới KHÔNG thành công !!!", "Báo lỗi !");
                return;
            }
            if (UpdateAccount(username, display_name, current_password, EncodingPassword(new_password)))
            {
                MessageBox.Show("Cập nhật tài khoản thành công !!!", "Thông báo !");
                if (updateAccountEvent != null)
                {
                    updateAccountEvent(this, new AccountEvent(getAccount(username)));
                }
            }
            else
            {
                MessageBox.Show("Cập nhật tài khoản KHÔNG thành công !!!", "Báo lỗi !");
            }
        }

        #endregion
        #region AccountEvents
        public class AccountEvent : EventArgs
        {
            private Account acc;
            public Account Acc
            {
                get { return acc; }
                set { acc = value; }
            }
            public AccountEvent(Account acc)
            {
                this.Acc = acc;
            }
        }
        #endregion

    }
}
