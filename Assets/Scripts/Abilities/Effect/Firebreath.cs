using UnityEngine;
using System.Collections.Generic;

public class Firebreath : MonoBehaviour
{
    private int damagePerSecond;
    private float duration = 1f; 
    private float damageInterval = 0.5f; //Damage every 0.5 seconds
    private Dictionary<GameObject, float> nextDamageTime = new Dictionary<GameObject, float>();

    public void Initialize(int damage)
    {
        damagePerSecond = damage;
        Destroy(gameObject, duration);
        Debug.Log("Firebreath initialized. Will destroy in: " + duration);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Check if it's time to damage this specific enemy again
            if (!nextDamageTime.ContainsKey(other.gameObject) || Time.time >= nextDamageTime[other.gameObject])
            {
                Health health = other.GetComponent<Health>();
                if(health!=null)
                    health.DamageHealth(damagePerSecond);
                nextDamageTime[other.gameObject] = Time.time + damageInterval;
            }
        }
    }
}