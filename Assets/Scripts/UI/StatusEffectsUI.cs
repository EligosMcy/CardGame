using System;
using System.Collections.Generic;
using Enums;
using UnityEngine;

namespace UI
{
    public class StatusEffectsUI : MonoBehaviour
    {
        [SerializeField]
        private StatusEffectUI _statusEffectUIPrefab;

        [SerializeField] 
        private Sprite _armorSprite, _burnSprite;

        [SerializeField]
        private Color _armorColor = new Color(0.2f, 0.6f, 1f);

        [SerializeField]
        private Color _burnColor = new Color(1f, 0.3f, 0.2f);

        private Dictionary<StatusEffectType, StatusEffectUI> _statusEffectUIs = new();

        public void UpdateStatusEffectUI(StatusEffectType statusEffect, int stackCount)
        {
            if (stackCount == 0)
            {
                if (_statusEffectUIs.TryGetValue(statusEffect, out StatusEffectUI statusEffectUI))
                {
                    _statusEffectUIs.Remove(statusEffect);
                    Destroy(statusEffectUI.gameObject);
                }
            }
            else
            {
                if (!_statusEffectUIs.ContainsKey(statusEffect))
                {
                    StatusEffectUI statusEffectUI = Instantiate(_statusEffectUIPrefab, transform);
                    _statusEffectUIs.Add(statusEffect, statusEffectUI);
                }

                Sprite sprite = getSpriteByType(statusEffect);
                Color color = getColorByType(statusEffect);

                _statusEffectUIs[statusEffect].Set(sprite, stackCount, color);
            }
        }

        private Sprite getSpriteByType(StatusEffectType statusEffect)
        {
            return statusEffect switch
            {
                StatusEffectType.ARMOR => _armorSprite,
                StatusEffectType.BURN => _burnSprite,
                _ => null,
            };
        }

        private Color getColorByType(StatusEffectType statusEffect)
        {
            return statusEffect switch
            {
                StatusEffectType.ARMOR => _armorColor,
                StatusEffectType.BURN => _burnColor,
                _ => Color.white,
            };
        }
    }
}