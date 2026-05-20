using Data;
using Effects;
using General.ActionSystemComponents;
using Interfaces;
using SerializeReferenceEditor;
using System.Collections.Generic;
using Systems;
using UnityEngine;
using Views;

namespace Models
{
    /// <summary>
    /// 特权模型 - 代表游戏中的被动技能/遗物效果
    /// 
    /// 特权系统工作原理：
    /// 1. 每个特权都有一个"触发条件"（PerkCondition）和一个"执行效果"（Effect）
    /// 2. 当条件满足时（比如敌人攻击），特权会自动触发对应的效果
    /// 3. 这是一种典型的观察者模式实现
    /// 
    /// 生命周期：
    /// - OnAdd(): 特权被添加时调用，订阅触发条件
    /// - OnRemove(): 特权被移除时调用，取消订阅
    /// </summary>
    public class Perk
    {
        /// <summary>
        /// 特权的显示图标
        /// </summary>
        public Sprite Image => _data.Image;

        /// <summary>
        /// 特权的配置数据（ScriptableObject）
        /// </summary>
        private readonly PerkData _data;

        /// <summary>
        /// 触发条件实例（如：敌人攻击时、回合开始时等）
        /// </summary>
        private readonly PerkCondition _condition;

        /// <summary>
        /// 自动目标效果（包含目标模式和效果）
        /// </summary>
        private TargetMode _targetMode;

        private Effect _effect;

        /// <summary>
        /// 构造函数 - 从配置数据创建特权实例
        /// </summary>
        /// <param name="perkData">特权配置数据</param>
        public Perk(PerkData perkData)
        {
            _data = perkData;
            _condition = perkData.PerkCondition;

            _targetMode = perkData.TargetMode;
            _effect = perkData.Effect;
        }

        /// <summary>
        /// 特权被添加到玩家身上时调用
        /// 订阅触发条件，开始监听游戏事件
        /// </summary>
        public void OnAdd()
        {
            if (_condition == null)
            {
                Debug.LogWarning($"Perk {_data.name} has no condition configured");
                return;
            }

            if (_data.UseAutoTarget && (_targetMode == null || _effect == null))
            {
                Debug.LogWarning($"Perk {_data.name} is missing TargetMode or Effect configuration");
                return;
            }

            _condition.SubscribeCondition(reaction);
        }

        /// <summary>
        /// 特权被移除时调用
        /// 取消订阅，停止监听游戏事件
        /// </summary>
        public void OnRemove()
        {
            _condition.UnSubscribeCondition(reaction);
        }

        /// <summary>
        /// 条件满足时的回调方法
        /// 这是特权效果的实际执行入口
        /// </summary>
        /// <param name="gameAction">触发条件的游戏动作</param>
        private void reaction(GameAction gameAction)
        {
            if (_condition.SatisfiesConditionIsMet(gameAction))
            {
                HashSet<CombatantView> targets = new HashSet<CombatantView>();

                if (_data.UseActionCasterAsTarget && gameAction is IHaveCaster haveCaster)
                {
                    targets.Add(haveCaster.Caster);
                }

                if (_data.UseAutoTarget)
                {
                    targets.UnionWith(_targetMode.GetTargets());
                }

                if (_data.UseManualTarget && gameAction is IHaveManualTarget haveManualTarget)
                {
                    targets.Add(haveManualTarget.ManualTarget);
                }

                //这里的Caster应该永远是HeroView
                GameAction perkEffectAction = _effect.GetGameAction(new List<CombatantView>(targets), HeroSystem.Instance.HeroView);

                ActionSystem.Instance.AddReaction(perkEffectAction);
            }
        }
    }
}