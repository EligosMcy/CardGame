using UnityEngine;

namespace General.ActionSystemComponents.UITest
{
    public class PlayModeView : MonoBehaviour
    {
        [SerializeField] private PlayView playView;

        private PlayEntity playEntity;

        private void Awake()
        {
            playEntity = new PlayEntity(80, 5, 0, 3, 99);
        }

        private void Start()
        {
            UpdateView();
        }

        public void TakeDamage(int damage)
        {
            int remainingDamage = damage;

            if (playEntity.Armor > 0)
            {
                if (playEntity.Armor >= remainingDamage)
                {
                    playEntity.Armor -= remainingDamage;
                    remainingDamage = 0;
                }
                else
                {
                    remainingDamage -= playEntity.Armor;
                    playEntity.Armor = 0;
                }
            }

            playEntity.Health -= remainingDamage;
            
            if (playEntity.Health < 0)
            {
                playEntity.Health = 0;
            }

            UpdateView();
        }

        public void Heal(int amount)
        {
            playEntity.Health += amount;
            
            if (playEntity.Health > playEntity.MaxHealth)
            {
                playEntity.Health = playEntity.MaxHealth;
            }

            UpdateView();
        }

        public void AddArmor(int amount)
        {
            playEntity.Armor += amount;
            UpdateView();
        }

        public void IncreaseAttack(int amount)
        {
            playEntity.AttackPower += amount;
            UpdateView();
        }

        public void AddEnergy(int amount)
        {
            playEntity.Energy += amount;
            UpdateView();
        }

        public void SpendEnergy(int amount)
        {
            if (playEntity.Energy >= amount)
            {
                playEntity.Energy -= amount;
                UpdateView();
            }
        }

        public void AddGold(int amount)
        {
            playEntity.Gold += amount;
            UpdateView();
        }

        public void SpendGold(int amount)
        {
            if (playEntity.Gold >= amount)
            {
                playEntity.Gold -= amount;
                UpdateView();
            }
        }

        public void ResetEnergy(int amount)
        {
            playEntity.Energy = amount;
            UpdateView();
        }

        public void ClearArmor()
        {
            playEntity.Armor = 0;
            UpdateView();
        }

        private void UpdateView()
        {
            playView.UpdateHealth(playEntity.Health, playEntity.MaxHealth);
            playView.UpdateAttackPower(playEntity.AttackPower);
            playView.UpdateArmor(playEntity.Armor);
            playView.UpdateEnergy(playEntity.Energy);
            playView.UpdateGold(playEntity.Gold);
        }
    }
}