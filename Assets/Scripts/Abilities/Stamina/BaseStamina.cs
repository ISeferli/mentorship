using System.Collections;
using UnityEngine;

public class BaseStamina : IStamina
{
    public StaminaData staminaData { get; set; }
    public BaseStamina(int staminaUses)
    {
        staminaData = new StaminaData
        {
            maxStaminaUses = staminaUses,
            currentStaminaUses = staminaUses,
            regenRate = 1,
            dashTime = .2f,
            dashCooldown = .25f,
        };
    }
    public bool CanDash() => staminaData.currentStaminaUses > 0;

    private float regenTimer = 0f;
    public IEnumerator DashRoutine(System.Action onDashStart, System.Action onDashEnd)
    {
        staminaData.currentStaminaUses--;
        GameEventsManager.instance.graphicEvents.ChangeStaminaUI(false);
        onDashStart?.Invoke();
        yield return new WaitForSeconds(staminaData.dashTime);
        onDashEnd?.Invoke();
        yield return new WaitForSeconds(staminaData.dashCooldown);
    }

    public void RegenTick()
    {
        regenTimer += Time.deltaTime;
        if(regenTimer >= 2f)
        {
            staminaData.currentStaminaUses++;
            GameEventsManager.instance.graphicEvents.ChangeStaminaUI(true);
            regenTimer = 0f;
        }
    }

    public void GetAbilityUpgrade(string type, IAbility statUpgrade)
    {
        throw new System.NotImplementedException();
    }
}
