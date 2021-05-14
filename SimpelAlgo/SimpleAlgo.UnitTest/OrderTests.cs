using NUnit.Framework;
using SimpleAlgo.Business;
using System.Collections.Generic;

namespace SimpleAlgo.UnitTest
{
    public class OrderTests
    {
        private List<Product> Products;

        [SetUp]
        public void Setup()
        {
            Products = new List<Product>();
            Products.Add(new Product("Melk", 1.50));
            Products.Add(new Product("Chocolade", 3));
            Products.Add(new Product("Golden Coin", 10000));
            Products.Add(new Product("Fristy", 2.50));
            Products.Add(new Product("Cola", 2));
        }


        [Test]
        public void Sort()
        {
            //Arrange
            var newOrder = new Order(Products);
            bool Asc = true;

            //Act
            var OrderedProductList = newOrder.SortProductsByPrice(Asc);

            //Assert
            Assert.IsTrue(OrderedProductList != null);
        }

        [Test]
        public void GetAllProducts()
        {
            //Arrange
            var newOrder = new Order(Products);

            //Act
            var OrderedProducts = newOrder.GetAllProducts(2);
            
            //Assert
            Assert.IsTrue(OrderedProducts.Count > 3);
        }

        [Test]
        public void GiveAveragePrice()
        {
            //Arrange
            var newOrder = new Order(Products);

            //Act
            var AveragePrice = newOrder.GiveAveragePrice();

            //Assert
            Assert.IsTrue(AveragePrice != 0);
        }

        [Test]
        public void GiveMaximumPrice()
        {
            //Arrange
            var newOrder = new Order(Products);

            //Act
            var MaxPrice = newOrder.GiveMaximumPrice();

            //Assert
            Assert.IsTrue(MaxPrice == 10000);
        }
    }
}