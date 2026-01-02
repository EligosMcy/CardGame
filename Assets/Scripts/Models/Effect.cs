using System;
using System.Collections.Generic;
using General.ActionSystemComponents;
using Views;

namespace Models
{
    [Serializable]
    public abstract class Effect
    {
        public abstract GameAction GetGameAction(List<CombatantView> targets, CombatantView caster);
    }
}