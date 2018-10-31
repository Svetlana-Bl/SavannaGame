using SavannaConsoleGame.Interfaces;

namespace SavannaConsoleGame.SavannaLogic.Animals
{
    public class Lion : Animal, IAnimalBehavior
    {
        public Lion() : base()
        {
            LiveState = true;
            Health = 10;
        }

        public override void SpecialAction()
        {
            //life level increase

            int rowCoordinate = -1, columnCoordinate = -1;
            UpdateVision('A', ref rowCoordinate, ref columnCoordinate);

            if (rowCoordinate == -1 && columnCoordinate == -1)
            {
                Move();
            }
            else
            {

            }
        }

    }
}
