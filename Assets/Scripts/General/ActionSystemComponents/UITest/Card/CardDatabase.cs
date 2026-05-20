using System.Collections.Generic;
using UnityEngine;

namespace General.ActionSystemComponents.UITest
{
    public static class CardDatabase
    {
        private static Dictionary<string, CardData> cardDictionary = new Dictionary<string, CardData>();
        private static bool isInitialized = false;

        public static void Initialize(string jsonPath)
        {
            if (isInitialized) return;

            TextAsset jsonAsset = Resources.Load<TextAsset>(jsonPath);
            if (jsonAsset == null)
            {
                Debug.LogError("CardDatabase: 无法加载卡牌数据文件: " + jsonPath);
                return;
            }

            ParseJson(jsonAsset.text);
            isInitialized = true;
        }

        public static void ParseJson(string jsonText)
        {
            CardDatabaseData data = JsonUtility.FromJson<CardDatabaseData>(jsonText);
            
            if (data != null && data.cards != null)
            {
                foreach (CardData card in data.cards)
                {
                    if (!cardDictionary.ContainsKey(card.name))
                    {
                        cardDictionary.Add(card.name, card);
                    }
                    else
                    {
                        Debug.LogWarning("CardDatabase: 重复的卡牌名称: " + card.name);
                    }
                }
            }
        }

        public static CardData GetCardByName(string name)
        {
            if (cardDictionary.TryGetValue(name, out CardData card))
            {
                return card;
            }
            return null;
        }

        public static List<CardData> GetAllCards()
        {
            return new List<CardData>(cardDictionary.Values);
        }

        public static List<CardData> GetCardsByType(CardType type)
        {
            List<CardData> result = new List<CardData>();
            foreach (var card in cardDictionary.Values)
            {
                if (card.GetCardType() == type)
                {
                    result.Add(card);
                }
            }
            return result;
        }

        public static List<CardData> GetCardsByRarity(CardRarity rarity)
        {
            List<CardData> result = new List<CardData>();
            foreach (var card in cardDictionary.Values)
            {
                if (card.GetCardRarity() == rarity)
                {
                    result.Add(card);
                }
            }
            return result;
        }

        public static int GetCardCount()
        {
            return cardDictionary.Count;
        }

        public static void Clear()
        {
            cardDictionary.Clear();
            isInitialized = false;
        }
    }
}