using Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Splines;

namespace Views
{
    public class HandView : MonoBehaviour
    {
        [SerializeField]
        [Range(1, 100)]
        private int _maxHandSize;

        [SerializeField]
        private SplineContainer _splineContainer;

        private readonly List<CardView> _cardViewList = new List<CardView>();

        private readonly float _updateCardDuration = 0.15f;

        private readonly float _splineFloat = 1;

        private readonly float _middleSplineFloat = 0.5f;

        private readonly float _cardTweenDuration = 0.25f;

        public IEnumerator AddCard(CardView cardView)
        {
            _cardViewList.Add(cardView);

            yield return updateCardPositions(_updateCardDuration);
        }

        public CardView RemoveCard(Card card)
        {
            CardView cardView = getCardView(card);

            if (cardView == null)
            {
                return null;
            }

            _cardViewList.Remove(cardView);

            StartCoroutine(updateCardPositions(_updateCardDuration));

            return cardView;
        }

        [ContextMenu("Refresh Card Positions")]
        private void RefreshCardPositions()
        {
            if (Application.isPlaying)
            {
                StartCoroutine(updateCardPositions(_updateCardDuration));
            }
            else
            {
                int handCardListCount = _cardViewList.Count;
                if (handCardListCount == 0) return;

                for (int i = 0; i < handCardListCount; i++)
                {
                    calculateCardTransform(i, handCardListCount, out Vector3 position, out Quaternion rotation);

                    CardView cardView = _cardViewList[i];
                    cardView.UpdateCardViewPosRot(position, rotation, _cardTweenDuration);
                    cardView.UpdateSortingGroupSortingLayer(i);
                }
            }
        }

        private CardView getCardView(Card card)
        {
            return _cardViewList.FirstOrDefault(cardView => cardView.Card == card);
        }

        private void calculateCardTransform(int cardIndex, int totalCards, out Vector3 position, out Quaternion rotation)
        {
            float maxHandSize = Mathf.Max(_maxHandSize, totalCards);

            float cardSpacing = _splineFloat / maxHandSize;
            float firstCardOffsetFloat = ((totalCards - 1) * cardSpacing) / 2;
            float firstCardPositionFloat = _middleSplineFloat - firstCardOffsetFloat;

            float p = firstCardPositionFloat + cardIndex * cardSpacing;

            Spline spline = _splineContainer.Spline;
            Vector3 splinePosition = spline.EvaluatePosition(p);
            position = splinePosition + transform.position;

            Vector3 forward = spline.EvaluateTangent(p);
            Vector3 up = spline.EvaluateUpVector(p);
            Vector3 cardUp = Vector3.Cross(up, forward).normalized;
            rotation = Quaternion.LookRotation(up, cardUp);
        }

        private IEnumerator updateCardPositions(float duration)
        {
            if (_cardViewList == null) yield break;

            int handCardListCount = _cardViewList.Count;
            if (handCardListCount == 0) yield break;

            for (int i = 0; i < handCardListCount; i++)
            {
                calculateCardTransform(i, handCardListCount, out Vector3 position, out Quaternion rotation);

                CardView cardView = _cardViewList[i];
                cardView.UpdateCardViewPosRot(position, rotation, _cardTweenDuration);
                cardView.UpdateSortingGroupSortingLayer(i);
            }

            yield return new WaitForSeconds(duration);
        }
    }
}
