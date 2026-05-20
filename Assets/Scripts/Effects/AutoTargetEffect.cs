using System;
using Models;
using SerializeReferenceEditor;
using UnityEngine;

namespace Effects
{
    /// <summary>
    /// 自动目标效果包装器 - 将目标模式和效果组合在一起
    /// 用于不需要手动选择目标的卡牌效果
    /// </summary>
    [Serializable]
    public class AutoTargetEffect
    {
        [field: SerializeReference,SR] public TargetMode TargetMode { get; private set; }
        [field: SerializeReference,SR] public Effect Effect { get; private set; }
    }
}