using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    /// <summary>
    /// Damages the player health. Informs the UI health bar to decrease by the
    /// points of damage the enemy does and informs the health component to decrease
    /// health
    /// </summary>
    /// <param name="targetHealth">Targets health component</param>
    /// <param name="pointsOfDamage">Points of damage that the enemy does</param>
    public void DamagePlayer(Health targetHealth, int pointsOfDamage)
    {
        GameEventsManager.Instance.graphicEvents.ChangeCurrentHealthUI(-pointsOfDamage);
        targetHealth.DamageHealth(pointsOfDamage);
    }
}
