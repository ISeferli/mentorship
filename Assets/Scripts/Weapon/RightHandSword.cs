using System.Collections.Generic;
using UnityEngine;

public class RightHandSword : MonoBehaviour, WeaponInterface
{
    [Header("Attack Settings")]
    [SerializeField] private float attackRange = 0.5f;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private LayerMask enemyLayer;
    public List<BaseStat> stats { get; set; }

    public void PerformAttack(GameObject personToHit, CharacterStats character)
    {
        Debug.Log("Right Hand Attack: " + character.attributes["Strength"].CalculateStatValue());
        // Detect enemies in range of attack
        Collider[] hitEnemy = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayer);
        // Damage enemy
        foreach(Collider enemy in hitEnemy)
        {
            Debug.Log("We hit " + enemy.name);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}

// https://www.youtube.com/watch?v=sPiVz1k-fEs