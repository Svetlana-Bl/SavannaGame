using System;
using SavannaConsoleGame.Models;

namespace SavannaConsoleGame.SavannaLogic
{
    public class AnimalCreationOnTheField
    {
        public static void WaitButtonPress()//redo this while-> make possibility to automaticaly understand what type of animal it is
        {
            while (true)
            {
                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.A:
                        CreateNewAnimal('A');
                        break;

                    case ConsoleKey.L:
                        CreateNewAnimal('L');
                        break;

                    default:
                        break;
                }
            }
        }

        private static void CreateNewAnimal(char animal)//TODO: add max count of animals on the field
        {
            Random rand = new Random();
            int x, y;
            bool approach = false;

            while (approach != true)
            {
                x = rand.Next(0, GameField.FieldLength);
                y = rand.Next(0, GameField.FieldWidth);

                if (GameField.Field[x, y] == '_' && CurrentAnimals.Animals.Count<=20)
                {
                    GameField.Field[x, y] = animal;
                    approach = true;
                    
                    Animal newAnimal = CheckAnimalType(animal);

                    newAnimal.LocationX = x;
                    newAnimal.LocationY = y;
                    CurrentAnimals.Animals.Add(newAnimal);
                }
            }
        }

        private static Animal CheckAnimalType(char animal)//TODO: create auto check what animal it is
        {
            Animal newAnimal;
            if (animal == 'A')
                newAnimal = new Antelope();
            else newAnimal = new Lion();
            return newAnimal;
        }
        
    }
}