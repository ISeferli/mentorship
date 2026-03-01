using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public void DamagePlayer(Health targetHealth, int pointsOfDamage)
    {
        GameEventsManager.instance.graphicEvents.ChangeHealthUI(pointsOfDamage);
        targetHealth.DamageHealth(pointsOfDamage);
    }
}
