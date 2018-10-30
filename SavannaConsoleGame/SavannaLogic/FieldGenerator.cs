using SavannaConsoleGame.Models;

namespace SavannaConsoleGame.SavannaLogic
{
    public class FieldGenerator
    {
        public static void GenerateSavannaField()
        {
            GameField.Field = new char[GameField.FieldLength, GameField.FieldWidth];

            for (int i = 0; i < GameField.FieldLength; i++)
            {
                for (int j = 0; j < GameField.FieldWidth; j++)
                {
                    GameField.Field[i, j] = '_';
                }
            }
        }
    }
}