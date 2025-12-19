using TMPro;
using UnityEngine;

namespace UI
{
    public class ManaUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _manaText;

        public void UpdateManaText(int currentMana)
        {
            _manaText.text = currentMana.ToString();
        }
    }
}