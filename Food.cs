using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopManager
{
    public class Food
    {
        public Food(int id, int idCategory, string name, float price)
        {
            this.Id = id;
            this.CategoryID = categoryID;
            this.Name = name;
            this.Price = price;
        }
        public Food(DataRow row)
        {
            this.Id = (int)row["id"];
            this.Name = row["name"].ToString();
            this.CategoryID = (int)row["Idcategory"];
            this.Price = (float)Convert.ToDouble(row["price"].ToString());
        }

        private float price;

        public float Price
        {
            get { return price; }
            set { price = value; }
        }
        private int categoryID;

        public int CategoryID
        {
            get { return categoryID; }
            set { categoryID = value; }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private int id;
        private DataRow item;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}
