using NUnit.Framework;
using CircusTrein.Business;
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

            var Carnivore = new Animal("Tiger", AnimalDiet.Carnivore, AnimalSize.Big);
            var Herbivore = new Animal("Elephant", AnimalDiet.Herbivore, AnimalSize.Big);

            var Cart = new Cart(10);
            Cart.CheckAndAddAnimal(Carnivore);

            Assert.IsFalse(Cart.CheckAndAddAnimal(Herbivore));
        }

        [Test]
        public void Larger_Carnivore_And_Smaller_Herbivore_Cant_Fit_Together()
        {
            var Carnivore = new Animal("Tiger", AnimalDiet.Carnivore, AnimalSize.Big);
            var Herbivore = new Animal("Deer", AnimalDiet.Herbivore, AnimalSize.Medium);

            var Cart = new Cart(10);
            Cart.CheckAndAddAnimal(Carnivore);

            Assert.IsFalse(Cart.CheckAndAddAnimal(Herbivore));
        }

        [Test]
        public void Smaller_Carnivore_And_Larger_Herbivore_Can_Fit_Together()
        {
            var Carnivore = new Animal("Hyena", AnimalDiet.Carnivore, AnimalSize.Medium);
            var Herbivore = new Animal("Elephant", AnimalDiet.Herbivore, AnimalSize.Big);

            var Cart = new Cart(10);
            Cart.CheckAndAddAnimal(Carnivore);

            Assert.IsTrue(Cart.CheckAndAddAnimal(Herbivore));
        }
    }
}