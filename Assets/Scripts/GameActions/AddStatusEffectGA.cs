using System.Collections.Generic;
using Enums;
using General.ActionSystemComponents;
using Views;

namespace GameActions
{
    /// <summary>
    /// 添加状态效果游戏动作 - 为目标添加指定类型和层数的状态效果
    /// </summary>
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