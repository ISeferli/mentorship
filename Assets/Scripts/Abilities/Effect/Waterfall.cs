using UnityEngine;
using System.Collections.Generic;

public class Waterfall : MonoBehaviour
{
    private int damagePerTick;
    private float slowAmount;
    private float duration = 3.0f;

    public void Initialize(int damage, float slow)
    {
        damagePerTick = damage;
        slowAmount = slow;
        Destroy(gameObject, duration);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Apply Damage
            Health health = other.GetComponent<Health>();
            if(health!=null)
                health.DamageHealth(damagePerTick);
            if (other.CompareTag("Player"))
            {
                GameEventsManager.Instance.graphicEvents.ChangeCurrentHealthUI(-damagePerTick);   
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Adding special effect of the attack, to slow down the enemies
        if (other.CompareTag("Enemy"))
        {
            var enemyMovement = other.GetComponent<UnityEngine.AI.NavMeshAgent>();
            if (enemyMovement != null)
            {
                enemyMovement.speed /= slowAmount;
            }
        }
    }
}