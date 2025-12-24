using System.Collections.Generic;
using General.ActionSystemComponents;
using Views;

namespace GameActions
{
    public class DealDamageGA : GameAction
    {
        public int Amount { get; set; }

        public List<CombatantView> Targets { get; set; }

        public DealDamageGA(int amount, List<CombatantView> targets)
        {
            Amount = amount;
            Targets = targets == null ? null : new List<CombatantView>(targets);
        }
    }
}