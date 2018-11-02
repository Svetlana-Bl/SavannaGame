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
            foreach (Animal animal in SavannaAnimals.Animals)
            {
                if (animal.LocationX == x && animal.LocationY == y)
                {
                    GameField.Field[LocationX, LocationY] = '_';
                    GameField.Field[x, y] = ButtonSymbol;
                    animal.Health = 0;
                    IncreaseHealth();
                }
            }
        }
    }
}
