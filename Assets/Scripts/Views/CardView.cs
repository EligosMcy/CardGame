using TMPro;
using UnityEngine;

namespace Assets.Scripts.Views
{
    public class CardView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _title;

        [SerializeField] private TMP_Text _description;

        [SerializeField] private TMP_Text _mana;

        [SerializeField] private SpriteRenderer _imageSr;

        [SerializeField] private GameObject _wrapper;
    }
}
