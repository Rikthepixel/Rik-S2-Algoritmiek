using System;
using System.Collections.Generic;
using System.Text;

namespace CircusTrein.Business
{

    public class Animal
    {
        public string Name { get; set; }
        public AnimalDiet Diet { get; set; }
        public AnimalSize Size { get; set; }
    
        public Animal(string AnimalName, AnimalDiet AnimalFoodType, AnimalSize AnimalSize)
        {
            Name = AnimalName;
            Diet = AnimalFoodType;
            Size = AnimalSize;
        }

        public int GetPoints()
        {
            return (int)Size;
        }
    }
}
