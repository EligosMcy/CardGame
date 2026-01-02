using System.Collections.Generic;
using Data;
using Effects;
using General.ActionSystemComponents;
using Interfaces;
using Systems;
using UnityEngine;
using Views;

namespace Models
{
    public class Perk
    {
        public Sprite Image => _data.Image;

        private readonly PerkData _data;

        private readonly PerkCondition _condition;

        private readonly AutoTargetEffect _autoTargetEffect;

        public Perk(PerkData perkData)
        {
            _data = perkData;

            _condition = perkData.PerkCondition;

            _autoTargetEffect = perkData.AutoTargetEffect;
        }

        public void OnAdd()
        {
            _condition.SubscribeCondition(reaction);
        }

        public void OnRemove()
        {
            _condition.UnSubscribeCondition(reaction);
        }

        private void reaction(GameAction gameAction)
        {
            if (_condition.SunConditionIsMet(gameAction))
            {
                List<CombatantView> targets = new List<CombatantView>();

                if (_data.UseActionCasterAsTarget && gameAction is IHaveCaster haveCaster)
                {
                    targets.Add(haveCaster.Caster);
                }

                if (_data.UseAutoTarget)
                {
                    targets.AddRange(_autoTargetEffect.TargetMode.GetTargets());
                }

                GameAction perkEffectAction =
                    _autoTargetEffect.Effect.GetGameAction(targets, HeroSystem.Instance.HeroView);

                ActionSystem.Instance.AddReaction(perkEffectAction);

            }
        }
    }
}