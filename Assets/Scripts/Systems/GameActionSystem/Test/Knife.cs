using System;
using Systems.GameActionSystem.Test;
using UnityEngine;

namespace Systems.GameActionSystem
{
    public class Knife : MonoBehaviour
    {
        private void OnEnable()
        {
            ActionSystem.SubscribeReaction<DrawCardGA>(drawCardReaction, ReactionTiming.POST);
        }

        private void OnDisable()
        {
            ActionSystem.UnsubscribeReaction<DrawCardGA>(drawCardReaction, ReactionTiming.POST);
        }

        private void drawCardReaction(DrawCardGA drawCardGa)
        {
            DealDamageGA dealDamageGA = new DealDamageGA(3);

            ActionSystem.Instance.AddReaction(dealDamageGA);
        }
    }
}