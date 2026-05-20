using System;
using GameActions;
using General.ActionSystemComponents;
using Models;

namespace PerkConditions
{
    /// <summary>
    /// 敌人攻击时触发条件 - 当敌人攻击玩家时触发特权效果
    ///
    /// 使用场景：
    /// - 反击类特权：敌人攻击时对敌人造成伤害
    /// - 防御类特权：敌人攻击时获得护甲
    /// - 反伤类特权：敌人攻击时反弹伤害
    ///
    /// 工作流程：
    /// 1. 订阅 AttackHeroGA（敌人攻击玩家）动作
    /// 2. 当敌人攻击玩家时，ActionSystem会通知所有订阅者
    /// 3. 条件检查通过（这里始终返回true）
    /// 4. 触发特权效果
    ///
    /// 扩展说明：
    /// - 可以通过重写 SatisfiesConditionIsMet 方法来实现更复杂的条件判断
    /// - 例如：只在玩家生命值低于50%时触发，或只对特定类型的敌人触发
    /// </summary>
    public class OnEnemyAttackCondition : PerkCondition
    {
        /// <summary>
        /// 订阅条件 - 监听敌人攻击玩家的动作
        /// </summary>
        /// <param name="reaction">条件满足时执行的回调</param>
        public override void SubscribeCondition(Action<GameAction> reaction)
        {
            // 订阅 AttackHeroGA 动作，当敌人攻击玩家时会触发
            // ReactionTiming 决定了在动作的哪个阶段触发（Before/After）
            ActionSystem.SubscribeReaction<AttackHeroGA>(reaction, ReactionTiming);
        }

        /// <summary>
        /// 取消订阅 - 停止监听敌人攻击动作
        /// </summary>
        /// <param name="reaction">要取消的回调</param>
        public override void UnSubscribeCondition(Action<GameAction> reaction)
        {
            // 取消订阅时需要使用相同的 ReactionTiming 参数
            ActionSystem.UnsubscribeReaction<AttackHeroGA>(reaction, ReactionTiming);
        }

        /// <summary>
        /// 判断条件是否满足
        /// 这里简化处理，只要敌人攻击就满足条件
        ///
        /// 扩展用法：
        /// - 可以通过 gameAction 参数获取攻击者的详细信息
        /// - 可以根据攻击类型、伤害值、攻击者类型等判断是否触发
        /// </summary>
        /// <param name="gameAction">游戏动作（AttackHeroGA）</param>
        /// <returns>始终返回true，表示条件满足</returns>
        public override bool SatisfiesConditionIsMet(GameAction gameAction)
        {
            // 可以在这里添加更复杂的条件判断
            // 例如：只在玩家生命值低于50%时触发
            // if (gameAction is AttackHeroGA attack && attack.Damage >= someValue)
            // {
            //     return true;
            // }
            return true;
        }
    }
}