using System.Collections.Generic;
using Models;
using Systems;
using UnityEngine;
using Views;

namespace TargetModels
{
    public class RandomEnemyTM : TargetMode
    {
        public override List<CombatantView> GetTargets()
        {
            int enemiesCount = EnemySystem.Instance.Enemies.Count;

            List<CombatantView> returnList = null;

            if (enemiesCount > 0)
            {
                int randomIndex = Random.Range(0, enemiesCount);

                CombatantView combatantView = EnemySystem.Instance.Enemies[randomIndex];

                returnList = new List<CombatantView>() { combatantView };
            }

            return returnList;
        }
    }
}