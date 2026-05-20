using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace General.ActionSystemComponents.Test
{
    public class Health : MonoBehaviour
    {
        [SerializeField]
        private TextMeshPro _healthText;

        [SerializeField] 
        private Transform _healthAttackPoint;

        public Transform HealthAttackPoint => _healthAttackPoint;

        private int _healthAmount;

        private void Awake()
        {
            _healthAmount = 100;

            updateHealthText();
        }

        public IEnumerator ReduceHealth(int damageAmount)
        {
            yield return 0;

            _healthAmount -= damageAmount;

            updateHealthText();

            Sequence sequence = DOTween.Sequence();

            sequence.Append(transform.DOScale(1.25f, 0.25f));

            sequence.Append(transform.DOScale(1f, 0.25f));

            yield return sequence.WaitForCompletion();
        }

        private void updateHealthText()
        {
            _healthText.text = _healthAmount.ToString();
        }
    }
}