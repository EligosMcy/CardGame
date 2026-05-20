using System;

namespace General.ActionSystemComponents.UITest
{
    /// <summary>
    /// 卡牌类型枚举
    /// Attack: 攻击卡 - 用于对敌人造成伤害
    /// Skill: 技能卡 - 提供防御、恢复或其他特殊效果
    /// Power: 能力卡 - 提供持续性效果或改变战斗规则
    /// </summary>
    public enum CardType
    {
        Attack,
        Skill,
        Power
    }

    /// <summary>
    /// 卡牌稀有度枚举
    /// Common: 普通 - 白色边框，出现概率最高
    /// Uncommon: 罕见 - 蓝色边框，出现概率中等
    /// Rare: 稀有 - 金色边框，出现概率较低
    /// </summary>
    public enum CardRarity
    {
        Common,
        Uncommon,
        Rare
    }

    /// <summary>
    /// 卡牌效果数据结构
    /// 包含卡牌可能具有的各种效果参数
    /// </summary>
    [Serializable]
    public class CardEffectData
    {
        /// <summary>造成的伤害值</summary>
        public int damage;

        /// <summary>提供的护甲值</summary>
        public int armor;

        /// <summary>恢复的生命值</summary>
        public int heal;

        /// <summary>获得的能量值</summary>
        public int energy;

        /// <summary>额外抽牌的数量</summary>
        public int drawCards;

        /// <summary>是否针对所有敌人（群体攻击）</summary>
        public bool targetAll;

        /// <summary>是否具有吸血效果（造成伤害时恢复生命）</summary>
        public bool lifesteal;

        /// <summary>施加的燃烧层数（每层每回合造成伤害）</summary>
        public int burn;

        /// <summary>反伤值（受到攻击时对攻击者造成伤害）</summary>
        public int thorns;

        /// <summary>回合结束时获得的护甲值</summary>
        public int endTurnArmor;

        /// <summary>回合结束时恢复的生命值</summary>
        public int endTurnHeal;

        /// <summary>回合开始时获得的能量值</summary>
        public int startTurnEnergy;

        /// <summary>回合结束时失去的能量值</summary>
        public int endTurnEnergyLoss;

        /// <summary>使用卡牌时对自己造成的伤害值</summary>
        public int selfDamage;

        /// <summary>满足条件时的伤害倍率</summary>
        public int conditionDamageMultiplier;
    }

    /// <summary>
    /// 卡牌数据类
    /// 存储单张卡牌的完整信息
    /// </summary>
    [Serializable]
    public class CardData
    {
        /// <summary>卡牌名称</summary>
        public string name;

        /// <summary>卡牌类型（attack/skill/power）</summary>
        public string type;

        /// <summary>打出卡牌所需的能量费用</summary>
        public int cost;

        /// <summary>卡牌稀有度（common/uncommon/rare）</summary>
        public string rarity;

        /// <summary>卡牌的描述文本，显示卡牌效果</summary>
        public string description;

        /// <summary>卡牌的效果数据，包含各种数值效果</summary>
        public CardEffectData effect;

        /// <summary>
        /// 获取卡牌类型（枚举形式）
        /// </summary>
        /// <returns>卡牌类型的枚举值</returns>
        public CardType GetCardType()
        {
            return Enum.Parse<CardType>(type, true);
        }

        /// <summary>
        /// 获取卡牌稀有度（枚举形式）
        /// </summary>
        /// <returns>卡牌稀有度的枚举值</returns>
        public CardRarity GetCardRarity()
        {
            return Enum.Parse<CardRarity>(rarity, true);
        }
    }

    /// <summary>
    /// 卡牌数据库数据结构
    /// 用于JSON反序列化，包含所有卡牌数据的数组
    /// </summary>
    [Serializable]
    public class CardDatabaseData
    {
        /// <summary>所有卡牌数据的数组</summary>
        public CardData[] cards;
    }
}