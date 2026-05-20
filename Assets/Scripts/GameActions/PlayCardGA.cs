using General.ActionSystemComponents;
using Interfaces;
using Models;
using Views;

namespace GameActions
{
    /// <summary>
    /// 出牌游戏动作 - 玩家打出一张卡牌
    /// 包含卡牌信息和手动选择的目标（如果有）
    /// </summary>
    public class PlayCardGA : GameAction, IHaveManualTarget
    {
        public EnemyView ManualTarget { get;}
        public Card Card { get; set; }

        public PlayCardGA(Card card)
        {
            Card = card;
            ManualTarget = null;
        }

        public PlayCardGA(Card card, EnemyView target)
        {
            Card = card;
            ManualTarget = target;
        }
    }
}