using System;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class SwordWeapon : MonoBehaviour
{
    [Header("Attack Settings")]
    [SerializeField] private PlayableStats stats;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private Collider hitbox;

    public bool IsAttacking {set {isAttacking = value;}}

    // Is the character attacking
    public IAttack baseAttack;
    private bool isAttacking = false;

    void Start()
    {
        hitbox.enabled = false;
        baseAttack = new BaseAttack(stats.GetStatValue("Attack"));
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

    public void HandleHit(Collider collider)
    {
        // When the collider of the sword hits an object with an Enemy tag
        if (collider.CompareTag("Enemy") && isAttacking)
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
    }
}
