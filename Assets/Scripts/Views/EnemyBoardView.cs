using Creators;
using Data;
using System.Collections.Generic;
using UnityEngine;

namespace Views
{
    public class EnemyBoardView : MonoBehaviour
    {
        [SerializeField] private List<Transform> _slots;

        public List<EnemyView> EnemyViews { get; private set; } = new List<EnemyView>();

        public void AddEnemy(EnemyData enemyData)
        {
            Transform slot = _slots[EnemyViews.Count];

            EnemyView enemyView = EnemyViewCreator.Instance.CreateEnemyView(enemyData, slot.position, slot.rotation);

            enemyView.transform.SetParent(slot);

            EnemyViews.Add(enemyView);
        }


        public void RemoveEnemy(EnemyData enemyData)
        {
            Transform slot = _slots[EnemyViews.Count];

            EnemyView enemyView = EnemyViewCreator.Instance.CreateEnemyView(enemyData, slot.position, slot.rotation);

            enemyView.transform.SetParent(slot);

            EnemyViews.Add(enemyView);
        }

    }
}