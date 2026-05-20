using General.ActionSystemComponents;
using Views;

namespace GameActions
{
    /// <summary>
    /// 击杀敌人游戏动作 - 移除指定敌人
    /// 触发敌人死亡动画和掉落逻辑
    /// </summary>
    public class KillEnemyGA : GameAction
    {
        public EnemyView EnemyView { get; private set; }

        public KillEnemyGA(EnemyView enemyView)
        {
            EnemyView = enemyView;
        }
    }
}