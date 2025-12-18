using System;
using Creators;
using Data;
using Models;
using UnityEngine;
using UnityEngine.InputSystem;
using Views;

namespace Systems
{
    public class TestSystem : MonoBehaviour
    {
        [SerializeField] private HandView _handView;

        [SerializeField] private CardData _testCardData;

        [SerializeField] private InputActionProperty _creatorCardViewInputAction;

        private void Start()
        {
            _creatorCardViewInputAction.action.Enable();

            _creatorCardViewInputAction.action.performed += creatorCardView;
        }

        private void creatorCardView(InputAction.CallbackContext obj)
        {
            Card card = new Card(_testCardData);

            CardView cardView = CardViewCreator.Instance.CreateCardView(card, transform.position, Quaternion.identity);
            StartCoroutine(_handView.AddCard(cardView));
        }
    }
}
