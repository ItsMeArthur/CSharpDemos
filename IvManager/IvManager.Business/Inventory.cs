using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IvManager.Business
{
    public static class Inventory
    {
        public static List<Product> Products { get; set; }

        static Inventory()
        {
            Products = new List<Product>();
        }

        public static void Load()
        {
            Products = DataManager.LoadProducts();
        }

        public static void Save()
        {
            DataManager.SaveProducts(Products);
        }
        
        public static void Add(Product produto)
        {
            Products.Add(produto);
        }
    }
}
