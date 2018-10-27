using System;
using System.Collections.Generic;
using System.Threading;
using SavannaConsoleGame.Models;

namespace SavannaConsoleGame.SavannaLogic
{
    public class AnimalCreationOnTheField
    {
        List<Animal> currentAnimals = new List<Animal>();
        public GameField _gameField = new GameField();

        public AnimalCreationOnTheField(GameField gameField)
        {
            _gameField = gameField;
        }

        public void WaitButtonPress()
        {
            new Thread(ButtonHandler).Start();
        }

        private void ButtonHandler()//redo this while-> make possibility to automaticaly understand what type of animal it is
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

        private void CreateNewAnimal(GameField gameField, char animal)
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
                }
            }
            _gameField = gameField;
        }

        //TODO: add max count of animals on the field
    }
}