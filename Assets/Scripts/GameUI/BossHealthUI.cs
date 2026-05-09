using UnityEngine;
using UnityEngine.UI;

public class BossHealthUI : MonoBehaviour
{
    [Header("Boss Playable Stats")]
    [SerializeField] PlayableStats stats;

    [Header("Boss Health Bar Settings")]
    [SerializeField] Slider healthBar;

    void OnEnable()
    {
        GameEventsManager.Instance.graphicEvents.OnEnemyHealthChange += ChangeBossHealthBar;
    }

    void OnDisable()
    {
        GameEventsManager.Instance.graphicEvents.OnEnemyHealthChange -= ChangeBossHealthBar;
    }

    void Start()
    {
        healthBar.maxValue = stats.GetStatValue("Health");
        healthBar.value = stats.GetStatValue("Health");
    }

    private void ChangeBossHealthBar(int damage)
    {
        healthBar.value -= damage;
    }
}
