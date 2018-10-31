using SavannaConsoleGame.Interfaces;

namespace SavannaConsoleGame.SavannaLogic.Animals
{
    public class Antelope : Animal, IAnimalBehavior
    {
        public Antelope() : base()
        {
            Health = 10;
            Predator = false;
        }

        public override void SpecialAction()
        {
            
        }

    }
}
