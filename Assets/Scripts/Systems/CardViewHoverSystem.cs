using System;
using General;
using Models;
using UnityEngine;
using Views;

namespace Systems
{
    /// <summary>
    /// 卡牌悬停系统 - 管理卡牌hover时显示详细信息
    /// 当鼠标悬停在手牌上时显示卡牌的详细视图
    /// </summary>
    public class CardViewHoverSystem : Singleton<CardViewHoverSystem>
    {
        [SerializeField] private CardView _cardViewHover;

        public void Show(Card card, Vector3 position)
        {
            _cardViewHover.gameObject.SetActive(true);
            _cardViewHover.Setup(card);
            _cardViewHover.transform.position = position;
        }

        public void Hide()
        {
            _cardViewHover.gameObject.SetActive(false);
        }

    }
}