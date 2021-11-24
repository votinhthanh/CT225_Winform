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
        }
        #region Methods
        void LoadDateTimePickerBill()
        {
            dtpkFromDate.Format = DateTimePickerFormat.Custom; 
            dtpkFromDate.CustomFormat = "    'Từ ngày' dd 'tháng' MM 'năm' yyyy";
            dtpkToDate.Format = DateTimePickerFormat.Custom;
            dtpkToDate.CustomFormat = "    'Đến ngày' dd 'tháng' MM 'năm' yyyy";
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
        #region FoodMethods
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
        Food GetFoodByName(string food_name)
        {
            string connectSTR = @"Data Source=.\sqlexpress;Initial Catalog=Coffee_Shop_Manager;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectSTR);
            connection.Open();
            string query = "SELECT * FROM Food WHERE name = N'" + food_name + "'";
            SqlCommand command = new SqlCommand(query, connection);
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);
            connection.Close();
            Food food = null;
            foreach (DataRow item in data.Rows)
            {
                food = new Food(item);
                return food;
            }
            return food;
        }
        bool InsertFood(string food_name, int category_id, float food_price)
        {
            string connectSTR = @"Data Source=.\sqlexpress;Initial Catalog=Coffee_Shop_Manager;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectSTR);
            connection.Open();
            string query = "INSERT Food (name, idCategory, price) VALUES (N'" + food_name + "', "+ category_id+", "+ food_price+")";
            SqlCommand command = new SqlCommand(query, connection);
            int result = 0;
            result = (int)command.ExecuteNonQuery();
            connection.Close();
            return result > 0;
        }
        bool UpdateFood(int food_id, int category_id, string food_name, float food_price)
        {
            string connectSTR = @"Data Source=.\sqlexpress;Initial Catalog=Coffee_Shop_Manager;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectSTR);
            connection.Open();
            string query = "UPDATE Food SET name = N'" + food_name + "', price = "+ food_price + ", idCategory = "+ category_id + " WHERE id = " + food_id;
            SqlCommand command = new SqlCommand(query, connection);
            int result = 0;
            result = (int)command.ExecuteNonQuery();
            connection.Close();
            return result > 0;
        }
        bool DeleteBillInfoByIdFood(int food_id)
        {
            string connectSTR = @"Data Source=.\sqlexpress;Initial Catalog=Coffee_Shop_Manager;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectSTR);
            connection.Open();
            string query = "DELETE BillInfo WHERE idFood = " + food_id;
            SqlCommand command = new SqlCommand(query, connection);
            int result = 0;
            result = (int)command.ExecuteNonQuery();
            connection.Close();
            return result > 0;
        }
        bool DeleteFood(int food_id)
        {
            string connectSTR = @"Data Source=.\sqlexpress;Initial Catalog=Coffee_Shop_Manager;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectSTR);
            connection.Open();
            string query = "DELETE Food WHERE id = " + food_id;
            SqlCommand command = new SqlCommand(query, connection);
            int result = 0;
            result = (int)command.ExecuteNonQuery();
            connection.Close();
            return result > 0;
        }
        #endregion

        //CATEGORY
        #region CategoryMethods
        void addCategoryFoodBinding()
        {
            txtCategoryName.DataBindings.Add(new Binding("Text", dtgvCategory.DataSource, "TÊN DANH MỤC", true, DataSourceUpdateMode.Never));
            txtCategoryId.DataBindings.Add(new Binding("Text", dtgvCategory.DataSource, "MÃ", true, DataSourceUpdateMode.Never));
        }
        Category GetCategoryByName(string name)
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
            string query = "SELECT c.id AS [MÃ], c.name AS [TÊN DANH MỤC], (CASE WHEN COUNT(f.id) > 0 THEN COUNT(f.id) ELSE 0 END) as [SỐ LƯỢNG MÓN] ";
                query += "FROM CategoryFood AS c LEFT JOIN Food AS f ON f.idCategory = c.id GROUP BY c.name, c.id";
            SqlCommand command = new SqlCommand(query, connection);
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);
            connection.Close();
            categoryFoodList.DataSource = data;
        }
        bool InsertCategory(string category_name)
        {
            string connectSTR = @"Data Source=.\sqlexpress;Initial Catalog=Coffee_Shop_Manager;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectSTR);
            connection.Open();
            string query = "INSERT CategoryFood (name) VALUES (N'" + category_name + "')";
            SqlCommand command = new SqlCommand(query, connection);
            int result = 0;
            result = (int)command.ExecuteNonQuery();
            connection.Close();
            return result > 0;
        }
        bool UpdateCategory(int category_id, string category_name)
        {
            string connectSTR = @"Data Source=.\sqlexpress;Initial Catalog=Coffee_Shop_Manager;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectSTR);
            connection.Open();
            string query = "UPDATE CategoryFood SET name = N'" + category_name + "' WHERE id = "+ category_id;
            SqlCommand command = new SqlCommand(query, connection);
            int result = 0;
            result = (int)command.ExecuteNonQuery();
            connection.Close();
            return result > 0;
        }
        bool DeleteFoodByIdCategory(int category_id)
        {
            string connectSTR = @"Data Source=.\sqlexpress;Initial Catalog=Coffee_Shop_Manager;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectSTR);
            connection.Open();
            string query = "EXEC USP_DeleteFoodByIdCategory " + category_id;
            SqlCommand command = new SqlCommand(query, connection);
            int result = 0;
            result = (int)command.ExecuteNonQuery();
            connection.Close();
            return result > 0;
        }
        bool DeleteCategory(int category_id)
        {
            string connectSTR = @"Data Source=.\sqlexpress;Initial Catalog=Coffee_Shop_Manager;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectSTR);
            connection.Open();
            string query = "DELETE CategoryFood WHERE id = " + category_id;
            SqlCommand command = new SqlCommand(query, connection);
            int result = 0;
            result = (int)command.ExecuteNonQuery();
            connection.Close();
            return result > 0;
        }
        #endregion

        //TABLE
        #region TableMethods
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
        Table GetTableByName(string table_name)
        {
            string connectSTR = @"Data Source=.\sqlexpress;Initial Catalog=Coffee_Shop_Manager;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectSTR);
            connection.Open();
            string query = "SELECT * FROM TableFood WHERE name = N'" + table_name + "'";
            SqlCommand command = new SqlCommand(query, connection);
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);
            connection.Close();
            Table table = null;
            foreach (DataRow item in data.Rows)
            {
                table = new Table(item);
                return table;
            }
            return table;
        }
        bool InsertTable(string table_name)
        {
            string connectSTR = @"Data Source=.\sqlexpress;Initial Catalog=Coffee_Shop_Manager;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectSTR);
            connection.Open();
            string query = "INSERT TableFood (name) VALUES (N'" + table_name + "')";
            SqlCommand command = new SqlCommand(query, connection);
            int result = 0;
            result = (int)command.ExecuteNonQuery();
            connection.Close();
            return result > 0;
        }
        bool UpdateTable(int table_id, string table_name, string table_status)
        {
            string connectSTR = @"Data Source=.\sqlexpress;Initial Catalog=Coffee_Shop_Manager;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectSTR);
            connection.Open();
            string query = "UPDATE TableFood SET name = N'" + table_name + "', status = N'" + table_status + "' WHERE id = " + table_id;
            SqlCommand command = new SqlCommand(query, connection);
            int result = 0;
            result = (int)command.ExecuteNonQuery();
            connection.Close();
            return result > 0;
        }
        bool DeleteBillByIdTable(int table_id)
        {
            string connectSTR = @"Data Source=.\sqlexpress;Initial Catalog=Coffee_Shop_Manager;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectSTR);
            connection.Open();
            string query = "EXEC USP_DeleteBillIdTable " + table_id;
            SqlCommand command = new SqlCommand(query, connection);
            int result = 0;
            result = (int)command.ExecuteNonQuery();
            connection.Close();
            return result > 0;
        }
        bool DeleteTable(int table_id)
        {
            string connectSTR = @"Data Source=.\sqlexpress;Initial Catalog=Coffee_Shop_Manager;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectSTR);
            connection.Open();
            string query = "DELETE TableFood WHERE id = " + table_id;
            SqlCommand command = new SqlCommand(query, connection);
            int result = 0;
            result = (int)command.ExecuteNonQuery();
            connection.Close();
            return result > 0;
        }
        #endregion

        //Account
        #region AccountMethods
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
        bool InsertAccount(string username, string displayname, int type)
        {
            string password_new = EncodingPassword("0");
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
            string password = EncodingPassword("0");
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
        #region FoodEvents
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
        private event EventHandler insertFoodEvent;
        public event EventHandler InsertFoodEvent
        {
            add { insertFoodEvent += value; }
            remove { insertFoodEvent -= value; }
        }
        private event EventHandler updateFoodEvent;
        public event EventHandler UpdateFoodEvent
        {
            add { updateFoodEvent += value; }
            remove { updateFoodEvent -= value; }
        }
        private event EventHandler deleteFoodEvent;
        public event EventHandler DeleteFoodEvent
        {
            add { deleteFoodEvent += value; }
            remove { deleteFoodEvent -= value; }
        }
        private void btnAddFood_Click(object sender, EventArgs e)
        {
            string food_name = txtFoodName.Text;
            int category_id = (cbFoodCategory.SelectedItem as Category).ID;
            float food_price = (float)nmFoodPrice.Value;
            Food food = GetFoodByName(food_name);
            if (food != null)
            {
                MessageBox.Show("Món ăn đã tồn tại !!!", "Báo lỗi!");
                return;
            }
            if (InsertFood(food_name, category_id, food_price))
            {
                MessageBox.Show("Thêm món '" + food_name + "' thành công !!!", "Thông báo !");
                if (insertFoodEvent != null)
                {
                    insertFoodEvent(this, new EventArgs());
                }
                LoadListFood();
                LoadListCategoryFood();
            }
            else
            {
                MessageBox.Show("Thêm món ăn KHÔNG thành công !!!", "Báo lỗi!");
            }
        }
        private void btnEditFood_Click(object sender, EventArgs e)
        {
            int food_id = int.Parse(txtFoodID.Text);
            int category_id = (cbFoodCategory.SelectedItem as Category).ID;
            string food_name = txtFoodName.Text;
            float food_price = (float)nmFoodPrice.Value;
            if (UpdateFood(food_id, category_id, food_name, food_price))
            {
                MessageBox.Show("Cập nhật món '" + food_name + "' thành công !!!", "Thông báo !");
                if (updateFoodEvent != null)
                {
                    updateFoodEvent(this, new EventArgs());
                }
                LoadListFood();
                LoadListCategoryFood();
            }
            else
            {
                MessageBox.Show("Cập nhật món ăn KHÔNG thành công !!!", "Báo lỗi!");
            }
        }
        private void btnDelFood_Click(object sender, EventArgs e)
        {
            int food_id = int.Parse(txtFoodID.Text);
            string food_name = txtFoodName.Text;
            if (!DeleteBillInfoByIdFood(food_id))
            {
                MessageBox.Show("Xóa món ăn KHÔNG thành công !!!", "Báo lỗi!");
                return;
            }
            if(DeleteFood(food_id))
            {
                MessageBox.Show("Xóa món '" + food_name + "' thành công !!!", "Thông báo !");
                if (deleteFoodEvent != null)
                {
                    deleteFoodEvent(this, new EventArgs());
                }
                LoadListFood();
                LoadListCategoryFood();
                LoadListTableFood();
            }
            else
            {
                MessageBox.Show("Xóa món ăn KHÔNG thành công !!!", "Báo lỗi!");
            }
        }

        #endregion

        //CATEGORY
        #region CaegoryEvents
        private event EventHandler insertCategoryFoodEvent;
        public event EventHandler InsertCategoryFooodEvent
        {
            add { insertCategoryFoodEvent += value; }
            remove { insertCategoryFoodEvent -= value; }
        }
        private event EventHandler updateCategoryFoodEvent;
        public event EventHandler UpdateCategoryFoodEvent
        {
            add { updateCategoryFoodEvent += value; }
            remove { updateCategoryFoodEvent -= value; }
        }
        private event EventHandler deleteCategoryFoodEvent;
        public event EventHandler DeleteCategoryFoodEvent
        {
            add { deleteCategoryFoodEvent += value; }
            remove { deleteCategoryFoodEvent -= value; }
        }
        private void btnShowCategory_Click(object sender, EventArgs e)
        {
            LoadListCategoryFood();
        }
        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            string category_name = txtCategoryName.Text;
            
            Category category = GetCategoryByName(category_name);
            if(category != null)
            {
                MessageBox.Show("Danh mục đã tồn tại !!!", "Báo lỗi!");
                return;
            }
            if (InsertCategory(category_name))
            {
                MessageBox.Show("Thêm danh mục '" + category_name + "' thành công !!!", "Thông báo !");
                if (insertCategoryFoodEvent != null)
                {
                    insertCategoryFoodEvent(this, new EventArgs());
                }
                LoadListCategoryFood();
            }
            else
            {
                MessageBox.Show("Thêm danh mục không thành công !!!", "Báo lỗi!");
            }
        }
        private void btnEditCategory_Click(object sender, EventArgs e)
        {
            int category_id = int.Parse(txtCategoryId.Text);
            string category_name = txtCategoryName.Text;
            if (UpdateCategory(category_id, category_name))
            {
                MessageBox.Show("Cập nhật danh mục '" + txtCategoryName.Text + "' thành công !!!", "Thông báo !");
                if (updateCategoryFoodEvent != null)
                {
                    updateCategoryFoodEvent(this, new EventArgs());
                }
                LoadListCategoryFood();
            }
            else
            {
                MessageBox.Show("Cập nhật danh mục KHÔNG thành công !!!", "Báo lỗi!");
            }
        }
        private void btnDelCategory_Click(object sender, EventArgs e)
        {
            int category_id = int.Parse(txtCategoryId.Text);
            if (!DeleteFoodByIdCategory(category_id))
            {
                MessageBox.Show("Xóa danh mục KHÔNG thành công !!!", "Báo lỗi!");
                return;
            }
            if (DeleteCategory(category_id))
            {
                MessageBox.Show("Xóa danh mục '" + txtCategoryName.Text + "' thành công !!!", "Thông báo !");
                if (deleteCategoryFoodEvent != null)
                {
                    deleteCategoryFoodEvent(this, new EventArgs());
                }
                LoadListFood();
                LoadListCategoryFood();
                LoadListTableFood();
            }
            else
            {
                MessageBox.Show("Xóa danh mục KHÔNG thành công !!!", "Báo lỗi!");
            }
        }
        #endregion

        //TABLE
        #region TableEvents
        private event EventHandler insertTableFoodEvent;
        public event EventHandler InsertTableFoodEvent
        {
            add { insertTableFoodEvent += value; }
            remove { insertTableFoodEvent -= value; }
        }
        private event EventHandler updateTableFoodEvent;
        public event EventHandler UpdateTableFoodEvent
        {
            add { updateTableFoodEvent += value; }
            remove { updateTableFoodEvent -= value; }
        }
        private event EventHandler deleteTableFoodEvent;
        public event EventHandler DeleteTableFoodEvent
        {
            add { deleteTableFoodEvent += value; }
            remove { deleteTableFoodEvent -= value; }
        }
        private void btnShowTable_Click(object sender, EventArgs e)
        {
            LoadListTableFood();
        }
        private void btnAddTable_Click(object sender, EventArgs e)
        {
            string table_name = txtTableName.Text;

            Table table = GetTableByName(table_name);
            if (table != null)
            {
                MessageBox.Show("Bàn đã tồn tại !!!", "Báo lỗi!");
                return;
            }
            if (InsertTable(table_name))
            {
                MessageBox.Show("Thêm bàn mới thành công !!!", "Thông báo !");
                if (insertTableFoodEvent != null)
                {
                    insertTableFoodEvent(this, new EventArgs());
                }
                LoadListTableFood();
            }
            else
            {
                MessageBox.Show("Thêm bàn mới KHÔNG thành công !!!", "Báo lỗi!");
            }
        }
        private void btnEditTable_Click(object sender, EventArgs e)
        {
            int table_id = int.Parse(txtTableID.Text);
            string table_name = txtTableName.Text;
            string table_status = txtTableStatus.Text;
            if (UpdateTable(table_id, table_name, table_status))
            {
                MessageBox.Show("Cập nhật '" + table_name + "' thành công !!!", "Thông báo !");
                if (updateTableFoodEvent != null)
                {
                    updateTableFoodEvent(this, new EventArgs());
                }
                LoadListTableFood();
            }
            else
            {
                MessageBox.Show("Cập nhật bàn ăn KHÔNG thành công !!!", "Báo lỗi!");
            }
        }
        private void btnDeltable_Click(object sender, EventArgs e)
        {
            int table_id = int.Parse(txtTableID.Text);
            string table_name = txtFoodName.Text;
            if (!DeleteBillByIdTable(table_id))
            {
                MessageBox.Show("Xóa bàn ăn KHÔNG thành công !!!", "Báo lỗi!");
                return;
            }
            if(DeleteTable(table_id))
            {
                MessageBox.Show("Xóa bàn '" + table_name + "' thành công !!!", "Thông báo !");
                if (deleteTableFoodEvent != null)
                {
                    deleteTableFoodEvent(this, new EventArgs());
                }
                LoadListTableFood();
            }
            else
            {
                MessageBox.Show("Xóa bàn ăn KHÔNG thành công !!!", "Báo lỗi!");
            }
        }
        #endregion

        //ACCOUNT
        #region AccountEvents
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
