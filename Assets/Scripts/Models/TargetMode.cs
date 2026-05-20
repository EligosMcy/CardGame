using System;
using System.Collections.Generic;
using Views;

namespace Models
{
    /// <summary>
    /// 目标模式基类 - 定义如何选择卡牌/效果的目标
    /// 派生类实现GetTargets方法返回目标列表
    /// </summary>
    [Serializable]
    public abstract class TargetMode
    {
        public abstract List<CombatantView> GetTargets();
    }
}