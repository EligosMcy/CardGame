using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    /// <summary>
    /// 英雄数据 - ScriptableObject格式的英雄定义
    /// 包含英雄的图像、生命值和初始卡组
    /// </summary>
    [CreateAssetMenu(fileName = "HeroData", menuName = "Data/HeroData", order = 0)]
    public class HeroData : ScriptableObject
    {
        [field: SerializeField] public Sprite Image { get; private set; }

        [field: SerializeField] public int Health { get; private set; }

        [field: SerializeField] public List<CardData> Deck { get; private set; }
    }
}