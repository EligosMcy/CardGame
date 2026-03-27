using System.Collections.Generic;
using Enums;
using General.ActionSystemComponents;
using Views;

namespace GameActions
{
    public class AddStatusEffectGA : GameAction
    {
        public StatusEffectType StatusEffectType { get; private set; }

        public int StackCount { get; private set; }

        public List<CombatantView> Targets { get; private set; }

        public AddStatusEffectGA(StatusEffectType statusEffectType, int stackCount, List<CombatantView> targets)
        {
            StatusEffectType = statusEffectType;
            StackCount = stackCount;
            Targets = targets;
        }
    }
}