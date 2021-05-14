using System;
using System.Collections.Generic;

namespace CircusTrein.Business
{
    public class Cart
    {
        public List<Animal> Animals { private set; get; }
        public int PointLimit;
        public Cart(int pointLimit)
        {
            Animals = new List<Animal>();
            PointLimit = pointLimit;
        }

        public List<Animal> GetAnimalsWithFoodtype(Foodtype foodtype)
        {
            var AnimalsWithFoodType = new List<Animal>();
            for (int i = 0; i < Animals.Count; i++)
            {
                if (Animals[i].Foodtype == foodtype)
                {
                    AnimalsWithFoodType.Add(Animals[i]);
                }
            }
            return AnimalsWithFoodType;
        }
        public bool AnimalFits(Animal NewAnimal)
        {
            bool Result = true;
            var NewAnimalPoints = NewAnimal.GetPoints();
            var CartPoints = GetPoints();
            if (CartPoints + NewAnimalPoints > PointLimit)
            {
                //Over Cart limit
                return false;
            }
            if (CartPoints == 0)
            {
                //No animals in cart
                return true;
            }

            if (NewAnimal.Foodtype == Foodtype.Herbivore)
            {
                //Hebribvores just have to watch out for Carnivores
                var Carnivours = GetAnimalsWithFoodtype(Foodtype.Carnivore);
                for (int i = 0; i < Carnivours.Count; i++)
                {
                    var CarnivorePoints = Carnivours[i].GetPoints();
                    if (CarnivorePoints >= NewAnimalPoints)
                    {
                        //Carnivour is bigger
                        //Console.WriteLine("Carnivore is bigger");
                        return false;
                    }
                    else
                    {
                        //Console.WriteLine("Carnivore is smaller");
                        //carnivour is smaller
                        Result = true;
                    }
                }

            }
            else if (NewAnimal.Foodtype == Foodtype.Carnivore)
            {
                //Carnivores have to keep Herbivores and other Carnivores in mind
                var Herbivours = GetAnimalsWithFoodtype(Foodtype.Herbivore);
                for (int i = 0; i < Herbivours.Count; i++)
                {
                    var HerbivorePoints = Herbivours[i].GetPoints();
                    if (HerbivorePoints <= NewAnimalPoints)
                    {
                        //HerbivorePoints is smaller
                        return false;
                    }
                    else
                    {
                        //HerbivorePoints is Bigger
                        Result = true;
                    }
                }

                var Carnivours = GetAnimalsWithFoodtype(Foodtype.Carnivore);
                if (Carnivours.Count > 0)
                {
                    return false;
                }

            }

            return Result;
        }

        public bool AddAnimal(Animal NewAnimal)
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

    }
}
