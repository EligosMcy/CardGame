using System.Collections.Generic;
using Data;
using Effects;
using UnityEngine;

namespace Models
{
    /// <summary>
    /// 卡牌模型 - 运行时卡牌数据实例
    /// 基于ScriptableObject的CardData创建，持有可变的费用等运行时数据
    /// </summary>
    public class Card
    {
        public string Title => _data.name;

        public string Description => _data.Description;

        public Sprite Image => _data.Image;

        public Effect ManualTargetEffect => _data.ManualTargetEffect;

        public List<AutoTargetEffect> OtherEffects => _data.OtherEffects;

        public int Mana { get; private set; }


        private readonly CardData _data;

        public Card(CardData cardData)
        {
            _data = cardData;
            Mana = cardData.Mana;
        }
    }
}