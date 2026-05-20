using System;
using System.Collections;
using Enums;
using GameActions;
using General.ActionSystemComponents;
using UnityEngine;
using Views;

namespace Systems
{
    /// <summary>
    /// 燃烧系统 - 处理燃烧状态效果的伤害应用
    /// 当目标有燃烧层数时，每层造成1点伤害并移除1层燃烧
    /// </summary>
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