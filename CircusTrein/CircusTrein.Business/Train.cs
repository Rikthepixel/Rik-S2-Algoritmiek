using System;
using System.Collections.Generic;
using System.Text;

namespace CircusTrein.Business
{
    public class Train
    {
        private List<Cart> Carts { set; get; }
        private int pointsPerCartLimit;

        public Train()
        {
            pointsPerCartLimit = 10;
            Carts = new List<Cart>();
        }
        public Train(int PointsPerCartLimit)
        {
            pointsPerCartLimit = PointsPerCartLimit;
            Carts = new List<Cart>();
        }
        public Train(List<Animal> Animals)
        {
            pointsPerCartLimit = 10;
            Carts = new List<Cart>();
            LoadAnimals(Animals);
        }
        
        public Train(List<Animal> Animals, int PointsPerCartLimit)
        {
            Carts = new List<Cart>();
            LoadAnimals(Animals);
            pointsPerCartLimit = PointsPerCartLimit;
        }

        public void LoadAnimals(List<Animal> Animals)
        {

            //Sort list from big to small
            for (int i = 0; i < Animals.Count; i++)
            {
                for (int j = 0; j < Animals.Count; j++)
                {
                    if (j == i)
                    {
                        continue;
                    }
                    else if ((int)Animals[i].Size > (int)Animals[j].Size)
                    {
                        var Temp = Animals[i];
                        Animals[i] = Animals[j];
                        Animals[j] = Temp;
                    }
                }
            }

            List<Animal> OtherAnimals = new List<Animal>();
            //First add the carnivores
            for (int i = 0; i < Animals.Count; i++)
            {
                if (Animals[i].Diet == AnimalDiet.Carnivore)
                {
                    AddAnimal(Animals[i]);
                }
                else
                {
                    OtherAnimals.Add(Animals[i]);
                }
            }

            //Add the Herbivores
            for (int i = 0; i < OtherAnimals.Count; i++)
            {
                AddAnimal(OtherAnimals[i]);
            }
        }

        public void AddAnimal(Animal newAnimal)
        {
            if (Carts.Count > 0)
            {
                bool FoundACart = false;
                for (int i = 0; i < Carts.Count; i++)
                {

                    var Result = Carts[i].CheckAndAddAnimal(newAnimal);
                    if (Result)
                    {
                        //Animal has found a cart, break out of the loop
                        FoundACart = true;
                        break;
                    }

                }
                if (!FoundACart)
                {
                    //There are no fitting cart, create a new one
                    var newCart = new Cart(pointsPerCartLimit);
                    newCart.CheckAndAddAnimal(newAnimal);
                    Carts.Add(newCart);
                }
            }
            else
            {
                //There are no carts, create a new one
                var newCart = new Cart(pointsPerCartLimit);
                newCart.CheckAndAddAnimal(newAnimal);
                Carts.Add(newCart);
            }

        }

        public List<Cart> GetCarts()
        {
            return Carts;
        }
    }
}
