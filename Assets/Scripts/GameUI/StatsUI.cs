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
        GameEventsManager.instance.graphicEvents.OnCurrentHealthChange += ChangeCurrentHealthBar;
        GameEventsManager.instance.graphicEvents.OnMaxHealthChange += ChangeMaxHealthBar;
        GameEventsManager.instance.graphicEvents.OnStaminaUse += ChangeStaminaBar;
    }

    void OnDisable()
    {
        GameEventsManager.instance.graphicEvents.OnCurrentHealthChange -= ChangeCurrentHealthBar;
        GameEventsManager.instance.graphicEvents.OnMaxHealthChange -= ChangeMaxHealthBar;
        GameEventsManager.instance.graphicEvents.OnStaminaUse -= ChangeStaminaBar;
    }

    void Start()
    {
        healthBar.maxValue = stats.GetStatValue("Health");
        healthBar.value = stats.GetStatValue("Health");
        staminaBar.maxValue = 2;
        staminaBar.value = 2;
    }

    private void ChangeCurrentHealthBar(int amount)
    {
        healthBar.value -= amount;
    }

    private void ChangeMaxHealthBar(int amount)
    {
        healthBar.maxValue += amount;
    }

    private void ChangeStaminaBar(bool rise)
    {
        if(rise)
            staminaBar.value += 1;
        else
            staminaBar.value -= 1;
    }
}
