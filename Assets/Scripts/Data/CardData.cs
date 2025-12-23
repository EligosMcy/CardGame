using Models;
using SerializeReferenceEditor;
using System.Collections.Generic;
using Effects;
using UnityEngine;

namespace Data
{
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
