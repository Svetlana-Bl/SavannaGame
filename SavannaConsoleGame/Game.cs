using System.Threading;
using SavannaConsoleGame.ConsoleLogic;
using SavannaConsoleGame.Models;

namespace SavannaConsoleGame.SavannaLogic
{
    public class Game
    {
        public static void Run()
        {
            SavannaDictionary.SetDefautDictionaryParameters();
            ConsoleOutput.ShowIntroduction();
            ConsoleOutput.ShowGameRules();
            SetGameField();
            SavannaEngine.StartWildLife();
        }

        public static void SetGameField()
        {
            ConsoleInput.InputLengthAndWidthOfField();
            Thread.Sleep(1000);
            GameField.Field = FieldGenerator.GenerateSavannaField();
        }
    }
}
