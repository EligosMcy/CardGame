using General.ActionSystemComponents;

namespace GameActions
{
    /// <summary>
    /// 消耗能量游戏动作 - 减少玩家的能量
    /// 在打出卡牌时触发
    /// </summary>
    public class SpendManaGA : GameAction
    {
        public int Amount { get; set; }

        public SpendManaGA(int amount)
        {
            Amount = amount;
        }
    }
}