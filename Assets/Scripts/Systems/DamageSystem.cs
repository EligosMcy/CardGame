using System;
using System.Collections;
using GameActions;
using General;
using General.ActionSystemComponents;
using UnityEngine;
using Views;

namespace Systems
{
    /// <summary>
    /// 伤害系统 - 处理对目标的伤害施加
    /// 应用伤害数值、播放受伤特效、检测目标死亡并触发击杀事件
    /// </summary>
    public class DamageSystem : Singleton<DamageSystem>
    {
        [SerializeField] private GameObject _damageVFX;

        private void OnEnable()
        {
            ActionSystem.AttachPerformer<DealDamageGA>(dealDamagePerformer);
        }


        private void OnDisable()
        {
            ActionSystem.DetachPerformer<DealDamageGA>();
        }

        private IEnumerator dealDamagePerformer(DealDamageGA dealDamageGa)
        {
            foreach (CombatantView combatantView in dealDamageGa.Targets)
            {
                combatantView.Damage(dealDamageGa.Amount);
                Transform targetTran = combatantView.transform;
                Instantiate(_damageVFX, targetTran.position, targetTran.rotation);

                yield return new WaitForSeconds(0.15f);

                if (combatantView.CurrentHealth <= 0)
                {
                    if (combatantView is EnemyView enemyView)
                    {
                        KillEnemyGA killEnemyGa = new KillEnemyGA(enemyView);
                        ActionSystem.Instance.AddReaction(killEnemyGa);
                    }
                }
                else
                {
                    // Do some game over logic here
                    // Open game other scene
                }
            }

            yield return 0;
        }

    }
}