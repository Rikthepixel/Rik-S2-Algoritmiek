using System;
using CircusTrein.Business;
using System.Collections.Generic;

namespace CircusTrein.Front
{
    class Program
    {
        static void Main(string[] args)
        {
            var Animals = new List<Animal>();
            Animals.Add(new Animal("Tiger", AnimalDiet.Carnivore, AnimalSize.Big));
            Animals.Add(new Animal("Tiger", AnimalDiet.Carnivore, AnimalSize.Big));
            Animals.Add(new Animal("Maki", AnimalDiet.Herbivore, AnimalSize.Small));
            Animals.Add(new Animal("Maki", AnimalDiet.Herbivore, AnimalSize.Small));
            Animals.Add(new Animal("Maki", AnimalDiet.Herbivore, AnimalSize.Small));
            Animals.Add(new Animal("Meerkat", AnimalDiet.Herbivore, AnimalSize.Small));
            Animals.Add(new Animal("Lion", AnimalDiet.Carnivore, AnimalSize.Big));
            Animals.Add(new Animal("Hyena", AnimalDiet.Carnivore, AnimalSize.Medium));
            Animals.Add(new Animal("Hyena", AnimalDiet.Carnivore, AnimalSize.Medium));
            Animals.Add(new Animal("Elephant", AnimalDiet.Herbivore, AnimalSize.Big));
            Animals.Add(new Animal("Elephant", AnimalDiet.Herbivore, AnimalSize.Big));
            Animals.Add(new Animal("Elephant", AnimalDiet.Herbivore, AnimalSize.Big));

            var CircusTrain = new Train();
            CircusTrain.LoadAnimals(Animals);

            var TrainCarts = CircusTrain.GetCarts();
            for (int i = 0; i < TrainCarts.Count; i++)
            {
                var Cart = TrainCarts[i];
                Console.WriteLine($"Cart #{i} contains:");
                foreach (var animal in Cart.GetAnimals())
                {
                    Console.WriteLine("  - " + animal.Name);
                }
            }

        }
    }
}
