using System;
using System.Threading;
using SavannaConsoleGame.Models;

namespace SavannaConsoleGame.ConsoleLogic
{
    public class ConsoleInput
    {
         public static void InputLengthAndWidthOfField()
         {
            ConsoleOutput.RequestFieldLength();
            GameField.FieldLength = CheckInputLengthOrWidth();

            ConsoleOutput.RequestFieldWidth();
            GameField.FieldWidth = CheckInputLengthOrWidth();

            Console.Clear();   
         }

        private static int CheckInputLengthOrWidth()
        {
            bool Valid = false;
            int parameterToInt = 0;
            string parameter = "";

            while (!Valid)
            {
                parameter = Console.ReadLine();
                if (int.TryParse(parameter, out parameterToInt))
                {
                    Valid = true;
                    if (Math.Abs(parameterToInt) < 10)
                    {
                        parameterToInt = 10;
                        Console.WriteLine("Number {0} is too low. Default is 10", Math.Abs(Convert.ToInt32(parameter)));
                    } else if (Math.Abs(parameterToInt) > 25)
                    {
                        parameterToInt = 25;
                        Console.WriteLine("Number {0} is too high. Default is 25", Math.Abs(Convert.ToInt32(parameter)));
                    } else parameterToInt = Math.Abs(Convert.ToInt32(parameter));
                    Thread.Sleep(1000);
                }
                else
                {
                    Console.WriteLine("Incorrect input! Please, enter number (number from 10 to 25)!");
                }
            }
            return parameterToInt;
        }
    }
}