using System;

namespace SavannaConsoleGame.ConsoleLogic
{
    public class UserInterface
    {
        public void OutputMenu()
        {
            bool menuOutput = true;
            while (menuOutput)
            {
                Console.WriteLine("--------------------------------");
                Console.WriteLine("-------Welcome to Savanna-------");
                Console.WriteLine("--------------------------------");
                Console.WriteLine("\n--------------Menu--------------");
                Console.WriteLine("1. Start new game.");
                Console.WriteLine("--------------------------------");
                var answer = 0;

                answer = CheckInputParameter("Choice: ");
                switch (answer)
                {
                    case (int)MenuChoice.StartNewGame:
                        var fieldSize = CheckInputParameter("Enter field size, then press Enter: ");
                        Console.Clear();
                        menuOutput = false;
                        break;

                    default:
                        Console.WriteLine("Incorrect input. Write the number of your choice again.");
                        menuOutput = false;
                        break;
                }
            }
            Console.ReadKey();
        }

        private int CheckInputParameter(string outputString)
        {
            bool Valid = false;
            int parameterToInt;
            string parameter = "";

            Console.WriteLine(outputString);
            while (!Valid)
            {
                parameter = Console.ReadLine();
                if (int.TryParse(parameter, out parameterToInt))
                {
                    Valid = true;
                }
                else
                {
                    Console.WriteLine("Incorrect input! Please, try again!");
                }
            }
            return Convert.ToInt32(parameter);
        }
    }
}