using System;
using UnityEngine;

public class BaseAttack : IAttack
{
    public void PerformAttack(int pointsDamage, GameObject personToHit)
    {
        Debug.Log("Hand Attack: " + pointsDamage);
        // Detect enemies in range of attack
        // personToHit.GetComponent<EnemyAI>().TakeDamage(stats.GetStatValue("Attack"));
    }
}
