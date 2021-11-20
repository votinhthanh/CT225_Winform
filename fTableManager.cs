using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShopManager
{
    public partial class fTableManager : Form
    {
        public object ListViewSubItems { get; private set; }

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
        public fTableManager(Account acc)
        {
            InitializeComponent();
            this.LoginAccount = acc;
            LoadTable();
            loadCategory();
            LoadComboBoxTable(cbSwitchTable);
        }

        #region Methods
        /*HÀM HIỂN THỊ USERNAME KHI ĐĂNG NHẬP THÀNH CÔNG*/
        void changeAccount(int type)
        {
            adminToolStripMenuItem.Enabled = type == 1;
            accountInformationToolStripMenuItem.Text += "(" + LoginAccount.DisplayName + ")";
        }

        /*HÀM HIỂN THỊ DANH SÁCH BÀN ĂN*/
        void LoadTable()
        {
            flpTable.Controls.Clear();
            string connectSTR = @"Data Source=.\sqlexpress;Initial Catalog=Coffee_Shop_Manager;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectSTR);
            connection.Open();
            string query = "EXEC USP_GetAllTableFood";
            SqlCommand command = new SqlCommand(query, connection);
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);
            connection.Close();
            List<Table> listTable = new List<Table>();
            foreach (DataRow item in data.Rows)
            {
                Table table = new Table(item);
                listTable.Add(table);
            }
            foreach (Table item in listTable)
            {
                Button btn = new Button();
                btn.Width = 80;
                btn.Height = 80;
                btn.Click += Btn_Click;
                btn.Tag = item;
                switch (item.Status)
                {
                    case "Trống":
                        btn.BackColor = Color.Aqua;
                        break;
                    default:
                        btn.BackColor = Color.IndianRed;
                        break;
                }
                btn.Text = item.Name + Environment.NewLine + item.Status;
                flpTable.Controls.Add(btn);
            }
        }

        /*HÀM HIỂN THỊ DS TÊN BÀN ĂN CHO CHỨC NĂNG CHUYỂN BÀN*/
        void LoadComboBoxTable(ComboBox cb)
        {
            string connectSTR = @"Data Source=.\sqlexpress;Initial Catalog=Coffee_Shop_Manager;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectSTR);

            connection.Open();

            string query = "EXEC USP_GetAllTableFood";
            SqlCommand command = new SqlCommand(query, connection);

            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);

            adapter.Fill(data);

            connection.Close();
            List<Table> listTable = new List<Table>();
            foreach (DataRow item in data.Rows)
            {
                Table table = new Table(item);
                listTable.Add(table);
            }

            cb.DataSource = listTable;
            cb.DisplayMember = "Name";
        }

        /*HÀM HIỂN THỊ DANH SÁCH DANH MỤC MÓN ĂN*/
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

            cbCategoryFood.DataSource = listCategory;
            cbCategoryFood.DisplayMember = "Name";
        }

        /*HÀM HIỂN THỊ DANH SÁCH MÓN ĂN THEO DANH MỤC HIỂN THỊ*/
        void loadFoodListByCategoryID(int id)
        {
            string connectSTR = @"Data Source=.\sqlexpress;Initial Catalog=Coffee_Shop_Manager;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectSTR);

            connection.Open();

            string query = "EXEC USP_GetFoodListByCategoryId " + id;
            SqlCommand command = new SqlCommand(query, connection);
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);
            connection.Close();
            List<Food> listFood = new List<Food>();
            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                listFood.Add(food);
            }
            cbFood.DataSource = listFood;
            cbFood.DisplayMember = "Name";
        }

        /*THÊM BILL MỚI (TH BÀN TRỐNG) KHI THÊM MÓN CHO BÀN ĂN*/
        public bool InsertBill(int idTable)
        {
            string connectSTR = @"Data Source=.\sqlexpress;Initial Catalog=Coffee_Shop_Manager;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectSTR);

            connection.Open();

            string query = "EXEC USP_InsertBill " + idTable;
            SqlCommand command = new SqlCommand(query, connection);
            int result = 0;

            result = (int)command.ExecuteNonQuery();

            connection.Close();

            return result > 0;
        }

        /*LẤY RA DANH SÁCH BILL CHƯA CHECK OUT BẰNG IDTABLE*/
        public int GetUncheckBillIdByTableId(int idTable)
        {
            string connectSTR = @"Data Source=.\sqlexpress;Initial Catalog=Coffee_Shop_Manager;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectSTR);

            connection.Open();

            string query = "SELECT * FROM dbo.Bill WHERE status = 0 AND idTable = " + idTable;
            SqlCommand command = new SqlCommand(query, connection);
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);
            connection.Close();
            if (data.Rows.Count > 0)
            {
                Bill bill = new Bill(data.Rows[0]);
                return bill.Id;
            }
            return -1;
        }

        /*THÊM CẬP NHẬT CHI TIẾT HÓA ĐƠN KHI THÊM MÓN CHO BÀN*/
        public bool InsertBillInfo(int idBill, int idFood, int count)
        {
            string connectSTR = @"Data Source=.\sqlexpress;Initial Catalog=Coffee_Shop_Manager;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectSTR);
            connection.Open();
            string query = "EXEC USP_InsertBillInfo " + idBill + "," + idFood + "," + count;
            SqlCommand command = new SqlCommand(query, connection);
            int result = 0;
            result = (int)command.ExecuteNonQuery();
            connection.Close();
            return result > 0;
        }

        /*LẤY BILL MỚI NHẤT => THÊM MÓN ĂN CHO BÀN MỚI*/
        public int GetMaxIdBill()
        {
            try
            {
                string connectSTR = @"Data Source=.\sqlexpress;Initial Catalog=Coffee_Shop_Manager;Integrated Security=True";

                SqlConnection connection = new SqlConnection(connectSTR);

                connection.Open();

                string query = "select max(id) as MaxID from bill";
                SqlCommand command = new SqlCommand(query, connection);
                int data = 0;
                data = (int)command.ExecuteScalar();
                connection.Close();
                return data;
            }
            catch (Exception e)
            {
                return 1;
            }
        }

        /*LẤY ID BILL CHƯA CHECK BANG ID TABLE*/
        public int GetIdBillByIdTable(int idTable)
        {
            try
            {
                string connectSTR = @"Data Source=.\sqlexpress;Initial Catalog=Coffee_Shop_Manager;Integrated Security=True";
                SqlConnection connection = new SqlConnection(connectSTR);
                connection.Open();
                string query = "SELECT id AS ID from bill WHERE idTable = " + idTable + " AND status = 0";
                SqlCommand command = new SqlCommand(query, connection);
                int data = 0;
                if (command.ExecuteScalar() == null)
                {
                    return -1;
                }
                data = (int)command.ExecuteScalar();
                connection.Close();
                return data;
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        /*CẬP NHẬP LẠI BÀN SAU KHI XÓA BILL*/
        public bool UpdateStatusTable(int idTable)
        {
            string connectSTR = @"Data Source=.\sqlexpress;Initial Catalog=Coffee_Shop_Manager;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectSTR);
            connection.Open();
            string query = "UPDATE TableFood SET status = N'Trống' WHERE id = " + idTable;
            SqlCommand command = new SqlCommand(query, connection);
            int result = 0;

            result = (int)command.ExecuteNonQuery();

            connection.Close();

            return result > 0;
        }

        /*CHUYỂN BÀN QUA LẠI*/
        public void SwitchTable(int idTable1, int idTable2)
        {
            string connectSTR = @"Data Source=.\sqlexpress;Initial Catalog=Coffee_Shop_Manager;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectSTR);

            connection.Open();

            string query = "EXEC USP_SwitchTable " + idTable1 + ", " + idTable2;
            SqlCommand command = new SqlCommand(query, connection);
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);
            connection.Close();
        }

        /*DELETE BILL INFO BY ID BILL*/
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

        /*DELETE BILL BY ID BILL*/
        public bool DeleteBiLLById(int idBill)
        {
            string connectSTR = @"Data Source=.\sqlexpress;Initial Catalog=Coffee_Shop_Manager;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectSTR);
            connection.Open();
            string query = "DELETE Bill WHERE id = " + idBill;
            SqlCommand command = new SqlCommand(query, connection);
            int result = 0;
            result = (int)command.ExecuteNonQuery();
            connection.Close();
            return result > 0;
        }

        /*GỘP HAI BÀN LẠI VỚI NHAU*/
        public void MergeTowTable(int idTable1, int idTable2)
        {
            int IdBill1 = GetIdBillByIdTable(idTable1);
            if (IdBill1 != -1)
            {
                List<BillInfo> listFoodBill1 = new List<BillInfo>();
                string connectSTR = @"Data Source=.\sqlexpress;Initial Catalog=Coffee_Shop_Manager;Integrated Security=True";
                SqlConnection connection = new SqlConnection(connectSTR);
                connection.Open();
                string query = "SELECT * FROM BillInfo WHERE idBill = " + IdBill1;
                SqlCommand command = new SqlCommand(query, connection);
                DataTable data = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                connection.Close();
                foreach (DataRow item in data.Rows)
                {
                    BillInfo bi = new BillInfo(item);
                    listFoodBill1.Add(bi);
                }
                bool check = false;
                int IdBill2 = GetIdBillByIdTable(idTable2);
                foreach (BillInfo item in listFoodBill1)
                {
                    check = InsertBillInfo(IdBill2, item.FoodID, item.Count);
                }
                check = DeleteBiLLInfoByIdBill(IdBill1);
                check = DeleteBiLLById(IdBill1);
                check = UpdateStatusTable(idTable1);
            }
        }

        /*THANH TOÁN HÓA ĐƠN*/
        public void CheckOut(int idBill, float discount, float totalPrice)
        {
            string connectSTR = @"Data Source=.\sqlexpress;Initial Catalog=Coffee_Shop_Manager;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectSTR);

            connection.Open();

            string query = "EXEC USP_CheckoutBill " + idBill + ", " + discount + ", " + totalPrice;
            SqlCommand command = new SqlCommand(query, connection);
            int data = command.ExecuteNonQuery();
            connection.Close();
        }

        /*HIỂN THỊ DANH SÁCH MÓN ĂN KHI CLICK BÀN TƯƠNG ỨNG*/
        void ShowBill(int id)
        {
            lsvBill.Items.Clear();
            string connectSTR = @"Data Source=.\sqlexpress;Initial Catalog=Coffee_Shop_Manager;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectSTR);

            connection.Open();

            string query = "EXEC USP_GetDetailBillByTableId " + id;
            SqlCommand command = new SqlCommand(query, connection);
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);
            connection.Close();

            List<Menu> listMenu = new List<Menu>();
            foreach (DataRow item in data.Rows)
            {
                Menu menu_item = new Menu(item);
                listMenu.Add(menu_item);
            }
            float totalPrice = 0;
            foreach (Menu item in listMenu)
            {
                totalPrice += item.Price * item.Count;
                ListViewItem lsvitem = new ListViewItem(item.FoodName.ToString());
                lsvitem.SubItems.Add(item.Count.ToString());
                lsvitem.SubItems.Add(item.Price.ToString());
                lsvitem.SubItems.Add(item.TotalPrice.ToString());
                lsvBill.Items.Add(lsvitem);
            }
            CultureInfo culture = new CultureInfo("vi-VN");
            txtTotalPriceVn.Text = (totalPrice - totalPrice * 50 / 100).ToString("c", culture);
            txtTotalPriceEn.Text = (totalPrice / 22681.01).ToString("c");
            LoadTable();
        }
        #endregion

        #region Events

        /*SỰ DỤNG QUYỀN ADMIN*/
        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAdmin f = new fAdmin();
            f.loginAccount = LoginAccount;
            f.InsertFoodEvent += f_InsertFoodEvent;
            f.UpdateFoodEvent += f_UpdateFoodEvent;
            f.DeleteFoodEvent += f_DeleteFoodEvent;
            
            f.InsertCategoryFoodEvent += f_InsertCategoryFoodEvent;
            f.UpdateCategoryFoodEvent += f_UpdateCategoryFoodEvent;
            f.DeleteCategoryFoodEvent += f_DeleteCategoryFoodEvent;

            f.InsertTableFoodEvent += f_InsertTableFoodEvent;
            f.UpdateTableFoodEvent += f_UpdateTableFoodEvent;
            f.DeleteTableFoodEvent += f_DeleteTableFoodEvent;
            f.ShowDialog();
        }

        /*ĐĂNG XUẤT TÀI KHOẢN*/
        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /*XEM THÔNG TIN TÀI KHOẢN*/
        private void showInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAccountProfile f = new fAccountProfile(LoginAccount);
            f.UpdateAccountEvent += f_UpdateAccountEvent;
            f.ShowDialog();
            this.Show();
        }

        /*CẬP NHẬT TÊN HIỂN THỊ KHI CẬP NHẬT TÀI KHOẢN*/
        private void f_UpdateAccountEvent(object sender, AccountEvent e)
        {
            accountInformationToolStripMenuItem.Text = "Account Information (" + e.Acc.DisplayName + ")";
        }
              
        /*LOAD LẠI DANH SÁCH THỨC ĂN TƯƠNG ỨNG KHI THAY ĐỔI DANH MỤC*/
        private void cbCategoryFood_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null)
            {
                return;
            }
            Category category_selected = cb.SelectedItem as Category;

            int idCategory = category_selected.ID;
            loadFoodListByCategoryID(idCategory);
        }

        /*THÊM MÓN ĂN CHO TABLE*/
        private void btnAddFood_Click(object sender, EventArgs e)
        {
            Table table = lsvBill.Tag as Table;

            if (table == null)
            {
                MessageBox.Show("Please select table !!!");
                return;
            }
            int idBill = GetUncheckBillIdByTableId(table.ID);
            int idFood = (cbFood.SelectedItem as Food).Id;
            int count = (int)nmCount.Value;
            bool check = false;
            if (idBill == -1)
            {
                /*TẠO BILL MỚI CHO BÀN*/
                check = InsertBill(table.ID);
                int idBillMax = (int)GetMaxIdBill();
                check = InsertBillInfo(idBillMax, idFood, count);
            }
            else
            {
                check = InsertBillInfo(idBill, idFood, count);
            }
            if (check)
            {
                MessageBox.Show("Add food for table '" + table.Name + "' is successfull !", "Alert !");
                ShowBill(table.ID);
            }
            else
            {
                MessageBox.Show("Can't Add food for table '" + table.Name + "!", "Error!");
            }

        }

        /*THANH TOÁN CHO TABLE*/
        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            Table table = lsvBill.Tag as Table;
            int idBill = GetUncheckBillIdByTableId(table.ID);
            int discount = (int)nmDiscount.Value;

            double totalPrice = Convert.ToDouble(txtTotalPriceVn.Text.Split(',')[0].Replace(".", ""));
            double discountPrice = totalPrice / 100 * discount;
            float finalTotalPrice = (float)(totalPrice - discountPrice);
            if (idBill != -1)
            {
                if (MessageBox.Show("Do you want to check out  for this table? \n" +
                   String.Format("Table {0}:\nTotal Price = {1}\n Discount = {2}\n Pay = {3}", table.ID, totalPrice, discount, finalTotalPrice)
                   , "Alert !!!", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    CheckOut(idBill, discount, finalTotalPrice);
                    ShowBill(table.ID);
                }
            }
            LoadTable();
        }

        /*CHUYỂN BÀN*/
        private void btnSwitchTable_Click(object sender, EventArgs e)
        {
            Table table = lsvBill.Tag as Table;

            if (table == null)
            {
                MessageBox.Show("Please select table !!!");
                return;
            }
            int idTable1 = table.ID;
            int idTable2 = (cbSwitchTable.SelectedItem as Table).ID;
            int idBillTable1 = GetUncheckBillIdByTableId(idTable1);
            int idBillTable2 = GetUncheckBillIdByTableId(idTable2);
            if(idBillTable2 == -1)
            {
                bool check = InsertBill(idTable2);
                idBillTable2 = GetUncheckBillIdByTableId(idTable2);
            }
            if (MessageBox.Show(String.Format("Do you want to merge table {0} witch Table {1}?", idTable1, idTable2)
                   , "Alert !!!", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                if(idBillTable1 != -1)
                {
                    MergeTowTable(idTable1, idTable2);
                    LoadTable();
                    LoadComboBoxTable(cbSwitchTable);
                }
            }
            else
            {
                if (MessageBox.Show(String.Format("Do you want to switch from table {0} to Table {1}?", idTable1, idTable2)
                   , "Alert !!!", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    SwitchTable(idTable1, idTable2);
                    LoadTable();
                    LoadComboBoxTable(cbSwitchTable);
                }
            }
        }

        /*HIỂN THI DANH SÁCH MÓN ĂN KHI CLICK VÀ BÀN TƯƠNG ỨNG*/
        private void Btn_Click(object sender, EventArgs e)
        {
            int tableId = ((sender as Button).Tag as Table).ID;
            lsvBill.Tag = (sender as Button).Tag;
            ShowBill(tableId);
        }

        /*
         * BẮT SỰ KIỆN LOAD LẠI PAGE QUẢN LÝ BÀN ĂN
         * 
         * KHI THÊM SỬA XÓA MÓN ĂN
         */
        private void f_DeleteFoodEvent(object sender, EventArgs e)
        {
            loadFoodListByCategoryID((cbCategoryFood.SelectedItem as Category).ID);
            if (lsvBill.Tag != null)
                ShowBill((lsvBill.Tag as Table).ID);
            LoadTable();
        }
        private void f_UpdateFoodEvent(object sender, EventArgs e)
        {
            loadFoodListByCategoryID((cbCategoryFood.SelectedItem as Category).ID);
            if (lsvBill.Tag != null)
                ShowBill((lsvBill.Tag as Table).ID);
        }
        private void f_InsertFoodEvent(object sender, EventArgs e)
        {
            loadFoodListByCategoryID((cbCategoryFood.SelectedItem as Category).ID);
            if (lsvBill.Tag != null)
                ShowBill((lsvBill.Tag as Table).ID);
        }

        /*
         * BẮT SỰ KIỆN LOAD LẠI PAGE QUẢN LÝ BÀN ĂN
         * 
         * KHI THÊM SỬA XÓA DANH MỤC MÓN ĂN
         */
        private void f_DeleteCategoryFoodEvent(object sender, EventArgs e)
        {
            loadCategory();
            loadFoodListByCategoryID((cbCategoryFood.SelectedItem as Category).ID);
            if (lsvBill.Tag != null)
                ShowBill((lsvBill.Tag as Table).ID);
            LoadTable();
        }

        private void f_UpdateCategoryFoodEvent(object sender, EventArgs e)
        {
            loadCategory();
            loadFoodListByCategoryID((cbCategoryFood.SelectedItem as Category).ID);
            if (lsvBill.Tag != null)
                ShowBill((lsvBill.Tag as Table).ID);
            LoadTable();
        }

        private void f_InsertCategoryFoodEvent(object sender, EventArgs e)
        {
            loadCategory();
            loadFoodListByCategoryID((cbCategoryFood.SelectedItem as Category).ID);
            if (lsvBill.Tag != null)
                ShowBill((lsvBill.Tag as Table).ID);
            LoadTable();
        }

        /*
         * BẮT SỰ KIỆN LOAD LẠI PAGE QUẢN LÝ BÀN ĂN
         * 
         * KHI THÊM SỬA XÓA bàn ăn
         */
        private void f_InsertTableFoodEvent(object sender, EventArgs e)
        {
            loadCategory();
            loadFoodListByCategoryID((cbCategoryFood.SelectedItem as Category).ID);
            if (lsvBill.Tag != null)
                ShowBill((lsvBill.Tag as Table).ID);
            LoadTable();
        }

        private void f_UpdateTableFoodEvent(object sender, EventArgs e)
        {
            loadCategory();
            loadFoodListByCategoryID((cbCategoryFood.SelectedItem as Category).ID);
            if (lsvBill.Tag != null)
                ShowBill((lsvBill.Tag as Table).ID);
            LoadTable();
        }

        private void f_DeleteTableFoodEvent(object sender, EventArgs e)
        {
            loadCategory();
            loadFoodListByCategoryID((cbCategoryFood.SelectedItem as Category).ID);
            if (lsvBill.Tag != null)
                ShowBill((lsvBill.Tag as Table).ID);
            LoadTable();
        }
        #endregion
    }
}

/*if (MessageBox.Show(String.Format("IDBILL = {0}", idBill)
       , "Alert !!!", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
{
    return;
}*/
