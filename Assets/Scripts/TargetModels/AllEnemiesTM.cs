using System.Collections.Generic;
using Models;
using Systems;
using Views;

namespace TargetModels
{
    public class AllEnemiesTM :TargetMode
    {
        public override List<CombatantView> GetTargets()
        {
            List<CombatantView> returnList = new List<CombatantView>(EnemySystem.Instance.Enemies);

            return returnList;
        }
    }
}