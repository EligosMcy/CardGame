using System.Collections.Generic;
using General;
using Models;
using UI;
using UnityEngine;

namespace Systems
{
    /// <summary>
    /// 特权系统 - 管理玩家的特权/技能/遗物
    /// 
    /// 职责：
    /// 1. 管理特权的添加和移除
    /// 2. 同步更新UI显示
    /// 3. 调用特权的生命周期方法
    /// 
    /// 使用示例：
    /// ```csharp
    /// // 创建特权并添加
    /// Perk perk = new Perk(perkData);
    /// PerkSystem.Instance.AddPerk(perk);
    /// 
    /// // 移除特权
    /// PerkSystem.Instance.RemovePerk(perk);
    /// ```
    /// </summary>
    public class PerkSystem : Singleton<PerkSystem>
    {
        /// <summary>
        /// 特权UI组件 - 用于显示玩家当前拥有的特权
        /// </summary>
        [SerializeField] private PerksUI _perksUI;

        /// <summary>
        /// 当前激活的特权列表
        /// </summary>
        private readonly List<Perk> _perks = new List<Perk>();

        /// <summary>
        /// 添加特权到玩家身上
        /// </summary>
        /// <param name="perk">要添加的特权实例</param>
        public void AddPerk(Perk perk)
        {
            // 1. 添加到内部列表
            _perks.Add(perk);
            
            // 2. 更新UI显示
            _perksUI.AddPerkUI(perk);
            
            // 3. 调用特权的OnAdd方法，开始监听事件
            perk.OnAdd();
        }

        /// <summary>
        /// 从玩家身上移除特权
        /// </summary>
        /// <param name="perk">要移除的特权实例</param>
        public void RemovePerk(Perk perk)
        {
            // 1. 从内部列表移除
            _perks.Remove(perk);
            
            // 2. 更新UI显示
            _perksUI.RemovePerkUI(perk);
            
            // 3. 调用特权的OnRemove方法，停止监听事件
            perk.OnRemove();
        }
    }
}