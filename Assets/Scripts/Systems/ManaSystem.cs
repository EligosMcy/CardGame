using System;
using System.Collections;
using GameActions;
using General;
using General.ActionSystemComponents;
using UI;
using UnityEngine;

namespace Systems
{
    public class ManaSystem : Singleton<ManaSystem>
    {
        [SerializeField] private ManaUI _manaUI;

        private const int MAX_MANA = 10;

        private int _currentMana = MAX_MANA;

        private void Start()
        {
            _currentMana = MAX_MANA;

            _manaUI.UpdateManaText(_currentMana);
        }

        private void OnEnable()
        {
            ActionSystem.AttachPerformer<SpendManaGA>(spendManaPerformer);
            ActionSystem.AttachPerformer<RefillManaGA>(refillManaPerformer);

            ActionSystem.SubscribeReaction<EnemyTurnGA>(enemyTurnPostReaction, ReactionTiming.POST);
        }

        private void OnDisable()
        {
            ActionSystem.DetachPerformer<SpendManaGA>();
            ActionSystem.DetachPerformer<RefillManaGA>();

            ActionSystem.UnsubscribeReaction<EnemyTurnGA>(enemyTurnPostReaction, ReactionTiming.POST);
        }

        public bool HasEnoughMana(int mana)
        {
            return _currentMana >= mana;
        }

        private IEnumerator refillManaPerformer(RefillManaGA refillManaGa)
        {
            _currentMana = MAX_MANA;

            _manaUI.UpdateManaText(_currentMana);

            yield return 0;
        }

        private IEnumerator spendManaPerformer(SpendManaGA spendManaGa)
        {
            _currentMana -= spendManaGa.Amount;

            _manaUI.UpdateManaText(_currentMana);

            yield return 0;
        }

        private void enemyTurnPostReaction(EnemyTurnGA enemyTurnGa)
        {
            RefillManaGA refillManaGa = new RefillManaGA();

            ActionSystem.Instance.AddReaction(refillManaGa);
        }
    }
}