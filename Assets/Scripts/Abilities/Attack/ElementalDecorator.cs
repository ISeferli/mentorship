using System.Collections.Generic;
using UnityEngine;

public abstract class ElementalDecorator : IAttack
{
    // Get the instance of a specific interface of the attacks
    protected IAttack specificAttack;

    // Have unique attack data for the ability
    public AttackData attackData { get; set; }

    // List of effects added to this decorator
    protected List<IEffect> effects = new List<IEffect>();

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
    /// Add an effect on the list
    /// </summary>
    /// <param name="effect">Type of effect to add</param>
    public void AddEffect(IEffect effect)
    {
        if (effect != null && !effects.Contains(effect))
            effects.Add(effect);
    }

    /// <summary>
    /// Use specific effect by name to the target
    /// </summary>
    /// <param name="effectName">Name of the effect</param>
    /// <param name="target">Target of damage</param>
    public void UseEffect(string effectName, GameObject target)
    {
        // Find the effect in the list
        IEffect effect = effects.Find(e => e.EffectID == effectName);
        if (effect != null)
            effect.ExecuteEffect(target, attackData);
        else
            Debug.LogWarning($"Effect {effectName} not found on this decorator.");
    }

    /// <summary>
    /// Calls the function for performing attack until it reaches the base attack object
    /// </summary>
    /// <param name="personToHit"><b>GameObject</b> of the item the character hit</param>
    public virtual void PerformAttack(int pointsDamage, GameObject personToHit)
    {
        specificAttack.PerformAttack(pointsDamage, personToHit);
        // Execute all attached effects
        // foreach (var effect in effects)
        //     effect.ExecuteEffect(personToHit, attackData);
    }
}
