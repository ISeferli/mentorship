using UnityEngine;

public class HealthMaxIncreaseDecorator : HealthDecorator
{
    public HealthMaxIncreaseDecorator(IHealth wrappedHealth, int healthStat) : base(wrappedHealth)
    {
        healthData.maxHealth += healthStat;
        GameEventsManager.instance.graphicEvents.ChangeMaxHealthUI(healthStat);
    }
}
