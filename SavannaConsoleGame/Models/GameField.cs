﻿namespace SavannaConsoleGame.Models
{
    public static class GameField
    {
        public static char[,] Field;
        public static char[,] NextStepField;
        public static int FieldLength { get; set; }
        public static int FieldWidth { get; set; }
    }
}
