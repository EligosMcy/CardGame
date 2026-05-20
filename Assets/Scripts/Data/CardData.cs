using Models;
using SerializeReferenceEditor;
using System.Collections.Generic;
using Effects;
using UnityEngine;

namespace Data
{
    /// <summary>
    /// 卡牌数据 - ScriptableObject格式的卡牌定义
    /// 包含卡牌名称、费用、效果等配置信息
    /// </summary>
    [CreateAssetMenu(menuName = "Data/CardData", fileName = "CardData", order = 0)]
    public class CardData : ScriptableObject
    {
        [field: SerializeField]
        public string Description { get; private set; }

        [field: SerializeField]
        public int Mana { get; private set; }

        [field: SerializeField]
        public Sprite Image { get; private set; }

        [field: SerializeReference, SR]
        public Effect ManualTargetEffect { get; private set; } = null;

        [field: SerializeField]
        public List<AutoTargetEffect> OtherEffects { get; private set; } = new List<AutoTargetEffect>();
    }
}