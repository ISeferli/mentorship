using System.Collections;

public interface IStamina : IAbility
{
    public StaminaData staminaData { get; set; }
    public bool CanDash();
    public IEnumerator DashRoutine(System.Action onDashStart, System.Action onDashEnd);
    public void RegenTick();
}

public class StaminaData
{
    public int maxStaminaUses;
    public int currentStaminaUses;
    public int regenRate;
    public float dashTime;
    public float dashCooldown;
}