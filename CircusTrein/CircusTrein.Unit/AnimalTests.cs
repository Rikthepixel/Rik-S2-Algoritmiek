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

            Assert.IsFalse(Carnivore.CanBePaired(Herbivore));
        }
    }
}
