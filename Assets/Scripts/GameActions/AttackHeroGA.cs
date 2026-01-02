using General.ActionSystemComponents;
using Interfaces;
using Views;

namespace GameActions
{
    public class AttackHeroGA : GameAction,IHaveCaster
    {
        public EnemyView Attacker;

        public CombatantView Caster { get; private set; }

        public AttackHeroGA(EnemyView attacker)
        {
            Attacker = attacker;
            Caster = attacker;
        }

    }
}