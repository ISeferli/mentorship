using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy attack profile")]
    [SerializeField] public AttackProfile profile;
    [SerializeField] public PlayableStats stats;

    private EnemyAttack enemyAttack;

    void Awake()
    {
        enemyAttack = GetComponent<EnemyAttack>();
    }
    
    /// <summary>
    /// Initializing a specific Enemy object based on the specified arguments
    /// </summary>
    public void Initialize()
    {
        IAttack baseAttack = new BaseAttack(stats.GetStatValue("Attack"), 1, "Base");
        enemyAttack.EnemyAttackLibrary.AddAttack(EnemyAttackFactory.CreateElementalAttack(profile, stats, baseAttack, enemyAttack));
    }
}