using System.Collections.Generic;
using General.ActionSystemComponents;
using Interfaces;
using Views;

namespace GameActions
{
    /// <summary>
    /// 造成伤害游戏动作 - 对目标列表造成指定数量的伤害
    /// 实现IHaveCaster接口，追踪伤害来源
    /// </summary>
    public class DealDamageGA : GameAction, IHaveCaster
    {
        public int Amount { get; set; }

        public List<CombatantView> Targets { get; set; }

        public CombatantView Caster { get; private set; }

        public DealDamageGA(int amount, List<CombatantView> targets, CombatantView caster)
        {
            Amount = amount;
            Targets = targets == null ? null : new List<CombatantView>(targets);
            Caster = caster;
        }

    }
}