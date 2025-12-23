using System.Collections.Generic;
using Data;
using Effects;
using UnityEngine;

namespace Models
{
    // 这里 Card 和 CardView 为什么不写在一起?

    // 原因:
    // 如果有一种牌,有两张相同的牌,当使用掉一个后降低随机一张牌的费用
    // 这时候 使用固定的 Scriptable 作为数据源头实现就会错误

    // 1.如果直接修改 Scriptable 就会导致所有牌数据都改了
    // 2.综上所述: 再Scriptable之上再使用Card来存储数据
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
