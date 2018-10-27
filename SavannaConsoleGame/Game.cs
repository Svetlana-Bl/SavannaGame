using System;
using System.Threading;
using SavannaConsoleGame.ConsoleLogic;
using SavannaConsoleGame.Models;

namespace SavannaConsoleGame.SavannaLogic
{
    public class Game
    {
        private static GameField _gameField = new GameField();
        
        public static void Start()
        {
            _gameField = SetGameField();
            AnimalCreationOnTheField newAnimalManager = new AnimalCreationOnTheField(_gameField);

            Thread GameThread = new Thread(new ThreadStart(newAnimalManager.WaitButtonPress));
            GameThread.Name = String.Format("GameThread");
            GameThread.Start();

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
