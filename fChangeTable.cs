using QuanLyQuanCafe.Bill;
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
    public partial class fChangeTable : Form
    {
        private Table tableFirst;
        public Table TableFirst
        {
            get { return tableFirst; }
            set
            {
                tableFirst = value;
            }
        }

        private Table tableSecond;
        public Table TableSecond
        {
            get { return tableSecond; }
            set
            {
                tableSecond = value;
            }
        }
        public fChangeTable(Table tableFirst, Table tableSecond)
        {
            
            InitializeComponent();
            this.tableFirst = tableFirst;
            this.tableSecond = tableSecond;
            LoadAlert();
        }
        #region Methods
        void LoadAlert()
        {
            string alert = "Thay đổi từ '" + this.TableFirst.Name + "'  ===>  '" + this.tableSecond.Name + "'";
            txtChangeTable.Text = alert;
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

            string query = "INSERT Bill (idTable) VALUES (" + idTable + ")";
            SqlCommand command = new SqlCommand(query, connection);
            int result = (int)command.ExecuteNonQuery();

            connection.Close();
            return result > 0;
        }

        public void SwitchTable(int idTable1, int idTable2)
        {
            string connectSTR = @"Data Source=.\sqlexpress;Initial Catalog=Coffee_Shop_Manager;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectSTR);

            connection.Open();

            string query = "EXEC USP_SwitchTable " + idTable1 + ", "+ idTable2;
            SqlCommand command = new SqlCommand(query, connection);
            int result = (int)command.ExecuteNonQuery();

            connection.Close();
        }

        public void MergeTable(int idTable1, int idTable2)
        {
            string connectSTR = @"Data Source=.\sqlexpress;Initial Catalog=Coffee_Shop_Manager;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectSTR);

            connection.Open();

            string query = "EXEC USP_MergeTable " + idTable1 + ", " + idTable2;
            SqlCommand command = new SqlCommand(query, connection);
            int result = (int)command.ExecuteNonQuery();

            connection.Close();
        }
        #endregion
        private void fChangeTable_Load(object sender, EventArgs e)
        {
            
        }
        private event EventHandler switchTableEvent;
        public event EventHandler SwitchTableEvent
        {
            add { switchTableEvent += value; }
            remove { switchTableEvent -= value; }
        }
        private void btnSwitchTable_Click(object sender, EventArgs e)
        {
            int idTable1 = this.tableFirst.ID;
            int idTable2 = this.tableSecond.ID;
            int idBillTable1 = getIdBillUnCheckOutByIdTable(idTable1);
            int idBillTable2 = getIdBillUnCheckOutByIdTable(idTable2);
            bool check1 = false;
            bool check2 = false;
            if (idBillTable1 == -1)
            {
                check1 = InsertBill(idTable1);
            }
            if (idBillTable2 == -1)
            {
                check2 = InsertBill(idTable2);
            }
            SwitchTable(idTable1, idTable2);
            MessageBox.Show("Chuyển bàn thành công !!!", "Thông báo !!!");
            if (switchTableEvent != null)
            {
                switchTableEvent(this, new EventArgs());
            }
            this.Close();
        }
        private event EventHandler mergeTableEvent;
        public event EventHandler MergeTableEvent
        {
            add { mergeTableEvent += value; }
            remove { mergeTableEvent -= value; }
        }
        private void btnMergeTable_Click(object sender, EventArgs e)
        {
            int idTable1 = this.tableFirst.ID;
            int idTable2 = this.tableSecond.ID;
            int idBillTable1 = getIdBillUnCheckOutByIdTable(idTable1);
            int idBillTable2 = getIdBillUnCheckOutByIdTable(idTable2);
            if (idBillTable1 == -1)
            {
                return;
            }
            MergeTable(idTable1, idTable2);
            MessageBox.Show("Gộp bàn "+ this.tableFirst.Name+" sang "+this.tableSecond.Name+" thành công !!!", "Thông báo !!!");
            if (mergeTableEvent != null)
            {
                mergeTableEvent(this, new EventArgs());
            }
            this.Close();
        }

        private void btnExits_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
