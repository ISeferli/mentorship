using UnityEngine;

public class FireAttackDecorator : AttackDecorator
{
    public FireAttackDecorator(IAttack specificAttack) : base(specificAttack) { }

    public override void PerformAttack(int pointsDamage, GameObject personToHit)
    {
        base.PerformAttack(pointsDamage, personToHit);
        Debug.Log("Add fire attack");
    }
}
