using UnityEngine;

public class FallingBoulderDecorator : ElementalDecorator
{
    private int radius;

    public FallingBoulderDecorator(int damageAmount, int radius, GameObject attackPrefab, IAttack specificAttack) : base(specificAttack)
    {
        attackData.damage += damageAmount;
        attackData.attackPrefab = attackPrefab;
        attackData.cooldown = 4f;
        this.radius = radius;
    }

    public override void PerformAttack(int pointsDamage, GameObject personToHit, GameObject attacker)
    {
        base.PerformAttack(pointsDamage, personToHit, attacker);
        bool isBoss = attacker.CompareTag("Boss");
        bool canAttack = isBoss || attackData.cooldownTimer <= 0;
        if (canAttack)
        {
            if (attackData.attackPrefab == null) return;
            // Define the center of the impact zone
            Vector3 centerPoint = personToHit.transform.position;
            // Spawn multiple boulders
            for (int i = 0; i < 5; i++)
            {
                // Calculate a random point within the radius on the XZ plane
                Vector2 randomOffset = Random.insideUnitCircle * this.radius;
                Vector3 spawnPos = new Vector3(centerPoint.x + randomOffset.x, centerPoint.y + 10f, centerPoint.z + randomOffset.y);
                GameObject boulder = GameObject.Instantiate(attackData.attackPrefab, spawnPos, Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360)));
                // You can reuse your Projectile script or create a simple FallingObject script
                Projectile proj = boulder.GetComponent<Projectile>();
                if (proj != null)
                {
                    // Direction is straight down
                    proj.Initialize(Vector3.down, attackData.damage);
                }
            }

            attackData.cooldownTimer = attackData.cooldown;
            Debug.Log("Sky Rain attack triggered!");
        }
    }
}