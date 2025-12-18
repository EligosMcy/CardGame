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

        public Card Card { get; private set; }

        public void Setup(Card card)
        {
            Card = card;

            _title.text = card.Title;

            _description.text = card.Description;

            _mana.text = card.Mana.ToString();

            _imageSr.sprite = card.Image;
        }


        private readonly float _cardHoverPosY = -2f;

        private void OnMouseEnter()
        {
            _wrapper.SetActive(false);

            Vector3 hoverPos = new Vector3(transform.position.x, _cardHoverPosY, 0);

            CardViewHoverSystem.Instance.Show(Card, hoverPos);
        }

        private void OnMouseExit()
        {
            CardViewHoverSystem.Instance.Hide();

            _wrapper.SetActive(true);
        }
    }
}
