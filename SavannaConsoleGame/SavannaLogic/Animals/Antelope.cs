using SavannaConsoleGame.Interfaces;
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

            FieldCornerCheck(ref startRowCoordinate, ref endRowCoordinate, ref startColumnCoordinate, ref endColumnCoordinate);
            Avoid(startRowCoordinate, endRowCoordinate, startColumnCoordinate, endColumnCoordinate);
        }

        public void Avoid(int startRowCoordinate, int endRowCoordinate, int startColumnCoordinate, int endColumnCoordinate)
        {
            bool approach = false;
            while (approach != true)
            {
                int randomX, randomY;
                randomX = random.Next(startRowCoordinate, endRowCoordinate+1);
                randomY = random.Next(startColumnCoordinate, endColumnCoordinate+1);

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

        private void FieldCornerCheck(ref int startRowCoordinate, ref int endRowCoordinate, ref int startColumnCoordinate, ref int endColumnCoordinate)
        {
            if (LocationX == 0)
            {
                startRowCoordinate = LocationX;
                endRowCoordinate = LocationX + 1;
            }

            if (LocationY == 0)
            {
                startColumnCoordinate = LocationY;
                endColumnCoordinate = LocationY + 1;
            }

            if (LocationX == GameField.FieldLength - 1)
            {
                startRowCoordinate = LocationX + 1;
                endRowCoordinate = GameField.FieldLength - 1;
            }

            if (LocationY == GameField.FieldLength - 1)
            {
                startColumnCoordinate = LocationY + 1;
                endColumnCoordinate = GameField.FieldLength - 1;
            }
        }

    }
}
