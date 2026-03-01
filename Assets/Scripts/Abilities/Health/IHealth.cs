using UnityEngine;

public interface IHealth : IAbility
{
    public HealthData healthData { get; set; }
    public void ChangeHealth(int healthPoints);
}

public class HealthData
{
    public int maxHealth;
    public int currentHealth;
}