using System;
using System.Collections.Generic;
using System.Text;

namespace CircusTrein.Business
{
    public enum Foodtype
    {
        Carnivore,
        Omnivore,
        Herbivore
    }

    public enum AnimalSize
    {
        Small,
        Medium,
        Big
    }
    public class Animal
    {
        public string Name { get; set; }
        public Foodtype Foodtype { get; set; }
        public AnimalSize Size { get; set; }
    
        public Animal(string AnimalName, Foodtype AnimalFoodType, AnimalSize AnimalSize)
        {
            Name = AnimalName;
            Foodtype = AnimalFoodType;
            Size = AnimalSize;
        }

        public int GetPoints()
        {
            switch (Size)
            {
                case AnimalSize.Small:
                    return 1;
                case AnimalSize.Medium:
                    return 3;
                case AnimalSize.Big:
                    return 5;
                default:
                    return 1;
            }
        }
    }
}
