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
            Load();
        }
        #region Methods
        void Load()
        {
            dtgvTable.DataSource = tableFoodList;
            dtgvFood.DataSource = foodList;
            dtgvAccount.DataSource = accountList;
            dtgvCategory.DataSource = categoryFoodList;
            loadDateTimePickerBill();
            LoadListFood();
            LoadListAccount();
            LoadListCategoryFood();
            LoadListTableFood();
            loadCategory();
            addFoodBinding();
            addCategoryFoodBinding();
            addAccountBinding();
            addTableFoodBinding();
        }

        /*
         * HIỂN THỊ DANH THU THEO THÁNG HIỆN TẠI
         * 
         * HIỂN THỊ DANH THU THEO KHOẢNG THỜI GIAN
         * 
         * LẤY DANH SÁCH HÓA ĐƠN THEO KHOẢNG THỜI GIAN
         */
        void loadDateTimePickerBill()
        {
            DateTime today = DateTime.Now;
            dtpkFromDate.Value = new DateTime(today.Year, today.Month, 1);
            dtpkToDate.Value = dtpkFromDate.Value.AddMonths(1).AddDays(-1);
            string beginDate = dtpkFromDate.Value.Date.ToString("yyyy-MM-dd");
            string endDate = dtpkToDate.Value.Date.ToString("yyyy-MM-dd");
            LoadListBillByDate(beginDate, endDate);
        }
        void LoadListBillByDate(string checkIn, string checkOut)
        {
            dtgvBill.DataSource = getListBillByDate(checkIn, checkOut);
        }
        public DataTable getListBillByDate(string checkIn, string checkOut)
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

            return data;
        }

        /*
         * BINDING MÓN ĂN
         * 
         * HIỂN THỊ DANH SÁCH MÓN ĂN, LOAD THEO DANH MỤC MÓN ĂN
         * 
         * THÊM, SỬA, XÓA MÓN ĂN
         * 
         * XÓA BILL INFO KHI XÓA MÓN ĂN
         * 
         * TÌM KIẾM MÓN ĂN THEO TÊN GẦN ĐÚNG
         */
        void addFoodBinding()
        {
            txtFoodName.DataBindings.Add(new Binding("Text", dtgvFood.DataSource, "Food Name", true, DataSourceUpdateMode.Never));
            txtFoodID.DataBindings.Add(new Binding("Text", dtgvFood.DataSource, "ID", true, DataSourceUpdateMode.Never));
            nmFoodPrice.DataBindings.Add(new Binding("Value", dtgvFood.DataSource, "Price", true, DataSourceUpdateMode.Never));
        }
        void LoadListFood()
        {
            string connectSTR = @"Data Source=.\sqlexpress;Initial Catalog=Coffee_Shop_Manager;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectSTR);

            connection.Open();

            string query = "EXEC USP_GetAllFood";
            SqlCommand command = new SqlCommand(query, connection);
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);
            connection.Close();
            foodList.DataSource = data;
        }
        public bool InsertFood(string name, int categoryID, float price)
        {
            string connectSTR = @"Data Source=.\sqlexpress;Initial Catalog=Coffee_Shop_Manager;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectSTR);

            connection.Open();

            string query = "EXEC USP_InsertFood N'" + name + "', " + categoryID + ", " + price;
            SqlCommand command = new SqlCommand(query, connection);
            int result = 0;

            result = (int)command.ExecuteNonQuery();

            connection.Close();

            return result > 0;
        }
        public bool UpdateFood(int id, string name, int categoryID, float price)
        {
            string connectSTR = @"Data Source=.\sqlexpress;Initial Catalog=Coffee_Shop_Manager;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectSTR);

            connection.Open();

            string query = "EXEC USP_UpdateFood " + id + ", N'" + name + "', " + categoryID + ", " + price;
            SqlCommand command = new SqlCommand(query, connection);
            int result = 0;

            result = (int)command.ExecuteNonQuery();

            connection.Close();

            return result > 0;
        }
        public bool DeleteFood(int id)
        {
            string connectSTR = @"Data Source=.\sqlexpress;Initial Catalog=Coffee_Shop_Manager;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectSTR);

            connection.Open();

            string query = "EXEC USP_DeleteFood " + id;
            SqlCommand command = new SqlCommand(query, connection);
            int result = 0;

            result = (int)command.ExecuteNonQuery();

            connection.Close();

            return result > 0;
        }
        public bool deleteBillInfoByFoodID(int id)
        {
            string connectSTR = @"Data Source=.\sqlexpress;Initial Catalog=Coffee_Shop_Manager;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectSTR);

            connection.Open();

            string query = "EXEC USP_DeleteBillInfoByFoodID " + id;
            SqlCommand command = new SqlCommand(query, connection);
            int result = 0;

            result = (int)command.ExecuteNonQuery();

            connection.Close();

            return result > 0;
        }
        void searchFoodByName(string search_name)
        {
            string connectSTR = @"Data Source=.\sqlexpress;Initial Catalog=Coffee_Shop_Manager;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectSTR);

            connection.Open();

            string query = "SELECT food.id as ID, food.name as [Food Name], food.price as Price, category.name as [Category Name] FROM Food food join FoodCategory category on food.idCategory = category.id WHERE food.name LIKE N'%" + search_name + "%'";
            SqlCommand command = new SqlCommand(query, connection);
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);

            adapter.Fill(data);
            connection.Close();
            if(data == null)
            {
                MessageBox.Show("NO RESULT !!!", "Alert !");
                return;
            }
            else
            {
                foodList.DataSource = data;
            }
        }
        public Category GetCategoryByName(string name)
        {
            string connectSTR = @"Data Source=.\sqlexpress;Initial Catalog=Coffee_Shop_Manager;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectSTR);

            connection.Open();

            string query = "EXEC USP_GetCategoryByName N'" + name + "'";
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
        void loadCategory()
        {
            string connectSTR = @"Data Source=.\sqlexpress;Initial Catalog=Coffee_Shop_Manager;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectSTR);

            connection.Open();

            string query = "EXEC USP_GetAllCategory";
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
        /*
         * BINDING TÀI KHOẢN
         * 
         * HIỂN THỊ DANH SÁCH TÀI KHOẢN
         * 
         * THÊM, SỬA, XÓA TÀI KHOẢN
         * 
         * RESET PASSWORD (MÃ HÓA PASSWORD)
         */
        void addAccountBinding()
        {
            txtUserName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "UserName", true, DataSourceUpdateMode.Never));
            txtDisplayName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "DisplayName", true, DataSourceUpdateMode.Never));
            txtAccountType.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "Type", true, DataSourceUpdateMode.Never));
        }
        void LoadListAccount()
        {
            string connectSTR = @"Data Source=.\sqlexpress;Initial Catalog=Coffee_Shop_Manager;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectSTR);

            connection.Open();

            string query = "SELECT UserName, DisplayName, Type FROM Account";
            SqlCommand command = new SqlCommand(query, connection);
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);
            connection.Close();
            accountList.DataSource = data;
        }
        public bool InsertAccount(string username, string displayname, int type)
        {
            string password_new = EncodingPassword("1");
            string connectSTR = @"Data Source=.\sqlexpress;Initial Catalog=Coffee_Shop_Manager;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectSTR);

            connection.Open();

            string query = "EXEC USP_InsertAccount N'" + username + "', N'" + displayname + "', " + type + ", N'" + password_new + "'";
            SqlCommand command = new SqlCommand(query, connection);
            int result = 0;

            result = (int)command.ExecuteNonQuery();

            connection.Close();

            return result > 0;
        }
        public bool UpdateAccount(string username, string displayname, int type)
        {
            string connectSTR = @"Data Source=.\sqlexpress;Initial Catalog=Coffee_Shop_Manager;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectSTR);

            connection.Open();

            string query = "UPDATE Account SET DisplayName = N'" + displayname + "', Type = " + type + " WHERE UserName = N'" + username + "'";
            SqlCommand command = new SqlCommand(query, connection);
            int result = 0;

            result = (int)command.ExecuteNonQuery();

            connection.Close();

            return result > 0;
        }
        public bool DeleteAccount(string username)
        {

            string connectSTR = @"Data Source=.\sqlexpress;Initial Catalog=Coffee_Shop_Manager;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectSTR);

            connection.Open();

            string query = "Delete Account where UserName = N'" + username + "'";
            SqlCommand command = new SqlCommand(query, connection);
            int result = 0;

            result = (int)command.ExecuteNonQuery();

            connection.Close();

            return result > 0;
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
        public bool ResetPasswordTo0(string username)
        {
            string connectSTR = @"Data Source=.\sqlexpress;Initial Catalog=Coffee_Shop_Manager;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectSTR);

            connection.Open();

            string query = "UPDATE Account SET PassWord = N'0' WHERE UserName = N'" + username + "'";
            SqlCommand command = new SqlCommand(query, connection);
            int result = 0;

            result = (int)command.ExecuteNonQuery();

            connection.Close();

            return result > 0;
        }

        /*
         * BINDING DANH MỤC MÓN ĂN
         * 
         * HIỂN THỊ DANH SÁCH DANH MỤC MÓN ĂN
         * 
         * THÊM, SỬA, XÓA DANH MỤC MÓN ĂN
         * 
         */
        void addCategoryFoodBinding()
        {
            txtCategoryName.DataBindings.Add(new Binding("Text", dtgvCategory.DataSource, "Name", true, DataSourceUpdateMode.Never));
            txtCategoryId.DataBindings.Add(new Binding("Text", dtgvCategory.DataSource, "ID", true, DataSourceUpdateMode.Never));
        }
        void LoadListCategoryFood()
        {
            string connectSTR = @"Data Source=.\sqlexpress;Initial Catalog=Coffee_Shop_Manager;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectSTR);

            connection.Open();

            string query = "SELECT id AS ID, name as Name FROM FoodCategory";
            SqlCommand command = new SqlCommand(query, connection);
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);
            connection.Close();
            categoryFoodList.DataSource = data;
        }
        public bool InsertCategoryFood(string name)
        {
            string connectSTR = @"Data Source=.\sqlexpress;Initial Catalog=Coffee_Shop_Manager;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectSTR);

            connection.Open();

            string query = "INSERT FoodCategory(name) VALUES (N'" + name + "')";
            SqlCommand command = new SqlCommand(query, connection);
            int result = 0;

            result = (int)command.ExecuteNonQuery();

            connection.Close();

            return result > 0;
        }
        public bool UpdateCategoryFood(string name, int id)
        {
            string connectSTR = @"Data Source=.\sqlexpress;Initial Catalog=Coffee_Shop_Manager;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectSTR);

            connection.Open();

            string query = "UPDATE FoodCategory SET name = N'" + name + "' WHERE id = N'" + id + "'";
            SqlCommand command = new SqlCommand(query, connection);
            int result = 0;

            result = (int)command.ExecuteNonQuery();

            connection.Close();

            return result > 0;
        }
        public bool DeleteBillInfoByIdCategoryFood(int idCategoryFood)
        {
            List<Food> listFood = new List<Food>();
            string connectSTR = @"Data Source=.\sqlexpress;Initial Catalog=Coffee_Shop_Manager;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectSTR);
            connection.Open();
            string query = "SELECT * FROM Food WHERE idCategory = " + idCategoryFood;
            SqlCommand command = new SqlCommand(query, connection);
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);
            connection.Close();
            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                listFood.Add(food);
            }
            bool check = false;
            foreach (Food item in listFood)
            {
                check = deleteBillInfoByFoodID(item.Id);
            }
            return check;
        }
        public bool DeleteFoodByIdCategoryFood(int idCategoryFood)
        {
            string connectSTR = @"Data Source=.\sqlexpress;Initial Catalog=Coffee_Shop_Manager;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectSTR);
            connection.Open();
            string query = "EXEC USP_DeleteFoodByIdCategoryFood " + idCategoryFood;
            SqlCommand command = new SqlCommand(query, connection);
            int result = 0;
            result = (int)command.ExecuteNonQuery();
            connection.Close();
            return result > 0;
        }
        public bool DeleteCategoryFood(int id)
        {

            string connectSTR = @"Data Source=.\sqlexpress;Initial Catalog=Coffee_Shop_Manager;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectSTR);

            connection.Open();

            string query = "Delete FoodCategory where id = " + id;
            SqlCommand command = new SqlCommand(query, connection);
            int result = 0;

            result = (int)command.ExecuteNonQuery();

            connection.Close();

            return result > 0;
        }

        /*
         * BINDING DANH MỤC MÓN ĂN
         * 
         * HIỂN THỊ DANH SÁCH DANH MỤC MÓN ĂN
         * 
         * THÊM, SỬA, XÓA DANH MỤC MÓN ĂN
         * 
         */
        void addTableFoodBinding()
        {
            txtTableStatus.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "Status", true, DataSourceUpdateMode.Never));
            txtTableName.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "Name", true, DataSourceUpdateMode.Never));
            txtTableID.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "ID", true, DataSourceUpdateMode.Never));
        }
        void LoadListTableFood()
        {
            string connectSTR = @"Data Source=.\sqlexpress;Initial Catalog=Coffee_Shop_Manager;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectSTR);

            connection.Open();

            string query = "SELECT id AS ID, name as Name, status AS Status FROM TableFood";
            SqlCommand command = new SqlCommand(query, connection);
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);
            connection.Close();
            tableFoodList.DataSource = data;
        }
        public bool InsertTableFood(string name)
        {
            string connectSTR = @"Data Source=.\sqlexpress;Initial Catalog=Coffee_Shop_Manager;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectSTR);

            connection.Open();

            string query = "INSERT TableFood(name) VALUES (N'" + name + "')";
            SqlCommand command = new SqlCommand(query, connection);
            int result = 0;

            result = (int)command.ExecuteNonQuery();

            connection.Close();

            return result > 0;
        }
        public bool UpdateTableFood(string name, int id)
        {
            string connectSTR = @"Data Source=.\sqlexpress;Initial Catalog=Coffee_Shop_Manager;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectSTR);

            connection.Open();

            string query = "UPDATE TableFood SET name = N'" + name + "' WHERE id = N'" + id + "'";
            SqlCommand command = new SqlCommand(query, connection);
            int result = 0;

            result = (int)command.ExecuteNonQuery();

            connection.Close();

            return result > 0;
        }
        public bool DeleteBiLLInfoByIdBill(int idBill)
        {
            string connectSTR = @"Data Source=.\sqlexpress;Initial Catalog=Coffee_Shop_Manager;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectSTR);
            connection.Open();
            string query = "EXEC USP_DeleteBillInfoByBillID " + idBill;
            SqlCommand command = new SqlCommand(query, connection);
            int result = 0;
            result = (int)command.ExecuteNonQuery();
            connection.Close();
            return result > 0;
        }
        public bool DeleteBillInfoByIdTableFood(int idTableFood)
        {
            List<Bill> listBill = new List<Bill>();
            string connectSTR = @"Data Source=.\sqlexpress;Initial Catalog=Coffee_Shop_Manager;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectSTR);
            connection.Open();
            string query = "SELECT * FROM Bill WHERE idTable = " + idTableFood;
            SqlCommand command = new SqlCommand(query, connection);
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);
            connection.Close();
            foreach (DataRow item in data.Rows)
            {
                Bill bill = new Bill(item);
                listBill.Add(bill);
            }
            bool check = false;
            foreach (Bill item in listBill)
            {
                check = DeleteBiLLInfoByIdBill(item.Id);
            }
            return check;
        }
        public bool DeleteBillByIdTableFood(int idTableFood)
        {
            string connectSTR = @"Data Source=.\sqlexpress;Initial Catalog=Coffee_Shop_Manager;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectSTR);
            connection.Open();
            string query = "EXEC USP_DeleteBillByIdTable " + idTableFood;
            SqlCommand command = new SqlCommand(query, connection);
            int result = 0;
            result = (int)command.ExecuteNonQuery();
            connection.Close();
            return result > 0;
        }
        public bool DeleteTableFood(int id)
        {

            string connectSTR = @"Data Source=.\sqlexpress;Initial Catalog=Coffee_Shop_Manager;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectSTR);

            connection.Open();

            string query = "Delete TableFood where id = " + id;
            SqlCommand command = new SqlCommand(query, connection);
            int result = 0;

            result = (int)command.ExecuteNonQuery();

            connection.Close();

            return result > 0;
        }
        #endregion

        #region Events
        /*HIỂN THỊ DOANH THU*/
        private void btnViewBill_Click(object sender, EventArgs e)
        {
            string beginDate = dtpkFromDate.Value.Date.ToString("yyyy-MM-dd");
            string endDate = dtpkToDate.Value.Date.ToString("yyyy-MM-dd");
            if (MessageBox.Show(String.Format("Fromdate {0} toDate {1}?", beginDate, endDate)
                   , "Alert !!!", MessageBoxButtons.OK) == System.Windows.Forms.DialogResult.OK)
            {
                LoadListBillByDate(beginDate, endDate);
            }
        }

        /*LOAD LẠI DANH MỤC MÓN ĂN KHI CLICK MON ĂN TƯƠNG ỨNG*/
        private void txtFoodID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtgvFood.SelectedCells.Count > 0)
                {
                    string categoryName = (string)dtgvFood.SelectedCells[0].OwningRow.Cells["Category Name"].Value;

                    Category category = GetCategoryByName(categoryName);
                    if(category != null)
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
                else
                {
                    return;
                }
            }
            catch{
                return;
            }
        }

        /*
         * TẠO SỰ KIỆN LOAD LẠI PAGE QUẢN LÝ BÀN ĂN
         * 
         * KHI THÊM SỬA XÓA MÓN ĂN
         */
        private event EventHandler insertFoodEvent;
        public event EventHandler InsertFoodEvent
        {
            add { insertFoodEvent += value; }
            remove { insertFoodEvent -= value; }
        }
        private event EventHandler deleteFoodEvent;
        public event EventHandler DeleteFoodEvent
        {
            add { deleteFoodEvent += value; }
            remove { deleteFoodEvent -= value; }
        }
        private event EventHandler updateFoodEvent;
        public event EventHandler UpdateFoodEvent
        {
            add { updateFoodEvent += value; }
            remove { updateFoodEvent -= value; }
        }

        /*
         * HIỂN THỊ DANH SÁCH MÓN ĂN, LOAD THEO DANH MỤC MÓN ĂN
         * 
         * THÊM, SỬA, XÓA MÓN ĂN
         * 
         * TÌM KIẾM MÓN ĂN THEO TÊN GẦN ĐÚNG
         */
        private void btnShowFood_Click(object sender, EventArgs e)
        {
            LoadListFood();
        }
        private void btnAddFood_Click(object sender, EventArgs e)
        {
            int categoryID = (cbFoodCategory.SelectedItem as Category).ID;
            string foodName = txtFoodName.Text;
            float foodPrice = (float) nmFoodPrice.Value;
            if (InsertFood(foodName, categoryID, foodPrice))
            {
                MessageBox.Show("Add '" + foodName + "' is successfull !", "Alert !");
                LoadListFood();
                if (insertFoodEvent != null)
                {
                    insertFoodEvent(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Can't add '" + foodName + "' now !", "Error!");
            }
        }
        private void btnEditFood_Click(object sender, EventArgs e)
        {
            int categoryID = (cbFoodCategory.SelectedItem as Category).ID;
            string foodName = txtFoodName.Text;
            float foodPrice = (float)nmFoodPrice.Value;
            int id = int.Parse(txtFoodID.Text);
            if (UpdateFood(id, foodName, categoryID, foodPrice))
            {
                MessageBox.Show("Update '" + foodName + "' is successfull !", "Alert !");
                LoadListFood();
                if (updateFoodEvent != null)
                {
                    updateFoodEvent(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Can't update '" + foodName + "' now !", "Error!");
            }
        }
        private void btnDelFood_Click(object sender, EventArgs e)
        {
            string foodName = txtFoodName.Text;
            int id = int.Parse(txtFoodID.Text);
            deleteBillInfoByFoodID(id);
            if (DeleteFood(id))
            {
                MessageBox.Show("Delete '" + foodName + "' is successfull !", "Alert !");
                LoadListFood();
                if (deleteFoodEvent != null)
                {
                    deleteFoodEvent(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Can't delete '" + foodName + "' now !", "Error!");
            }
        }
        private void btnSearchFood_Click(object sender, EventArgs e)
        {
            searchFoodByName(txtSearchFood.Text);
        }

        /*
         * TẠO SỰ KIỆN LOAD LẠI PAGE QUẢN LÝ BÀN ĂN
         * 
         * KHI THÊM SỬA XÓA MÓN ĂN
         */
        private event EventHandler insertCategoryFoodEvent;
        public event EventHandler InsertCategoryFoodEvent
        {
            add { insertCategoryFoodEvent += value; }
            remove { insertCategoryFoodEvent -= value; }
        }
        private event EventHandler deleteCategoryFoodEvent;
        public event EventHandler DeleteCategoryFoodEvent
        {
            add { deleteCategoryFoodEvent += value; }
            remove { deleteCategoryFoodEvent -= value; }
        }
        private event EventHandler updateCategoryFoodEvent;
        public event EventHandler UpdateCategoryFoodEvent
        {
            add { updateCategoryFoodEvent += value; }
            remove { updateCategoryFoodEvent -= value; }
        }

        /* 
         * HIỂN THỊ DANH SÁCH DANH MỤC MÓN ĂN
         * 
         * THÊM, SỬA, XÓA DANH MỤC MÓN ĂN
         */
        private void btnShowCategory_Click(object sender, EventArgs e)
        {
            LoadListCategoryFood();
        }
        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            string name = txtCategoryName.Text;
            string connectSTR = @"Data Source=.\sqlexpress;Initial Catalog=Coffee_Shop_Manager;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectSTR);

            connection.Open();

            string query = "SELECT * FROM FoodCategory WHERE name = N'" + name + "'";
            SqlCommand command = new SqlCommand(query, connection);
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);
            connection.Close();

            if (data.Rows.Count == 0)
            {
                if (InsertCategoryFood(name))
                {
                    MessageBox.Show("Add category '" + name + "' is successfull !", "Alert !");
                    LoadListCategoryFood();
                    if (insertCategoryFoodEvent != null)
                    {
                        insertCategoryFoodEvent(this, new EventArgs());
                    }
                }
            }
            else
            {
                MessageBox.Show("Can't add category '" + name + "' now !", "Error!");
            }
        }
        private void btnEditCategory_Click(object sender, EventArgs e)
        {
            string category_name = txtCategoryName.Text;
            int id = int.Parse(txtCategoryId.Text);
            if (UpdateCategoryFood(category_name, id))
            {
                MessageBox.Show("Update category '" + category_name + "' is successfull !", "Alert !");
                LoadListCategoryFood();
                if (updateCategoryFoodEvent != null)
                {
                    updateCategoryFoodEvent(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Can't update category '" + category_name + "' now !", "Error!");
            }
        }
        private void btnDelCategory_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtCategoryId.Text);
            string name_category = txtCategoryName.Text;
            bool check = false;
            check = DeleteBillInfoByIdCategoryFood(id);
            check = DeleteFoodByIdCategoryFood(id);
            if (DeleteCategoryFood(id))
            {
                MessageBox.Show("Delete category '" + name_category + "' is successfull !", "Alert !");
                LoadListCategoryFood();
                if (deleteCategoryFoodEvent != null)
                {
                    deleteCategoryFoodEvent(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Can't delete category '" + name_category + "' now !", "Error!");
            }
        }
        /* 
        * HIỂN THỊ DANH SÁCH BÀN ĂN
        * 
        * THÊM, SỬA, XÓA BÀN ĂN
        */
        /*
         * TẠO SỰ KIỆN LOAD LẠI PAGE QUẢN LÝ BÀN ĂN
         * 
         * KHI THÊM SỬA XÓA MÓN ĂN
         */
        private event EventHandler insertTableFoodEvent;
        public event EventHandler InsertTableFoodEvent
        {
            add { insertTableFoodEvent += value; }
            remove { insertTableFoodEvent -= value; }
        }
        private event EventHandler deleteTableFoodEvent;
        public event EventHandler DeleteTableFoodEvent
        {
            add { deleteTableFoodEvent += value; }
            remove { deleteTableFoodEvent -= value; }
        }
        private event EventHandler updateTableFoodEvent;
        public event EventHandler UpdateTableFoodEvent
        {
            add { updateTableFoodEvent += value; }
            remove { updateTableFoodEvent -= value; }
        }
        private void btnShowTable_Click(object sender, EventArgs e)
        {
            LoadListTableFood();
        }
        private void btnAddTable_Click(object sender, EventArgs e)
        {
            string name = txtTableName.Text;
            string connectSTR = @"Data Source=.\sqlexpress;Initial Catalog=Coffee_Shop_Manager;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectSTR);

            connection.Open();

            string query = "SELECT * FROM TableFood WHERE name = N'" + name + "'";
            SqlCommand command = new SqlCommand(query, connection);
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);
            connection.Close();

            if (data.Rows.Count == 0)
            {
                if (InsertTableFood(name))
                {
                    MessageBox.Show("Add table '" + name + "' is successfull !", "Alert !");
                    LoadListTableFood();
                    if (insertTableFoodEvent != null)
                    {
                        insertTableFoodEvent(this, new EventArgs());
                    }
                }
            }
            else
            {
                MessageBox.Show("Can't add table '" + name + "' now !", "Error!");
            }
        }
        private void btnEditTable_Click(object sender, EventArgs e)
        {
            string table_name = txtTableName.Text;
            int id = int.Parse(txtTableID.Text);
            if (UpdateTableFood(table_name, id))
            {
                MessageBox.Show("Update table '" + table_name + "' is successfull !", "Alert !");
                LoadListTableFood();
                if (updateTableFoodEvent != null)
                {
                    updateTableFoodEvent(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Can't update table '" + table_name + "' now !", "Error!");
            }
        }
        private void btnDeltable_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtTableID.Text);
            string table_name = txtTableName.Text;
            bool check = false;
            check = DeleteBillInfoByIdTableFood(id);
            check = DeleteBillByIdTableFood(id);
            if (DeleteTableFood(id))
            {
                MessageBox.Show("Delete table '" + table_name + "' is successfull !", "Alert !");
                LoadListTableFood();
                if (deleteCategoryFoodEvent != null)
                {
                    deleteCategoryFoodEvent(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Can't delete table '" + table_name + "' now !", "Error!");
            }
        }

        /* 
         * HIỂN THỊ DANH SÁCH TÀI KHOẢN
         * 
         * THÊM, SỬA, XÓA TÀI KHOẢN
         * 
         * RESET PASSWORD (MÃ HÓA PASSWORD)
         */
        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            string displayname = txtDisplayName.Text;
            int type = int.Parse(txtAccountType.Text);
            string connectSTR = @"Data Source=.\sqlexpress;Initial Catalog=Coffee_Shop_Manager;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectSTR);

            connection.Open();

            string query = "SELECT * FROM Account WHERE UserName = N'" + username + "'";
            SqlCommand command = new SqlCommand(query, connection);
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);
            connection.Close();

            if (data.Rows.Count == 0)
            {
                if (InsertAccount(username, displayname, type))
                {
                    MessageBox.Show("Add account '" + username + "' is successfull !", "Alert !");
                    LoadListAccount();
                }
            }
            else
            {
                MessageBox.Show("Can't add account '" + username + "' now !", "Error!");
            }
        }
        private void btnEditAccount_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            string displayname = txtDisplayName.Text;
            int type = int.Parse(txtAccountType.Text);
            if (UpdateAccount(username, displayname, type))
            {
                MessageBox.Show("Update account '" + username + "' is successfull !", "Alert !");
                LoadListAccount();
            }
            else
            {
                MessageBox.Show("Can't edit account '" + username + "' now !", "Error!");
            }
        }
        private void btnDelAccount_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            if (loginAccount.UserName.Equals(username))
            {
                MessageBox.Show("Existing account cannot be deleted !", "Error!");
                return;
            }
            if (DeleteAccount(username))
            {
                MessageBox.Show("Delete account '" + username + "' is successfull !", "Alert !");
                LoadListAccount();
            }
            else
            {
                MessageBox.Show("Can't delete account '" + username + "' now !", "Error!");
            }

        }
        private void btnResetPass_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            if (ResetPasswordTo0(username))
            {
                MessageBox.Show("Reset password for account '" + username + "' is successfull !", "Alert !");
                LoadListAccount();
            }
            else
            {
                MessageBox.Show("Reset password for account '" + username + "' now !", "Error!");
            }
        }
        private void btnShowAccount_Click(object sender, EventArgs e)
        {
            LoadListAccount();
        }
        #endregion
        
    }
}
