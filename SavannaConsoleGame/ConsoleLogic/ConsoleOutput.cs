using System;
using System.Collections.Generic;
using SavannaConsoleGame.Models;
using SavannaConsoleGame.SavannaLogic;

namespace SavannaConsoleGame.ConsoleLogic
{
    public class ConsoleOutput
    {
        public static void ShowIntroduction()
        {
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("-----------------------Welcome to Savanna-----------------------");
            Console.WriteLine("----------------------------------------------------------------");
        }

        public static void RequestFieldLength()
        {
            Console.Write("\nEnter field length (number from 10 to 25), then press Enter: ");
        }

        public static void RequestFieldWidth()
        {
            Console.Write("\nEnter field width (number from 10 to 25), then press Enter: ");
        }

        public static void GameRules()
        {
            Console.WriteLine("\nRules: Press on buttons to create new animal. L - lion, A - antelope.\n");
        }

        public static void ShowGameField()
        {
            ShowButtonChoise();
            for (int i = 0; i < GameField.FieldLength; i++)
            {
                Console.Write("\n");
                for (int j = 0; j < GameField.FieldWidth; j++)
                {
                    Console.Write(string.Format("{0,3}", GameField.Field[i, j]));
                }
            }
            Console.WriteLine("\n");
        }

        public static void ShowButtonChoise()
        {
            Console.Write("Press on any from this button to create new animal: ");
            foreach (KeyValuePair<char, Animal> button in ButtonsDictionary.AnimalsAndLetters)
            {
                Console.Write("{0} ", button.Key);
            }
        }

    }
}
