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
            int currentAnimalIndex=0;
            foreach (Animal animal in SavannaAnimals.Animals)
            {
                if (animal.LocationX == x && animal.LocationY == y)
                {

                    GameField.Field[animal.LocationX, animal.LocationY] = '_';
                    if (SavannaAnimals.Animals[currentAnimalIndex] == animal)
                    {
                        SavannaAnimals.Animals.RemoveAt(currentAnimalIndex);
                    }
                    GameField.NextStepField[x, y] = ButtonSymbol;
                    animal.Health = 0;
                    IncreaseHealth();
                    break;
                }
                currentAnimalIndex++;
            }
        }
    }
}
