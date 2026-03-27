using System.Collections.Generic;
using DG.Tweening;
using Enums;
using TMPro;
using UI;
using UnityEngine;

namespace Views
{
    public class CombatantView : MonoBehaviour
    {
        [SerializeField] private TextMeshPro _healthText;

        [SerializeField] private SpriteRenderer _spriteRenderer;

        [SerializeField] private StatusEffectsUI _statusEffectsUI;

        public int MaxHealth { get; private set; }

        public int CurrentHealth { get; private set; }

        private Dictionary<StatusEffectType, int> _statusEffects = new Dictionary<StatusEffectType, int>();

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
            int remainingDamage = damageAmount;

            int currentArmor = GetStatusEffectStacks(StatusEffectType.ARMOR);

            if (currentArmor > 0)
            {
                if (currentArmor >= damageAmount)
                {
                    RemoveStatusEffect(StatusEffectType.ARMOR, damageAmount);

                    remainingDamage = 0;
                }
                else
                {
                    RemoveStatusEffect(StatusEffectType.ARMOR, currentArmor);

                    remainingDamage -= currentArmor;
                }
            }

            if (remainingDamage > 0)
            {
                CurrentHealth -= remainingDamage;

                if (CurrentHealth < 0)
                {
                    CurrentHealth = 0;
                }
            }

            transform.DOShakePosition(0.2f, 0.5f);

            updateHealthText();
        }

        public void AddStatusEffect(StatusEffectType statusEffectType, int stackCount)
        {
            if (_statusEffects.ContainsKey(statusEffectType))
            {
                _statusEffects[statusEffectType] += stackCount;
            }
            else
            {
                _statusEffects.Add(statusEffectType, stackCount);
            }

            _statusEffectsUI.UpdateStatusEffectUI(statusEffectType, GetStatusEffectStacks(statusEffectType));
        }

        public void RemoveStatusEffect(StatusEffectType statusEffectType, int stackCount)
        {
            if (_statusEffects.ContainsKey(statusEffectType))
            {
                _statusEffects[statusEffectType] -= stackCount;

                if (_statusEffects[statusEffectType] <= 0)
                {
                    _statusEffects.Remove(statusEffectType);
                }
            }

            _statusEffectsUI.UpdateStatusEffectUI(statusEffectType, GetStatusEffectStacks(statusEffectType));
        }

        public int GetStatusEffectStacks(StatusEffectType statusEffectType)
        {
            if (_statusEffects.TryGetValue(statusEffectType, out var stackCount)) return stackCount;

            return 0;
        }
    }
}