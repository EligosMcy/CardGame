using General.ActionSystemComponents;
using Interfaces;
using Views;

namespace GameActions
{
    /// <summary>
    /// 攻击英雄游戏动作 - 敌人对玩家发起攻击
    /// 包含攻击者信息，实现IHaveCaster接口
    /// </summary>
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