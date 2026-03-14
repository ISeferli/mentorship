using UnityEngine;

public class WaterAttackDecorator : ElementalDecorator
{
    /// <summary>
    /// Water decorator adds to the base damage and changes the base weapon color
    /// to blue.
    /// </summary>
    /// <param name="specificAttack">The base attack that will be modified</param>
    /// <param name="upgradeAmount">The amount with which the base attac damage will be upgraded</param>
    public WaterAttackDecorator(int upgradeAmount, IAttack specificAttack) : base(specificAttack)
    {
        attackData.color = Color.blue;
        attackData.betterColor = Color.green;
        attackData.weakColor = Color.red;
        attackData.damage += upgradeAmount;
    }

    public override void PerformAttack(int pointsDamage, GameObject personToHit)
    {
        base.PerformAttack(pointsDamage, personToHit);
        Debug.Log("Add water attack");
    }
}
