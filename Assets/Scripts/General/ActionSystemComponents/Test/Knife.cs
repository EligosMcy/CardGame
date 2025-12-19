using General.ActionSystemComponents.Test.GameActaionClass;
using System.Collections;
using UnityEngine;

namespace General.ActionSystemComponents.Test
{
    public class Knife : MonoBehaviour
    {
        [SerializeField]
        private Animator _swordManAnimator;

        private void OnEnable()
        {
            ActionSystem.SubscribeReaction<DrawCardGA>(drawCardReaction, ReactionTiming.POST);
        }

        private void OnDisable()
        {
            ActionSystem.UnsubscribeReaction<DrawCardGA>(drawCardReaction, ReactionTiming.POST);
        }

        public void PlayAnimator(string stateName)
        {
            _swordManAnimator.Play(stateName);
        }

        public IEnumerator PlayAnimatorAndWait(string stateName)
        {
            _swordManAnimator.Play(stateName); // 播放动画
            yield return 0;
        }

        private void drawCardReaction(DrawCardGA drawCardGa)
        {
            DealDamageGA dealDamageGa = new DealDamageGA(3);

            ActionSystem.Instance.AddReaction(dealDamageGa);
        }
    }
}