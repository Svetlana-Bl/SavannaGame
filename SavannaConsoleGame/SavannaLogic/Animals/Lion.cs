using SavannaConsoleGame.Interfaces;

namespace SavannaConsoleGame.SavannaLogic
{
    public class Lion : Animal, IAnimalBehavior
    {
        public const char animalButton = 'A';
        public Lion() : base()
        {
            LiveState = true;
            Health = 10;
            ButtonSymbol = 'L';
        }

        public override void SpecialAction()
        {
            //life level increase
        }

    }
}
