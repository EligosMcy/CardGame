using Creators;
using DG.Tweening;
using Extensions;
using GameActions;
using General.ActionSystemComponents;
using Models;
using System;
using System.Collections;
using System.Collections.Generic;
using Data;
using General;
using UnityEngine;
using Views;

namespace Systems
{
    public class CardSystem : Singleton<CardSystem>
    {
        [SerializeField] private HandView _handView;

        [SerializeField] private Transform _drawPilePoint;

        [SerializeField] private Transform _discardPilePoint;

        private readonly List<Card> _drawPile = new List<Card>();

        private readonly List<Card> _discardPile = new List<Card>();

        private readonly List<Card> _handPile = new List<Card>();


        private void OnEnable()
        {
            ActionSystem.AttachPerformer<DrawCardsGA>(drawCardsPerformer);
            ActionSystem.AttachPerformer<DiscardAllCardsGA>(discardAllCardsPerformer);
            ActionSystem.AttachPerformer<PlayCardGA>(playCardPerformer);

            //
            ActionSystem.SubscribeReaction<EnemyTurnGA>(enemyTurnPerReaction, ReactionTiming.PRE);
            ActionSystem.SubscribeReaction<EnemyTurnGA>(enemyTurnPostReaction, ReactionTiming.POST);
        }

        private void OnDisable()
        {
            ActionSystem.DetachPerformer<DrawCardsGA>();
            ActionSystem.DetachPerformer<DiscardAllCardsGA>();
            ActionSystem.DetachPerformer<PlayCardGA>();

            //
            ActionSystem.UnsubscribeReaction<EnemyTurnGA>(enemyTurnPerReaction, ReactionTiming.PRE);
            ActionSystem.UnsubscribeReaction<EnemyTurnGA>(enemyTurnPostReaction, ReactionTiming.POST);
        }

        public void Setup(List<CardData> deckData)
        {
            foreach (CardData cardData in deckData)
            {
                Card card = new Card(cardData);

                _drawPile.Add(card);
            }
        }

        private IEnumerator drawCardsPerformer(DrawCardsGA drawCardsGa)
        {
            int actualAmount = Math.Min(drawCardsGa.Amount, _drawPile.Count);

            int notDrawnAmount = drawCardsGa.Amount - actualAmount;

            for (int i = 0; i < actualAmount; i++)
            {
                yield return drawCard();
            }

            if (notDrawnAmount > 0)
            {
                refillDeck();

                for (int i = 0; i < notDrawnAmount; i++)
                {
                    yield return drawCard();
                }
            }

            yield return 0;
        }

        private IEnumerator discardAllCardsPerformer(DiscardAllCardsGA discardAllCardsGa)
        {
            foreach (Card card in _handPile)
            {
                CardView cardView = _handView.RemoveCard(card);

                yield return discardCard(cardView);
            }

            _handPile.Clear();
        }

        private IEnumerator playCardPerformer(PlayCardGA playCardGa)
        {
            _handPile.Remove(playCardGa.Card);

            CardView cardView = _handView.RemoveCard(playCardGa.Card);

            yield return discardCard(cardView);

            //spend Mana
            SpendManaGA spendManaGa = new SpendManaGA(playCardGa.Card.Mana);
            ActionSystem.Instance.AddReaction(spendManaGa);

            //perform Effects
            foreach (var effectWrapper in playCardGa.Card.OtherEffects)
            {
                List<CombatantView> targets = effectWrapper.TargetMode.GetTargets();

                PerformEffectGA performEffectGa = new PerformEffectGA(effectWrapper.Effect, targets);

                ActionSystem.Instance.AddReaction(performEffectGa);
            }

            yield return 0;
        }


        private void enemyTurnPerReaction(EnemyTurnGA enemyTurnGa)
        {
            DiscardAllCardsGA discardAllCardsGa = new DiscardAllCardsGA();

            ActionSystem.Instance.AddReaction(discardAllCardsGa);
        }

        private void enemyTurnPostReaction(EnemyTurnGA enemyTurnGa)
        {
            DrawCardsGA drawCardsGa = new DrawCardsGA(5);

            ActionSystem.Instance.AddReaction(drawCardsGa);
        }


        private IEnumerator discardCard(CardView cardView)
        {
            _discardPile.Add(cardView.Card);

            cardView.transform.DOMove(Vector3.zero, 0.15f);

            Tween tween = cardView.transform.DOMove(_discardPilePoint.position, 0.15f);

            yield return tween.WaitForCompletion();

            Destroy(cardView.gameObject);
        }


        private IEnumerator drawCard()
        {
            Card card = _drawPile.Draw();

            _handPile.Add(card);

            CardView cardView = CardViewCreator.Instance.CreateCardView(card, _drawPilePoint.position, _drawPilePoint.rotation);

            yield return _handView.AddCard(cardView);
        }

        private void refillDeck()
        {
            _drawPile.AddRange(_discardPile);

            _discardPile.Clear();
        }
    }
}