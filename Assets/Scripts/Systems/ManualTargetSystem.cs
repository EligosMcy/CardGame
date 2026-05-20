using General;
using UnityEngine;
using Views;

namespace Systems
{
    /// <summary>
    /// 手动目标系统 - 处理需要玩家手动选择目标的卡牌
    /// 显示瞄准箭头，管理目标选择过程
    /// </summary>
    public class ManualTargetSystem : Singleton<ManualTargetSystem>
    {
        [SerializeField] private ArrowView _arrowView;

        [SerializeField] private LayerMask _targetLayerMask;

        public void StartTargeting(Vector3 startPosition)
        {
            _arrowView.gameObject.SetActive(true);

            _arrowView.SetupArrow(startPosition);
        }


        public EnemyView EndTargeting(Vector3 endPosition)
        {
            _arrowView.gameObject.SetActive(false);

            if (Physics.Raycast(endPosition, Vector3.forward, out RaycastHit hit, 10f, _targetLayerMask)
                && hit.collider != null
                && hit.transform.TryGetComponent(out EnemyView enemyView))
            {
                return enemyView;
            }

            return null;
        }
    }
}