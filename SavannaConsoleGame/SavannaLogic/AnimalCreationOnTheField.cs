using System;
using System.Collections.Generic;
using SavannaConsoleGame.Models;

namespace SavannaConsoleGame.SavannaLogic
{
    public class AnimalCreationOnTheField
    {
        public static void WaitButtonPress()
        {
            while (true)
            {
                var key = Console.ReadKey();
                if (SavannaDictionary.AnimalsAndLettersDictionary.ContainsKey((char)key.Key))
                {
                    SetNewAnimalPosition((char)key.Key);
                }
            }
        }

        public static void SetNewAnimalPosition(char animal)
        {
            Random rand = new Random();
            int x, y;
            bool approach = false;

            while (approach != true)
            {
                x = rand.Next(0, GameField.FieldLength);
                y = rand.Next(0, GameField.FieldWidth);

                if (GameField.Field[x, y] == '_' && SavannaAnimals.Animals.Count <= 20)
                {
                    GameField.Field[x, y] = animal;
                    approach = true;
                    
                    Animal newAnimal = AddNewAnimal(animal);
                    newAnimal.LocationX = x;
                    newAnimal.LocationY = y;
                    SavannaAnimals.Animals.Add(newAnimal);
                }
            }
        }

        public static Animal AddNewAnimal(char animal)
        {
            Animal newAnimal = null;
            if (SavannaDictionary.AnimalsAndLettersDictionary.ContainsKey(animal))
            {
                Type animalType = SavannaDictionary.AnimalsAndLettersDictionary[animal];
                newAnimal = (Animal)Activator.CreateInstance(animalType);
                newAnimal.ButtonSymbol = animal;
                SetAnimalsParameters(newAnimal);
            }
            return newAnimal;
        }

        private static void SetAnimalsParameters(Animal animal)
        {
            animal.LiveState = true;
            animal.Health = 10;
            animal.Prey = new List<char>();
            animal.Enemies = new List<char>();

            foreach (KeyValuePair<char, Type> a in SavannaDictionary.AnimalsAndLettersDictionary)
            {
                Animal animalToAnalize = null;
                if (a.Value.GetType() != animal.GetType())
                {
                    Type animalType = a.Value;
                    animalToAnalize = (Animal)Activator.CreateInstance(animalType);
                    if (animal.Predator == true)
                    {
                        if (animalToAnalize.Predator != true)
                            animal.Prey.Add(a.Key);
                    }
                    else
                    {
                        if (animalToAnalize.Predator == true)
                            animal.Enemies.Add(a.Key);
                    }
                }
            }
        }
    }
}