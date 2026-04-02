using System.Collections.Generic;
using UnityEngine;

public abstract class ElementalDecorator : IAttack
{
    // Get the instance of a specific interface of the attacks
    protected IAttack specificAttack;

    // Have unique attack data for the ability
    public AttackData attackData { get; set; }

    /// <summary>
    /// Constructor that creates the instance of the ElementalDecorator that wraps the attack abilities together.
    /// </summary>
    /// <param name="specificAttack"><b>AttackInterface</b> variable that specifies the kind of attack ability</param>
    public ElementalDecorator(IAttack specificAttack)
    {
        this.specificAttack = specificAttack;
        this.attackData = specificAttack.attackData;
    }

    /// <summary>
    /// Calls the function for performing attack until it reaches the base attack object
    /// </summary>
    /// <param name="personToHit"><b>GameObject</b> of the item the character hit</param>
    /// <param name="attacker"> Object that calls the attack </param>
    public virtual void PerformAttack(int pointsDamage, GameObject personToHit, GameObject attacker)
    {
        specificAttack.PerformAttack(pointsDamage, personToHit, attacker);
    }
}
