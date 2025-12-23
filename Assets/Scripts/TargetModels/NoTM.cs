using System.Collections.Generic;
using Models;
using Views;

namespace TargetModels
{
    public class NoTM : TargetMode
    {
        public override List<CombatantView> GetTargets()
        {
            return null;
        }
    }
}