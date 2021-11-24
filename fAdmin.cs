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

        public fAdmin()
        {
            InitializeComponent();
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
            dtgvFood.DataSource = data;
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
            dtgvCategory.DataSource = data;
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
            dtgvTable.DataSource = data;
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
            dtgvAccount.DataSource = data;
        }
        #endregion

        #region Events
        private void btnViewBill_Click(object sender, EventArgs e)
        {
            string beginDate = dtpkFromDate.Value.Date.ToString("yyyy-MM-dd");
            string endDate = dtpkToDate.Value.Date.ToString("yyyy-MM-dd");
            LoadListBillByDate(beginDate, endDate);
        }
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
        #endregion

    }
}
