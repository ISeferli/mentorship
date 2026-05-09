using System;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class SwordWeapon : MonoBehaviour
{
    [Header("Attack Settings")]
    [SerializeField] private PlayableStats stats;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private BoxCollider hitbox;

    public bool IsAttacking {set {isAttacking = value;}}

    // Is the character attacking
    public BaseAttackComposition attackSet;
    private bool isAttacking = false;
    private AttackElement swordElement = AttackElement.None;

    void Start()
    {
        attackSet = new BaseAttackComposition();
        hitbox.enabled = false;
        BaseAttack baseAttack = new BaseAttack(stats.GetStatValue("Attack"), 1, "Base");
        attackSet.AddAttack(baseAttack);
        UpdateAttackRange();
    }

    void Update()
    {
        // Informa all the attacks in the attackSet so all internal decorators update their timers
        if (attackSet != null)
        {
            for(int i=1; i < attackSet.GetAttackListLength(); i++)
            {
                Debug.Log("Attack type: " + attackSet.GetAttackByNo(i).attackData.id);
                attackSet.GetAttackByNo(i).AttackTick();
                if (attackSet.GetAttackByNo(i).attackData.cooldownTimer <= 0f)
                {
                    Debug.Log("Attack damage: " + attackSet.GetAttackByNo(i).attackData.damage);
                    attackSet.GetAttackByNo(i).PerformAttack(stats.GetStatValue("Attack"), null, CharacterMovement.Instance.gameObject);
                }
            }
        }
    }

    public void EnableHitbox()
    {
        isAttacking = true;
        hitbox.enabled = true;
    }

    public void DisableHitbox()
    {
        isAttacking = false;
        hitbox.enabled = false;
    }

    public void UpdateAttackRange()
    {
        int attackRange = attackSet.GetBaseAttack("Base").attackData.range;
        hitbox.size = new Vector3(1f, 1f, attackRange);
        hitbox.center = new Vector3(0, 0, attackRange / 2f);
    }

    public void HandleHit(Collider collider)
    {
        // When the collider of the sword hits an object with an Enemy tag
        if ((collider.CompareTag("Enemy") || collider.CompareTag("Boss")) && isAttacking)
        {
            for(int i=0; i < attackSet.GetAttackListLength(); i++)
            {
                Debug.Log("Attack type: " + attackSet.GetAttackByNo(i).attackData.id);
                Debug.Log("Attack damage: " + attackSet.GetAttackByNo(i).attackData.damage);
                attackSet.GetAttackByNo(i).PerformAttack(stats.GetStatValue("Attack"), collider.gameObject, this.gameObject);
            }
            if(collider.CompareTag("Boss"))
                GameEventsManager.Instance.graphicEvents.ChangeEnemyHealthUI(attackSet.GetBaseAttack("Base").attackData.damage);
        }
    }

    /// <summary>
    /// Update the upgrade in the Base Attack object
    /// </summary>
    /// <param name="extraAttack">Upgrade for the base attack</param>
    /// <param name="attackID">Attack ID to be upgraded</param>
    public void SetAttackAbility(IAttack extraAttack, string attackID)
    {
        BaseAttack newBaseAttack = new BaseAttack(stats.GetStatValue("Attack"), 1, attackID);
        attackSet.UpgradeSpecificAttack(attackID, extraAttack, newBaseAttack);
        if(attackID.Equals("Base"))
        {
            swordElement = extraAttack.attackData.element;
            GetComponent<Renderer>().material.color = extraAttack.attackData.color;
            if(extraAttack.attackData.effect)
                Instantiate(extraAttack.attackData.effect, this.transform);
            GameEventsManager.Instance.gameEvents.AbilityElemenyChosen(swordElement);
        }
        UpdateAttackRange();
    }
}
