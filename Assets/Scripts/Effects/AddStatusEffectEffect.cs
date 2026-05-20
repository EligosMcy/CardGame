using System.Collections.Generic;
using Enums;
using GameActions;
using General.ActionSystemComponents;
using Models;
using UnityEngine;
using Views;

namespace Effects
{
    /// <summary>
    /// 添加状态效果 - 为目标添加指定状态效果的卡牌效果实现
    /// </summary>
    public class AddStatusEffectEffect : Effect
    {
        [SerializeField] private StatusEffectType _statusEffectType;

        [SerializeField] private int _stackCount;

        public override GameAction GetGameAction(List<CombatantView> targets, CombatantView caster)
        {
            return new AddStatusEffectGA(_statusEffectType, _stackCount, targets);
        }
    }
}