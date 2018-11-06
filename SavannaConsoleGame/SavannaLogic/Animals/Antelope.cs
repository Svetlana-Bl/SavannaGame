﻿using SavannaConsoleGame.Interfaces;
using SavannaConsoleGame.Models;

namespace SavannaConsoleGame.SavannaLogic.Animals
{
    public class Antelope : Animal, IAnimalBehavior
    {
        public Antelope() : base()
        {

        }

        public override void SpecialAction(int x, int y)
        {
            int startRowCoordinate = LocationX, endRowCoordinate = LocationX, startColumnCoordinate = LocationY, endColumnCoordinate = LocationY;

            if (y > LocationY)
            {
                startColumnCoordinate = LocationY - 1;
            }
            else
            {
                startColumnCoordinate = LocationY + 1;
            }


            if (x > LocationX)
            {
                startRowCoordinate = LocationX - 1;
            }
            else
            {
                startRowCoordinate = LocationX + 1;
            }

            VisionRange visionRange = new VisionRange() { startRowCoordinate = 0, endRowCoordinate = 0, startColumnCoordinate = 0, endColumnCoordinate = 0 };

            visionRange = FieldCornerCheck(visionRange);
            Avoid(visionRange);
        }

        public void Avoid(VisionRange visionRange)
        {
            bool approach = false;
            while (approach != true)
            {
                int randomX, randomY;
                randomX = random.Next(visionRange.startRowCoordinate, visionRange.endRowCoordinate + 1);
                randomY = random.Next(visionRange.startColumnCoordinate, visionRange.endColumnCoordinate + 1);

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

        private VisionRange FieldCornerCheck(VisionRange visionRange)
        {
            if (LocationX == 0)
            {
                visionRange.startRowCoordinate = LocationX;
                visionRange.endRowCoordinate = LocationX + 1;
            }

            if (LocationY == 0)
            {
                visionRange.startColumnCoordinate = LocationY;
                visionRange.endColumnCoordinate = LocationY + 1;
            }

            if (LocationX == GameField.FieldLength - 1)
            {
                visionRange.startRowCoordinate = LocationX + 1;
                visionRange.endRowCoordinate = GameField.FieldLength - 1;
            }

            if (LocationY == GameField.FieldLength - 1)
            {
                visionRange.startColumnCoordinate = LocationY + 1;
                visionRange.endColumnCoordinate = GameField.FieldLength - 1;
            }
            return visionRange;
        }

    }
}
