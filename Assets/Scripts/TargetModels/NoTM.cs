using System.Collections.Generic;
using Models;
using Views;

namespace TargetModels
{
    /// <summary>
    /// 无目标模式 - 不返回任何目标
    /// 用于不需要指定目标的卡牌效果（如抽牌、增加能量等）
    /// </summary>
    public class NoTM : TargetMode
    {
        public override List<CombatantView> GetTargets()
        {
            return null;
        }
    }
}