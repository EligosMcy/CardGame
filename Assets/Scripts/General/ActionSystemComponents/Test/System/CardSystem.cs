using System.Collections;
using DG.Tweening;
using General.ActionSystemComponents.Test.GameActaionClass;
using UnityEngine;

namespace General.ActionSystemComponents.Test
{
    public class CardSystem : MonoBehaviour
    {
        [SerializeField] private Card _cardPrefab;

        [SerializeField] private Transform _spawn;

        [SerializeField] private Transform _hand;

        private readonly float _moveDuration = 0.5f;

        private void OnEnable()
        {
            ActionSystem.AttachPerformer<DrawCardGA>(drawCardPerformer);
        }

        private void OnDisable()
        {
            ActionSystem.DetachPerformer<DrawCardGA>();
        }

        private IEnumerator drawCardPerformer(DrawCardGA drawCardGa)
        {
            Card card = Instantiate(_cardPrefab, _spawn.position, Quaternion.identity);

            Tween tween = card.transform.DOMove(_hand.position, _moveDuration);

            yield return tween.WaitForCompletion();
        }
    }
}