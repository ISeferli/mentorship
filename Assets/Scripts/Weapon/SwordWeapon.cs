using System;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class SwordWeapon : MonoBehaviour
{
    [Header("Attack Settings")]
    [SerializeField] private PlayableStats stats;
    [SerializeField] private LayerMask enemyLayer;
    public bool IsAttacking {set {isAttacking = value;}}

    // Is the character attacking
    public IAttack baseAttack;
    private bool isAttacking = false;

    void Start()
    {
        baseAttack = new BaseAttack(stats.GetStatValue("Attack"));
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Enemy") && isAttacking)
        {
            baseAttack.PerformAttack(stats.GetStatValue("Attack"), collider.gameObject);
        }
    }

    public void SetAttackAbility(AttackDecorator extraAttack)
    {
        baseAttack = extraAttack;
        GetComponent<Renderer>().material.color = extraAttack.attackData.color;
    }
}
