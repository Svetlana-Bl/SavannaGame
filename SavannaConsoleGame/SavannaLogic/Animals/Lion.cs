using SavannaConsoleGame.Interfaces;

namespace SavannaConsoleGame.SavannaLogic.Animals
{
    public class Lion : Animal, IAnimalBehavior
    {
        public Lion() : base()
        {
            Predator = true;
        }

        public override void SpecialAction()
        {
            //life level increase
        }
    }
}
