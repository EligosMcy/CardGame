using Data;
using GameActions;
using General.ActionSystemComponents;
using System.Collections.Generic;
using Models;
using UnityEngine;

namespace Systems
{
    /// <summary>
    /// 比赛设置系统 - 初始化一场战斗的所有数据
    /// 设置英雄、敌人、卡组和特权，准备战斗开始
    /// </summary>
    public class MatchSetupSystem : MonoBehaviour
    {
        [SerializeField] private HeroData _heroData;

        [SerializeField] private List<PerkData> _perkDataList;

        [SerializeField] private List<EnemyData> _enemyDataList;

        private void Start()
        {
            HeroSystem.Instance.Setup(_heroData);

            EnemySystem.Instance.Setup(_enemyDataList);

            CardSystem.Instance.Setup(_heroData.Deck);


            //
            foreach (PerkData perkData in _perkDataList)
            {
                Perk perk = new Perk(perkData);
                PerkSystem.Instance.AddPerk(perk);
            }

            //
            DrawCardsGA drawCardsGa = new DrawCardsGA(5);

            ActionSystem.Instance.Perform(drawCardsGa);
        }
    }
}