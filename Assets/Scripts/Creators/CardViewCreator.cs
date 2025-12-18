using DG.Tweening;
using General;
using Models;
using UnityEngine;
using Views;

namespace Creators
{
    public class CardViewCreator : Singleton<CardViewCreator>
    {
        [SerializeField] private CardView _cardViewPrefab;

        private readonly float _createShowDuration = 0.15f;

        public CardView CreateCardView(Card card, Vector3 position, Quaternion rotation)
        {
            CardView cardView = Instantiate(_cardViewPrefab, position, rotation);

            cardView.transform.localScale = Vector3.zero;

            cardView.transform.DOScale(Vector3.one, _createShowDuration);

            cardView.Setup(card);

            return cardView;
        }
    }
}
