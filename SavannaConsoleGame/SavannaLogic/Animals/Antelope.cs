using SavannaConsoleGame.Interfaces;

namespace SavannaConsoleGame.SavannaLogic
{
    public class Antelope : Animal, IAnimalBehavior
    {
        public Antelope() : base()
        {
            LiveState = true;
            Health = 5;
            Color = "";
        }

        public void Move()
        {

        }

        public void AvoidDanger()
        {

        }

        public void UpdateVisionRange()
        {
            //if see danger someone -> do special action
        }
    }
}
