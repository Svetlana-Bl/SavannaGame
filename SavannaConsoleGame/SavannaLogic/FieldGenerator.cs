namespace SavannaConsoleGame.SavannaLogic
{
    public class FieldGenerator
    {
        public static char[,] GenerateSavannaField(int fieldLength, int fieldWidth)
        {
            char[,] savannaField = new char[fieldLength, fieldWidth];

            for (int i = 0; i < fieldLength; i++)
            {
                for (int j = 0; j < fieldWidth; j++)
                {
                    savannaField[i, j] = '_';
                }
            }

            return savannaField;
        }
    }
}