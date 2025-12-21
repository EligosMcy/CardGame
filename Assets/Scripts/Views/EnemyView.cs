using TMPro;
using UnityEngine;

namespace Views
{
    public class EnemyView : CombatantView
    {
        [SerializeField] private TextMeshPro _attackText;

        public int AttackPower { get; set; }

        public void Setup()
        {
            AttackPower = 10;

            updateAttackText();

            SetupBase(10, null);
        }

        private void updateAttackText()
        {
            _attackText.text = "ATK: " + AttackPower;
        }
    }
}