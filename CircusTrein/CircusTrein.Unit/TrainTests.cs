using NUnit.Framework;
using CircusTrein.Business;
using System.Collections.Generic;

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
            Animals.Add(new Animal("Tiger", AnimalDiet.Carnivore, AnimalSize.Big));
            Animals.Add(new Animal("Maki", AnimalDiet.Herbivore, AnimalSize.Small));

            var CircusTrain = new Train();
            CircusTrain.LoadAnimals(Animals);

            var Carts = CircusTrain.GetCarts();
            Assert.IsTrue(Carts.Count > 1);
        }

        [Test]
        public void LargeCarnivore_LargeHerbivore_Sort()
        {
            var Animals = new List<Animal>();
            Animals.Add(new Animal("Tiger", AnimalDiet.Carnivore, AnimalSize.Big));
            Animals.Add(new Animal("Elephant", AnimalDiet.Herbivore, AnimalSize.Big));

            var CircusTrain = new Train();
            CircusTrain.LoadAnimals(Animals);

            var Carts = CircusTrain.GetCarts();
            Assert.IsTrue(Carts.Count > 1);
        }

        [Test]
        public void MediumCarnivore_LargeHerbivore_Sort()
        {
            var Animals = new List<Animal>();
            Animals.Add(new Animal("Hyena", AnimalDiet.Carnivore, AnimalSize.Medium));
            Animals.Add(new Animal("Elephant", AnimalDiet.Herbivore, AnimalSize.Big));

            var CircusTrain = new Train();
            CircusTrain.LoadAnimals(Animals);

            var Carts = CircusTrain.GetCarts();
            Assert.IsTrue(Carts.Count == 1);
        }

        [Test]
        public void SmallCarnivore_MediumHerbivore_Sort()
        {
            var Animals = new List<Animal>();
            Animals.Add(new Animal("Pirana", AnimalDiet.Carnivore, AnimalSize.Small));
            Animals.Add(new Animal("Deer", AnimalDiet.Herbivore, AnimalSize.Medium));

            var CircusTrain = new Train();
            CircusTrain.LoadAnimals(Animals);

            var Carts = CircusTrain.GetCarts();
            Assert.IsTrue(Carts.Count == 1);
        }
    }
}