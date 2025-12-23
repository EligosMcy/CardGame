using System.Collections;
using Creators;
using Data;
using System.Collections.Generic;
using DG.Tweening;
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

        public IEnumerator RemoveEnemy(EnemyView enemyView)
        {
            EnemyViews.Remove(enemyView);

            Tween tween = enemyView.transform.DOScale(Vector3.zero, 0.25f);

            yield return tween.WaitForCompletion();

            Destroy(enemyView.gameObject);
        }

    }
}