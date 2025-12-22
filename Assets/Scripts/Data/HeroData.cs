using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "HeroData", menuName = "Data/HeroData", order = 0)]
    public class HeroData : ScriptableObject
    {
        [field: SerializeField] public Sprite Image { get; private set; }

        [field: SerializeField] public int Health { get; private set; }

        [field: SerializeField] public List<CardData> Deck { get; private set; }
    }
}