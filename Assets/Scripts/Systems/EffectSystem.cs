using System;
using System.Collections;
using GameActions;
using General;
using General.ActionSystemComponents;

namespace Systems
{
    /// <summary>
    /// 效果系统 - 将效果转换为具体的游戏动作
    /// 根据效果类型和目标生成对应的GameAction并提交到动作系统执行
    /// </summary>
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