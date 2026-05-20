using System.Collections.Generic;
using Data;
using Models;
using Systems;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PerkChangeButtonsUI : MonoBehaviour
    {
        [SerializeField] private PerkButton _perkButtonPrefab;
        [SerializeField] private Transform _container;
        [SerializeField] private List<PerkData> _perkList;

        private Dictionary<string, PerkButton> _perkButtons = new Dictionary<string, PerkButton>();

        private void Start()
        {
            CreatePerkButtons();
        }

        private void CreatePerkButtons()
        {
            foreach (PerkData perkData in _perkList)
            {
                PerkButton button = Instantiate(_perkButtonPrefab, _container);
                button.Setup(perkData, OnAddClicked, OnRemoveClicked);
                UpdateButtonAdded(button, perkData);
                _perkButtons.Add(perkData.PerkStr, button);
            }
        }

        private void UpdateButtonAdded(PerkButton button, PerkData perkData)
        {
            bool isAdded = PerkSystem.Instance.Perks.Exists(p => p.PerkStr == perkData.PerkStr);
            button.ChangeAddBool(isAdded);
        }

        private void OnAddClicked(PerkData perkData)
        {
            Perk perk = new Perk(perkData);
            PerkSystem.Instance.AddPerk(perk);

            UpdateButtonAdded(_perkButtons[perkData.PerkStr], perkData);
        }

        private void OnRemoveClicked(PerkData perkData)
        {
            Perk perk = PerkSystem.Instance.Perks.Find(p => p.PerkStr == perkData.PerkStr);

            if (perk != null)
            {
                PerkSystem.Instance.RemovePerk(perk);
                UpdateButtonAdded(_perkButtons[perkData.PerkStr], perkData);
            }
        }
    }
}