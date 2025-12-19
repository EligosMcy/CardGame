using General;
using General.ActionSystemComponents;
using UnityEngine;

namespace Systems
{
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