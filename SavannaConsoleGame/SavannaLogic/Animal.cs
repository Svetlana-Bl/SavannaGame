using System;
using System.Collections.Generic;
using SavannaConsoleGame.Models;

namespace SavannaConsoleGame.SavannaLogic
{
    public abstract class Animal
    {
        static Random random = new Random();
        private double _health;
        public double Health
        {
            get { return _health; }
            set
            {
                if (value <= 0) Die();
                _health = value;
            }
        }

        public char ButtonSymbol { get; set; }
        public bool LiveState { get; set; }
        public bool Predator { get; set; }
        public int LocationX { get; set; }
        public int LocationY { get; set; }
        public List<char> Enemies { get; set; }
        public List<char> Prey { get; set; }

        public virtual void Behavior()
        {
            int rowCoordinate = -1, columnCoordinate = -1;
            List<char> animals = new List<char>();

            if (Predator == true)
            {
                if (Prey.Count != 0)
                    animals = Prey;
            }
            else
            {
                if (Enemies.Count != 0)
                    animals = Enemies;
            }

            int i = 0;
            while (animals.Count != i)
            {
                
                if (rowCoordinate != -1 && columnCoordinate != -1)
                    break;
                UpdateVision(animals[i], ref rowCoordinate, ref columnCoordinate);
                i++;
            }


            if (rowCoordinate == -1 && columnCoordinate == -1)
            {
                Move();
            }
            else
            {
                SpecialAction(rowCoordinate, columnCoordinate);
            }
        }

        public void UpdateVision(char animal, ref int x, ref int y)
        {
            int startRowCoordinate = 0, endRowCoordinate = 0, startColumnCoordinate = 0, endColumnCoordinate = 0;
            VisionRangeFocus(ref startRowCoordinate, ref endRowCoordinate, ref startColumnCoordinate, ref endColumnCoordinate);

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

            int startRowCoordinate = 0, endRowCoordinate = 0, startColumnCoordinate = 0, endColumnCoordinate = 0;
            VisionRangeFocus(ref startRowCoordinate, ref endRowCoordinate, ref startColumnCoordinate, ref endColumnCoordinate);

            while (approach != true)
            {
                int randomX, randomY;
                randomX = random.Next(startRowCoordinate, endRowCoordinate);
                randomY = random.Next(startColumnCoordinate, endColumnCoordinate);

                if (LocationX != randomX && LocationY != randomY)
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

        public virtual void SpecialAction(int x, int y)
        {
            Move();
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

        private void VisionRangeFocus(ref int startRowCoordinate, ref int endRowCoordinate, ref int startColumnCoordinate, ref int endColumnCoordinate)
        {
            startRowCoordinate = LocationX - 1;
            endRowCoordinate = LocationX + 2;
            startColumnCoordinate = LocationY - 1;
            endColumnCoordinate = LocationY + 2;

            if (LocationX == 0) startRowCoordinate = LocationX;
            if (LocationX == GameField.FieldLength - 1) endRowCoordinate = GameField.FieldLength;
            if (LocationY == 0) startColumnCoordinate = LocationY;
            if (LocationY == GameField.FieldWidth - 1) endColumnCoordinate = GameField.FieldWidth;
        }
    }
}
