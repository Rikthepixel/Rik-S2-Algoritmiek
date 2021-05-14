using System;
using System.Collections.Generic;
using SimpleAlgo.Business;

namespace SimpelAlgo.Front
{
    class Program
    {
        static void Main(string[] args)
        {
            var Products = new List<Product>();
            Products.Add(new Product("Melk", 1.50));
            Products.Add(new Product("Chocolade", 3));
            Products.Add(new Product("Golden Coin", 10000));
            Products.Add(new Product("Fristy", 2.50));
            Products.Add(new Product("Cola", 2));


            var newOrder = new Order(Products);
            for (int i = 0; i < newOrder.Products.Count; i++)
            {
                Console.WriteLine($"{i}: {newOrder.Products[i].Name} with price: {newOrder.Products[i].Price}");
            }

            Console.WriteLine("");

            newOrder.SortProductsByPrice(true);
            for (int i = 0; i < newOrder.Products.Count; i++)
            {
                Console.WriteLine($"{i}: {newOrder.Products[i].Name} with price: {newOrder.Products[i].Price}");
            }
        }
    }
}
