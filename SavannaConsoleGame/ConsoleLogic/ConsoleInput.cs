using System;
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
                    parameterToInt = Math.Abs(Convert.ToInt32(parameter));
                    if (parameterToInt < 10)
                    {
                        Console.WriteLine("Entered number is too low. Try again.", parameterToInt);
                        parameterToInt = 10;
                        
                    } else if (parameterToInt > 25)
                    {
                        parameterToInt = 25;
                        Console.WriteLine("Entered number is too high.Try again.", parameterToInt);
                    }else
                        Valid = true; 
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