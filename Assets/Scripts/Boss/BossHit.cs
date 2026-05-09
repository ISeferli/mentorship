using UnityEngine;

public class BossHit : StateMachineBehaviour
{
    private Health bossHealth;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       bossHealth = animator.GetComponent<Health>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (bossHealth.DetectDeath())
        {        
            Debug.Log("Boss should die");
            animator.SetTrigger("Death");
            GameEventsManager.Instance.gameEvents.RunCompleteEvent();
            Time.timeScale = 0f;
        }
    }
}
