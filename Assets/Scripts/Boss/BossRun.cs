using UnityEngine;
using UnityEngine.AI;

public class BossRun : StateMachineBehaviour
{
    private readonly float attackRange = 3f;
    private float rangedRange = 10f;
    private float decisionCooldown = 2f;
    private float timer;

    Transform player;
    NavMeshAgent bossAgent;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       player = GameObject.FindGameObjectWithTag("Player").transform;
       bossAgent = animator.GetComponent<NavMeshAgent>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Basic logic of attack system on boss
        bossAgent.SetDestination(player.position);
        timer += Time.deltaTime;
        if (timer >= decisionCooldown)
        {
            float distance = Vector3.Distance(player.position, bossAgent.transform.position);
            if (distance <= attackRange)
            {
                // Does mostly melee damage when close in range
                if (Random.value < 0.9f)
                    animator.SetTrigger("Attack");
                else
                    animator.SetTrigger("Attack2");
            }
            else if (distance <= rangedRange)
            {
                // Randomly choose which attack to do
                if (Random.value < 0.3f)
                    animator.SetTrigger("Attack");
                else
                    animator.SetTrigger("Attack2");
            }
            else
            {
                // When boss is far does range attack
                animator.SetTrigger("Attack2");
            }
            timer = 0f;
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
        animator.ResetTrigger("Attack2");
        animator.ResetTrigger("Attack3");
    }
}