using SavannaConsoleGame.Interfaces;

namespace SavannaConsoleGame.SavannaLogic
{
    public class Antelope : Animal, IAnimalBehavior
    {
        public Antelope() : base()
        {
            LiveState = true;
            Health = 10;
            ButtonSymbol = 'A';
        }

        public override void SpecialAction()
        {

        }

        public void UpdateVisionRange()
        {
            //if see danger someone -> do special action
        }
    }
}
