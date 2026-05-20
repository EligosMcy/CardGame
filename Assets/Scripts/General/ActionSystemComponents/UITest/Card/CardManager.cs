using System.Collections.Generic;
using UnityEngine;

namespace General.ActionSystemComponents.UITest
{
    public class CardManager : MonoBehaviour
    {
        [Header("卡牌配置")]
        [SerializeField] 
        private TextAsset cardJsonAsset;

        public static CardManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
                return;
            }

            InitializeCardDatabase();
        }

        private void InitializeCardDatabase()
        {
            if (cardJsonAsset != null)
            {
                CardDatabase.ParseJson(cardJsonAsset.text);
                Debug.Log("CardManager: 已加载 " + CardDatabase.GetCardCount() + " 张卡牌");
            }
            else
            {
                Debug.LogError("CardManager: 请指定卡牌JSON资源文件");
            }
        }

        public CardData GetCard(string cardName)
        {
            return CardDatabase.GetCardByName(cardName);
        }

        public List<CardData> GetAllCards()
        {
            return CardDatabase.GetAllCards();
        }

        public List<CardData> GetAttackCards()
        {
            return CardDatabase.GetCardsByType(CardType.Attack);
        }

        public List<CardData> GetSkillCards()
        {
            return CardDatabase.GetCardsByType(CardType.Skill);
        }

        public List<CardData> GetPowerCards()
        {
            return CardDatabase.GetCardsByType(CardType.Power);
        }

        public CardData DrawRandomCard()
        {
            List<CardData> allCards = CardDatabase.GetAllCards();
            if (allCards.Count == 0) return null;
            
            int randomIndex = Random.Range(0, allCards.Count);
            return allCards[randomIndex];
        }

        public CardData DrawRandomCardByType(CardType type)
        {
            List<CardData> cards = CardDatabase.GetCardsByType(type);
            if (cards.Count == 0) return null;
            
            int randomIndex = Random.Range(0, cards.Count);
            return cards[randomIndex];
        }

        public CardData DrawRandomCardByRarity(CardRarity rarity)
        {
            List<CardData> cards = CardDatabase.GetCardsByRarity(rarity);
            if (cards.Count == 0) return null;
            
            int randomIndex = Random.Range(0, cards.Count);
            return cards[randomIndex];
        }
    }
}