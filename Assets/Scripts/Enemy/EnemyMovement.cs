using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [Header("Necessary Enemy Components")]
    [SerializeField] private NavMeshAgent enemyAgent;

    [Header("Enemy Movement Settings")]
    [SerializeField] private float moveSpeed = 4f;

    private void Start()
    {
        enemyAgent.speed = moveSpeed;
    }

    public void MoveTo(Vector3 targetPosition)
    {
        enemyAgent.SetDestination(targetPosition);
    }
}
