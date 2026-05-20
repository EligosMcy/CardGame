using System.Collections.Generic;
using Models;
using Systems;
using Views;

namespace TargetModels
{
    /// <summary>
    /// 所有敌人目标模式 - 返回战场上所有敌人
    /// 用于群体攻击或群体效果卡牌
    /// </summary>
    public class AllEnemiesTM :TargetMode
    {
        public override List<CombatantView> GetTargets()
        {
            List<CombatantView> returnList = new List<CombatantView>(EnemySystem.Instance.Enemies);

            return returnList;
        }
    }
}