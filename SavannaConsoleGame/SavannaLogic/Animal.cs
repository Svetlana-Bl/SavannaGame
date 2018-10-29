namespace SavannaConsoleGame.SavannaLogic
{
    public abstract class Animal
    {
        private int _health;
        public int Health {
            get { return _health; }
            set
            {
                if (value == 0) Die();
                _health = value;
            }
        }

        public bool LiveState { get; set; }
        public string Color { get; set; }
        public int LocationX { get;set; }
        public int LocationY { get; set; }

        public virtual void UpdateVision()
        {

        }

        public virtual void DecreaseHealth()
        {
            Health--;
        }


        public void Die()
        {
            LiveState = false;
        }
    }
}
