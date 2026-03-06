using UnityEngine;

public class HealthRegenDecorator : HealthDecorator
{
    private float timer;
    
    /// <summary>
    /// Health Regeneration Decorator increases the regeneration rate to a 
    /// specific amount to show in the gameplay that the regeneration has begun.
    /// </summary>
    /// <param name="wrappedHealth">Base Health object that the upgrade will be added to</param>
    /// <param name="healthStat">Points that the regeneration rate will be increased with</param>
    public HealthRegenDecorator(IHealth wrappedHealth, int healthStat) : base(wrappedHealth)
    {
        healthData.regenRate += healthStat;
    }

    /// <summary>
    /// Inside the regeneration decorator, the function has logic for each second to
    /// add a point to the health.
    /// </summary>
    public override void RegenTick()
    {
        base.RegenTick();
        timer += Time.deltaTime;
        // Heal 1 point every second
        if(timer >= 1f)
        {
            wrappedHealth.ChangeHealth(healthData.regenRate);
            // Inform the UI to change the current health in the bar
            GameEventsManager.Instance.graphicEvents.ChangeCurrentHealthUI(healthData.regenRate);
            timer = 0;
        }
    }
}
