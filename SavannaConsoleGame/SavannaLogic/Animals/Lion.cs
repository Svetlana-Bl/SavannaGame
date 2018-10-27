using SavannaConsoleGame.Interfaces;

namespace SavannaConsoleGame.SavannaLogic
{
    public class Lion : Animal, IAnimalBehavior
    {
        public const char animalButton = 'A';
        public Lion() : base()
        {
            this.Health = 10;
            this.Color = "";
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

        public void DecreaseHealth()
        {

        }
    }
}
