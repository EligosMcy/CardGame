using System;
using General.ActionSystemComponents;

namespace Models
{
    [Serializable]
    public abstract class Effect
    {
        public abstract GameAction GetGameAction();
    }
}