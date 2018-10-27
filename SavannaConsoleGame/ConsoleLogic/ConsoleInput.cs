using System;

namespace SavannaConsoleGame.ConsoleLogic
{
    public class ConsoleInput
    {
         public static void InputHeightAndWidthOfField(ref int fieldHeight, ref int fieldWidth)
         {
            ConsoleOutput.ShowIntroduction();

            ConsoleOutput.RequestFieldHeight();
            fieldHeight = CheckInputHeightOrWidth();
            ConsoleOutput.RequestFieldWidth();
            fieldWidth = CheckInputHeightOrWidth();

            Console.Clear();   
         }

        private static int CheckInputHeightOrWidth()
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
                    if (parameterToInt < 10)
                    {
                        parameterToInt = 10;
                    } else if (parameterToInt > 25)
                    {
                        parameterToInt = 25;
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect input! Please, enter !");
                }
            }
            return parameterToInt;
        }
    }
}