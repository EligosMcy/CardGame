using Effects;
using Models;
using SerializeReferenceEditor;
using UnityEngine;

namespace Data
{
    /// <summary>
    /// 特权数据 - ScriptableObject格式的特权/遗物定义
    /// 
    /// 在Unity编辑器中创建，用于配置特权的行为：
    /// - 设置触发条件（如：敌人攻击时、回合开始时）
    /// - 设置执行效果（如：造成伤害、获得护甲、抽牌）
    /// - 设置目标选择方式（如：自己、所有敌人、随机敌人）
    /// 
    /// 配置示例（以"荆棘光环"特权为例）：
    /// - PerkCondition: OnEnemyAttackCondition（敌人攻击时）
    /// - AutoTargetEffect: 
    ///   - TargetMode: UseActionCasterAsTarget=true（以攻击者为目标）
    ///   - Effect: DealDamageEffect(3)（造成3点伤害）
    /// - 效果：敌人攻击玩家时，敌人受到3点伤害
    /// </summary>
    [CreateAssetMenu(fileName = "PerkData", menuName = "Data/PerkData", order = 0)]
    public class PerkData : ScriptableObject
    {
        /// <summary>
        /// 特权的显示图标
        /// </summary>
        [field: SerializeField]
        public Sprite Image { get; private set; }

        /// <summary>
        /// 触发条件 - 决定特权何时激活
        /// 使用SerializeReference支持多态配置
        /// 可选：OnEnemyAttackCondition（敌人攻击时）等
        /// </summary>
        [field: SerializeReference, SR] public PerkCondition PerkCondition { get; private set; }

        /// <summary>
        /// 自动目标效果 - 包含目标模式和实际效果
        /// - TargetMode: 如何选择目标（自己、所有敌人等）
        /// - Effect: 要执行的效果（伤害、护甲、抽牌等）
        /// </summary>
        [field: SerializeReference, SR] public AutoTargetEffect AutoTargetEffect { get; private set; }

        /// <summary>
        /// 是否使用自动目标模式获取目标
        /// 如果为true，会根据TargetMode获取目标
        /// </summary>
        [field: SerializeField] public bool UseAutoTarget { get; private set; } = true;

        /// <summary>
        /// 是否使用触发动作的发起者作为目标
        /// 如果为true，会将触发该动作的实体（如攻击的敌人）作为目标
        /// 常用于反击类效果
        /// </summary>
        [field: SerializeField] public bool UseActionCasterAsTarget { get; private set; } = false;
    }
}