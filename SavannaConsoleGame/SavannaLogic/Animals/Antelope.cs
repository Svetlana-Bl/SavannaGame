using SavannaConsoleGame.Interfaces;

namespace SavannaConsoleGame.SavannaLogic
{
    public class Antelope : Animal, IAnimalBehavior
    {
        public Antelope() : base()
        {
            this.Health = 10;
            this.Color = "";
        }

        public void Move()
        {

        }

        public void AvoidDanger()
        {

        }

        public void UpdateVisionRange()
        {
            
        }

        public void DecreaseHealth()
        {

        }
    }
}
