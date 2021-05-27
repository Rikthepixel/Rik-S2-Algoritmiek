using NUnit.Framework;
using CircusTrein.Business;
using System.Collections.Generic;
using CircusTrein.Business.Factory;

namespace CircusTrein.Unit
{
    public class TrainTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void LargeCarnivore_SmallHerbivore_Sort()
        {
            var Animals = new List<Animal>();
            Animals.Add(AnimalFactory.CreateBigCarnivore());
            Animals.Add(AnimalFactory.CreateSmallHerbivore());

            var CircusTrain = new Train();
            CircusTrain.LoadAnimals(Animals);

            var Carts = CircusTrain.GetCarts();
            Assert.IsTrue(Carts.Count > 1);
        }

        [Test]
        public void LargeCarnivore_LargeHerbivore_Sort()
        {
            var Animals = new List<Animal>();
            Animals.Add(AnimalFactory.CreateBigCarnivore());
            Animals.Add(AnimalFactory.CreateBigHerbivore());

            var CircusTrain = new Train();
            CircusTrain.LoadAnimals(Animals);

            var Carts = CircusTrain.GetCarts();
            Assert.IsTrue(Carts.Count > 1);
        }

        [Test]
        public void MediumCarnivore_LargeHerbivore_Sort()
        {
            var Animals = new List<Animal>();
            Animals.Add(AnimalFactory.CreateMediumCarnivore());
            Animals.Add(AnimalFactory.CreateBigHerbivore());

            var CircusTrain = new Train();
            CircusTrain.LoadAnimals(Animals);

            var Carts = CircusTrain.GetCarts();
            Assert.IsTrue(Carts.Count == 1);
        }

        [Test]
        public void SmallCarnivore_MediumHerbivore_Sort()
        {
            var Animals = new List<Animal>();
            Animals.Add(AnimalFactory.CreateSmallCarnivore());
            Animals.Add(AnimalFactory.CreateMediumHerbivore());

            var CircusTrain = new Train();
            CircusTrain.LoadAnimals(Animals);

            var Carts = CircusTrain.GetCarts();
            Assert.IsTrue(Carts.Count == 1);
        }

        [Test]
        public void Empty_List_Of_Animals()
        {
            var Animals = new List<Animal>();

            var CircusTrain = new Train();
            CircusTrain.LoadAnimals(Animals);

            var Carts = CircusTrain.GetCarts();
            Assert.IsTrue(Carts.Count == 0);
        }
    }
}