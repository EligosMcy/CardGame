using System;

namespace General.ActionSystemComponents.UITest
{
    public enum CardType
    {
        Attack,
        Skill,
        Power
    }

    public enum CardRarity
    {
        Common,
        Uncommon,
        Rare
    }

    [Serializable]
    public class CardEffectData
    {
        public int damage;
        public int armor;
        public int heal;
        public int energy;
        public int drawCards;
        public bool targetAll;
        public bool lifesteal;
        public int burn;
        public int thorns;
        public int endTurnArmor;
        public int endTurnHeal;
        public int startTurnEnergy;
        public int endTurnEnergyLoss;
        public int selfDamage;
        public int conditionDamageMultiplier;
    }

    [Serializable]
    public class CardData
    {
        public string name;
        public string type;
        public int cost;
        public string rarity;
        public string description;
        public CardEffectData effect;

        public CardType GetCardType()
        {
            return Enum.Parse<CardType>(type, true);
        }

        public CardRarity GetCardRarity()
        {
            return Enum.Parse<CardRarity>(rarity, true);
        }
    }

    [Serializable]
    public class CardDatabaseData
    {
        public CardData[] cards;
    }
}