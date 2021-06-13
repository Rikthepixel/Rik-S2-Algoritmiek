using System;
using System.Collections.Generic;
using System.Text;

namespace CircusTrein.Business
{

    public class Animal
    {
        public string Name { get; private set; }
        public AnimalDiet Diet { get; private set; }
        public AnimalSize Size { get; private set; }
    
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

        public bool CanBePaired(Animal OtherAnimal)
        {
            var Points = GetPoints();
            if (Diet == AnimalDiet.Carnivore)
            {
                if (OtherAnimal.Diet == AnimalDiet.Carnivore)
                {
                    return false;
                }
                else if (OtherAnimal.Diet == AnimalDiet.Herbivore && Points >= OtherAnimal.GetPoints())
                {
                    return false;
                }
            }
            else if ((Diet == AnimalDiet.Herbivore) && (OtherAnimal.Diet == AnimalDiet.Carnivore && OtherAnimal.GetPoints() >= Points))
            {
                return false;
            }

            return true;
        }
    }
}
