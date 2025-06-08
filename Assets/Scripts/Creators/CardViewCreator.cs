using Assets.Scripts.Views;
using DG.Tweening;
using General;
using UnityEngine;
using UnityEngine.Serialization;

public class CardViewCreator : Singleton<CardViewCreator>
{
    [SerializeField] private CardView _cardViewPrefab;

    private readonly float _createShowDuration = 0.15f;

    public CardView CreateCardView(Vector3 position, Quaternion rotation)
    {
        CardView cardView = Instantiate(_cardViewPrefab, position, rotation);

        cardView.transform.localScale = Vector3.zero;

        cardView.transform.DOScale(Vector3.one, _createShowDuration);

        return cardView;
    }
}
