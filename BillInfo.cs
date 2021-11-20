using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopManager
{
    public class BillInfo
    {
        public BillInfo(int id, int billid, int foodID, int count)
        {
            this.Id = id;
            this.BillID = billid;
            this.FoodID = foodID;
            this.Count = count;
        }
        public BillInfo(DataRow row)
        {
            this.id = (int)row["id"];
            this.BillID = (int)row["idbill"];
            this.FoodID = (int)row["idfood"];
            this.Count = (int)row["count"];
        }
        private int count;

        public int Count
        {
            get { return count; }
            set { count = value; }
        }
        private int foodID;

        public int FoodID
        {
            get { return foodID; }
            set { foodID = value; }
        }
        private int billID;

        public int BillID
        {
            get { return billID; }
            set { billID = value; }
        }
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}
