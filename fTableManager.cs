using QuanLyQuanCafe.Bill;
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
            set{
                loginAccount = value;
                changeAccount(loginAccount.Type);
            }
        }

        public fTableManager(Account acc)
        {
            InitializeComponent();
            this.LoginAccount = acc;
            LoadListTable();
            loadListCategoryFoodNameOnComboBox();
        }
        #region
        /*HIỂN THỊ TÊN HIỂN THỊ BÊN QUẢN LÝ QUÁN CAFE*/
        void changeAccount(int type)
        {
            adminToolStripMenuItem.Enabled = type == 1;
            accountInformationToolStripMenuItem.Text += " (" + LoginAccount.DisplayName + ")";
        }
        /*HÀM HIỂN THỊ DANH SÁCH BÀN ĂN*/
        void LoadListTable()
        {
            flpTable.Controls.Clear();
            string connectSTR = @"Data Source=.\sqlexpress;Initial Catalog=Coffee_Shop_Manager;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectSTR);
            connection.Open();
            string query = "SELECT * FROM TableFood";
            SqlCommand command = new SqlCommand(query, connection);
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);
            connection.Close();
            List<Table> listTable = new List<Table>();
            if(data == null)
            {
                return;
            }
            foreach (DataRow item in data.Rows)
            {
                Table table = new Table(item);
                listTable.Add(table);
            }
            foreach (Table item in listTable)
            {
                Button btn = new Button();
                btn.Width = 112;
                btn.Height = 112;
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
            cbChangeTable.DataSource = listTable;
            cbChangeTable.DisplayMember = "Name";
        }
        /*HÀM HIỂN THỊ DANH SÁCH DANH MỤC MÓN ĂN*/
        void loadListCategoryFoodNameOnComboBox()
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

            cbCategoryFood.DataSource = listCategory;
            cbCategoryFood.DisplayMember = "Name";
        }

        /*HÀM HIỂN THỊ DANH SÁCH MÓN ĂN THEO DANH MỤC HIỂN THỊ*/
        void loadListFoodByCategoryId(int id)
        {
            string connectSTR = @"Data Source=.\sqlexpress;Initial Catalog=Coffee_Shop_Manager;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectSTR);

            connection.Open();

            string query = "SELECT * FROM Food WHERE idCategory = " + id;
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
        int getIdBillUnCheckOutByIdTable(int idTable)
        {
            string connectSTR = @"Data Source=.\sqlexpress;Initial Catalog=Coffee_Shop_Manager;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectSTR);

            connection.Open();

            string query = "SELECT * FROM Bill WHERE status = 0 AND idTable = " + idTable;
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
        
        public bool InsertBill(int idTable)
        {
            string connectSTR = @"Data Source=.\sqlexpress;Initial Catalog=Coffee_Shop_Manager;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectSTR);

            connection.Open();

            string query = "INSERT Bill (idTable) VALUES (" + idTable +")";
            SqlCommand command = new SqlCommand(query, connection);
            int result = (int)command.ExecuteNonQuery();

            connection.Close();
            return result > 0;
        }

        public bool InsertBillInfo(int idBill, int idFood, int count)
        {
            string connectSTR = @"Data Source=.\sqlexpress;Initial Catalog=Coffee_Shop_Manager;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectSTR);

            connection.Open();

            string query = "EXEC USP_InsertBillInfo " + idBill + "," + idFood + "," + count;
            SqlCommand command = new SqlCommand(query, connection);
            int result = (int)command.ExecuteNonQuery();

            connection.Close();
            return result > 0;
        }

        public void ShowBill(int idTable)
        {
            lsvBill.Items.Clear();
            string connectSTR = @"Data Source=.\sqlexpress;Initial Catalog=Coffee_Shop_Manager;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectSTR);

            connection.Open();

            string query = "EXEC USP_GetBillInfoByIdTable " + idTable;
            SqlCommand command = new SqlCommand(query, connection);
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);
            connection.Close();
            if(data == null)
            {
                return;
            }
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
            int discount = (int)nmDiscount.Value;
            txtTotalPrice.Text = (totalPrice - totalPrice * discount / 100).ToString("c", culture);
            //LoadTable();
        }

        public void CheckOutBill(int idTable, float discount, float finalTotalPrice)
        {
            string connectSTR = @"Data Source=.\sqlexpress;Initial Catalog=Coffee_Shop_Manager;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectSTR);

            connection.Open();

            string query = "EXEC USP_CheckOutBillForTable " + idTable + ", " + discount + ", " + finalTotalPrice;
            SqlCommand command = new SqlCommand(query, connection);
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);
            connection.Close();
        }

        #endregion

        #region Events
        /*SỰ DỤNG QUYỀN ADMIN*/
        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAdmin f = new fAdmin();
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
            fAccountProfile f = new fAccountProfile();
            f.ShowDialog();
            this.Show();
        }
        private void cbCategoryFood_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null)
            {
                return;
            }
            Category category_selected = cb.SelectedItem as Category;
            int idCategory = category_selected.ID;
            loadListFoodByCategoryId(idCategory);
        }
        #endregion
        private void Btn_Click(object sender, EventArgs e)
        {
            int tableId = ((sender as Button).Tag as Table).ID;
            lsvBill.Tag = (sender as Button).Tag;
            nmDiscount.Value = 0;
            ShowBill(tableId);
        }
        private void btnAddFood_Click(object sender, EventArgs e)
        {
            Table tableClicked = lsvBill.Tag as Table;
            if (tableClicked == null)
            {
                MessageBox.Show("Vui lòng chọn bàn trước khi thêm món","Cảnh báo !");
                return;
            }
            int idFood = (cbFood.SelectedItem as Food).Id;
            string categoryFoodName = cbCategoryFood.Text;
            int count = (int)nmCount.Value;
            int idBill = getIdBillUnCheckOutByIdTable(tableClicked.ID);
            if(idBill == -1)
            {
                //tao bill moi
                InsertBill(tableClicked.ID);
                //them bill info
                int idBillMax = getIdBillUnCheckOutByIdTable(tableClicked.ID);
                InsertBillInfo(idBillMax, idFood, count);
                MessageBox.Show("Thêm " + count + " món '" + (cbFood.SelectedItem as Food).Name + "' vào bàn " + tableClicked.Name + "\n Thành công !!!");
            }
            else
            {
                InsertBillInfo(idBill, idFood, count);
                MessageBox.Show("Thêm " + count + " món '" + (cbFood.SelectedItem as Food).Name + "' vào bàn " + tableClicked.Name + "\n Thành công !!!");
            }
            ShowBill(tableClicked.ID);
            LoadListTable();
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            Table tableClicked = lsvBill.Tag as Table;
            int discount = (int)nmDiscount.Value;

            double finalTotalPrice = Convert.ToDouble(txtTotalPrice.Text.Split(',')[0].Replace(".", ""));
            if (tableClicked == null)
            {
                MessageBox.Show("Vui lòng chọn bàn muốn thanh toán", "Cảnh báo !");
                return;
            }
            if (MessageBox.Show("CHI TIẾT THANH TOÁN CHO " + tableClicked.Name +
                  String.Format("\nGIẢM GIÁ:   {0}\nTỔNG THANH TOÁN:    {1}", discount, finalTotalPrice)
                  , "Thông báo !!!", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                CheckOutBill(tableClicked.ID, discount, (float)finalTotalPrice);
                ShowBill(tableClicked.ID);
                LoadListTable();
            }
            
        }

        private void nmDiscount_ValueChanged(object sender, EventArgs e)
        {
            Table tableClicked = lsvBill.Tag as Table;
            if (tableClicked != null)
            {
                ShowBill(tableClicked.ID);
            }
            
        }

        private void btnChangeTable_Click(object sender, EventArgs e)
        {
            Table table1 = lsvBill.Tag as Table;
            Table table2 = cbChangeTable.SelectedItem as Table;
            if (table1 == null)
            {
                MessageBox.Show("Vui lòng chọn bàn trước !!!", "Cảnh báo !!!");
                return;
            }
            fChangeTable f = new fChangeTable(table1, table2);
            f.SwitchTableEvent += f_SwitchTableEvent;
            f.MergeTableEvent += f_MergeTableEvent;
            f.Show();
        }

        private void f_MergeTableEvent(object sender, EventArgs e)
        {
            LoadListTable();
        }

        private void f_SwitchTableEvent(object sender, EventArgs e)
        {
            LoadListTable();
        }
    }
}
