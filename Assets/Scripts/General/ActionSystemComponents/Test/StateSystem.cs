using System.Collections;
using General.ActionSystemComponents.Test.GameActaionClass;
using UnityEngine;

namespace General.ActionSystemComponents.Test
{
    public class StateSystem : MonoBehaviour
    {
        void OnEnable()
        {
            ActionSystem.AttachPerformer<IncreaseStatsGA>(increaseStatsPerformer);
        }

        void OnDisable()
        {
            ActionSystem.DetachPerformer<IncreaseStatsGA>();

        }

        private IEnumerator increaseStatsPerformer(IncreaseStatsGA increaseStatsGa)
        {
            int attack = increaseStatsGa.AttackIncreaseAmount;
            int health  = increaseStatsGa.HealthIncreaseAmount;
            yield return increaseStatsGa.Target.IncreaseAttackAndHealth(attack, health);
        }
    }
}