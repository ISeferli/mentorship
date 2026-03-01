using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    [Header("Necessary Attack Components")]
    [SerializeField] private Animator charAnimator;
    [SerializeField] private SwordWeapon rightSword;
    [SerializeField] private SwordWeapon leftSword;

    private bool leftAttack = false;
    private bool rightAttack = false;

    void Start()
    {
        // rightSword.SetAttackAbility(new FireAttackDecorator(rightSword.baseAttack));
        // leftSword.SetAttackAbility(new WaterAttackDecorator(leftSword.baseAttack));
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !leftAttack)
        {
            charAnimator.SetTrigger("LeftAttack");
            leftSword.IsAttacking = true;
            leftAttack = true;
        }

        if(Input.GetMouseButtonDown(1) && !rightAttack)
        {
            charAnimator.SetTrigger("RightAttack");
            rightSword.IsAttacking = true;
            rightAttack = true;
        }
    }

    public void EndLeftAttack()
    {
        leftAttack = false;
        leftSword.IsAttacking = false;
    }

    public void EndRightAttack()
    {
        rightAttack = false;
        rightSword.IsAttacking = false;
    }
}
