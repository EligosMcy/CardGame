using System.Collections;
using System.Collections.Generic;
using Data;
using DG.Tweening;
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

            ActionSystem.AttachPerformer<AttackHeroGA>(AttackHeroPerformer);
        }

        private void OnDisable()
        {
            ActionSystem.DetachPerformer<EnemyTurnGA>();

            ActionSystem.DetachPerformer<AttackHeroGA>();
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
            foreach (EnemyView enemyView in _enemyBoardView.EnemyViews)
            {
                AttackHeroGA attackHeroGa = new AttackHeroGA(enemyView);

                ActionSystem.Instance.AddReaction(attackHeroGa);
            }

            yield return 0;
        }

        private IEnumerator AttackHeroPerformer(AttackHeroGA attackHeroGa)
        {
            EnemyView attacker = attackHeroGa.Attacker;

            Transform attackerTran = attacker.transform;

            Tween tween = attacker.transform.DOMoveX(attackerTran.position.x - 1f, 0.15f);

            yield return tween.WaitForCompletion();

            attacker.transform.DOMoveX(attackerTran.position.x + 1, 0.25f);

            yield return 0;

            //Deal Damage

            CombatantView heroCombatantView = HeroSystem.Instance.HeroView;

            DealDamageGA dealDamageGa = new DealDamageGA(attacker.AttackPower, new List<CombatantView>() { heroCombatantView });

            ActionSystem.Instance.AddReaction(dealDamageGa);
        }

    }
}