using Effects;
using GameActions;
using General.ActionSystemComponents;
using Models;
using System;
using UnityEngine;

namespace PerkConditions
{
    /// <summary>
    /// 火球术触发条件 - 当玩家使用火球术时触发特权效果
    ///
    /// 使用场景：
    /// - 火焰增强特权：使用火球术后对目标额外造成伤害
    /// - 火焰系特权：火球术触发时获得额外效果（如燃烧）
    /// - 法术增强特权：特定卡牌触发时激活特权效果
    ///
    /// 工作流程：
    /// 1. 订阅 PlayCardGA（使用卡牌）动作
    /// 2. 当玩家使用卡牌时，ActionSystem会通知所有订阅者
    /// 3. 条件检查通过（检查是否是火球术）
    /// 4. 触发特权效果
    /// </summary>
    public class OnFireBallCondition : PerkCondition
    {
        /// <summary>
        /// 订阅条件 - 监听玩家使用卡牌的动作
        /// </summary>
        /// <param name="reaction">条件满足时执行的回调</param>
        public override void SubscribeCondition(Action<GameAction> reaction)
        {
            // 订阅 PlayCardGA 动作，当玩家使用卡牌时会触发
            ActionSystem.SubscribeReaction<PlayCardGA>(reaction, ReactionTiming);
        }

        /// <summary>
        /// 取消订阅 - 停止监听使用卡牌动作
        /// </summary>
        /// <param name="reaction">要取消的回调</param>
        public override void UnSubscribeCondition(Action<GameAction> reaction)
        {
            ActionSystem.UnsubscribeReaction<PlayCardGA>(reaction, ReactionTiming);
        }

        /// <summary>
        /// 判断条件是否满足 - 检查是否使用了火球术
        ///
        /// 这里通过卡牌的描述文本来判断是否是火球术
        /// 在实际项目中建议使用卡牌ID或卡牌类型来判断，以提高可靠性
        /// </summary>
        /// <param name="gameAction">游戏动作（PlayCardGA）</param>
        /// <returns>如果使用的是火球术返回true，否则返回false</returns>
        public override bool SatisfiesConditionIsMet(GameAction gameAction)
        {
            // 将游戏动作转换为 PlayCardGA 类型
            if (gameAction is PlayCardGA playCardGa)
            {
                // 通过卡牌描述判断是否是火球术
                // 这种方式依赖于卡牌描述文本，建议使用更可靠的方式（如卡牌ID）
                if (playCardGa.Card.Description == "Deal 1 damage to Manual Target")
                {
                    return true;
                }
            }

            return false;
        }
    }
}