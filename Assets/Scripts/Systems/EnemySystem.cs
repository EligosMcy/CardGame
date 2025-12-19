using System.Collections;
using GameActions;
using General.ActionSystemComponents;
using UnityEngine;

namespace Systems
{
    public class EnemySystem : MonoBehaviour
    {
        private void OnEnable()
        {
            ActionSystem.AttachPerformer<EnemyTurnGA>(enemyTurnPerformer);
        }

        private void OnDisable()
        {
            ActionSystem.DetachPerformer<EnemyTurnGA>();
        }


        private IEnumerator enemyTurnPerformer(EnemyTurnGA enemyTurnGa)
        {
            Debug.Log("Enemy Turn");

            yield return new WaitForSeconds(2f);

            Debug.Log("End Enemy Turn");
        }

    }
}