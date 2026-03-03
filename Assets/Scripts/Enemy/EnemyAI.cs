using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(EnemyAttack), typeof(EnemyMovement), typeof(Rigidbody))]
[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAI : MonoBehaviour
{
    [SerializeField] private PlayableStats stats;
    private enum EnemyState
    {
        Roaming,
        Chase,
        Attack,
        Damage,
        Death
    }

    // Necessary components for enemy logic
    private EnemyMovement enemyMovement;
    private EnemyAttack enemyAttack;
    private EnemyState enemyState;
    private NavMeshAgent enemyAgent;
    private GameObject targetPlayer;

    // Enemy changing settings
    private bool canAttack = true;
    private int pointsOfDamage = 0;


    private void Awake()
    {
        // Initialize the state of the enemy to roaming
        enemyState = EnemyState.Roaming;
        targetPlayer = GameObject.FindGameObjectWithTag("Player");
        enemyMovement = GetComponent<EnemyMovement>();
        enemyAttack = GetComponent<EnemyAttack>();
        enemyAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        HandleStates();
    }

    private void HandleStates()
    {
        switch (enemyState)
        {
            case EnemyState.Roaming:
                enemyAgent.stoppingDistance = 0;
                if(!enemyAgent.hasPath) StartCoroutine(RoamingRoutine());
                if(CanSeePlayer()) enemyState = EnemyState.Chase;
                break;
            case EnemyState.Chase:
                enemyAgent.stoppingDistance = 2;
                GetToPlayer();
                if(enemyAgent.remainingDistance <= enemyAgent.stoppingDistance && !enemyAgent.pathPending) enemyState = EnemyState.Attack;
                if(ForgetPlayer())
                {
                    enemyState = EnemyState.Roaming;
                    enemyAgent.ResetPath();
                }
                break;
            case EnemyState.Attack:
                if(DistanceToPlayer() > enemyAgent.stoppingDistance + 2) enemyState = EnemyState.Chase;
                if (DistanceToPlayer() < 2.5 && canAttack) StartCoroutine(AttackRoutine());
                break;
            case EnemyState.Damage:
                GetComponent<Health>().DamageHealth(pointsOfDamage);
                pointsOfDamage = 0;
                if(GetComponent<Health>().DetectDeath()) enemyState = EnemyState.Death;
                else enemyState = EnemyState.Chase;
                break;
            case EnemyState.Death:
                GameEventsManager.instance.gameEvents.EnemyDeathEvent();
                Destroy(gameObject);
                break;
        }
    }

    /// <summary>
    /// Function that handles roaming state of the enemy
    /// </summary>
    /// <returns>Passes a <b>Vector3</b> each 2 seconds to the EnemyMovement script to handle the move direction</returns>
    private IEnumerator RoamingRoutine()
    {
        while (enemyState == EnemyState.Roaming)
        {
            Vector3 roamingPosition = GetRoamingPosition();
            enemyMovement.MoveTo(roamingPosition);
            yield return new WaitForSeconds(2f);
        }
    }

    /// <summary>
    /// Calculates a new <b>Vector3</b> variable that points out the position that the enemy will move to while
    /// roaming
    /// </summary>
    /// <returns><b>Vector3</b> position variable</returns>
    private Vector3 GetRoamingPosition()
    {
        // return new Vector3(Random.Range(-3f, 3f), transform.position.y, Random.Range(-3f, 3f));
        return transform.position + new Vector3(Random.Range(-3f, 3f), 0f, Random.Range(-3f, 3f));
    }

    /// <summary>
    /// Checks if the enemy is in distance of the target player
    /// </summary>
    /// <returns><b>boolean</b> true if the target is 
    /// closer than 10 metres away, false in the other case.</returns>
    private bool CanSeePlayer()
    {
        if (DistanceToPlayer() < 10)
            return true;
        return false;
    }

    /// <summary>
    /// Find the distance of the target player.
    /// </summary>
    private float DistanceToPlayer()
    {
        return Vector3.Distance(targetPlayer.transform.position, transform.position);
    }

    /// <summary>
    /// Function that handles chasing the player when the Chase state has begun
    /// </summary>
    /// <returns></returns>
    private void GetToPlayer()
    {
        enemyMovement.MoveTo(targetPlayer.transform.position);
    }

    /// <summary>
    /// After the player gets far away from the enemy, the enemy forgets about them.
    /// </summary>
    private bool ForgetPlayer()
    {
        if (DistanceToPlayer() > 20)
            return true;
        return false;
    }

    private IEnumerator AttackRoutine()
    {
        canAttack = false;
        enemyAttack.DamagePlayer(targetPlayer.GetComponent<Health>(), stats.GetStatValue("Attack"));
        yield return new WaitForSeconds(4f);
        canAttack = true;
    }

    public void TakeDamage(int damagePoints)
    {
        pointsOfDamage = damagePoints;
        enemyState = EnemyState.Damage;
    }
}


// https://gamedev.tv/courses/unity-2d-rpg-combat/sword-animation/253