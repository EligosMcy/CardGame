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

        public List<EnemyView> Enemies => _enemyBoardView.EnemyViews;

        private void OnEnable()
        {
            ActionSystem.AttachPerformer<EnemyTurnGA>(enemyTurnPerformer);

            ActionSystem.AttachPerformer<AttackHeroGA>(attackHeroPerformer);

            ActionSystem.AttachPerformer<KillEnemyGA>(killEnemyPerformer);
        }

        private void OnDisable()
        {
            ActionSystem.DetachPerformer<EnemyTurnGA>();

            ActionSystem.DetachPerformer<AttackHeroGA>();

            ActionSystem.DetachPerformer<KillEnemyGA>();
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

        private IEnumerator attackHeroPerformer(AttackHeroGA attackHeroGa)
        {
            EnemyView attacker = attackHeroGa.Attacker;

            Transform attackerTran = attacker.transform;

            Tween tween = attacker.transform.DOMoveX(attackerTran.position.x - 1f, 0.15f);

            yield return tween.WaitForCompletion();

            attacker.transform.DOMoveX(attackerTran.position.x + 1, 0.25f);

            yield return 0;

            //Deal Damage

            CombatantView heroCombatantView = HeroSystem.Instance.HeroView;

            DealDamageGA dealDamageGa = new DealDamageGA(attacker.AttackPower, new List<CombatantView>() { heroCombatantView }, attackHeroGa.Caster);

            ActionSystem.Instance.AddReaction(dealDamageGa);
        }

        private IEnumerator killEnemyPerformer(KillEnemyGA killEnemyGa)
        {
            yield return _enemyBoardView.RemoveEnemy(killEnemyGa.EnemyView);
        }

    }
}