using System;
using General.ActionSystemComponents;
using UnityEngine;

namespace Models
{
    public abstract class PerkCondition
    {
        [SerializeField] 
        protected ReactionTiming ReactionTiming;

        public abstract void SubscribeCondition(Action<GameAction> reaction);
        public abstract void UnSubscribeCondition(Action<GameAction> reaction);
        public abstract bool SunConditionIsMet();
    }
}