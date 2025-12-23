using System;
using System.Collections.Generic;
using Views;

namespace Models
{
    [Serializable]
    public abstract class TargetMode
    {
        public abstract List<CombatantView> GetTargets();
    }
}