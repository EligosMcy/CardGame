using UnityEngine;

namespace Data
{
    /// <summary>
    /// 敌人数据 - ScriptableObject格式的敌人定义
    /// 包含敌人的图像、生命值、攻击力等配置
    /// </summary>
    [CreateAssetMenu(fileName = "EnemyData", menuName = "Data/EnemyData", order = 0)]
    public class EnemyData : ScriptableObject
    {
        [field: SerializeField] public Sprite Image { get; private set; }

        [field: SerializeField] public int Health { get; private set; }

        [field: SerializeField] public int AttackPower { get; private set; }
    }
}