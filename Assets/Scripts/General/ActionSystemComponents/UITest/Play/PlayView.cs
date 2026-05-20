using TMPro;
using UnityEngine;

namespace General.ActionSystemComponents.UITest
{
    public class PlayView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI healthText;
        [SerializeField] private TextMeshProUGUI attackPowerText;
        [SerializeField] private TextMeshProUGUI armorText;
        [SerializeField] private TextMeshProUGUI energyText;
        [SerializeField] private TextMeshProUGUI goldText;

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

        public void UpdateEnergy(int energy)
        {
            energyText.text = $"ENERGY: {energy}";
        }

        public void UpdateGold(int gold)
        {
            goldText.text = $"GOLD: {gold}";
        }
    }
}