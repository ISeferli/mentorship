using UnityEngine;

public class WaterAttackDecorator : AttackDecorator
{
    public WaterAttackDecorator(IAttack specificAttack) : base(specificAttack)
    {
        attackData.color = Color.blue;
        attackData.betterColor = Color.green;
        attackData.weakColor = Color.red;
        attackData.damage += 10;
    }

    public override void PerformAttack(int pointsDamage, GameObject personToHit)
    {
        base.PerformAttack(pointsDamage, personToHit);
        Debug.Log("Add water attack");
    }
}
