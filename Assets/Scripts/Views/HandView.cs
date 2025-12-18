using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
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

        private float _splineFloat = 1;

        private readonly float _middleSplineFloat = 0.5f;

        private readonly float _cardTweenDuration = 0.25f;

        public IEnumerator AddCard(CardView cardView)
        {
            _cardViewList.Add(cardView);

            yield return updateCardPositions(_updateCardDuration);
        }

        private IEnumerator updateCardPositions(float duration)
        {
            if (_cardViewList == null) yield break;

            Vector3 handViewPos = transform.position;

            int handCardListCount = _cardViewList.Count;

            if (handCardListCount == 0) yield break;

            float cardSpacing = 1f / _maxHandSize;

            float firstCardOffsetFloat = ((handCardListCount - 1) * cardSpacing) / 2;

            float firstCardPositionFloat = _middleSplineFloat - firstCardOffsetFloat;

            //
            Spline spline = _splineContainer.Spline;

            for (int i = 0; i < handCardListCount; i++)
            {
                float p = firstCardPositionFloat + i * cardSpacing;

                Vector3 splinePosition = spline.EvaluatePosition(p);

                Vector3 forward = spline.EvaluateTangent(p);

                Vector3 up = spline.EvaluateUpVector(p);

                Vector3 cardUp = Vector3.Cross(up, forward).normalized;

                Quaternion rotation = Quaternion.LookRotation(up, cardUp);

                _cardViewList[i].transform.DOMove(splinePosition + handViewPos, _cardTweenDuration);
                _cardViewList[i].transform.DORotateQuaternion(rotation, _cardTweenDuration);
            }

            yield return new WaitForSeconds(duration);
        }
    }
}
