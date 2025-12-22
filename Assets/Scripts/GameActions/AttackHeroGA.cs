using General.ActionSystemComponents;
using Views;

namespace GameActions
{
    public class AttackHeroGA : GameAction
    {
        public EnemyView Attacker;

        public AttackHeroGA(EnemyView attacker)
        {
            Attacker = attacker;
        }
    }
}