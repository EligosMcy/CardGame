using System;
using General.ActionSystemComponents;
using UnityEngine;

namespace Models
{
    /// <summary>
    /// 特权条件基类 - 定义特权触发的条件机制
    /// 
    /// 设计思路：
    /// - 这是一个抽象基类，所有具体的触发条件都继承自它
    /// - 使用观察者模式，订阅特定的游戏动作（GameAction）
    /// - 当特定动作发生时，检查条件是否满足，满足则触发特权效果
    /// 
    /// 派生类需要实现的三个方法：
    /// 1. SubscribeCondition(): 订阅游戏事件
    /// 2. UnSubscribeCondition(): 取消订阅
    /// 3. SunConditionIsMet(): 判断条件是否满足
    /// </summary>
    public abstract class PerkCondition
    {
        /// <summary>
        /// 反应时机 - 决定在动作执行的哪个阶段触发
        /// 可选值：Before（动作前）、After（动作后）
        /// </summary>
        [SerializeField]
        protected ReactionTiming ReactionTiming;

        /// <summary>
        /// 订阅条件 - 注册对特定游戏动作的监听
        /// </summary>
        /// <param name="reaction">条件满足时要执行的回调方法</param>
        public abstract void SubscribeCondition(Action<GameAction> reaction);

        /// <summary>
        /// 取消订阅 - 停止监听特定游戏动作
        /// </summary>
        /// <param name="reaction">要取消的回调方法</param>
        public abstract void UnSubscribeCondition(Action<GameAction> reaction);

        /// <summary>
        /// 判断条件是否满足
        /// 可以在订阅的动作发生后，进行额外的条件检查
        /// </summary>
        /// <param name="gameAction">触发的游戏动作</param>
        /// <returns>条件是否满足</returns>
        public abstract bool SunConditionIsMet(GameAction gameAction);
    }
}