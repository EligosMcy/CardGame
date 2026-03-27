using System;
using System.Collections;
using GameActions;
using General.ActionSystemComponents;
using Unity.VisualScripting;
using UnityEngine;
using Views;

namespace Systems
{
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