using UnityEngine;

public class ProjectileEffect : IEffect
{
    public string EffectID => "Projectile";
    public void ExecuteEffect(GameObject target, AttackData data)
    {
        Debug.Log($"Applying {data.damage * 0.2f} of range {data.range} to {target.name}");
    }
}