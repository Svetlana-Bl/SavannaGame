using System;
using System.Collections.Generic;
using System.Threading;
using SavannaConsoleGame.ConsoleLogic;
using SavannaConsoleGame.Models;

namespace SavannaConsoleGame.SavannaLogic
{
    public class SavannaEngine
    {
        AnimalCreationOnTheField newAnimalManager;
        Mutex mutex = new Mutex();
        List<char> buttonChoise = new List<char>();

        private List<Animal> _currentAnimals = new List<Animal>();
        private GameField _gameField = new GameField();

        public void StartWildLife(GameField gameField)
        {
            _gameField = gameField;
            buttonChoise.Add('A');
            buttonChoise.Add('L');
            newAnimalManager = new AnimalCreationOnTheField(_gameField, _currentAnimals);

            Thread GameThread = new Thread(new ThreadStart(newAnimalManager.WaitButtonPress));
            GameThread.Name = String.Format("GameThread");
            GameThread.Start();

            Thread SavannasThread = new Thread(new ThreadStart(Start));
            SavannasThread.Name = String.Format("SavannasThread");
            SavannasThread.Start();
        }

        private void Start()
        {
            while (true)
            {
                if (mutex.WaitOne())
                {
                    UpdateCurrentAnimals();
                    ConsoleOutput.ShowGameField(_gameField, buttonChoise);
                    //Console.WriteLine("{0}", _currentAnimals[1].Health);
                    Thread.Sleep(1000);
                    Console.SetCursorPosition(0,0);
                }
                mutex.ReleaseMutex();
            }
        }

        private void UpdateCurrentAnimals()
        {
            _currentAnimals = AnimalCreationOnTheField.GetAnimals();

            for (int i = 0; i < _currentAnimals.Count; i++)
            {
                _currentAnimals[i].DecreaseHealth();
                if (_currentAnimals[i].LiveState == false)
                {
                    _gameField.Field[_currentAnimals[i].LocationX, _currentAnimals[i].LocationY] = '_';
                    _currentAnimals.RemoveAt(i);
                    i--;
                }
            }
        }

    }
}