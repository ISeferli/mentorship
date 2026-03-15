using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public static class UpgradeFactory
{
    private static Dictionary<string, Func<int, IAbility, IAbility>> availableUpgrades = new Dictionary<string, Func<int, IAbility, IAbility>>()
    {
        { "Fire", (amount, stat) => new FireAttackDecorator(amount, (IAttack)stat) },
        { "Water", (amount, stat) => new WaterAttackDecorator(amount, (IAttack)stat) },
        { "HealthIncrease", (amount, stat) => new HealthMaxIncreaseDecorator((IHealth)stat, amount) },
        { "HealthRegen", (amount, stat) => new HealthRegenDecorator((IHealth)stat, amount) },
        { "StaminaIncrease", (amount, stat) => new StaminaMaxDecorator((IStamina)stat) },
        { "StaminaRegen", (amount, stat) => new StaminaRegenDecorator((IStamina)stat, amount) }
    };

    public static IEffect CreateEffect(string effectName)
    {
        IEffect effect = null;
        switch(effectName)
        {
            case "Projectile":
                effect = new ProjectileEffect();
                break;
        };
        return effect;
    }

    public static T CreateUpgrade<T>(string type, int amount, T stat) where T : IAbility
    {
        return (T)availableUpgrades[type](amount, stat);
    }
}
