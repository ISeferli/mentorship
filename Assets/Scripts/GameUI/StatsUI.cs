using UnityEngine;
using UnityEngine.UI;

public class StatsUI : MonoBehaviour
{
    [Header("Starting Stats")]
    [SerializeField] private PlayableStats stats;

    [Header("Health Bar Settings")]
    [SerializeField] Slider healthBar;

    [Header("Stamina Bar Settings")]
    [SerializeField] Slider staminaBar;

    void OnEnable()
    {
        GameEventsManager.instance.graphicEvents.OnHealthChange += ChangeHealthBar;
    }

    void OnDisable()
    {
        GameEventsManager.instance.graphicEvents.OnHealthChange -= ChangeHealthBar;
    }

    void Start()
    {
        healthBar.maxValue = stats.GetStatValue("Health");
        healthBar.value = stats.GetStatValue("Health");
        staminaBar.maxValue = stats.GetStatValue("Speed");
        staminaBar.value = stats.GetStatValue("Speed");
    }

    private void ChangeHealthBar(int amount)
    {
        healthBar.value -= amount;
    }

    private void ChangeStaminaBar(int amount)
    {
        healthBar.value -= amount;
    }
}
