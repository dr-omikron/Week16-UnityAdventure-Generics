namespace Develop._2.Spawner
{
    public class Dragon : Enemy
    {
        public float Mana { get; private set; }

        public void Initialize(int health, float mana)
        {
            Health = health;
            Mana = mana;
        }
    }
}
