﻿using System;
using CircusTrein.Business;
using System.Collections.Generic;

namespace CircusTrein.Front
{
    class Program
    {
        static void Main(string[] args)
        {
            var Animals = new List<Animal>();
            Animals.Add(new Animal("Tijger", Foodtype.Carnivore, AnimalSize.Big));
            Animals.Add(new Animal("Tijger", Foodtype.Carnivore, AnimalSize.Big));
            Animals.Add(new Animal("Maki", Foodtype.Herbivore, AnimalSize.Small));
            Animals.Add(new Animal("Maki", Foodtype.Herbivore, AnimalSize.Small));
            Animals.Add(new Animal("Maki", Foodtype.Herbivore, AnimalSize.Small));
            Animals.Add(new Animal("Stokstaartje", Foodtype.Herbivore, AnimalSize.Small));
            Animals.Add(new Animal("Leeuw", Foodtype.Carnivore, AnimalSize.Big));
            Animals.Add(new Animal("Hyena", Foodtype.Carnivore, AnimalSize.Medium));
            Animals.Add(new Animal("Hyena", Foodtype.Carnivore, AnimalSize.Medium));
            Animals.Add(new Animal("Olifant", Foodtype.Herbivore, AnimalSize.Big));
            Animals.Add(new Animal("Olifant", Foodtype.Herbivore, AnimalSize.Big));
            Animals.Add(new Animal("Olifant", Foodtype.Herbivore, AnimalSize.Big));

            var CircusTrain = new Train();
            CircusTrain.LoadAnimals(Animals);

            for (int i = 0; i < CircusTrain.Carts.Count; i++)
            {
                var Cart = CircusTrain.Carts[i];
                Console.WriteLine($"Cart #{i} contains:");
                foreach (var animal in Cart.Animals)
                {
                    Console.WriteLine("  - " + animal.Name);
                }
            }

        }
    }
}
