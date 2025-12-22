using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "Data/EnemyData", order = 0)]
    public class EnemyData : ScriptableObject
    {
        [field: SerializeField] public Sprite Image { get; private set; }

        [field: SerializeField] public int Health { get; private set; }

        [field: SerializeField] public int AttackPower { get; private set; }
    }
}