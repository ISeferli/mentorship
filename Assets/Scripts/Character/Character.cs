using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("Get characters' base abilities.")]
    public IHealth CurrentHealth { get; set; }
    public IStamina CurrentStamina { get; set; }

    void Awake()
    {
        CurrentHealth = GetComponent<Health>();
        CurrentStamina = GetComponent<CharacterMovement>().baseStamina;
    }

    void Update()
    {
        // If the character has regeneration abilities, then call the function inside
        if(CurrentHealth.healthData.regenRate > 0 && CurrentHealth.healthData.currentHealth<CurrentHealth.healthData.maxHealth)
            CurrentHealth.RegenTick();
        if (CurrentStamina.staminaData.currentStaminaUses < CurrentStamina.staminaData.maxStaminaUses)
            CurrentStamina.RegenTick();
    }
}