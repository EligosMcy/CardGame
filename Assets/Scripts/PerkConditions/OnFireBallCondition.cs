using System;
using GameActions;
using General.ActionSystemComponents;
using Models;
using UnityEngine;

namespace PerkConditions
{
    public class OnFireBallCondition : PerkCondition
    {
        public override void SubscribeCondition(Action<GameAction> reaction)
        {
            ActionSystem.SubscribeReaction<PlayCardGA>(reaction, ReactionTiming);
        }

        public override void UnSubscribeCondition(Action<GameAction> reaction)
        {
            ActionSystem.UnsubscribeReaction<PlayCardGA>(reaction, ReactionTiming);
        }

        public override bool SunConditionIsMet(GameAction gameAction)
        {
            if (gameAction is PlayCardGA playCardGa)
            {
                if (playCardGa.Card.Description == "Deal 1 damage to Manual Target")
                {
                    return true;
                }
            }

            return false;
        }
    }
}