using System;
using System.Collections.Generic;

namespace CircusTrein.Business
{
    public class Cart
    {
        private List<Animal> Animals { set; get; }
        private int PointLimit;

        public Cart(int pointLimit)
        {
            Animals = new List<Animal>();
            PointLimit = pointLimit;
        }

        public bool AnimalFits(Animal Animal)
        { 
            var CartPoints = GetPoints();
            if (CartPoints == 0)
            {
                //No animals in cart
                return true;
            }

            var AnimalPoints = Animal.GetPoints();
            if (CartPoints + AnimalPoints > PointLimit)
            {
                //Over Cart limit
                return false;
            }

            if (Animal.Diet == AnimalDiet.Carnivore)
            {
                for (int i = 0; i < Animals.Count; i++)
                {
                    var OtherAnimal = Animals[i];
                    if (OtherAnimal.Diet == AnimalDiet.Carnivore)
                    {
                        return false;
                    }
                    else if (OtherAnimal.Diet == AnimalDiet.Herbivore && AnimalPoints >= OtherAnimal.GetPoints())
                    {
                        return false;
                    }
                }
            }
            else if (Animal.Diet == AnimalDiet.Herbivore) 
            {
                for (int i = 0; i < Animals.Count; i++)
                {
                    var OtherAnimal = Animals[i];
                    if (OtherAnimal.Diet == AnimalDiet.Carnivore && OtherAnimal.GetPoints() >= AnimalPoints)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public bool CheckAndAddAnimal(Animal NewAnimal)
        {
            var CanFit = AnimalFits(NewAnimal);
            if (CanFit)
            {
                Animals.Add(NewAnimal);
            }
            return CanFit;
        }

        public int GetPoints()
        {
            var CartPoints = 0;
            for (int i = 0; i < Animals.Count; i++)
            {
                CartPoints += Animals[i].GetPoints();
            }

            return CartPoints;
        }

        public List<Animal> GetAnimals()
        {
            return Animals;
        }

    }
}
