using UnityEngine;

public abstract class HealthDecorator : IHealth
{
    // Get the instance of a specific interface of the attacks
    protected IHealth wrappedHealth;

    // Have unique attack data for the ability
    public HealthData healthData { get; set; }

    /// <summary>
    /// Constructor that creates the instance of the HealthDecorator that wraps the health abilities together.
    /// </summary>
    /// <param name="healthToUpgrade"><b>HealthInterface</b> variable that specifies the kind of health ability</param>
    public HealthDecorator(IHealth healthToUpgrade)
    {
        this.wrappedHealth = healthToUpgrade;
        this.healthData = wrappedHealth.healthData;
    }    

    public void GetAbilityUpgrade(string type, IAbility statUpgrade)
    {
        wrappedHealth.GetAbilityUpgrade(type, statUpgrade);
    }

    public void ChangeHealth(int healthPoints)
    {
        wrappedHealth.ChangeHealth(healthPoints);
    }
}
