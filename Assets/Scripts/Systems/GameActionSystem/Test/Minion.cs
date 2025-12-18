using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Systems.GameActionSystem.Test
{
    public class Minion : MonoBehaviour
    {
        private int _attackAmount;

        private int _healthAmount;

        [SerializeField]
        private TextMeshPro _attackText;

        [SerializeField]
        private TextMeshPro _healthText;

        private void Awake()
        {
            _attackAmount = 1;
            _healthAmount = 1;

            updateHealthText();
            updateAttackText();
        }

        void OnEnable()
        {
            ActionSystem.SubscribeReaction<DealDamageGA>(dealDamageReaction, ReactionTiming.POST);
        }
        void OnDisable()
        {
            ActionSystem.UnsubscribeReaction<DealDamageGA>(dealDamageReaction, ReactionTiming.POST);
        }
        private void dealDamageReaction(DealDamageGA dealDamageGa)
        {
            IncreaseStatsGA increaseStatsGa = new(this, dealDamageGa.Amount, dealDamageGa.Amount);

            ActionSystem.Instance.AddReaction(increaseStatsGa);
        }

        public IEnumerator IncreaseAttackAndHealth(int attack, int health)
        {
            _attackAmount += attack;
            _healthAmount += health;

            updateHealthText();
            updateAttackText();

            yield return 0;
        }

        private void updateAttackText()
        {
            updateText(_attackAmount, _attackText);
        }

        private void updateHealthText()
        {
            updateText(_healthAmount, _healthText);
        }

        private void updateText(int amount, TextMeshPro textMeshPro)
        {
            textMeshPro.text = amount.ToString();
        }

    }
}