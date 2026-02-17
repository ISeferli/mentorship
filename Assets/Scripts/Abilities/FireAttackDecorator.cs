using UnityEngine;

public class FireAttackDecorator : AttackDecorator
{
    public FireAttackDecorator(IAttack specificAttack) : base(specificAttack)
    {
        attackData.color = Color.red;
        attackData.betterColor = Color.blue;
        attackData.weakColor = Color.green;
        attackData.damage += 5;
    }

    public override void PerformAttack(int pointsDamage, GameObject personToHit)
    {
        base.PerformAttack(pointsDamage, personToHit);
        Debug.Log("Add fire attack");
    }
}
