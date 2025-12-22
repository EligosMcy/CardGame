using System;
using System.Collections;
using GameActions;
using General;
using General.ActionSystemComponents;
using UnityEngine;
using Views;

namespace Systems
{
    public class DamageSystem : Singleton<DamageSystem>
    {
        [SerializeField] private GameObject _damageVFX;

        private void OnEnable()
        {
            ActionSystem.AttachPerformer<DealDamageGA>(dealDamagePerformer);
        }


        private void OnDisable()
        {
            ActionSystem.DetachPerformer<DealDamageGA>();
        }

        private IEnumerator dealDamagePerformer(DealDamageGA dealDamageGa)
        {
            foreach (CombatantView combatantView in dealDamageGa.Targets)
            {
                combatantView.Damage(dealDamageGa.Amount);
                Transform targetTran = combatantView.transform;
                Instantiate(_damageVFX, targetTran.position, targetTran.rotation);

                yield return new WaitForSeconds(0.15f);
            }

            yield return 0;
        }

    }
}