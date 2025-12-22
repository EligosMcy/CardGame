using System.Collections;
using System.Collections.Generic;
using Data;
using GameActions;
using General;
using General.ActionSystemComponents;
using UnityEngine;
using Views;

namespace Systems
{
    public class EnemySystem : Singleton<EnemySystem>
    {
        [SerializeField]
        private EnemyBoardView _enemyBoardView;

        private void OnEnable()
        {
            ActionSystem.AttachPerformer<EnemyTurnGA>(enemyTurnPerformer);
        }

        private void OnDisable()
        {
            ActionSystem.DetachPerformer<EnemyTurnGA>();
        }

        public void Setup(List<EnemyData> enemyDataList)
        {
            foreach (EnemyData enemyData in enemyDataList)
            {
                _enemyBoardView.AddEnemy(enemyData);
            }
        }

        private IEnumerator enemyTurnPerformer(EnemyTurnGA enemyTurnGa)
        {
            Debug.Log("Enemy Turn");

            yield return new WaitForSeconds(2f);

            Debug.Log("End Enemy Turn");
        }

    }
}