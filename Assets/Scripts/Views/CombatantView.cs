using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Views
{
    public class CombatantView : MonoBehaviour
    {
        [SerializeField] private TextMeshPro _healthText;

        [SerializeField] private SpriteRenderer _spriteRenderer;

        public int MaxHealth { get; private set; }

        public int CurrentHealth { get; private set; }

        protected void SetupBase(int health, Sprite image)
        {
            MaxHealth = CurrentHealth = health;

            _spriteRenderer.sprite = image;

            updateHealthText();
        }

        private void updateHealthText()
        {
            _healthText.text = "HP: " + CurrentHealth;
        }

        public void Damage(int damageAmount)
        {
            CurrentHealth -= damageAmount;

            if (CurrentHealth < 0)
            {
                CurrentHealth = 0;
            }

            transform.DOShakePosition(0.2f, 0.5f);

            updateHealthText();
        }


    }
}