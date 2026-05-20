using System.Collections.Generic;
using General.ActionSystemComponents;
using Models;
using Views;

namespace GameActions
{
    /// <summary>
    /// 执行效果游戏动作 - 触发卡牌的实际效果
    /// 包含效果对象和目标列表
    /// </summary>
    public class PerformEffectGA : GameAction
    {
        public Effect Effect { get; set; }

        public List<CombatantView> Targets { get; set; }

        public PerformEffectGA(Effect effect, List<CombatantView> targets)
        {
            Effect = effect;
            Targets = targets == null ? null : new List<CombatantView>(targets);
        }
    }
}