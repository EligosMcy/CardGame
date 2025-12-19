using Data;
using System.Collections.Generic;
using GameActions;
using General.ActionSystemComponents;
using UnityEngine;

namespace Systems
{
    public class MatchSetupSystem : MonoBehaviour
    {
        [SerializeField] private List<CardData> _deckData;

        private void Start()
        {
            CardSystem.Instance.Setup(_deckData);

            RefillManaGA refillManaGa = new RefillManaGA();

            ActionSystem.Instance.Perform(refillManaGa, () =>
            {
                DrawCardsGA drawCardsGa = new DrawCardsGA(5);

                ActionSystem.Instance.Perform(drawCardsGa);
            });
        }
    }
}