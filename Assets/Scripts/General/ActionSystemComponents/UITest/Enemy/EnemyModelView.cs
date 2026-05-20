using UnityEngine;

namespace General.ActionSystemComponents.UITest
{
    public class EnemyModelView : MonoBehaviour
    {
        [SerializeField] private EnemyView enemyView;

        private EnemyEntity enemyEntity;

        private void Awake()
        {
            enemyEntity = new EnemyEntity(20, 3, 1);
        }

        private void Start()
        {
            UpdateView();
        }

        public void TakeDamage(int damage)
        {
            int remainingDamage = damage;

            if (enemyEntity.Armor > 0)
            {
                if (enemyEntity.Armor >= remainingDamage)
                {
                    enemyEntity.Armor -= remainingDamage;
                    remainingDamage = 0;
                }
                else
                {
                    remainingDamage -= enemyEntity.Armor;
                    enemyEntity.Armor = 0;
                }
            }

            enemyEntity.Health -= remainingDamage;
            
            if (enemyEntity.Health < 0)
            {
                enemyEntity.Health = 0;
            }

            UpdateView();
        }

        public void Heal(int amount)
        {
            enemyEntity.Health += amount;
            
            if (enemyEntity.Health > enemyEntity.MaxHealth)
            {
                enemyEntity.Health = enemyEntity.MaxHealth;
            }

            UpdateView();
        }

        public void AddArmor(int amount)
        {
            enemyEntity.Armor += amount;
            UpdateView();
        }

        public void IncreaseAttack(int amount)
        {
            enemyEntity.AttackPower += amount;
            UpdateView();
        }

        private void UpdateView()
        {
            enemyView.UpdateHealth(enemyEntity.Health, enemyEntity.MaxHealth);
            enemyView.UpdateAttackPower(enemyEntity.AttackPower);
            enemyView.UpdateArmor(enemyEntity.Armor);
        }
    }
}