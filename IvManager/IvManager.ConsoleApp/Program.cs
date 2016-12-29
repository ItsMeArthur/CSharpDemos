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
            bool runAgain = true;
            while (runAgain)
            {
                Console.WriteLine("======== MENU ========");
                Console.WriteLine("(1) to list products.");
                Console.WriteLine("(2) to add products.");
                Console.WriteLine("(3) to exit.");
                Console.Write("Input : ");
                int input = int.Parse(Console.ReadLine());

                if (input == 1)
                {
                    Inventory.Load();
                    Console.WriteLine("__________________________");
                    foreach (var item in Inventory.Products)
                    {
                        System.Console.WriteLine("{0} | {1} | {2} | {3} ",
                            item.Id, item.Name, item.Price, item.Quantity);
                    }
                }
                else if (input == 2)
                {
                    Console.Write("N° of items to add: ");
                    int itemsToAdd = int.Parse(Console.ReadLine());

                    for (int i = 1; i <= itemsToAdd; i++)
                    {
                        Console.WriteLine("__________________________");
                        Console.WriteLine("PRODUCT " + i.ToString());

                        Product prod = new Product();

                        prod.Id = i;
                        Console.Write("Name: ");
                        prod.Name = Console.ReadLine();
                        Console.Write("Price: ");
                        prod.Price = decimal.Parse(Console.ReadLine());
                        Console.Write("Quantity: ");
                        prod.Quantity = int.Parse(Console.ReadLine());

                        Inventory.Add(prod);
                    }
                    Inventory.Save();
                }
                else if (input == 3)
                    runAgain = false;
                else
                    Console.WriteLine("Invalid input. Try again. ");

            }
        }
    }
}
