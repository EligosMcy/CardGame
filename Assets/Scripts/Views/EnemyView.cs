using Data;
using TMPro;
using UnityEngine;

namespace Views
{
    public class EnemyView : CombatantView
    {
        [SerializeField] private TextMeshPro _attackText;

        public int AttackPower { get; set; }

        public void Setup(EnemyData enemyData)
        {
            AttackPower = enemyData.AttackPower;

            updateAttackText();

            SetupBase(enemyData.Health, enemyData.Image);
        }

        private void updateAttackText()
        {
            _attackText.text = "ATK: " + AttackPower;
        }
    }
}