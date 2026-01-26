using UnityEngine;

[RequireComponent(typeof(PlayableStats))]
public class Health : MonoBehaviour
{
    // Health Essential Components
    private PlayableStats stats;
    private Animator animator;

    // Stats during gameplay
    private int maxHealth;
    private int currentHealth;

    void Start()
    {
        stats = GetComponent<PlayableStats>();
        animator = GetComponent<Animator>();
        maxHealth = stats.GetStatValue("Constitution") * 5;
        currentHealth = maxHealth;
    }

    /// <summary>
    /// This function handles the damage that can be done to any character that
    /// has the Health component
    /// </summary>
    /// <param name="damage">Points of damage done to character</param>
    public void DamageHealth(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Current Health: " + currentHealth);
        animator.SetTrigger("TakeDamage");
    }
}
