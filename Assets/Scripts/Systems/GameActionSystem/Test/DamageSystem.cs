using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace Systems.GameActionSystem.Test
{
    public class DamageSystem : MonoBehaviour
    {
        [SerializeField]
        private Knife _knife;

        [SerializeField]
        private Health _health;

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
            int damageAmount = dealDamageGa.Amount;

            Vector3 knifeStartPos = _knife.transform.position;

            Tween tween = _knife.transform.DOMove(_health.transform.position, 0.25f);

            yield return tween.WaitForCompletion();

            _knife.transform.DOMove(knifeStartPos, 0.5f);

            yield return _health.ReduceHealth(damageAmount);
        }
    }
}