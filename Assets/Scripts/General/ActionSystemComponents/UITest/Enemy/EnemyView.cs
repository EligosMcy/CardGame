using TMPro;
using UnityEngine;

namespace General.ActionSystemComponents.UITest
{
    public class EnemyView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI healthText;
        [SerializeField] private TextMeshProUGUI attackPowerText;
        [SerializeField] private TextMeshProUGUI armorText;

        public void UpdateHealth(int currentHealth, int maxHealth)
        {
            healthText.text = $"HP: {currentHealth}/{maxHealth}";
        }

        public void UpdateAttackPower(int attackPower)
        {
            attackPowerText.text = $"ATK: {attackPower}";
        }

        public void UpdateArmor(int armor)
        {
            armorText.text = $"ARMOR: {armor}";
        }
    }
}