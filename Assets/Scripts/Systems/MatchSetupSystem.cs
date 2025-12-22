using Data;
using GameActions;
using General.ActionSystemComponents;
using System.Collections.Generic;
using UnityEngine;

namespace Systems
{
    public class MatchSetupSystem : MonoBehaviour
    {
        [SerializeField] private HeroData _heroData;

        [SerializeField] private List<EnemyData> _enemyDataList;

        private void Start()
        {
            HeroSystem.Instance.Setup(_heroData);

            EnemySystem.Instance.Setup(_enemyDataList);

            CardSystem.Instance.Setup(_heroData.Deck);

            RefillManaGA refillManaGa = new RefillManaGA();

            ActionSystem.Instance.Perform(refillManaGa, () =>
            {
                DrawCardsGA drawCardsGa = new DrawCardsGA(5);

                ActionSystem.Instance.Perform(drawCardsGa);
            });
        }
    }
}