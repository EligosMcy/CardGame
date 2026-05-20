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
    /// <summary>
    /// 英雄系统 - 管理玩家英雄的状态和行为
    /// 处理英雄设置、状态效果管理和回合开始/结束时的逻辑
    /// </summary>
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