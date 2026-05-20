using System.Collections.Generic;
using GameActions;
using General.ActionSystemComponents;
using Models;
using UnityEngine;
using Views;

namespace Effects
{
    /// <summary>
    /// 抽牌效果 - 抽取指定数量卡牌的效果实现
    /// </summary>
    public class DrawCardEffect : Effect
    {
        [SerializeField]
        private int _drawAmount;

        public override GameAction GetGameAction(List<CombatantView> targets,CombatantView caster)
        {
            DrawCardsGA drawCardsGa = new DrawCardsGA(_drawAmount);

            return drawCardsGa;
        }
    }
}