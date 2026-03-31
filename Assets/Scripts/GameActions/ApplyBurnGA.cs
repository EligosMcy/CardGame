using General.ActionSystemComponents;
using UnityEngine;
using Views;

namespace GameActions
{
    public class ApplyBurnGA : GameAction
    {
        public int BurnDamage { get; private set; }
        public CombatantView Target { get; private set; }

        public ApplyBurnGA(int burnDamage,CombatantView target)
        {
            BurnDamage = burnDamage;
            Target = target;
        }
    }
}

