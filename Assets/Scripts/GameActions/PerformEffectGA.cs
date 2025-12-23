using System.Collections.Generic;
using General.ActionSystemComponents;
using Models;
using Views;

namespace GameActions
{
    public class PerformEffectGA : GameAction
    {
        public Effect Effect { get; set; }

        public List<CombatantView> Targets { get; set; }

        public PerformEffectGA(Effect effect, List<CombatantView> targets)
        {
            Effect = effect;
            Targets = targets == null ? null : new List<CombatantView>(targets);
        }
    }
}