namespace General.ActionSystemComponents.Test.GameActaionClass
{
    //提升属性
    public class IncreaseStatsGA : GameAction
    {
        public Minion Target;

        public int AttackIncreaseAmount;

        public int HealthIncreaseAmount;

        public IncreaseStatsGA(Minion target, int attackIncreaseAmount, int healthIncreaseAmount)
        {
            Target = target;
            AttackIncreaseAmount = attackIncreaseAmount;
            HealthIncreaseAmount = healthIncreaseAmount;
        }
    }

    //Card System

    //Card Draw System

    //Damage System

    //Stat System

    //Minion System
}