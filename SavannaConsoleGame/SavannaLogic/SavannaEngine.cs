using System;
using System.Threading;
using SavannaConsoleGame.ConsoleLogic;
using SavannaConsoleGame.Models;

namespace SavannaConsoleGame.SavannaLogic
{
    public class SavannaEngine
    {
        private GameField _gameField = new GameField();
        Mutex mutex = new Mutex();

        public void StartWildLife(GameField gameField)
        {
            _gameField = gameField;

            Thread SavannasThread = new Thread(new ThreadStart(Start));
            SavannasThread.Name = String.Format("SavannasThread");
            SavannasThread.Start();
        }

        private void Start()//rename method
        {
            while (true)
            {
                if (mutex.WaitOne())
                {
                    ConsoleOutput.ShowGameField(_gameField);
                    Thread.Sleep(1000);
                    Console.SetCursorPosition(0,0);
                    //Console.Clear();
                }
                mutex.ReleaseMutex();
            }
        }
    }
}