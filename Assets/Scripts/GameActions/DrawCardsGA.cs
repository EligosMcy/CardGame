using General.ActionSystemComponents;

namespace GameActions
{
    /// <summary>
    /// 抽牌游戏动作 - 从抽牌堆抽取指定数量的牌
    /// </summary>
    public class DrawCardsGA : GameAction
    {
        public int Amount { get; set; }

        public DrawCardsGA(int amount)
        {
            Amount = amount;
        }
    }
}