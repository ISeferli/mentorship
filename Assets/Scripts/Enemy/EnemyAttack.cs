using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public void DamagePlayer(Health targetHealth, int pointsOfDamage)
    {
        targetHealth.DamageHealth(pointsOfDamage);
    }
}
