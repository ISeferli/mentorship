using UnityEngine;
using UnityEngine.AI;

public class BossSpecialAttack : StateMachineBehaviour
{
    NavMeshAgent bossAgent;
    EnemyAttack bossAttack;
    bool hasAttacked;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        bossAgent = animator.GetComponent<NavMeshAgent>();
        bossAttack = animator.GetComponent<EnemyAttack>();
        hasAttacked = false;
        if (bossAgent != null)
        {
            // Stop the boss from moving
            bossAgent.isStopped = true;
            bossAgent.velocity = Vector3.zero;
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!hasAttacked )
        {
            if (bossAttack != null)
                bossAttack.BossSpecialAttack();
            hasAttacked = true;
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (bossAgent != null)
        {
            // Resume the agent's ability to move
            bossAgent.isStopped = false;
        }  
    }
}
