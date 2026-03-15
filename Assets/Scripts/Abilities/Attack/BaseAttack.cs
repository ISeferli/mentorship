using UnityEngine;

public class BaseAttack : IAttack
{
    public AttackData attackData { get; set; }

    /// <summary>
    /// Constructor of the base attack the user will have
    /// </summary>
    /// <param name="baseDamage">Points of the base damage the character does on hit</param>
    public BaseAttack(int baseDamage, int baseRange)
    {
        attackData = new AttackData
        {
            betterColor = Color.white,
            color = Color.white,
            weakColor = Color.white,
            damage = baseDamage,
            range = baseRange
        };
    }

    /// <summary>
    /// Function to be called when the character attacks an enemy. It is connected
    /// to the EnemyAI script that contains the different states of the enemy.
    /// </summary>
    /// <param name="pointsDamage">Points of damage the character does to the enemy</param>
    /// <param name="personToHit">The object that is hit from the collider</param>
    public void PerformAttack(int pointsDamage, GameObject personToHit)
    {
        // Detect enemies in range of attack
        personToHit.GetComponent<EnemyAI>().TakeDamage(attackData.damage);
    }
}
