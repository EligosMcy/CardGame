using Data;
using UnityEngine;

namespace Views
{
    public class HeroView : CombatantView
    {
        public void Setup(HeroData heroData)
        {
            SetupBase(heroData.Health, heroData.Image);
        }
    }
}