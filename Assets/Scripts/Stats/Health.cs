using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Health Essential Components")]
    [SerializeField] private CharacterStats characterStats;

    [Header("Basic Health Stats")]
    [SerializeField] private Animator charAnimator;

    // Stats during gameplay
    private int maxHealth;
    private int currentHealth;

    void Start()
    {
        maxHealth = characterStats.GetStatValue("Constitution") * 5;
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
        charAnimator.SetTrigger("TakeDamage");
    }
}
