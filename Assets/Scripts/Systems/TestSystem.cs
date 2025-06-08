using System;
using Assets.Scripts.Views;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Systems
{
    public class TestSystem : MonoBehaviour
    {
        [SerializeField] private HandView _handView;

        [SerializeField] private InputActionProperty _creatorCardViewInputaction;

        private void Start()
        {
            _creatorCardViewInputaction.action.Enable();

            _creatorCardViewInputaction.action.performed += creatorCardView;
        }

        private void creatorCardView(InputAction.CallbackContext obj)
        {
            CardView cardView = CardViewCreator.Instance.CreateCardView(transform.position, Quaternion.identity);
            StartCoroutine(_handView.AddCard(cardView));
        }
    }
}
