using System.Collections.Generic;
using GameActions;
using General.ActionSystemComponents;
using Models;
using Systems;
using UnityEngine;
using Views;

namespace Effects
{
    public class DealDamageEffect : Effect
    {
        [SerializeField] private int _damageAmount;

        public override GameAction GetGameAction(List<CombatantView> targets, CombatantView caster)
        {
            DealDamageGA dealDamageGa = new DealDamageGA(_damageAmount, targets, caster);

            return dealDamageGa;
        }
    }
}