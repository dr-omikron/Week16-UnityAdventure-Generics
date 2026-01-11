namespace Develop._2.Spawner
{
    public class Elf : Enemy
    {
        public int Agility { get; private set; }

        public void Initialize(int health, int agility)
        {
            Health = health;
            Agility = agility;
        }
    }
}
