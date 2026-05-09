using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private CapsuleCollider enemyCollider;
    private bool isAttacking {get;set;}
    private int damagePoints;
    public BaseAttackComposition EnemyAttackLibrary {get;set;}

    void Awake()
    {
        enemyCollider.enabled = false;
        EnemyAttackLibrary = new BaseAttackComposition();
    }

    /// <summary>
    /// Attacks the player health. Informs the UI health bar to decrease by the
    /// points of damage the enemy does and informs the health component to decrease
    /// health
    /// </summary>
    /// <param name="targetHealth">Targets health component</param>
    /// <param name="pointsOfDamage">Points of damage that the enemy does</param>
    public void AttackPlayer()
    {
        damagePoints = EnemyAttackLibrary.GetBaseAttack("Base").attackData.damage;
        GetComponent<Animator>().SetTrigger("Attack");
        isAttacking = true;
    }

    /// <summary>
    /// Function that is called on animation that enables the
    /// collider of the enemy to detect hit
    /// </summary>
    public void EnableAttackColliderAnim()
    {
        enemyCollider.enabled = true;
    }

    /// <summary>
    /// Function that is called on animation that disables the
    /// collider of the enemy's hit box
    /// </summary>
    public void EndOfAttackAnim()
    {
        isAttacking = false;
        enemyCollider.enabled = false;
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.CompareTag("Player") && isAttacking)
        {
            Debug.Log("Hit");
            GameEventsManager.Instance.graphicEvents.ChangeCurrentHealthUI(-damagePoints);
            collider.GetComponent<Health>().DamageHealth(damagePoints);
        }
    }


    // Boss Attack Functionality
    public void MeleeAttackPlayer()
    {
        damagePoints = EnemyAttackLibrary.GetBaseAttack("Base").attackData.damage;
        Debug.Log("Enemy does: " + damagePoints);
        isAttacking = true;
    }

    public void BossRangeAttack()
    {
        Debug.Log("Boss Range Attack");
        EnemyAttackLibrary.GetBaseAttack("Range").PerformAttack(EnemyAttackLibrary.GetBaseAttack("Range").attackData.damage, GameObject.FindGameObjectWithTag("Player"), this.gameObject);
    }

    public void BossSpecialAttack()
    {
        Debug.Log("Boss Special Attack");
        EnemyAttackLibrary.GetBaseAttack("Special").PerformAttack(EnemyAttackLibrary.GetBaseAttack("Range").attackData.damage, GameObject.FindGameObjectWithTag("Player"), this.gameObject);
    }
}
