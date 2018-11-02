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
            Move();
        }

    }
}
