using UnityEngine;

public class Enemy : MonoBehaviour
{
    private EnemyAttack enemyAttack;

    void Awake()
    {
        enemyAttack = GetComponent<EnemyAttack>();
    }
    
    /// <summary>
    /// Initializing a specific Enemy object based on the specified arguments
    /// </summary>
    /// <param name="profile">The attack profile of the enemy</param>
    /// <param name="stats">The base stats of the enemy</param>
    public void Initialize(AttackProfile profile, PlayableStats stats)
    {
        IAttack baseAttack = new BaseAttack(stats.GetStatValue("Attack"), 1, "Base");
        enemyAttack.EnemyAttackLibrary.AddAttack(EnemyAttackFactory.CreateElementalAttack(profile, stats, baseAttack, enemyAttack));
    }
}