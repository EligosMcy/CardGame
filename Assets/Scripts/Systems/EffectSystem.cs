using System;
using System.Collections;
using GameActions;
using General;
using General.ActionSystemComponents;

namespace Systems
{
    public class EffectSystem : Singleton<EffectSystem>
    {
        private void OnDisable()
        {
            ActionSystem.DetachPerformer<PerformEffectGA>();


        }

        private void OnEnable()
        {
            ActionSystem.AttachPerformer<PerformEffectGA>(performEffectGaPerformer);
        }

        private IEnumerator performEffectGaPerformer(PerformEffectGA performEffectGa)
        {
            GameAction effectAction = performEffectGa.Effect.GetGameAction(performEffectGa.Targets, HeroSystem.Instance.HeroView);

            ActionSystem.Instance.AddReaction(effectAction);

            yield return 0;
        }
    }
}