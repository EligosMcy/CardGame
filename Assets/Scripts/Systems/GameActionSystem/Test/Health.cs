using System;
using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Systems.GameActionSystem.Test
{
    public class Health : MonoBehaviour
    {
        [SerializeField] 
        private TextMeshProUGUI _healthText;

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
        }

        private void updateHealthText()
        {
            _healthText.text = _healthAmount.ToString();
        }
    }
}