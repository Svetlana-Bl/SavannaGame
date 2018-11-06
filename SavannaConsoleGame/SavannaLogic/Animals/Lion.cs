using SavannaConsoleGame.Interfaces;
using SavannaConsoleGame.Models;

namespace SavannaConsoleGame.SavannaLogic.Animals
{
    public class Lion : Animal, IAnimalBehavior
    {
        public Lion() : base()
        {
            Predator = true;
        }

        public override void SpecialAction(int x, int y)
        {
            int currentAnimalIndex = 0;
            foreach (Animal animal in SavannaAnimals.Animals)
            {
                if (animal.LocationX == x && animal.LocationY == y)
                {
                    animal.Health = 0;
                    GameField.NextStepField[x, y] = ButtonSymbol;
                    LocationX = x;
                    LocationY = y;
                    GameField.NextStepField[LocationX, LocationY] = '_';

                    IncreaseHealth();
                    break;
                }
                currentAnimalIndex++;
            }
        }
    }
}
