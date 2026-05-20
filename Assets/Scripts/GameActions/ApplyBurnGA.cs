using General.ActionSystemComponents;
using UnityEngine;
using Views;

namespace GameActions
{
    /// <summary>
    /// 应用燃烧游戏动作 - 对目标施加燃烧伤害
    /// 每层燃烧每回合造成1点伤害
    /// </summary>
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