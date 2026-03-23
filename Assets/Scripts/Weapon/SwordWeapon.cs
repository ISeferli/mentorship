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
    public IAttack baseAttack;
    private bool isAttacking = false;

    void Start()
    {
        hitbox.enabled = false;
        baseAttack = new BaseAttack(stats.GetStatValue("Attack"), 1);
        UpdateAttackRange();
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
        int attackRange = baseAttack.attackData.range;
        hitbox.size = new Vector3(1f, 1f, attackRange);
        hitbox.center = new Vector3(0, 0, attackRange / 2f);
    }

    public void HandleHit(Collider collider)
    {
        // When the collider of the sword hits an object with an Enemy tag
        if ((collider.CompareTag("Enemy") || collider.CompareTag("Boss")) && isAttacking)
        {
            baseAttack.PerformAttack(stats.GetStatValue("Attack"), collider.gameObject);
        }
    }

    /// <summary>
    /// Update the upgrade in the Base Attack object
    /// </summary>
    /// <param name="extraAttack">Upgrade for the base attack</param>
    public void SetAttackAbility(ElementalDecorator extraAttack)
    {
        baseAttack = extraAttack;
        GetComponent<Renderer>().material.color = extraAttack.attackData.color;
        UpdateAttackRange();
    }
}
