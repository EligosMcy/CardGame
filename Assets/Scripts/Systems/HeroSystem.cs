using Data;
using GameActions;
using General;
using General.ActionSystemComponents;
using System;
using Enums;
using UnityEngine;
using Views;

namespace Systems
{
    public class HeroSystem : Singleton<HeroSystem>
    {
        [field: SerializeField] public HeroView HeroView { get; private set; }

        private void OnEnable()
        {
            //
            ActionSystem.SubscribeReaction<EnemyTurnGA>(enemyTurnPerReaction, ReactionTiming.PRE);
            ActionSystem.SubscribeReaction<EnemyTurnGA>(enemyTurnPostReaction, ReactionTiming.POST);
        }

        private void OnDisable()
        {
            //
            ActionSystem.UnsubscribeReaction<EnemyTurnGA>(enemyTurnPerReaction, ReactionTiming.PRE);
            ActionSystem.UnsubscribeReaction<EnemyTurnGA>(enemyTurnPostReaction, ReactionTiming.POST);
        }

        public void Setup(HeroData heroData)
        {
            HeroView.Setup(heroData);
        }

        private void enemyTurnPerReaction(EnemyTurnGA enemyTurnGa)
        {
            DiscardAllCardsGA discardAllCardsGa = new DiscardAllCardsGA();

            ActionSystem.Instance.AddReaction(discardAllCardsGa);
        }

        private void enemyTurnPostReaction(EnemyTurnGA enemyTurnGa)
        {
            int burnStacks = HeroView.GetStatusEffectStacks(StatusEffectType.BURN);

            if (burnStacks > 0)
            {
                ApplyBurnGA applyBurnGA = new ApplyBurnGA(burnStacks, HeroView);

                ActionSystem.Instance.AddReaction(applyBurnGA);
            }

            DrawCardsGA drawCardsGa = new DrawCardsGA(5);

            ActionSystem.Instance.AddReaction(drawCardsGa);
        }

    }
}