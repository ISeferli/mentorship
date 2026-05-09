using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public static class UpgradeFactory
{
    private static Dictionary<string, Func<Upgrade, IAbility, IAbility>> availableUpgrades = 
        new Dictionary<string, Func<Upgrade, IAbility, IAbility>>()
    {
        { "Fire", (upgr, stat) => new FireAttackDecorator(upgr.amount, upgr.upgradeEffect, upgr.element, (IAttack)stat) },
        { "Water", (upgr, stat) => new WaterAttackDecorator(upgr.amount, upgr.upgradeEffect, upgr.element, (IAttack)stat) },
        { "HealthIncrease", (upgr, stat) => new HealthMaxIncreaseDecorator((IHealth)stat, upgr.amount) },
        { "HealthRegen", (upgr, stat) => new HealthRegenDecorator((IHealth)stat, upgr.amount) },
        { "StaminaIncrease", (upgr, stat) => new StaminaMaxDecorator((IStamina)stat) },
        { "StaminaRegen", (upgr, stat) => new StaminaRegenDecorator((IStamina)stat, upgr.amount) },
        { "Projectile", (upgr, stat) => new ProjectileAttackDecorator(upgr.amount, upgr.upgradePrefab, (IAttack)stat)},
        { "Waterfall", (upgr, stat) => new WaterfallAttackDecorator(upgr.amount, 3, upgr.upgradePrefab, (IAttack)stat)},
        { "Firebreath", (upgr, stat) => new FirebreathAttackDecorator(upgr.amount, upgr.upgradePrefab, (IAttack)stat)},
    };

    public static T CreateUpgrade<T>(Upgrade upgrade, T stat) where T : IAbility
    {
        if (availableUpgrades.TryGetValue(upgrade.upgradeName, out var factory))
        {
            return (T)factory(upgrade, stat);
        }
        return stat;
    }
}
