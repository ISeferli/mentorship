using UnityEngine;

public class Health : MonoBehaviour, IHealth
{
    [Header("Stats")]
    [SerializeField] private PlayableStats stats;

    // Health Essential Components
    private Animator animator;

    // Stats during gameplay
    public HealthData healthData { get; set; } = new HealthData();

    private int phases = 4; // Maximum phases number

    void Start()
    {
        animator = GetComponent<Animator>();
        healthData.maxHealth = stats.GetStatValue("Health");
        healthData.currentHealth = healthData.maxHealth;
    }

    /// <summary>
    /// Changes health by adding the health points that you want to
    /// increase.
    /// </summary>
    /// <param name="healthPoints">Health points that you want to add.
    /// If it is negative number, it decreases the health</param>
    public void ChangeHealth(int healthPoints)
    {
        healthData.currentHealth = Mathf.Clamp(healthData.currentHealth + healthPoints, 0, healthData.maxHealth);
    }

    /// <summary>
    /// Base regenaration function for health. While not upgraded, it does nothings.
    /// </summary>
    public void RegenTick()
    {
        /* Base health does nothing every frame */
    }

    /// <summary>
    /// This function handles the damage that can be done to any character that
    /// has the Health component
    /// </summary>
    /// <param name="damage">Points of damage done to character</param>
    public void DamageHealth(int damage)
    {
        ChangeHealth(-damage);
        Debug.Log(healthData.currentHealth);
        animator.SetTrigger("TakeDamage");
    }

    /// <summary>
    /// Detect if the character's life has reached 0
    /// </summary>
    /// <returns><b>boolean</b> which is true if the character
    /// has 0 life, false if life is still positive</returns>
    public bool DetectDeath()
    {
        if(healthData.currentHealth <= 0)
            return true;
        return false;
    }

    /// <summary>
    /// Detect the life percentage that the character has lost
    /// throughout the game
    /// </summary>
    /// <returns> The life percentage in decimal that is lost </returns>
    public float DetectLifePercentage()
    {
        return (float)healthData.currentHealth/healthData.maxHealth;
    }

    public void CheckLifeStatus()
    {
        if(DetectDeath()) Debug.Log("Death");
        float lifePer = DetectLifePercentage();
        int currentPhase = Mathf.CeilToInt(lifePer * 4);
        // If the current quarter is less than the last recorded quarter
        // it means the character just lost 25% of its life
        if (currentPhase < phases && currentPhase > 0)
        {
            // Trigger your specific attack
            animator.SetTrigger("Attack3");
            // Update the last phase
            phases = currentPhase;
        }
    }
}
