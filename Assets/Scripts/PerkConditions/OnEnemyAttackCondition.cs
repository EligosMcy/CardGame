using System;
using GameActions;
using General.ActionSystemComponents;
using Models;

namespace PerkConditions
{
    public class OnEnemyAttackCondition : PerkCondition
    {
        public override void SubscribeCondition(Action<GameAction> reaction)
        {
            ActionSystem.SubscribeReaction<AttackHeroGA>(reaction, ReactionTiming);
        }

        public override void UnSubscribeCondition(Action<GameAction> reaction)
        {
            ActionSystem.UnsubscribeReaction<AttackHeroGA>(reaction, ReactionTiming);
        }

        public override bool SunConditionIsMet()
        {
            return true;
        }
    }
}