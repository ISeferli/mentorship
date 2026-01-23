using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    [Header("Necessary Attack Components")]
    [SerializeField] private Animator charAnimator;
    [SerializeField] private RightHandSword rightSword;
    [SerializeField] private LeftHandSword leftSword;

    private bool leftAttack = false;
    private bool rightAttack = false;

    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !leftAttack)
        {
            Debug.Log("Left Attack");
            charAnimator.SetTrigger("LeftAttack");
            leftSword.PerformAttack(null, GetComponent<CharacterStats>());
            leftAttack = true;
        }

        if(Input.GetMouseButtonDown(1) && !rightAttack)
        {
            Debug.Log("Right Attack");
            charAnimator.SetTrigger("RightAttack");
            rightSword.PerformAttack(null, GetComponent<CharacterStats>());
            rightAttack = true;
        }
    }

    public void EndLeftAttack()
    {
        leftAttack = false;
    }

    public void EndRightAttack()
    {
        rightAttack = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag.Equals("Enemy"))
            Debug.Log("Collide");
    }
}
