using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
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
                changeAccount(loginAccount.Type);
            }
        }
        
        public fAccountProfile(Account acc)
        {
            InitializeComponent();
            LoginAccount = acc;
        }

        /* Method for Account Profile*/
        #region Methods
        void changeAccount(int type)
        {
            txtUserName.Text = LoginAccount.UserName;
            txtDisplayName.Text = LoginAccount.DisplayName;
        }
        void updateAccount()
        {
            string displayName = txtDisplayName.Text;
            string password = txtPassword.Text;
            string newpass = txtNewPass.Text;
            string reenterPass = txtRetypeNewPass.Text;
            string username = txtUserName.Text;
            if (!newpass.Equals(reenterPass))
            {
                MessageBox.Show("Mật khẩu không khớp", "Thông báo");
            }
            else
            {
                if (getUpdateAccount(username, displayName, password, newpass))
                {
                    MessageBox.Show("Cập nhật thành công", "Thông báo");
                    if(updateAccountEvent != null)
                    {
                        updateAccountEvent(this, new AccountEvent(getAccountByUserName(username)));
                    }
                }
                else
                {
                    MessageBox.Show("Mật khẩu không chính xác", "Thông báo");
                }
            }

        }

        public bool getUpdateAccount(string username, string displayName, string password, string newpass)
        {
            string connectSTR = @"Data Source=.\sqlexpress;Initial Catalog=Coffee_Shop_Manager;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectSTR);

            connection.Open();

            string query = "EXEC USP_UpdateAccount N'" + username + "', N'" + displayName + "', '" + password + "', '" + newpass + "'";
            SqlCommand command = new SqlCommand(query, connection);
            int result = 0;

            result = (int)command.ExecuteNonQuery();

            connection.Close();

            return result > 0;
        }

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
        #endregion


        /* Event for Account Profile*/
        #region Events

        private event EventHandler<AccountEvent> updateAccountEvent;
        public event EventHandler<AccountEvent> UpdateAccountEvent
        {
            add { updateAccountEvent += value; }
            remove { updateAccountEvent -= value; }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdateAccount_Click(object sender, EventArgs e)
        {
            updateAccount();
        }
        #endregion
    }

    public class AccountEvent : EventArgs
    {
        private Account acc;

        public Account Acc
        {
            get
            {
                return acc;
            }
            set
            {
                acc = value;
            }
        }

        public AccountEvent(Account acc)
        {
            this.Acc = acc;
        }
    }
}
