using NUnit.Framework;
using CircusTrein.Business;
using CircusTrein.Business.Factory;
using System.Collections.Generic;

namespace CircusTrein.Unit
{
    public class CartTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Same_Size_Carnivore_And_Herbivore_Cant_Fit_Together()
        {

            var Carnivore = AnimalFactory.CreateBigCarnivore();
            var Herbivore = AnimalFactory.CreateBigHerbivore();

            var Cart = new Cart(10);
            Cart.CheckAndAddAnimal(Carnivore);

            Assert.IsFalse(Cart.CheckAndAddAnimal(Herbivore));
        }

        [Test]
        public void Larger_Carnivore_And_Smaller_Herbivore_Cant_Fit_Together()
        {
            var Carnivore = AnimalFactory.CreateBigCarnivore();
            var Herbivore = AnimalFactory.CreateMediumHerbivore();

            var Cart = new Cart(10);
            Cart.CheckAndAddAnimal(Carnivore);

            Assert.IsFalse(Cart.CheckAndAddAnimal(Herbivore));
        }

        [Test]
        public void Smaller_Carnivore_And_Larger_Herbivore_Can_Fit_Together()
        {
            var Carnivore = AnimalFactory.CreateMediumCarnivore();
            var Herbivore = AnimalFactory.CreateBigHerbivore();

            var Cart = new Cart(10);
            Cart.CheckAndAddAnimal(Carnivore);

            Assert.IsTrue(Cart.CheckAndAddAnimal(Herbivore));
        }

        [Test]
        public void Carnivores_Cant_Fit_Together()
        {
            var Carnivore = AnimalFactory.CreateBigCarnivore();
            var Herbivore = AnimalFactory.CreateBigCarnivore();

            var Cart = new Cart(10);
            Cart.CheckAndAddAnimal(Carnivore);

            Assert.IsFalse(Cart.CheckAndAddAnimal(Herbivore));
        }
    }
}