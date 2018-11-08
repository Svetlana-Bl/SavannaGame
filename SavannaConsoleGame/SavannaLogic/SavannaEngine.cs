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

            Thread SavannasThread = new Thread(new ThreadStart(StartLifeLoop));
            SavannasThread.Name = "SavannasThread";
            SavannasThread.Start();
        }

        private static void StartLifeLoop()
        {
            while (true)
            {
                if (mutex.WaitOne())
                {
                    UpdateCurrentAnimalsHealth();

                    ConsoleOutput.ShowGameField();
                    
                    MoveCurrentAnimals();
                    Thread.Sleep(1000);
                    //Console.SetCursorPosition(0, 0);
                    Console.Clear();
                }
                mutex.ReleaseMutex();
            }
        }

        private static void UpdateCurrentAnimalsHealth()
        {
            for (int i = 0; i < SavannaAnimals.Animals.Count; i++)
            {
                SavannaAnimals.Animals[i].DecreaseHealth();
                if (SavannaAnimals.Animals[i].LiveState == false)
                {
                    if (GameField.Field[SavannaAnimals.Animals[i].LocationX, SavannaAnimals.Animals[i].LocationY] == SavannaAnimals.Animals[i].ButtonSymbol)
                    {
                        GameField.Field[SavannaAnimals.Animals[i].LocationX, SavannaAnimals.Animals[i].LocationY] = '_';
                    }

                    SavannaAnimals.Animals.RemoveAt(i);
                    i--;
                }
            }
        }

        private static void MoveCurrentAnimals()
        {
            if (SavannaAnimals.Animals.Count >= 1)
            {
                GameField.NextStepField = FieldGenerator.GenerateSavannaField();
                int i = 0;
                while (i < SavannaAnimals.Animals.Count)
                {
                    if(SavannaAnimals.Animals[i].LiveState == true)
                        SavannaAnimals.Animals[i].Behavior();
                    i++;
                }
                GameField.Field = GameField.NextStepField;
            }
        }
    }
}