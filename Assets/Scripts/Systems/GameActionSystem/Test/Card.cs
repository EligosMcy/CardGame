using System;
using Systems.GameActionSystem.Test.GameActaionClass;
using UnityEngine;

namespace Systems.GameActionSystem.Test
{
    public class Card : MonoBehaviour
    {
        private void OnMouseDown()
        {
            if (ActionSystem.Instance.IsPerforming)
            {
                return;
            }

            DrawCardGA drawCardGa = new DrawCardGA();

            ActionSystem.Instance.Perform(drawCardGa);

            Destroy(gameObject);
        }
    }
}