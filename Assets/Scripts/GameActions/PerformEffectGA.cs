using General.ActionSystemComponents;
using Models;

namespace GameActions
{
    public class PerformEffectGA : GameAction
    {
        public Effect Effect { get; set; }
        public PerformEffectGA(Effect effect)
        {
            Effect = effect;
        }
    }
}