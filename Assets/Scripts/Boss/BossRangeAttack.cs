using UnityEngine;
using UnityEngine.AI;

public class BossRangeAttack : StateMachineBehaviour
{
    NavMeshAgent bossAgent;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        bossAgent = animator.GetComponent<NavMeshAgent>();
        if (bossAgent != null)
        {
            // Stop the boss from moving
            bossAgent.isStopped = true;
            bossAgent.velocity = Vector3.zero;
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
