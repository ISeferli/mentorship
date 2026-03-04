using UnityEngine;

public class StaminaRegenDecorator : StaminaDecorator
{
    public StaminaRegenDecorator(IStamina specificStamina) : base(specificStamina)
    {
        Debug.Log("here");
        staminaData.dashCooldown = 0.05f;
    }
}
