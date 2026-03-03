using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [Header("Enemy Movement Settings")]
    [SerializeField] private float moveSpeed = 4f;
    
    private NavMeshAgent enemyAgent;

    private void Awake()
    {
        enemyAgent = GetComponent<NavMeshAgent>();
        enemyAgent.speed = moveSpeed;
    }

    public void MoveTo(Vector3 targetPosition)
    {
        enemyAgent.SetDestination(targetPosition);
    }
}
