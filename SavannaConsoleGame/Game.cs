using SavannaConsoleGame.ConsoleLogic;
using SavannaConsoleGame.Models;

namespace SavannaConsoleGame.SavannaLogic
{
    public class Game
    {
        public static void Run()
        {
            ConsoleOutput.ShowIntroduction();
            ConsoleOutput.GameRules();
            SetGameField();
            SavannaEngine.StartWildLife();
        }

        public static void SetGameField()
        {
            ConsoleInput.InputLengthAndWidthOfField();
            GameField.Field = FieldGenerator.GenerateSavannaField();
        }
    }
}
