using UnityEngine;

public class WaterfallAttackDecorator : ElementalDecorator
{
    private float slowMultiplier;
    public WaterfallAttackDecorator(int damageAmount, float slowAmount, GameObject attackPrefab, IAttack specificAttack) : base(specificAttack)
    {
        attackData.damage += damageAmount;
        attackData.attackPrefab = attackPrefab;
        attackData.cooldown = 10f;
        this.slowMultiplier = slowAmount;
    }

    public override void PerformAttack(int pointsDamage, GameObject personToHit, GameObject attacker)
    {
        base.PerformAttack(pointsDamage, personToHit, attacker);
        if (attackData.cooldownTimer <= 0 || attacker.CompareTag("Boss"))
        {
            if (attackData.attackPrefab == null) return;
            float spawnDistance = 2.5f; 
            Vector3 spawnPosition = attacker.transform.position + attacker.transform.forward * spawnDistance;
            // Keep it on the ground level if your character's pivot is at their feet
            spawnPosition.y = attacker.transform.position.y;
            GameObject waterfall = GameObject.Instantiate(attackData.attackPrefab, spawnPosition, attacker.transform.rotation);
            // Setup the logic for the waterfall effect
            Waterfall waterfallEffect = waterfall.GetComponent<Waterfall>();
            if (waterfallEffect != null)
                waterfallEffect.Initialize(attackData.damage, slowMultiplier);
            attackData.cooldownTimer = attackData.cooldown;
        }
    }
}