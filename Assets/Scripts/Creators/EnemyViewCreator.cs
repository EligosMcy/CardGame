using Data;
using General;
using UnityEngine;
using Views;

namespace Creators
{
    /// <summary>
    /// 敌人视图创建器 - 管理敌人UI的实例化
    /// 根据敌人数据创建对应的敌人视图
    /// </summary>
    public class EnemyViewCreator : Singleton<EnemyViewCreator>
    {
        [SerializeField] private EnemyView _enemyViewPrefab;

        public EnemyView CreateEnemyView(EnemyData enemyData, Vector3 position, Quaternion rotation)
        {
            EnemyView enemyView = Instantiate(_enemyViewPrefab, position, rotation);

            enemyView.Setup(enemyData);

            return enemyView;
        }
    }
}