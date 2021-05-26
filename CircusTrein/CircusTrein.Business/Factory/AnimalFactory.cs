using System;
using System.Collections.Generic;
using System.Text;

namespace CircusTrein.Business.Factory
{
    public class AnimalFactory
    {

        public static List<Animal> CreateRandomAnimals(int Amount)
        {
            var Animals = new List<Animal>();

            for (int i = 0; i < Amount; i++)
            {
                Random random = new Random();

                var Values = Enum.GetValues(typeof(AnimalSize));
                AnimalSize RandomSize = (AnimalSize)Values.GetValue(random.Next(Values.Length));

                Values = Enum.GetValues(typeof(AnimalDiet));
                AnimalDiet RandomDiet = (AnimalDiet)Values.GetValue(random.Next(Values.Length));

                Animals.Add(new Animal($"Animal #{i}", RandomDiet, RandomSize));
            }

            return Animals;
        }

        #region Herbivores

        public static Animal CreateBigHerbivore()
        {
            return new Animal("BigHerbivore", AnimalDiet.Herbivore, AnimalSize.Big);
        }

        public static Animal CreateMediumHerbivore()
        {
            return new Animal("MediumHerbivore", AnimalDiet.Herbivore, AnimalSize.Medium);
        }

        public static Animal CreateSmallHerbivore()
        {
            return new Animal("SmallHerbivore", AnimalDiet.Herbivore, AnimalSize.Small);
        }
        #endregion

        #region Carnivores

        public static Animal CreateBigCarnivore()
        {
            return new Animal("BigCarnivore", AnimalDiet.Carnivore, AnimalSize.Big);
        }

        public static Animal CreateMediumCarnivore()
        {
            return new Animal("MediumCarnivore", AnimalDiet.Carnivore, AnimalSize.Medium);
        }

        public static Animal CreateSmallCarnivore()
        {
            return new Animal("SmallCarnivore", AnimalDiet.Carnivore, AnimalSize.Small);
        }
        #endregion
    }
}
