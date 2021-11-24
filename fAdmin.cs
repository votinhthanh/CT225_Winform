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
    public partial class fAdmin : Form
    {
        BindingSource foodList = new BindingSource();
        BindingSource categoryFoodList = new BindingSource();
        BindingSource tableFoodList = new BindingSource();
        BindingSource accountList = new BindingSource();
        public Account loginAccount;
        public fAdmin()
        {
            InitializeComponent();
            dtgvFood.DataSource = foodList;
            dtgvCategory.DataSource = categoryFoodList;
            dtgvTable.DataSource = tableFoodList;
            dtgvAccount.DataSource = accountList;
            LoadDateTimePickerBill();
            LoadListFood();
            LoadListCategoryNameForComboBox();
            addFoodBinding();
            LoadListCategoryFood();
            addCategoryFoodBinding();
            LoadListTableFood();
            addTableFoodBinding();
            LoadListAccount();
            addAccountBinding();
            //dtgvFood.DataSource = foodList;
        }
        #region Methods
        void LoadDateTimePickerBill()
        {
            DateTime today = DateTime.Now;
            dtpkFromDate.Value = new DateTime(today.Year, today.Month, 1);
            dtpkToDate.Value = dtpkFromDate.Value.AddMonths(1).AddDays(-1);
            string beginDate = dtpkFromDate.Value.Date.ToString("yyyy-MM-dd");
            string endDate = dtpkToDate.Value.Date.ToString("yyyy-MM-dd");
            LoadListBillByDate(beginDate, endDate);
        }
        public void LoadListBillByDate(string checkIn, string checkOut)
        {
            string connectSTR = @"Data Source=.\sqlexpress;Initial Catalog=Coffee_Shop_Manager;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectSTR);
            connection.Open();
            string query = "EXEC USP_getListBillByDate '" + checkIn + "', '" + checkOut + "'";
            SqlCommand command = new SqlCommand(query, connection);
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);
            connection.Close();
            dtgvBill.DataSource = data;
        }

        //FOOD
        void addFoodBinding()
        {
            txtFoodName.DataBindings.Add(new Binding("Text", dtgvFood.DataSource, "TÊN MÓN", true, DataSourceUpdateMode.Never));
            txtFoodID.DataBindings.Add(new Binding("Text", dtgvFood.DataSource, "MÃ", true, DataSourceUpdateMode.Never));
            nmFoodPrice.DataBindings.Add(new Binding("Value", dtgvFood.DataSource, "GIÁ", true, DataSourceUpdateMode.Never));
        }
        void LoadListFood()
        {
            string connectSTR = @"Data Source=.\sqlexpress;Initial Catalog=Coffee_Shop_Manager;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectSTR);

            connection.Open();

            string query = "SELECT f.id AS [MÃ], f.name AS [TÊN MÓN], c.name AS [DANH MỤC], price AS [GIÁ] FROM Food AS f JOIN CategoryFood AS c ON f.idCategory = c.id";
            SqlCommand command = new SqlCommand(query, connection);
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);
            connection.Close();
            foodList.DataSource = data;
        }
        void LoadListCategoryNameForComboBox()
        {
            string connectSTR = @"Data Source=.\sqlexpress;Initial Catalog=Coffee_Shop_Manager;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectSTR);

            connection.Open();

            string query = "SELECT * FROM CategoryFood";
            SqlCommand command = new SqlCommand(query, connection);
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);
            connection.Close();
            List<Category> listCategory = new List<Category>();
            foreach (DataRow item in data.Rows)
            {
                Category category = new Category(item);
                listCategory.Add(category);
            }

            cbFoodCategory.DataSource = listCategory;
            cbFoodCategory.DisplayMember = "Name";
        }
        void LoadListFoodLikeValueSearch(string key_search)
        {
            string connectSTR = @"Data Source=.\sqlexpress;Initial Catalog=Coffee_Shop_Manager;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectSTR);

            connection.Open();

            string query = "SELECT f.id AS [MÃ], f.name AS [TÊN MÓN], c.name AS [DANH MỤC], price AS [GIÁ] FROM Food AS f JOIN CategoryFood AS c ON f.idCategory = c.id";
            query += " WHERE f.name LIKE N'%" + key_search + "%'";
            SqlCommand command = new SqlCommand(query, connection);
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);
            connection.Close();
            foodList.DataSource = data;
        }
        //CATEGORY
        void addCategoryFoodBinding()
        {
            txtCategoryName.DataBindings.Add(new Binding("Text", dtgvCategory.DataSource, "TÊN DANH MỤC", true, DataSourceUpdateMode.Never));
            txtCategoryId.DataBindings.Add(new Binding("Text", dtgvCategory.DataSource, "MÃ", true, DataSourceUpdateMode.Never));
        }
        public Category GetCategoryByName(string name)
        {
            string connectSTR = @"Data Source=.\sqlexpress;Initial Catalog=Coffee_Shop_Manager;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectSTR);

            connection.Open();

            string query = "SELECT * FROM CategoryFood WHERE name = N'" + name + "'";
            SqlCommand command = new SqlCommand(query, connection);
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);
            connection.Close();
            Category category = null;
            foreach (DataRow item in data.Rows)
            {
                category = new Category(item);
                return category;
            }
            return category;
        }
        void LoadListCategoryFood()
        {
            string connectSTR = @"Data Source=.\sqlexpress;Initial Catalog=Coffee_Shop_Manager;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectSTR);
            connection.Open();
            string query = "SELECT c.id AS [MÃ], c.name AS [TÊN DANH MỤC], count(f.id) as [SỐ LƯỢNG MÓN] FROM CategoryFood AS c JOIN Food AS f ON f.idCategory = c.id GROUP BY c.name, c.id";
            SqlCommand command = new SqlCommand(query, connection);
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);
            connection.Close();
            categoryFoodList.DataSource = data;
        }

        //TABLE
        void addTableFoodBinding()
        {
            txtTableName.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "TÊN BÀN", true, DataSourceUpdateMode.Never));
            txtTableID.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "MÃ", true, DataSourceUpdateMode.Never));
            txtTableStatus.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "TRẠNG THÁI", true, DataSourceUpdateMode.Never));
        }
        void LoadListTableFood()
        {
            string connectSTR = @"Data Source=.\sqlexpress;Initial Catalog=Coffee_Shop_Manager;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectSTR);
            connection.Open();
            string query = "SELECT t.id AS [MÃ], t.name AS [TÊN BÀN],t.status AS [TRẠNG THÁI], (CASE WHEN COUNT(b.id) > 0 THEN COUNT(b.id) ELSE 0 END) AS [SL HĐ] ";
            query += "FROM TableFood AS t LEFT JOIN Bill AS b ON t.id = b.idTable GROUP BY t.name, t.id, t.status";
            SqlCommand command = new SqlCommand(query, connection);
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);
            connection.Close();
            tableFoodList.DataSource = data;
        }

        //Account
        void addAccountBinding()
        {
            txtUserName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "TÊN ĐĂNG NHẬP", true, DataSourceUpdateMode.Never));
            txtDisplayName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "TÊN HIỂN THỊ", true, DataSourceUpdateMode.Never));
            txtAccountType.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "LOẠI TÀI KHOẢN", true, DataSourceUpdateMode.Never));
        }
        void LoadListAccount()
        {
            string connectSTR = @"Data Source=.\sqlexpress;Initial Catalog=Coffee_Shop_Manager;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectSTR);
            connection.Open();
            string query = "SELECT UserName AS [TÊN ĐĂNG NHẬP], DisplayName AS [TÊN HIỂN THỊ], Type AS [LOẠI TÀI KHOẢN] FROM Account";
            SqlCommand command = new SqlCommand(query, connection);
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);
            connection.Close();
            accountList.DataSource = data;
        }
        Account getAccountByUserName(string username)
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
        bool InsertAccount(string username, string displayname, int type)
        {
            string password_new = "0";
            string connectSTR = @"Data Source=.\sqlexpress;Initial Catalog=Coffee_Shop_Manager;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectSTR);
            connection.Open();
            string query = "INSERT Account (UserName, DisplayName, Type, PassWord) VALUES (N'" + username + "', N'" + displayname + "', " + type + ", N'" + password_new + "')";
            SqlCommand command = new SqlCommand(query, connection);
            int result = 0;
            result = (int)command.ExecuteNonQuery();
            connection.Close();
            return result > 0;
        }
        bool DeleteAccount(string username)
        {
            string connectSTR = @"Data Source=.\sqlexpress;Initial Catalog=Coffee_Shop_Manager;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectSTR);
            connection.Open();
            string query = "DELETE Account WHERE UserName = N'" + username + "'";
            SqlCommand command = new SqlCommand(query, connection);
            int result = 0;
            result = (int)command.ExecuteNonQuery();
            connection.Close();
            return result > 0;
        }
        bool UpdateAccount(string username, string display_name, int type)
        {
            string connectSTR = @"Data Source=.\sqlexpress;Initial Catalog=Coffee_Shop_Manager;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectSTR);
            connection.Open();
            string query = "UPDATE Account SET DisplayName = N'"+ display_name+ "', Type = " +type+ " WHERE UserName = N'"+username+"'";
            SqlCommand command = new SqlCommand(query, connection);            
            int result = 0;
            result = (int)command.ExecuteNonQuery();
            connection.Close();
            return result > 0;
        }
        bool ResetPasswordAccount(string username)
        {
            string password = "0";
            string connectSTR = @"Data Source=.\sqlexpress;Initial Catalog=Coffee_Shop_Manager;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectSTR);
            connection.Open();
            string query = "UPDATE Account SET PassWord = N'" + password + "' WHERE UserName = N'" + username + "'";
            SqlCommand command = new SqlCommand(query, connection);
            int result = 0;
            result = (int)command.ExecuteNonQuery();
            connection.Close();
            return result > 0;
        }
        #endregion

        #region Events
        //BILL
        private void btnViewBill_Click(object sender, EventArgs e)
        {
            string beginDate = dtpkFromDate.Value.Date.ToString("yyyy-MM-dd");
            string endDate = dtpkToDate.Value.Date.ToString("yyyy-MM-dd");
            LoadListBillByDate(beginDate, endDate);
        }
        //FOOD
        private void txtFoodID_TextChanged(object sender, EventArgs e)
        {
            if (dtgvFood.SelectedCells.Count > 0)
            {
                string categoryName = (string)dtgvFood.SelectedCells[0].OwningRow.Cells["DANH MỤC"].Value;
                Category category = GetCategoryByName(categoryName);
                if (category != null)
                {
                    cbFoodCategory.SelectedItem = category;
                    int index = -1;
                    int i = 0;
                    foreach (Category item in cbFoodCategory.Items)
                    {
                        if (item.ID == category.ID)
                        {
                            index = i;
                            break;
                        }
                        i++;
                    }
                    cbFoodCategory.SelectedIndex = index;
                }
            }
        }
        private void txtSearchFood_Click(object sender, EventArgs e)
        {
            txtSearchFood.Text = "";
        }
        private void btnSearchFood_Click(object sender, EventArgs e)
        {
            string key_search = txtSearchFood.Text;
            if (!key_search.Equals("")) LoadListFoodLikeValueSearch(key_search);
            else LoadListFood();
        }
        private void btnShowFood_Click(object sender, EventArgs e)
        {
            LoadListFood();
        }
        //ACCOUNT
        private event EventHandler<AccountEvent> updateAccountEvent;
        public event EventHandler<AccountEvent> UpdateAccountEvent
        {
            add { updateAccountEvent += value; }
            remove { updateAccountEvent -= value; }
        }
        private void btnShowAccount_Click(object sender, EventArgs e)
        {
            LoadListAccount();
        }
        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            string displayname = txtDisplayName.Text;
            int type = int.Parse(txtAccountType.Text);
            Account acc = getAccountByUserName(username);
            if (acc == null)
            {
                if (InsertAccount(username, displayname, type))
                {
                    MessageBox.Show("Thêm tài khoản '" + username + "' thành công !!!", "Thông báo !");
                    LoadListAccount();
                }
            }
            else
            {
                MessageBox.Show("Thêm tài khoản không thành công !!!", "Báo lỗi!");
            }
        }
        private void btnEditAccount_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            string display_name = txtDisplayName.Text;
            int type = int.Parse(txtAccountType.Text);
            bool isSuccessfull = UpdateAccount(username, display_name, type);
            if (isSuccessfull)
            {
                MessageBox.Show("Cập nhật tài khoản '" + username + "' thành công !!!", "Thông báo !");
                if (updateAccountEvent != null)
                {
                    updateAccountEvent(this, new AccountEvent(getAccountByUserName(username)));
                }
                LoadListAccount();
            }
            else
            {
                MessageBox.Show("Cập nhật tài khoản không thành công !!!", "Báo lỗi !");
            }
        }
        private void btnDelAccount_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            if (loginAccount.UserName.Equals(username))
            {
                MessageBox.Show("Không thể xóa tài khoản đang đăng nhập !!!", "Cảnh lỗi !");
                return;
            }
            if (DeleteAccount(username))
            {
                MessageBox.Show("Xóa tài khoản '" + username + "' thành công !!!", "Thông báo !");
                LoadListAccount();
            }
            else
            {
                MessageBox.Show("Xóa tài khoản '" + username + "' không thành công !!!", "Báo lỗi !");
            }
        }
        private void btnResetPass_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            if (ResetPasswordAccount(username))
            {
                MessageBox.Show("Khôi phục mật khẩu thành công !!!", "Thông báo !");
                LoadListAccount();
            }
            else
            {
                MessageBox.Show("Khôi phục mật khẩu không thành công !!!", "Báo lỗi !");
            }
        }
        #endregion

        #region AccountEvents
        public class AccountEvent : EventArgs
        {
            private Account acc;
            public Account Acc
            {
                get{ return acc; }
                set{ acc = value; }
            }
            public AccountEvent(Account acc)
            {
                this.Acc = acc;
            }
        }
        #endregion

        
    }
}
