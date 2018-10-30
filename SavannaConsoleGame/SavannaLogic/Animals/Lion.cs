using SavannaConsoleGame.Interfaces;

namespace SavannaConsoleGame.SavannaLogic
{
    public class Lion : Animal, IAnimalBehavior
    {
        public const char animalButton = 'A';
        public Lion() : base()
        {
            LiveState = true;
            Health = 20;
            Color = "";
        }

        public void Move()
        {

        }

        public void Eat()
        {
            //life level increase
        }

        public void UpdateVisionRange()
        {

        }

    }
}
