using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleAlgo.Business
{
    public class Order
    {
        public List<Product> Products { private set; get; }

        public Order(List<Product> products)
        {
            Products = products;
        }

        public double GiveMaximumPrice()
        {
            double MaxPrice = 0;
            foreach (var product in Products)
            {
                if (product.Price > MaxPrice)
                {
                    MaxPrice = product.Price;
                }
            }
            return MaxPrice;
        }

        public double GiveAveragePrice()
        {
            double TotalPrice = 0;
            var ProductCount = Products.Count;
            foreach (var product in Products)
            {
                TotalPrice += product.Price;
            }
            return TotalPrice / ProductCount;
        }

        public List<Product> GetAllProducts(double MinimumPrice)
        {
            var ReturnProducts = new List<Product>();
            foreach (var product in Products)
            {
                if (product.Price >= MinimumPrice)
                {
                    ReturnProducts.Add(product);
                }
            }
            return ReturnProducts;
        }

        private bool ComparePriceAsc(Product A, Product B)
        {
            return A.Price < B.Price;
        }
        private bool ComparePriceDec(Product A, Product B)
        {
            return A.Price > B.Price;
        }
        public List<Product> SortProductsByPrice(bool Asc = true)
        {
            QuickSort.CompareFunction<Product> ComparePrice = ComparePriceAsc;
            if (!Asc)
            {
                ComparePrice = ComparePriceDec;
            }

            Products = QuickSort.Sort<Product>(Products, ComparePrice);
            return Products;
        }
    }
}
