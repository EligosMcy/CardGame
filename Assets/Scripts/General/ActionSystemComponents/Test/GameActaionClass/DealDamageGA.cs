namespace General.ActionSystemComponents.Test.GameActaionClass
{
    //造成伤害
    public class DealDamageGA : GameAction
    {
        public int Amount;

        public DealDamageGA(int amount)
        {
            Amount = amount;
        }
    }
}