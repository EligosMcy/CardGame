namespace General.ActionSystemComponents.UITest
{
    public class PlayEntity
    {
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int AttackPower { get; set; }
        public int Armor { get; set; }
        public int Energy { get; set; }
        public int Gold { get; set; }

        public PlayEntity(int maxHealth, int attackPower, int armor, int energy, int gold)
        {
            MaxHealth = maxHealth;
            Health = maxHealth;
            AttackPower = attackPower;
            Armor = armor;
            Energy = energy;
            Gold = gold;
        }
    }
}