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

    public void Initialize(AttackProfile profile, PlayableStats stats)
    {
        IAttack baseAttack = new BaseAttack(stats.GetStatValue("Attack"), 1);
        enemyAttack.BaseAttack = EnemyAttackFactory.CreateAttack(profile, stats, baseAttack, enemyAttack);
        foreach(var effect in profile.additionalEffects)
        {
            // Add from factory the specific effect based on the string name
            if (enemyAttack.BaseAttack is ElementalDecorator decorator)
                decorator.AddEffect(EnemyAttackFactory.CreateEffect(effect.effectID));
        }
    }
}