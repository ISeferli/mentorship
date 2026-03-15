using UnityEngine;

public class Enemy : MonoBehaviour
{
    private EnemyAttack enemyAttack;

    void Awake()
    {
        enemyAttack = GetComponent<EnemyAttack>();
    }

    public void Initialize(AttackProfile profile, PlayableStats stats)
    {
        IAttack baseAttack = new BaseAttack(stats.GetStatValue("Attack"), 1);
        enemyAttack.BaseAttack = EnemyAttackFactory.CreateAttack(profile, stats, baseAttack, enemyAttack);
    }
}