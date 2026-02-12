using UnityEngine;

public class WaterAttackDecorator : AttackDecorator
{
    public WaterAttackDecorator(IAttack specificAttack) : base(specificAttack) { }

    public override void PerformAttack(int pointsDamage, GameObject personToHit)
    {
        base.PerformAttack(pointsDamage, personToHit);
        Debug.Log("Add water attack");
    }
}
