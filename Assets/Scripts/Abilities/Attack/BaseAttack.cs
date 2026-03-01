using UnityEngine;

public class BaseAttack : IAttack
{
    public AttackData attackData { get; set; }

    public BaseAttack(int baseDamage)
    {
        attackData = new AttackData
        {
            betterColor = Color.white,
            color = Color.white,
            weakColor = Color.white,
            damage = baseDamage
        };
    }

    public void PerformAttack(int pointsDamage, GameObject personToHit)
    {
        Debug.Log("Hand Attack: " + attackData.damage);
        // Detect enemies in range of attack
        personToHit.GetComponent<EnemyAI>().TakeDamage(attackData.damage);
    }

    public void GetAbilityUpgrade(string type, IAbility statUpgrade)
    {
        Debug.Log("Upgraded ability");
    }
}
