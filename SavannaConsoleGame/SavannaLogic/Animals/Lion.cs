using SavannaConsoleGame.Interfaces;

namespace SavannaConsoleGame.SavannaLogic.Animals
{
    public class Lion : Animal, IAnimalBehavior
    {
        public Lion() : base()
        {
            Health = 10;
            Predator = true;
        }

        public override void SpecialAction()
        {
            //life level increase
        }
    }
}
