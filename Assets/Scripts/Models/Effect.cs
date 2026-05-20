using System;
using System.Collections.Generic;
using General.ActionSystemComponents;
using Views;

namespace Models
{
    /// <summary>
    /// 效果基类 - 所有卡牌效果的抽象基类
    /// 派生类实现GetGameAction方法将效果转换为具体的游戏动作
    /// </summary>
    [Serializable]
    public abstract class Effect
    {
        public abstract GameAction GetGameAction(List<CombatantView> targets, CombatantView caster);
    }
}