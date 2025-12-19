using System;
using GameActions;
using General.ActionSystemComponents;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class EndTurnButtonUI : MonoBehaviour
    {
        private Button _button;

        private void Awake()
        {
            _button = transform.GetComponent<Button>();

            _button.onClick.AddListener(onClick);
        }

        private void onClick()
        {
            EnemyTurnGA enemyTurnGa = new EnemyTurnGA();

            ActionSystem.Instance.Perform(enemyTurnGa);
        }
    }
}
