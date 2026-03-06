using UnityEngine;

public class HealthMaxIncreaseDecorator : HealthDecorator
{
    /// <summary>
    /// Health Max Increase Decorator changes the max health of the object
    /// to the amont specified.
    /// </summary>
    /// <param name="wrappedHealth">Base health that will be upgraded</param>
    /// <param name="healthStat">Points that will be added to health</param>
    public HealthMaxIncreaseDecorator(IHealth wrappedHealth, int healthStat) : base(wrappedHealth)
    {
        healthData.maxHealth += healthStat;
        GameEventsManager.Instance.graphicEvents.ChangeMaxHealthUI(healthStat);
    }
}
