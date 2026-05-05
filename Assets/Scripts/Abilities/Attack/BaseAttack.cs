using UnityEngine;

public class BaseAttack : IAttack
{
    public AttackData attackData { get; set; }

    /// <summary>
    /// Constructor of the base attack the user will have
    /// </summary>
    /// <param name="baseDamage">Points of the base damage the character does on hit</param>
    /// <param name="baseRange">Range of the attack</param>
    /// <param name="attackID">Name of the specific attack</param>
    public BaseAttack(int baseDamage, int baseRange, string attackID)
    {
        attackData = new AttackData
        {
            id = attackID,
            betterColor = Color.white,
            color = Color.white,
            weakColor = Color.white,
            effect = null,
            damage = baseDamage,
            range = baseRange,
            cooldown = 0f,
            cooldownTimer = 0f,
        };
    }

    /// <summary>
    /// Function to be called when the character attacks an enemy. It is connected
    /// to the EnemyAI script that contains the different states of the enemy.
    /// </summary>
    /// <param name="pointsDamage">Points of damage the character does to the enemy</param>
    /// <param name="personToHit">The object that is hit from the collider</param>
    /// <param name="attacker">The object that calls the attack</param>
    public void PerformAttack(int pointsDamage, GameObject personToHit, GameObject attacker)
    {
        if(personToHit == null) return;
        // Detect enemies in range of attack        
        if (personToHit.CompareTag("Enemy"))
            personToHit.GetComponent<EnemyAI>().TakeDamage(attackData.damage);
        else if (personToHit.CompareTag("Boss")) 
            personToHit.GetComponent<Health>().DamageHealth(attackData.damage);
    }

    /// <summary>
    /// Function to be called automatically if the timer of the attack has reached
    /// its peak.
    /// </summary>
    public void AttackTick()
    {
         // Reduce the timer for this specific attack layer
        if (attackData.cooldownTimer > 0)
            attackData.cooldownTimer -= Time.deltaTime;
    }
}
