using UnityEngine;

public class FireAttackDecorator : AttackDecorator
{
    /// <summary>
    /// Fire decorator adds to the base damage and changes the base weapon color
    /// to red.
    /// </summary>
    /// <param name="specificAttack">The base attack that will be modified</param>
    /// <param name="upgradeAmount">The amount with which the base attac damage will be upgraded</param>
    public FireAttackDecorator(int upgradeAmount, IAttack specificAttack) : base(specificAttack)
    {
        attackData.color = Color.red;
        attackData.betterColor = Color.blue;
        attackData.weakColor = Color.green;
        attackData.damage += upgradeAmount;
    }

    public override void PerformAttack(int pointsDamage, GameObject personToHit)
    {
        base.PerformAttack(pointsDamage, personToHit);
        Debug.Log("Add fire attack");
    }
}
