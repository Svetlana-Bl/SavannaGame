using SavannaConsoleGame.SavannaLogic;

namespace SavannaConsoleGame.Interfaces
{
    public interface IAnimalBehavior
    {
        void Move();
        void DecreaseHealth();
        void Die();
        Animal UpdateVision(char animal, bool sameAnimal);
        void SpecialAction(int x, int y);
    }
}
