using IvManager.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace IvManager.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //The main loop
            bool runAgain = true;
            while (runAgain)
            {
                PrintMenu();
                int input = int.Parse(Console.ReadLine());



                switch (input)
                {
                    case 0:
                        runAgain = false;
                        break;

                    case 1:
                        PrintProductsList();
                        break;

                    case 2:
                        Console.Write("N° of items to add: ");
                        int itemsToAdd = int.Parse(Console.ReadLine());
                        AddProducts(itemsToAdd);
                        break;

                    case 3:
                        PrintProductsList();
                        Console.Write("ID of item to remove: ");
                        int itemToRemove = int.Parse(Console.ReadLine());
                        Inventory.RemoveProduct(itemToRemove);
                        break;

                    case 4:
                        Console.WriteLine("Are you sure you want to delete all items?");
                        Console.WriteLine("(1) - Yes");
                        Console.WriteLine("(2) - No");
                        int deleteInput = int.Parse(Console.ReadLine());
                        HandleInventoryDeletion(deleteInput);
                        break;

                    case 5:
                        PrintInventoryInfoMenu();
                        int infoInput = int.Parse(Console.ReadLine());
                        PrintIventoryInfo(infoInput);
                        break;

                    default:
                        Console.WriteLine("Invalid input. Try again. ");
                        break;
                }                    
            }
        }

        private static void HandleInventoryDeletion(int deleteInput)
        {
            switch (deleteInput)
            {
                case 1:
                    Inventory.ClearInventory();
                    break;
                case 2:
                    Console.WriteLine("Inventory was not removed.");
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }

        private static void PrintIventoryInfo(int infoInput)
        {
            switch (infoInput)
            {
                case 1:
                    int productCount = Inventory.GetProductCount();
                    Console.WriteLine($"Product count: {productCount}");
                    break;
                case 2:
                    int unitCount = Inventory.GetUnitCount();
                    Console.WriteLine($"Unit count: {unitCount}");
                    break;
                case 3:
                    decimal inventoryValue = Inventory.GetInventoryValue();
                    Console.WriteLine($"Inventory value: {inventoryValue}");
                    break;
                default:
                    break;
            }
        }

        private static void PrintInventoryInfoMenu()
        {
            Console.WriteLine("========= INVENTORY INFO =========");
            Console.WriteLine("(1) - Products in inventory");
            Console.WriteLine("(2) - Units in inventory");
            Console.WriteLine("(3) - Inventory value");
            Console.WriteLine("(0) - Back");
            Console.Write("Input: ");
        }

        private static void PrintMenu()
        {
            Console.WriteLine("======== MENU ========");
            Console.WriteLine("(1) to list products.");
            Console.WriteLine("(2) to add products.");
            Console.WriteLine("(3) to remove a product. ");
            Console.WriteLine("(4) to delete the inventory. ");
            Console.WriteLine("(5) to get inventory info. ");

            Console.WriteLine("(0) to exit.");
            Console.Write("Input : ");
        }

        private static void AddProducts(int itemsToAdd)
        {
            for (int i = 1; i <= itemsToAdd; i++)
            {
                Console.WriteLine("__________________________");
                Console.WriteLine("PRODUCT " + i.ToString());

                Product prod = new Product();

                prod.Id = Inventory.GetNewId();
                Console.Write("Name: ");
                prod.Name = Console.ReadLine();
                Console.Write("Price: ");
                prod.Price = decimal.Parse(Console.ReadLine());
                Console.Write("Quantity: ");
                prod.Quantity = int.Parse(Console.ReadLine());

                Inventory.Add(prod);
            }
        }

        private static void PrintProductsList()
        {
            Console.WriteLine("__________________________");
            foreach (var item in Inventory.Products)
            {
                Console.WriteLine("{0} | {1} | {2} | {3} ",
                    item.Id, item.Name, item.Price, item.Quantity);
            }
            Console.WriteLine("__________________________");
        }
    }
}
