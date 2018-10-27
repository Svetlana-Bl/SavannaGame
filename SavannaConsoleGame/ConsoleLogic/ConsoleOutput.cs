using System;
using SavannaConsoleGame.Models;

namespace SavannaConsoleGame.ConsoleLogic
{
    public class ConsoleOutput
    {
        public static void ShowIntroduction()
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine("-------Welcome to Savanna-------");
            Console.WriteLine("--------------------------------");
        }

        public static void RequestFieldHeight()
        {
            Console.WriteLine("Enter field height, then press Enter: ");
        }

        public static void RequestFieldWidth()
        {
            Console.WriteLine("Enter field width, then press Enter: ");
        }

        public static void ShowGameField(GameField gameField)
        {
            for (int i = 0; i < gameField.FieldLength; i++)
            {
                Console.Write("\n");

                for (int j = 0; j < gameField.FieldWidth; j++)
                {
                    Console.Write(String.Format("{0,3}", gameField.Field[i, j]));
                }
            }
            Console.WriteLine("\n");
        }

    }
}
