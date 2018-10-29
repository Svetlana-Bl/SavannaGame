using System;
using System.Threading;
using SavannaConsoleGame.ConsoleLogic;
using SavannaConsoleGame.Models;

namespace SavannaConsoleGame.SavannaLogic
{
    public class Game
    {
        private static GameField _gameField = new GameField();
        
        public static void Run()
        {
            ConsoleOutput.ShowIntroduction();
            ConsoleOutput.GameRules();
            _gameField = SetGameField();
            SavannaEngine savannaEngine = new SavannaEngine();
            savannaEngine.StartWildLife(_gameField);
        }

        public static GameField SetGameField()
        {
            GameField gameField = new GameField();
            int fieldLength = 0;
            int fieldWidth = 0;

            ConsoleInput.InputHeightAndWidthOfField(ref fieldLength, ref fieldWidth);
            gameField.FieldLength = fieldLength;
            gameField.FieldWidth = fieldWidth;
            gameField.Field = FieldGenerator.GenerateSavannaField(fieldLength, fieldWidth);

            return gameField;
        }
    }
}
