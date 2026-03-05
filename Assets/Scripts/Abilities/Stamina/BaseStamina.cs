using System.Collections;
using UnityEngine;

public class BaseStamina : IStamina
{
    public StaminaData staminaData { get; set; }
    
    /// <summary>
    /// Constructor of the base stamina. Takes specific number of stamina uses
    /// for max and current stamina that comes from character scriptable object.
    /// </summary>
    /// <param name="staminaUses">Uses that the character can use dash</param>
    public BaseStamina(int staminaUses)
    {
        staminaData = new StaminaData
        {
            maxStaminaUses = staminaUses,
            currentStaminaUses = staminaUses,
            regenRate = 1,
            dashTime = .2f,
            dashCooldown = 2f,
        };
    }
    
    /// <summary>
    /// Checks if the character can use dash
    /// </summary>
    /// <returns>True if the current uses are non zero, false otherwise</returns>
    public bool CanDash() => staminaData.currentStaminaUses > 0;
    private float regenTimer = 0f;

    /// <summary>
    /// Handles the dash ability. For each time the character dashes, the stamina bar
    /// decreases and for specific amount of time (dash cooldown) it waits for the dash to
    /// be called again.
    /// </summary>
    /// <param name="onDashStart">Function that handles what happens at the start of the dash</param>
    /// <param name="onDashEnd">Function that handles what happens at the end of the dash</param>
    /// <returns></returns>
    public IEnumerator DashRoutine(System.Action onDashStart, System.Action onDashEnd)
    {
        staminaData.currentStaminaUses--;
        GameEventsManager.instance.graphicEvents.ChangeStaminaUI(false);
        onDashStart?.Invoke();
        yield return new WaitForSeconds(staminaData.dashTime);
        onDashEnd?.Invoke();
        yield return new WaitForSeconds(staminaData.dashCooldown);
    }

    /// <summary>
    /// Regeneration function that for every point of time until the dash cooldown
    /// it regenerates the stamina
    /// </summary>
    public void RegenTick()
    {
        regenTimer += Time.deltaTime;
        if(regenTimer >= staminaData.dashCooldown)
        {
            staminaData.currentStaminaUses++;
            GameEventsManager.instance.graphicEvents.ChangeStaminaUI(true);
            regenTimer = 0f;
        }
    }
}
