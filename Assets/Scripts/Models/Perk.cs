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
    ///
    /// 目标选择模式：
    /// 特权支持三种目标选择模式，可以组合使用：
    /// - UseActionCasterAsTarget：使用动作者作为目标
    /// - UseAutoTarget：使用自动目标选择
    /// - UseManualTarget：使用手动选择的目标
    /// </summary>
    public class Perk
    {
        /// <summary>
        /// 特权的显示图标
        /// </summary>
        public Sprite Image => _data.Image;

        /// <summary>
        /// 特权的配置数据（ScriptableObject）
        /// 包含特权的所有配置信息，如图标、条件、效果等
        /// </summary>
        private readonly PerkData _data;

        /// <summary>
        /// 触发条件实例（如：敌人攻击时、回合开始时等）
        /// 定义了特权在什么情况下会被触发
        /// </summary>
        private readonly PerkCondition _condition;

        /// <summary>
        /// 自动目标效果（包含目标模式和效果）
        /// 用于在满足条件时自动选择目标
        /// </summary>
        private TargetMode _targetMode;

        /// <summary>
        /// 特权触发的实际效果
        /// 当条件满足时，会创建对应的游戏动作
        /// </summary>
        private Effect _effect;

        /// <summary>
        /// 构造函数 - 从配置数据创建特权实例
        ///
        /// 初始化过程：
        /// 1. 保存特权配置数据
        /// 2. 创建触发条件实例
        /// 3. 初始化目标模式和效果
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
        ///
        /// 重要：必须与 OnRemove() 配对调用
        /// 否则可能导致内存泄漏或重复触发
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
        ///
        /// 应该在特权威望移除、角色死亡或场景切换时调用
        /// </summary>
        public void OnRemove()
        {
            _condition.UnSubscribeCondition(reaction);
        }

        /// <summary>
        /// 条件满足时的回调方法
        /// 这是特权效果的实际执行入口
        ///
        /// 执行流程：
        /// 1. 检查条件是否满足
        /// 2. 收集所有目标（根据目标模式）
        /// 3. 创建游戏动作
        /// 4. 将动作添加到动作系统执行
        /// </summary>
        /// <param name="gameAction">触发条件的游戏动作</param>
        private void reaction(GameAction gameAction)
        {
            // 首先检查条件是否满足
            if (_condition.SatisfiesConditionIsMet(gameAction))
            {
                // 创建一个 HashSet 来存储目标，避免重复目标
                HashSet<CombatantView> targets = new HashSet<CombatantView>();

                // 模式1：使用动作者作为目标
                // 例如：反击类特权，攻击者受到反伤
                if (_data.UseActionCasterAsTarget && gameAction is IHaveCaster haveCaster)
                {
                    targets.Add(haveCaster.Caster);
                }

                // 模式2：使用自动目标选择
                // 例如：根据目标模式（随机、单体、群体等）自动选择目标
                if (_data.UseAutoTarget)
                {
                    targets.UnionWith(_targetMode.GetTargets());
                }

                // 模式3：使用手动选择的目标
                // 例如：某些特权只对玩家手动选择的目标生效
                if (_data.UseManualTarget && gameAction is IHaveManualTarget haveManualTarget)
                {
                    targets.Add(haveManualTarget.ManualTarget);
                }

                // 这里的 Caster 应该永远是 HeroView（玩家英雄）
                // 创建特权效果的游戏动作
                GameAction perkEffectAction = _effect.GetGameAction(
                    new List<CombatantView>(targets),
                    HeroSystem.Instance.HeroView
                );

                // 将动作添加到动作系统执行
                ActionSystem.Instance.AddReaction(perkEffectAction);
            }
        }
    }
}