namespace SavannaConsoleGame.Interfaces
{
    public interface IAnimalBehavior
    {
        void Move();
        void DecreaseHealth();
        void Die();
        void UpdateVision(char animal, ref int x, ref int y);
        void SpecialAction(int x, int y);
    }
}
