using System.Collections.Generic;
using Models;
using Systems;
using Views;

namespace TargetModels
{
    /// <summary>
    /// 英雄目标模式 - 返回玩家英雄
    /// 用于针对玩家自身的增益或减益效果
    /// </summary>
    public class HeroTM : TargetMode
    {
        public override List<CombatantView> GetTargets()
        {
            List<CombatantView> targets = new()
            {
                HeroSystem.Instance.HeroView
            };

            return targets;
        }
    }
}