using System;
using System.Collections;
using GameActions;
using General.ActionSystemComponents;
using Unity.VisualScripting;
using UnityEngine;
using Views;

namespace Systems
{
    /// <summary>
    /// 状态效果系统 - 应用和管理状态效果
    /// 为目标添加或移除各种状态效果（如燃烧、护甲等）
    /// </summary>
    public class StatusEffectSystem : MonoBehaviour
    {
        private void OnEnable()
        {
            ActionSystem.AttachPerformer<AddStatusEffectGA>(addStatusEffectPerformer);
        }

        private void OnDisable()
        {
            ActionSystem.DetachPerformer<AddStatusEffectGA>();
        }

        private IEnumerator addStatusEffectPerformer(AddStatusEffectGA addStatusEffectGa)
        {
            foreach (CombatantView target in addStatusEffectGa.Targets)
            {
                target.AddStatusEffect(addStatusEffectGa.StatusEffectType, addStatusEffectGa.StackCount);
                yield return null;
            }
        }
    }
}