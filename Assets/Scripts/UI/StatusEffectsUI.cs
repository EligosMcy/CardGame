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

        [SerializeField] private Sprite _armorSprite, _burnSprite;

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

                _statusEffectUIs[statusEffect].Set(sprite, stackCount);
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
    }
}