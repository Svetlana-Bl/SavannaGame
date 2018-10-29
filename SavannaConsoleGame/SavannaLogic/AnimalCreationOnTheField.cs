using System;
using System.Collections.Generic;
using SavannaConsoleGame.Models;

namespace SavannaConsoleGame.SavannaLogic
{
    public class AnimalCreationOnTheField
    {
        private static List<Animal> _currentAnimals = new List<Animal>();
        public static GameField _gameField = new GameField();

        public AnimalCreationOnTheField(GameField gameField, List<Animal> currentAnimals)
        {
            _gameField = gameField;
            _currentAnimals = currentAnimals;
        }

        public void WaitButtonPress()//redo this while-> make possibility to automaticaly understand what type of animal it is
        {
            while (true)
            {
                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.A:
                        CreateNewAnimal(_gameField, 'A');
                        break;

                    case ConsoleKey.L:
                        CreateNewAnimal(_gameField, 'L');
                        break;

                    default:
                        break;
                }
            }
        }

        private static void CreateNewAnimal(GameField gameField, char animal)
        {
            Random rand = new Random();
            int x, y;
            bool approach = false;

            while (approach != true)
            {
                x = rand.Next(0, gameField.FieldLength);
                y = rand.Next(0, gameField.FieldWidth);

                if (gameField.Field[x, y] == '_')
                {
                    gameField.Field[x, y] = animal;
                    approach = true;

                    //TODO: create method to check what animal it is
                    Animal newAnimal;
                    if (animal == 'A')
                        newAnimal = new Antelope();
                    else newAnimal = new Lion();

                    newAnimal.LocationX =x;
                    newAnimal.LocationY = y;
                    _currentAnimals.Add(newAnimal);
                }
            }
            _gameField = gameField;
            //TODO: add max count of animals on the field
        }

        public static List<Animal> GetAnimals()
        {
            return _currentAnimals;
        }
        
    }
}