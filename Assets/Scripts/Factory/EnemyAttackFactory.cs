using UnityEngine;

public static class EnemyAttackFactory
{
    public static IAttack CreateAttack(AttackProfile profile, PlayableStats stats, IAttack attack, EnemyAttack enemyAttack)
    {
        switch(profile.elements)
        {
            case AttackElement.Fire:
                attack = new FireAttackDecorator(4, attack);
                break;
            case AttackElement.Water:
                attack = new WaterAttackDecorator(7, attack);
                break;
        }
        return attack;
    }

    public static IEffect CreateEffect(string effectName, int effectDamage, GameObject effectPrefab)
    {
        IEffect effect = null;
        switch(effectName)
        {
            case "Projectile":
                effect = new ProjectileEffect(effectDamage, effectPrefab);
                break;
            case "Spawn":
                effect = new SpawnEffect(effectPrefab);
                break;
        };
        return effect;
    }
}