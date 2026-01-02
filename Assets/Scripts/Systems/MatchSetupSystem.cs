using Data;
using GameActions;
using General.ActionSystemComponents;
using System.Collections.Generic;
using Models;
using UnityEngine;

namespace Systems
{
    public class MatchSetupSystem : MonoBehaviour
    {
        [SerializeField] private HeroData _heroData;

        [SerializeField] private PerkData _perkData;

        [SerializeField] private List<EnemyData> _enemyDataList;

        private void Start()
        {
            HeroSystem.Instance.Setup(_heroData);

            EnemySystem.Instance.Setup(_enemyDataList);

            CardSystem.Instance.Setup(_heroData.Deck);


            //
            Perk perk = new Perk(_perkData);

            PerkSystem.Instance.AddPerk(perk);


            //
            DrawCardsGA drawCardsGa = new DrawCardsGA(5);

            ActionSystem.Instance.Perform(drawCardsGa);
        }
    }
}