using UnityEngine;

public interface IEffect
{
    /// <summary>
    /// ID of the effect that is being used
    /// </summary>
    public string EffectID { get; }

    /// <summary>
    /// Execute the effect that is assigned on that attack to the
    /// target using the attack data.
    /// </summary>
    /// <param name="target">Target that takes the damage</param>
    /// <param name="data">Attack data</param>
    public void ExecuteEffect(GameObject target, AttackData data);
}