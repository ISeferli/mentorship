using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Character Stats")]
    [SerializeField] private PlayableStats stats;

    // Health Essential Components
    private Animator animator;

    // Stats during gameplay
    private int maxHealth;
    private int currentHealth;

    void Start()
    {
        animator = GetComponent<Animator>();
        maxHealth = stats.GetStatValue("Health");
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

    /// <summary>
    /// Detect if the character's life has reached 0
    /// </summary>
    /// <returns><b>boolean</b> which is true if the character
    /// has 0 life, false if life is still positive</returns>
    public bool DetectDeath()
    {
        if(currentHealth <= 0)
            return true;
        return false;
    }
}
