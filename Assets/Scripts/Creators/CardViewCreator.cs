using DG.Tweening;
using General;
using Models;
using UnityEngine;
using Views;

namespace Creators
{
    /// <summary>
    /// 卡牌视图创建器 - 管理卡牌UI的实例化
    /// 创建卡牌视图并播放显示动画
    /// </summary>
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