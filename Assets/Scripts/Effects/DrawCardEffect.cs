using GameActions;
using General.ActionSystemComponents;
using Models;
using UnityEngine;

namespace Effects
{
    public class DrawCardEffect : Effect
    {
        [SerializeField]
        private int _drawAmount;

        public override GameAction GetGameAction()
        {
            DrawCardsGA drawCardsGa = new DrawCardsGA(_drawAmount);

            return drawCardsGa;
        }
    }
}
