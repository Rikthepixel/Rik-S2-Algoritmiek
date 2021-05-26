using System;
using CircusTrein.Business;
using CircusTrein.Business.Factory;
using System.Collections.Generic;

namespace CircusTrein.Front
{
    class Program
    {
        static void Main(string[] args)
        {
            var Animals = AnimalFactory.CreateRandomAnimals(100);

            var CircusTrain = new Train();
            CircusTrain.LoadAnimals(Animals);

            var TrainCarts = CircusTrain.GetCarts();
            for (int i = 0; i < TrainCarts.Count; i++)
            {
                var Cart = TrainCarts[i];
                Console.WriteLine($"Cart #{i} contains:");
                foreach (var animal in Cart.GetAnimals())
                {
                    Console.WriteLine("  - " + animal.Name + $" Size: {animal.Size} and Diet: {animal.Diet}");
                }
            }

        }
    }
}
