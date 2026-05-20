using Data;
using Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PerkButton : MonoBehaviour
    {
        [SerializeField] private Image _iconImage;
        [SerializeField] private Button _actionButton;
        [SerializeField] private TextMeshProUGUI _nameText;
        [SerializeField] private TextMeshProUGUI _actionText;

        private PerkData _perkData;
        private bool _isAdded;
        private System.Action<PerkData> _onAddCallback;
        private System.Action<PerkData> _onRemoveCallback;

        public void Setup(PerkData perkData, System.Action<PerkData> onAdd, System.Action<PerkData> onRemove)
        {
            _perkData = perkData;
            _onAddCallback = onAdd;
            _onRemoveCallback = onRemove;

            _iconImage.sprite = perkData.Image;
            _nameText.text = perkData.PerkStr;

            _actionButton.onClick.RemoveAllListeners();
            _actionButton.onClick.AddListener(OnActionClicked);
        }

        public void ChangeAddBool(bool isAdded)
        {
            _isAdded = isAdded;
            _actionText.text = isAdded ? "Remove" : "Add";
        }

        private void OnActionClicked()
        {
            if (_isAdded)
            {
                _onRemoveCallback?.Invoke(_perkData);
            }
            else
            {
                _onAddCallback?.Invoke(_perkData);
            }
        }
    }
}