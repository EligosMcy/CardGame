using System.Collections.Generic;
using General.ActionSystemComponents;
using Interfaces;
using Views;

namespace GameActions
{
    public class DealDamageGA : GameAction, IHaveCaster
    {
        public int Amount { get; set; }

        public List<CombatantView> Targets { get; set; }

        public CombatantView Caster { get; private set; }

        public DealDamageGA(int amount, List<CombatantView> targets, CombatantView caster)
        {
            Amount = amount;
            Targets = targets == null ? null : new List<CombatantView>(targets);
            Caster = caster;
        }

    }
}