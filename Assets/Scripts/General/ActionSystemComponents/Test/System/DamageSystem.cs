using System.Collections;
using DG.Tweening;
using General.ActionSystemComponents.Test.GameActaionClass;
using UnityEngine;

namespace General.ActionSystemComponents.Test
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

            _knife.PlayAnimator("Run");

            Tween toTween = _knife.transform.DOMove(_health.HealthAttackPoint.position, 0.25f);

            yield return toTween.WaitForCompletion();

            yield return _knife.PlayAnimatorAndWait("Attack",0.25f);

            yield return _health.ReduceHealth(damageAmount);

            _knife.PlayAnimator("Run");

            Tween backTween = _knife.transform.DOMove(knifeStartPos, 0.25f);

            yield return backTween.WaitForCompletion();

            _knife.PlayAnimator("Idle");
        }
    }
}