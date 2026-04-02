using UnityEngine;

public class Boss : MonoBehaviour
{
    [Header("Boss Profile")]
    [SerializeField] private PlayableStats bossStats;
    [SerializeField] private AttackProfile bossAttackProfile;
    private EnemyAttack enemyAttack;

    void Awake()
    {
        enemyAttack = GetComponent<EnemyAttack>();
        Initialize(bossAttackProfile, bossStats);
    }

    /// <summary>
    /// Initializing a specific Boss object based on the specified arguments
    /// </summary>
    /// <param name="profile"> Boss attack profile </param>
    /// <param name="stats"> Boss specific stats </param>
    public void Initialize(AttackProfile profile, PlayableStats stats)
    {
        IAttack baseAttack = new BaseAttack(stats.GetStatValue("Attack"), 1, "Base");
        enemyAttack.EnemyAttackLibrary.AddAttack(EnemyAttackFactory.CreateElementalAttack(profile, stats, baseAttack, enemyAttack));
        foreach (var attack in profile.additionalAttacks)
        {
            // Add from factory the specific attack based on the ID name
            IAttack additionalAttack = new BaseAttack(stats.GetStatValue("Attack"), 1, attack.attackID);
            enemyAttack.EnemyAttackLibrary.AddAttack(EnemyAttackFactory.CreateAttack(attack.attackDecoratorID, attack.attackDamage, attack.attackRadius, attack.attackPrefab, additionalAttack));
        }
    }
}