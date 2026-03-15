using UnityEngine;

public class BossAI : MonoBehaviour
{
    [SerializeField] private PlayableStats stats;
    private enum BossState
    {
        Idle,
        Melee,
        Special,
        Range,
        Death,
        Damage
    }

    // Necessary components for boss logic
    private GameObject targetPlayer;
    private EnemyAttack enemyAttack;
    private BossState bossState;

    void Start()
    {
        enemyAttack = GetComponent<EnemyAttack>();
        targetPlayer = GameObject.FindGameObjectWithTag("Player");
        bossState = BossState.Idle;
    }

    private void Update()
    {
        HandleStates();
    }

    private void HandleStates()
    {
        switch (bossState)
        {
            case BossState.Idle:
                Debug.Log("Idle");
                bossState = BossState.Melee;
                break;
            case BossState.Melee:
                Debug.Log("Melee");
                enemyAttack.AttackPlayer();
                bossState = BossState.Range;
                break;
            case BossState.Range:
                if (enemyAttack.BaseAttack is ElementalDecorator decorator)
                    decorator.UseEffect("Projectile", targetPlayer);
                break;
            case BossState.Special:
                break;
            case BossState.Damage:
                Debug.Log("Damage");
                break;
            case BossState.Death:
                Debug.Log("Death");
                Destroy(gameObject);
                break;
        }
    }

}