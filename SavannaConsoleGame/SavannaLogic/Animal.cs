using System;
using SavannaConsoleGame.Models;

namespace SavannaConsoleGame.SavannaLogic
{
    public abstract class Animal
    {
        private double _health;
        public double Health {
            get { return _health; }
            set
            {
                if (value == 0) Die();
                _health = value;
            }
        }

        public char ButtonSymbol { get; set; }
        public bool LiveState { get; set; }
        public int LocationX { get; set; }
        public int LocationY { get; set; }

        public void UpdateVision(char animal, ref int x, ref int y)
        {
            int startRowCoordinate = 0, endRowCoordinate = 0, startColumnCoordinate = 0, endColumnCoordinate = 0;
            SetVisionParameters(ref startRowCoordinate, ref endRowCoordinate, ref startColumnCoordinate, ref endColumnCoordinate);

            for (int rowCoordinate = startRowCoordinate; rowCoordinate < endRowCoordinate; rowCoordinate++)
            {
                for (int columnCoordinate = startColumnCoordinate; columnCoordinate < endColumnCoordinate; columnCoordinate++)
                {
                    if (rowCoordinate == LocationX && columnCoordinate == LocationY)
                        continue;
                    if (GameField.Field[rowCoordinate, columnCoordinate] == animal)
                    {
                        x = rowCoordinate;
                        y = columnCoordinate;
                        break;
                    }
                }
            } 
        }

        public void Move()
        {
            bool approach = false;
            int rowCoordinate = -1, columnCoordinate = -1;
            UpdateVision('L', ref rowCoordinate, ref columnCoordinate);

            if (rowCoordinate == -1 && columnCoordinate == -1)
            {
                int startRowCoordinate = 0, endRowCoordinate = 0, startColumnCoordinate = 0, endColumnCoordinate = 0;
                SetVisionParameters(ref startRowCoordinate, ref endRowCoordinate, ref startColumnCoordinate, ref endColumnCoordinate);

                while (approach != true)
                {
                    Random random = new Random();

                    int randomX, randomY;
                    randomX = random.Next(startRowCoordinate, endRowCoordinate);
                    randomY = random.Next(startColumnCoordinate, endColumnCoordinate);

                    if (LocationX == randomX && LocationY == randomY)
                    {
                        continue;
                    }
                    else
                    {
                        LocationX = randomX;
                        LocationY = randomY;

                        if (GameField.NextStepField[LocationX, LocationY] == '_')
                        {
                            GameField.NextStepField[LocationX, LocationY] = ButtonSymbol;
                            approach = true;
                        }
                    }
                }
            }
            else SpecialAction();
        }

        public virtual void SpecialAction()
        {

        }

        public virtual void DecreaseHealth()
        {
            Health -= 0.5;
        }

        public virtual void IncreaseHealth()
        {
            Health++;
        }

        public void Die()
        {
            LiveState = false;
        }

        private void SetVisionParameters(ref int startRowCoordinate, ref int endRowCoordinate, ref int startColumnCoordinate, ref int endColumnCoordinate)
        {
            startRowCoordinate = LocationX - 1;
            endRowCoordinate = LocationX + 2;
            startColumnCoordinate = LocationY - 1;
            endColumnCoordinate = LocationY + 2;

            if (LocationX == 0) startRowCoordinate = LocationX;
            if (LocationX == GameField.FieldLength - 1) endRowCoordinate = GameField.FieldLength;
            if (LocationY == 0) startColumnCoordinate = LocationY;
            if (LocationY == GameField.FieldWidth - 1) endColumnCoordinate = GameField.FieldWidth;
            return;
        }
    }
}
