using General.ActionSystemComponents;
using Views;

namespace GameActions
{
    public class KillEnemyGA : GameAction
    {
        public EnemyView EnemyView { get; private set; }

        public KillEnemyGA(EnemyView enemyView)
        {
            EnemyView = enemyView;
        }
    }
}