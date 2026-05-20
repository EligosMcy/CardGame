using General;
using General.ActionSystemComponents;
using UnityEngine;

namespace Systems
{
    /// <summary>
    /// 交互系统 - 管理玩家是否可以与UI进行交互
    /// 控制拖拽状态和交互锁定，防止在特定情况下误操作
    /// </summary>
    public class Interactions : Singleton<Interactions>
    {
        public bool PlayerIsDragging { get; set; } = false;

        public bool PlayerCanInteract()
        {
            return !ActionSystem.Instance.IsPerforming;
        }

        public bool PlayerCanHover()
        {
            return !PlayerIsDragging;
        }
    }
}