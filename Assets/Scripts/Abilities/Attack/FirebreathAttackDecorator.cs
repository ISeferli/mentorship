using UnityEngine;

public class FirebreathAttackDecorator : ElementalDecorator
{
    public FirebreathAttackDecorator(int damageAmount, GameObject attackPrefab, IAttack specificAttack) : base(specificAttack)
    {
        attackData.damage += damageAmount;
        attackData.attackPrefab = attackPrefab;
        attackData.cooldown = 10f;
    }

    public override void PerformAttack(int pointsDamage, GameObject personToHit, GameObject attacker)
    {
        base.PerformAttack(pointsDamage, personToHit, attacker);
        if (attackData.cooldownTimer <= 0 || attacker.CompareTag("Boss"))
        {
            if (attackData.attackPrefab == null) return;
            // Spawn the fire breath at the attacker's position, parented to the attacker 
            // so it moves with them as they turn.
            GameObject fireBreath = GameObject.Instantiate(attackData.attackPrefab, attacker.transform);
            // Offset it to come out of the "mouth" or front
            fireBreath.transform.localPosition = new Vector3(0, 1.5f, 1.0f); 
            Firebreath effect = fireBreath.GetComponent<Firebreath>();
            if (effect != null)
                effect.Initialize(attackData.damage);
            attackData.cooldownTimer = attackData.cooldown;
        }
    }
}