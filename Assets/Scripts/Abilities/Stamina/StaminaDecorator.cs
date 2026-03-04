using System;
using System.Collections;

public abstract class StaminaDecorator : IStamina
{
    // Get the instance of a specific interface of the stamina
    protected IStamina wrappedStamina;

    // Have unique stamina data for the ability
    public StaminaData staminaData { get; set; }

    public StaminaDecorator(IStamina staminaToUpgrade)
    {
        this.wrappedStamina = staminaToUpgrade;
        this.staminaData = wrappedStamina.staminaData;
    }

    public virtual bool CanDash()
    {
        return wrappedStamina.CanDash();
    }

    public virtual IEnumerator DashRoutine(Action onDashStart, Action onDashEnd)
    {
        yield return wrappedStamina.DashRoutine(onDashStart, onDashEnd);
    }

    public virtual void RegenTick()
    {
        wrappedStamina.RegenTick();
    }

    public void GetAbilityUpgrade(string type, IAbility statUpgrade)
    {
        wrappedStamina.GetAbilityUpgrade(type, statUpgrade);
    }
}