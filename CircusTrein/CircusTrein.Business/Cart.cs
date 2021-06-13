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

            for (int i = 0; i < Animals.Count; i++)
            {
                var OtherAnimal = Animals[i];
                if (!Animal.CanBePaired(OtherAnimal))
                {
                    return false;
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
