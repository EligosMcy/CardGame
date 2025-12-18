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
    }
}
