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
        attackData.cooldown = 5f;
    }

    public override void PerformAttack(int pointsDamage, GameObject personToHit, GameObject attacker)
    {
        base.PerformAttack(pointsDamage, personToHit, attacker);
        Debug.Log("Projectile attack");
        bool isBoss = attacker.CompareTag("Boss");
        float spawnOffset = 2.5f;
        Vector3 spawnPosition = attacker.transform.position + attacker.transform.forward * spawnOffset;
        bool canAttack = isBoss || attackData.cooldownTimer <= 0;
        if (canAttack)
        {
            Debug.Log("Reached cooldown");
            if (attackData.attackPrefab == null)
            {
                Debug.LogWarning("Projectile Attack missing prefab");
                return;
            }
            // Find direction of the road the projectile will take to reach the person to hit
            Vector3 direction = attacker.transform.forward;
            Debug.Log("Possible prefab " + attackData.attackPrefab.name);
            GameObject projectile = GameObject.Instantiate(attackData.attackPrefab, spawnPosition, Quaternion.identity);
            // Initialize projectile
            Projectile proj = projectile.GetComponent<Projectile>();
            Debug.Log("Damage to do: " + attackData.damage);
            if (proj != null)
                proj.Initialize(direction, attackData.damage);
            attackData.cooldownTimer = attackData.cooldown;
        }
    }
}