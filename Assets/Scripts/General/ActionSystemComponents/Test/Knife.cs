using System.Collections;
using General.ActionSystemComponents.Test.GameActaionClass;
using UnityEditor.Animations;
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
            Debug.Log("开始播放动画: " + stateName);

            float animationClipLength = GetClipLengthByName(stateName);

            yield return new WaitForSeconds(animationClipLength);

            Debug.Log("动画播放完毕: " + stateName);
        }

        /// <summary>
        /// 根据动画名称获取原始时长
        /// </summary>
        public float GetClipLengthByName(string clipName)
        {
            AnimatorController animatorController = _swordManAnimator.runtimeAnimatorController as AnimatorController;
            if (animatorController == null) return 0;

            // 遍历所有层、所有状态，匹配名称
            foreach (AnimatorControllerLayer layer in animatorController.layers)
            {
                foreach (ChildAnimatorState state in layer.stateMachine.states)
                {
                    if (state.state.name == clipName && state.state.motion is AnimationClip clip)
                    {
                        return clip.length;
                    }
                }
            }

            Debug.LogWarning($"未找到名为 {clipName} 的动画片段");
            return 0;
        }

        private void drawCardReaction(DrawCardGA drawCardGa)
        {
            DealDamageGA dealDamageGa = new DealDamageGA(3);

            ActionSystem.Instance.AddReaction(dealDamageGa);
        }
    }
}