using UnityEngine;
using System.Collections.Generic;

public class SwordWeapon : MonoBehaviour
{
    [Header("Attack Settings")]
    [SerializeField] private LayerMask enemyLayer;

    public bool IsAttacking {set {isAttacking = value;}}
    public List<BaseStat> stats { get; set; }

    // Is the character attacking
    private bool isAttacking = false;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Enemy") && isAttacking)
        {
            PerformAttack(collider.gameObject, GetComponentInParent<CharacterStats>());
        }
    }

    public void PerformAttack(GameObject personToHit, CharacterStats character)
    {
        Debug.Log("Hand Attack: " + character.attributes["Strength"].CalculateStatValue());
        // Detect enemies in range of attack
        personToHit.GetComponent<EnemyAI>().TakeDamage(character.attributes["Strength"].CalculateStatValue());
    }
}
