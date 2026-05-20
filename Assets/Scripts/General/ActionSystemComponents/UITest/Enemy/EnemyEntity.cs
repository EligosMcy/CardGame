namespace General.ActionSystemComponents.UITest
{
    public class EnemyEntity
    {
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int AttackPower { get; set; }
        public int Armor { get; set; }

        public EnemyEntity(int maxHealth, int attackPower, int armor)
        {
            MaxHealth = maxHealth;
            Health = maxHealth;
            AttackPower = attackPower;
            Armor = armor;
        }
    }
}