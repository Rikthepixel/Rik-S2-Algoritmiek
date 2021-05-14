using System;
using System.Collections.Generic;
using System.Text;

namespace CircusTrein.Business
{
    public class Train
    {
        public List<Cart> Carts { private set; get; }
        public int pointsPerCartLimit;
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
            for (int i = 0; i < Animals.Count; i++)
            {
                var CurrentAnimal = Animals[i];
                AddAnimal(CurrentAnimal);
            }
        }

        public void AddAnimal(Animal newAnimal)
        {
            if (Carts.Count > 0)
            {
                bool FoundACart = false;
                for (int i = 0; i < Carts.Count; i++)
                {

                    var Result = Carts[i].AddAnimal(newAnimal);
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
                    newCart.AddAnimal(newAnimal);
                    Carts.Add(newCart);
                }
            }
            else
            {
                //There are no carts, create a new one
                var newCart = new Cart(pointsPerCartLimit);
                newCart.AddAnimal(newAnimal);
                Carts.Add(newCart);
            }

        }

        public List<Animal> GetAllAnimals()
        {
            var Animals = new List<Animal>();
            foreach (var Cart in Carts)
            {
                foreach (var animal in Cart.Animals)
                {
                    Animals.Add(animal);
                }
            }
            return Animals;
        }

        public int GetTotalPoints()
        {
            var TotalPoints = 0;
            foreach (var Cart in Carts)
            {
                TotalPoints += Cart.GetPoints();
            }
            return TotalPoints;
        }
    }
}
