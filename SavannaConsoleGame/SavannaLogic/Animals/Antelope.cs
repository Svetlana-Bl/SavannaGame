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
            int rowCoordinate = -1, columnCoordinate = -1;
            UpdateVision('L', ref rowCoordinate, ref columnCoordinate);

            if (rowCoordinate == -1 && columnCoordinate == -1)
            {
                Move();
            }
            else
            {

            }
        }

        public void UpdateVisionRange()
        {
            //if see danger someone -> do special action
        }
    }
}
