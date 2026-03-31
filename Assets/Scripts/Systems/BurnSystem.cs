using System;
using System.Collections;
using Enums;
using GameActions;
using General.ActionSystemComponents;
using UnityEngine;
using Views;

namespace Systems
{
    public class BurnSystem : MonoBehaviour
    {
        [SerializeField] private GameObject _burnVFX;

        private void OnEnable()
        {
            ActionSystem.AttachPerformer<ApplyBurnGA>(applyBurnPerformer);
        }

        private void OnDisable()
        {
            ActionSystem.DetachPerformer<ApplyBurnGA>();
        }

        private IEnumerator applyBurnPerformer(ApplyBurnGA applyBurnGA)
        {
            CombatantView target = applyBurnGA.Target;

            Instantiate(_burnVFX, target.transform.position, Quaternion.identity);

            target.Damage(applyBurnGA.BurnDamage);

            target.RemoveStatusEffect(StatusEffectType.BURN, 1);

            yield return new WaitForSeconds(1f);
        }


    }
}