using System;
using GameActions;
using General.ActionSystemComponents;
using General.Util;
using Models;
using Systems;
using TMPro;
using UnityEngine;

namespace Views
{
    public class CardView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _title;

        [SerializeField] private TMP_Text _description;

        [SerializeField] private TMP_Text _mana;

        [SerializeField] private SpriteRenderer _imageSr;

        [SerializeField] private GameObject _wrapper;

        [SerializeField] private LayerMask _dropAreaLayerMask;

        public Card Card { get; private set; }

        private readonly float _cardHoverPosY = -2f;

        private Vector3 _dragStartPosition;

        private Quaternion _dragStartRotation;

        public void Setup(Card card)
        {
            Card = card;

            _title.text = card.Title;

            _description.text = card.Description;

            _mana.text = card.Mana.ToString();

            _imageSr.sprite = card.Image;
        }



        private void OnMouseEnter()
        {
            if (!Interactions.Instance.PlayerCanHover()) return;

            _wrapper.SetActive(false);

            Vector3 hoverPos = new Vector3(transform.position.x, _cardHoverPosY, 0);

            CardViewHoverSystem.Instance.Show(Card, hoverPos);
        }

        private void OnMouseExit()
        {
            if (!Interactions.Instance.PlayerCanHover()) return;

            CardViewHoverSystem.Instance.Hide();

            _wrapper.SetActive(true);
        }

        private void OnMouseDown()
        {
            if (!Interactions.Instance.PlayerCanInteract()) return;

            if (Card.ManualTargetEffect != null)
            {
                ManualTargetSystem.Instance.StartTargeting(transform.position);
            }
            else
            {
                Interactions.Instance.PlayerIsDragging = true;

                _wrapper.SetActive(true);

                CardViewHoverSystem.Instance.Hide();

                _dragStartPosition = transform.position;

                _dragStartRotation = transform.rotation;

                transform.rotation = Quaternion.Euler(Vector3.zero);

                transform.position = MouseUtil.GetMousePositionInWorldSpace(-1);
            }
        }

        public void OnMouseDrag()
        {
            if (!Interactions.Instance.PlayerCanInteract()) return;

            if (Card.ManualTargetEffect != null)
            {
                return;
            }

            transform.position = MouseUtil.GetMousePositionInWorldSpace(-1);
        }

        private void OnMouseUp()
        {
            if (!Interactions.Instance.PlayerCanInteract()) return;

            if (Card.ManualTargetEffect != null)
            {
                EnemyView target =
                    ManualTargetSystem.Instance.EndTargeting(MouseUtil.GetMousePositionInWorldSpace(-1f));

                if (target != null && ManaSystem.Instance.HasEnoughMana(Card.Mana))
                {
                    PlayCardGA playCardGa = new PlayCardGA(Card, target);

                    ActionSystem.Instance.Perform(playCardGa);
                }
            }
            else
            {
                if (ManaSystem.Instance.HasEnoughMana(Card.Mana) && Physics.Raycast(transform.position, Vector3.forward, out RaycastHit hit, 10f, _dropAreaLayerMask))
                {
                    PlayCardGA playCardGa = new PlayCardGA(Card);

                    ActionSystem.Instance.Perform(playCardGa);
                }
                else
                {
                    transform.position = _dragStartPosition;
                    transform.rotation = _dragStartRotation;
                }

                Interactions.Instance.PlayerIsDragging = false;
            }
        }
    }

}
