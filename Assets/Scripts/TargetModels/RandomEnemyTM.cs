using System.Collections.Generic;
using Models;
using Systems;
using UnityEngine;
using Views;

namespace TargetModels
{
    /// <summary>
    /// 随机敌人目标模式 - 随机返回一个敌人
    /// 用于随机目标攻击类卡牌
    /// </summary>
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