using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class StatusEffectUI : MonoBehaviour
    {
        [SerializeField]
        private Image _image;

        [SerializeField]
        private TextMeshProUGUI _stackCountText;

        public void Set(Sprite sprite, int stackCount)
        {
            _image.sprite = sprite;
            _stackCountText.text = stackCount.ToString();
        }

    }
}