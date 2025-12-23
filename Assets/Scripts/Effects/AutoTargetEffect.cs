using System;
using Models;
using SerializeReferenceEditor;
using UnityEngine;

namespace Effects
{
    [Serializable]
    public class AutoTargetEffect
    {
        [field: SerializeReference,SR] public TargetMode TargetMode { get; private set; }
        [field: SerializeReference,SR] public Effect Effect { get; private set; }
    }
}