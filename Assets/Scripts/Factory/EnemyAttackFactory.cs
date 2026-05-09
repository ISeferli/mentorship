using UnityEngine;

public static class EnemyAttackFactory
{
    public static IAttack CreateElementalAttack(AttackProfile profile, PlayableStats stats, IAttack attack, EnemyAttack enemyAttack)
    {
        switch(profile.elements)
        {
            case AttackElement.Fire:
                attack = new FireAttackDecorator(4, null, AttackElement.Fire, attack);
                break;
            case AttackElement.Water:
                attack = new WaterAttackDecorator(7, null, AttackElement.Water, attack);
                break;
        }
        return attack;
    }

    public static IAttack CreateAttack(string attackDecID, int effectDamage, int attackRadius, GameObject effectPrefab, IAttack attack)
    {
        switch(attackDecID)
        {
            case "Projectile":
                attack = new ProjectileAttackDecorator(effectDamage, effectPrefab, attack);
                break;
            case "Spawn":
                attack = new SpawnAttackDecorator(effectDamage, attackRadius, effectPrefab, attack);
                break;
            case "FireBoulder":
                attack = new FallingBoulderDecorator(effectDamage, attackRadius, effectPrefab, attack);
                break;
        };
        return attack;
    }
}