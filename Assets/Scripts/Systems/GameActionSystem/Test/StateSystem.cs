using System.Collections;
using UnityEngine;

namespace Systems.GameActionSystem.Test
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