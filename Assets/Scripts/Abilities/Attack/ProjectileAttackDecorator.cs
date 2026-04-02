using UnityEngine;

public class ProjectileAttackDecorator : ElementalDecorator
{
    /// <summary>
    /// Projectile decorator initializes the prefab of the projectile object of
    /// the attack and increases the base damage plus the amount specified for the
    /// projectile
    /// </summary>
    /// <param name="specificAttack">The base attack that will be modified</param>
    /// <param name="damageAmount">The amount with which the base attac damage will be upgraded</param>
    /// <param name="attackPrefab">The prefab of the attack </param>
    public ProjectileAttackDecorator(int damageAmount, GameObject attackPrefab, IAttack specificAttack) : base(specificAttack)
    {
        attackData.damage += damageAmount;
        attackData.attackPrefab = attackPrefab;
    }

    public override void PerformAttack(int pointsDamage, GameObject personToHit, GameObject attacker)
    {
        base.PerformAttack(pointsDamage, personToHit, attacker);
        if (attackData.attackPrefab == null)
        {
            Debug.LogWarning("Projectile Attack missing prefab");
            return;
        }
        // Find direction of the road the projectile will take to reach the person to hit
        Vector3 direction = (personToHit.transform.position - attacker.transform.position).normalized;
        GameObject projectile = GameObject.Instantiate(attackData.attackPrefab, attacker.transform.position, Quaternion.identity);
        // Initialize projectile
        Projectile proj = projectile.GetComponent<Projectile>();
        if (proj != null)
            proj.Initialize(direction, pointsDamage);
    }
}