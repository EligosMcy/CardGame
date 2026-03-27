using System.Collections.Generic;
using Models;
using Systems;
using Views;

namespace TargetModels
{
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