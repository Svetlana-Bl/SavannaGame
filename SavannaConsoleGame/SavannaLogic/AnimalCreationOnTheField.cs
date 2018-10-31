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
                if (ButtonsDictionary.AnimalsAndLetters.ContainsKey((char)key.Key))
                {
                    CreateNewAnimal((char)key.Key);
                }
            }
        }

        private static void CreateNewAnimal(char animal)
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

                    Animal newAnimal = CheckAnimalType(animal);

                    newAnimal.LocationX = x;
                    newAnimal.LocationY = y;
                    SavannaAnimals.Animals.Add(newAnimal);
                }
            }
        }

        private static Animal CheckAnimalType(char animal)
        {
            Animal newAnimal = null;

            if (ButtonsDictionary.AnimalsAndLetters.ContainsKey(animal))
            {
                newAnimal = ButtonsDictionary.AnimalsAndLetters[animal];
                newAnimal.ButtonSymbol = animal;
                newAnimal = SetAnimalsParameters(newAnimal)
            }
            return newAnimal;
        }

        private static Animal SetAnimalsParameters(Animal animal)
        {
            animal.LiveState = true;

            foreach (KeyValuePair<char, Animal> a in ButtonsDictionary.AnimalsAndLetters)
            {
                if (a.Value.GetType() != animal.GetType())
                {
                    if (animal.Predator == true)
                    {
                        if (a.Value.Predator != true)
                            animal.Prey.Add(a.Key);
                    }
                    else
                    {
                        if (a.Value.Predator == true)
                            animal.Enemies.Add(a.Key);
                    }
                }
            }

            return animal;
        }
    }
}