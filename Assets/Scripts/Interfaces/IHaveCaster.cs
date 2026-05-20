using Views;

namespace Interfaces
{
    /// <summary>
    /// 施法者接口 - 实现此接口的GameAction可以获取施法者
    /// 用于特权等需要知道谁发动了动作的场景
    /// </summary>
    public interface IHaveCaster
    {
        CombatantView Caster { get;}
    }
}