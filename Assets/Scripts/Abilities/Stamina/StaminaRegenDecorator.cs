using UnityEngine;

public class StaminaRegenDecorator : StaminaDecorator
{
    /// <summary>
    /// Stamina Regeneration Decorator that handles the decrease of the
    /// cooldown for the dash ability.
    /// </summary>
    /// <param name="specificStamina">Base stamina that will be upgraded</param>
    /// <param name="amount">Amount that the cooldown will be decreased with</param>
    public StaminaRegenDecorator(IStamina specificStamina, int amount) : base(specificStamina)
    {
        staminaData.dashCooldown -= amount;
    }
}
