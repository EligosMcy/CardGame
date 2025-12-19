using General.ActionSystemComponents.Test.GameActaionClass;
using UnityEngine;

namespace General.ActionSystemComponents.Test
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