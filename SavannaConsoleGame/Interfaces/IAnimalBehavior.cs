using SavannaConsoleGame.SavannaLogic;

namespace SavannaConsoleGame.Interfaces
{
    public interface IAnimalBehavior
    {
        void Move();
        void DecreaseHealth();
        void Die();
        Animal UpdateVision(char animal, int x, int y);
        void SpecialAction(int x, int y);
    }
}
