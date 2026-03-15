using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private CapsuleCollider enemyCollider;
    private bool isAttacking {get;set;}
    private int damagePoints;

    public IAttack BaseAttack {get;set;}

    void Start()
    {
        enemyCollider.enabled = false;
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
        damagePoints = BaseAttack.attackData.damage;
        Debug.Log("Enemy does: " + damagePoints);
        GetComponent<Animator>().SetTrigger("Attack");
        isAttacking = true;
    }

    public void EnableAttackColliderAnim()
    {
        enemyCollider.enabled = true;
    }

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
}
