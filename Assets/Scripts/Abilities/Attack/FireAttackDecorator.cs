using UnityEngine;

public class FireAttackDecorator : ElementalDecorator
{
    /// <summary>
    /// Fire decorator adds to the base damage and changes the base weapon color
    /// to red.
    /// </summary>
    /// <param name="specificAttack">The base attack that will be modified</param>
    /// <param name="upgradeAmount">The amount with which the base attac damage will be upgraded</param>
    public FireAttackDecorator(int upgradeAmount, GameObject upgradeEffect, AttackElement atElement, IAttack specificAttack) : base(specificAttack)
    {
        attackData.color = Color.red;
        attackData.betterColor = Color.blue;
        attackData.weakColor = Color.green;
        attackData.damage += upgradeAmount;
        attackData.effect = upgradeEffect;
        attackData.element = atElement;
    }

    public override void PerformAttack(int pointsDamage, GameObject personToHit, GameObject attacker)
    {
        base.PerformAttack(pointsDamage, personToHit, attacker);
        Debug.Log("Add fire attack");
    }
}
