namespace Develop._2.Spawner
{
    public class Ork : Enemy
    {
        public float Damage { get; private set; }

        public void Initialize(int health, float damage)
        {
            Health = health;
            Damage = damage;
        }
    }
}
