using UnityEngine;

public class StaminaMaxDecorator : StaminaDecorator
{
    public StaminaMaxDecorator(IStamina specificStamina) : base(specificStamina)
    {
        staminaData.maxStaminaUses++;
        GameEventsManager.instance.graphicEvents.ChangeMaxStaminaUI(1);
    }
}
