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
        private readonly AutoTargetEffect _autoTargetEffect;

        /// <summary>
        /// 构造函数 - 从配置数据创建特权实例
        /// </summary>
        /// <param name="perkData">特权配置数据</param>
        public Perk(PerkData perkData)
        {
            _data = perkData;
            _condition = perkData.PerkCondition;
            _autoTargetEffect = perkData.AutoTargetEffect;
        }

        /// <summary>
        /// 特权被添加到玩家身上时调用
        /// 订阅触发条件，开始监听游戏事件
        /// </summary>
        public void OnAdd()
        {
            // 订阅条件，当条件满足时会触发reaction回调
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
            // 1. 检查条件是否真正满足（额外的条件判断）
            if (_condition.SunConditionIsMet(gameAction))
            {
                // 2. 收集目标列表
                List<CombatantView> targets = new List<CombatantView>();

                // 选项1：是否使用触发动作的发起者作为目标
                // 例如：敌人攻击玩家时，把敌人作为目标进行反击
                if (_data.UseActionCasterAsTarget && gameAction is IHaveCaster haveCaster)
                {
                    targets.Add(haveCaster.Caster);
                }

                // 选项2：是否使用自动目标模式获取目标
                // 例如：对所有敌人、对自己、随机敌人等
                if (_data.UseAutoTarget)
                {
                    targets.AddRange(_autoTargetEffect.TargetMode.GetTargets());
                }

                // 3. 创建效果动作并执行
                // 把效果转换为具体的游戏动作（如造成伤害、添加护甲等）
                GameAction perkEffectAction = _autoTargetEffect.Effect.GetGameAction(targets, HeroSystem.Instance.HeroView);

                // 将动作添加到动作系统队列中执行
                ActionSystem.Instance.AddReaction(perkEffectAction);
            }
        }
    }
}