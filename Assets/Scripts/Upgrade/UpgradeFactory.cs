using UnityEngine;

public static class UpgradeFactory
{
    public static IAbility CreateAttackUpgrade(string type, IAttack statUpgrade)
    {
        switch(type)
        {
            case "Fire": return new FireAttackDecorator(statUpgrade);
            case "Water": return new WaterAttackDecorator(statUpgrade);
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

    public static IStamina CreateStaminUpgrade(string type, IStamina statUpgrade)
    {
        switch(type)
        {
            case "StaminaIncrease": return new StaminaMaxDecorator(statUpgrade);
            case "StaminaRegen": return new StaminaRegenDecorator(statUpgrade);
            default: return null;
        }   
    }
}
