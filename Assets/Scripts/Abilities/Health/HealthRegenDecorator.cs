using UnityEngine;

public class HealthRegenDecorator : HealthDecorator
{
    private float timer;
    public HealthRegenDecorator(IHealth wrappedHealth, int healthStat) : base(wrappedHealth)
    {
        healthData.regenRate += healthStat;
    }

    public override void RegenTick()
    {
        base.RegenTick();
        timer += Time.deltaTime;
        // Heal 1 point every second
        if(timer >= 1f)
        {
            wrappedHealth.ChangeHealth(healthData.regenRate);
            GameEventsManager.instance.graphicEvents.ChangeCurrentHealthUI(-healthData.regenRate);
            timer = 0;
        }
    }
}
