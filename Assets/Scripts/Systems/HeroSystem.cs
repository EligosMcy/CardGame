using Data;
using General;
using UnityEngine;
using Views;

namespace Systems
{
    public class HeroSystem : Singleton<HeroSystem>
    {
        [field: SerializeField] public HeroView HeroView { get; private set; }

        public void Setup(HeroData heroData)
        {
            HeroView.Setup(heroData);
        }
    }
}