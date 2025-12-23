using System.Collections.Generic;
using GameActions;
using General.ActionSystemComponents;
using Models;
using UnityEngine;
using Views;

namespace Effects
{
    public class DrawCardEffect : Effect
    {
        [SerializeField]
        private int _drawAmount;

        public override GameAction GetGameAction(List<CombatantView> targets)
        {
            DrawCardsGA drawCardsGa = new DrawCardsGA(_drawAmount);

            return drawCardsGa;
        }
    }
}
