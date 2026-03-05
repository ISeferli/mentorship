using UnityEngine;

public class StaminaMaxDecorator : StaminaDecorator
{
    /// <summary>
    /// Stamina Max Decorator that increases the max stamina uses
    /// of the character. Updates the UI when initialised
    /// </summary>
    /// <param name="specificStamina">Amount of uses that we want the stamina
    /// to be increases with</param>
    public StaminaMaxDecorator(IStamina specificStamina) : base(specificStamina)
    {
        staminaData.maxStaminaUses++;
        GameEventsManager.instance.graphicEvents.ChangeMaxStaminaUI(1);
    }
}
