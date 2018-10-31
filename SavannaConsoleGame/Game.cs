using System.Threading;
using SavannaConsoleGame.ConsoleLogic;
using SavannaConsoleGame.Models;

namespace SavannaConsoleGame.SavannaLogic
{
    public class Game
    {
        public static void Run()
        {
            ButtonsDictionary.SetDefautAnimalButton();
            ConsoleOutput.ShowIntroduction();
            ConsoleOutput.GameRules();
            SetGameField();
            SavannaEngine.StartWildLife();
        }

        public static void SetGameField()
        {
            ConsoleInput.InputLengthAndWidthOfField();
            Thread.Sleep(2000);
            GameField.Field = FieldGenerator.GenerateSavannaField();
        }
    }
}
