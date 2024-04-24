using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace SynCart
{
    public class ProductDetails
    {
        private static int s_productID = 100;
        public string ProductID { get; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public int Duration { get; set; }
        public ProductDetails(string productName, int stock, int price, int duration)
        {
            ProductID = "PID" + ++s_productID;
            ProductName = productName;
            Price = price;
            Stock = stock;
            Duration = duration;
        }
    }
}