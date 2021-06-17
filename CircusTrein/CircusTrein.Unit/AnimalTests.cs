using NUnit.Framework;
using CircusTrein.Business;
using CircusTrein.Business.Factory;
using System.Collections.Generic;

namespace CircusTrein.Unit
{
    class AnimalTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Same_Size_Carnivore_And_Herbivore_Cant_Be_Paired()
        {

            var Carnivore = AnimalFactory.CreateBigCarnivore();
            var Herbivore = AnimalFactory.CreateBigHerbivore();

            Assert.IsFalse(Carnivore.CanBePaired(Herbivore) && Herbivore.CanBePaired(Carnivore));

        }

        [Test]
        public void Smaller_Carnivore_And_Larger_Herbivore_Can_Be_Paired()
        {

            var Carnivore = AnimalFactory.CreateMediumCarnivore();
            var Herbivore = AnimalFactory.CreateBigHerbivore();

            Assert.IsTrue(Carnivore.CanBePaired(Herbivore) && Herbivore.CanBePaired(Carnivore));

        }

        [Test]
        public void Bigger_Carnivore_And_Smaller_Herbivore_Cant_Be_Paired()
        {

            var Carnivore = AnimalFactory.CreateBigCarnivore();
            var Herbivore = AnimalFactory.CreateSmallHerbivore();

            Assert.IsFalse(Carnivore.CanBePaired(Herbivore) && Herbivore.CanBePaired(Carnivore));

        }

        [Test]
        public void Two_Herbivores_Can_Be_Paired()
        {

            var Herbivore = AnimalFactory.CreateMediumHerbivore();
            var OtherHerbivore = AnimalFactory.CreateSmallHerbivore();

            Assert.IsTrue(Herbivore.CanBePaired(OtherHerbivore) && OtherHerbivore.CanBePaired(Herbivore));

        }

        [Test]
        public void Two_Carnivores_Cant_Be_Paired()
        {

            var Carnivore = AnimalFactory.CreateBigCarnivore();
            var OtherCarnivore = AnimalFactory.CreateMediumCarnivore();

            Assert.IsFalse(Carnivore.CanBePaired(OtherCarnivore) && OtherCarnivore.CanBePaired(Carnivore));

        }
    }
}
