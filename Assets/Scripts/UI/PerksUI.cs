using System.Collections.Generic;
using Models;
using UnityEngine;
using System.Linq;
namespace UI
{
    public class PerksUI : MonoBehaviour
    {
        [SerializeField] private PerkUI _perkUIPrefab;

        private readonly List<PerkUI> perkUis = new List<PerkUI>();

        public void AddPerkUI(Perk perk)
        {
            PerkUI perkUI = Instantiate(_perkUIPrefab, transform);

            perkUI.Setup(perk);

            perkUis.Add(perkUI);
        }

        public void RemovePerkUI(Perk perk)
        {
            PerkUI perkUI = perkUis.FirstOrDefault(pui => pui.Perk == perk);

            if (perkUI != null)
            {
                perkUis.Remove(perkUI);
                Destroy(perkUI.gameObject);
            }
        }
    }
}