using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    [Header("Necessary Attack Components")]
    [SerializeField] private Animator charAnimator;
    [SerializeField] private SwordWeapon rightSword;
    [SerializeField] private SwordWeapon leftSword;

    private bool leftAttack = false;
    private bool rightAttack = false;
    public SwordWeapon upgradeSword;

    void Start()
    {
        upgradeSword = leftSword;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !leftAttack)
        {
            charAnimator.SetTrigger("LeftAttack");
            leftSword.EnableHitbox();
            leftAttack = true;
        }

        if(Input.GetMouseButtonDown(1) && !rightAttack)
        {
            charAnimator.SetTrigger("RightAttack");
            rightSword.EnableHitbox();
            rightAttack = true;
        }
    }

    /// <summary>
    /// Reset character sword back to default state
    /// </summary>
    public void ResetUpgrades()
    {
        upgradeSword = leftSword;
    }

    /// <summary>
    /// Function that is called on animation and handles the
    /// end of the left attack
    /// </summary>
    public void EndLeftAttack()
    {
        leftAttack = false;
        leftSword.DisableHitbox();
    }

    /// <summary>
    /// Function that is called on animation and handles the
    /// end of the right attack
    /// </summary>
    public void EndRightAttack()
    {
        rightAttack = false;
        rightSword.DisableHitbox();
    }
}
