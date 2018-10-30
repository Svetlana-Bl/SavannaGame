using System;
using System.Threading;
using SavannaConsoleGame.ConsoleLogic;
using SavannaConsoleGame.Models;

namespace SavannaConsoleGame.SavannaLogic
{
    public class SavannaEngine
    {
        static Mutex mutex = new Mutex();

        public static void StartWildLife()
        {
            Thread GameThread = new Thread(new ThreadStart(AnimalCreationOnTheField.WaitButtonPress));
            GameThread.Name = "GameThread";
            GameThread.Start();

            Thread SavannasThread = new Thread(new ThreadStart(Start));
            SavannasThread.Name = "SavannasThread";
            SavannasThread.Start();
        }

        private static void Start()
        {
            while (true)
            {
                if (mutex.WaitOne())
                {
                    UpdateCurrentAnimals();
                    ConsoleOutput.ShowGameField();
                    if (CurrentAnimals.Animals.Count >= 1)
                    {
                        GameField.NextStepField = FieldGenerator.GenerateSavannaField();
                        int i = 0;
                        while (i <CurrentAnimals.Animals.Count)
                        {
                            CurrentAnimals.Animals[i].Move();
                            i++;
                        }
                        GameField.Field = GameField.NextStepField;
                    }
                    Thread.Sleep(1000);
                    Console.SetCursorPosition(0,0);
                    //Console.Clear();
                }
                mutex.ReleaseMutex();
            }
        }

        private static void UpdateCurrentAnimals()
        {
            for (int i = 0; i < CurrentAnimals.Animals.Count; i++)
            {
                CurrentAnimals.Animals[i].DecreaseHealth();
                if (CurrentAnimals.Animals[i].LiveState == false)
                {
                    GameField.Field[CurrentAnimals.Animals[i].LocationX, CurrentAnimals.Animals[i].LocationY] = '_';
                    CurrentAnimals.Animals.RemoveAt(i);
                    i--;
                }
            }
        }

    }
}