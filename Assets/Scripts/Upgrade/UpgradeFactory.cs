using UnityEngine;

public static class UpgradeFactory
{
    public static IAttack CreateAttackUpgrade(string type, int amount, IAttack statUpgrade)
    {
        switch(type)
        {
            case "Fire": return new FireAttackDecorator(amount, statUpgrade);
            case "Water": return new WaterAttackDecorator(amount, statUpgrade);
            default: return null;
        }   
    }

    public static IHealth CreateHealthUpgrade(string type, int amount, IHealth healthToWrap)
    {
        switch(type)
        {
            case "HealthIncrease": 
                return new HealthMaxIncreaseDecorator(healthToWrap, amount);
            case "HealthRegen":
                return new HealthRegenDecorator(healthToWrap, amount);
            default: return null;
        }
    }

    public static IStamina CreateStaminUpgrade(string type, int amount, IStamina statUpgrade)
    {
        switch(type)
        {
            case "StaminaIncrease": return new StaminaMaxDecorator(statUpgrade);
            case "StaminaRegen": return new StaminaRegenDecorator(statUpgrade, amount);
            default: return null;
        }   
    }
}
