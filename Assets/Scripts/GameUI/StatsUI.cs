using UnityEngine;
using UnityEngine.UI;

public class StatsUI : MonoBehaviour
{
    [Header("Playable Stats")]
    [SerializeField] PlayableStats stats;

    [Header("Health Bar Settings")]
    [SerializeField] Slider healthBar;

    [Header("Stamina Bar Settings")]
    [SerializeField] Slider staminaBar;

    void OnEnable()
    {
        GameEventsManager.Instance.graphicEvents.OnCurrentHealthChange += ChangeCurrentHealthBar;
        GameEventsManager.Instance.graphicEvents.OnMaxHealthChange += ChangeMaxHealthBar;
        GameEventsManager.Instance.graphicEvents.OnStaminaUse += ChangeStaminaBar;
        GameEventsManager.Instance.graphicEvents.OnMaxStaminaChange += ChangeMaxStaminaBar;
    }

    void OnDisable()
    {
        GameEventsManager.Instance.graphicEvents.OnCurrentHealthChange -= ChangeCurrentHealthBar;
        GameEventsManager.Instance.graphicEvents.OnMaxHealthChange -= ChangeMaxHealthBar;
        GameEventsManager.Instance.graphicEvents.OnStaminaUse -= ChangeStaminaBar;
        GameEventsManager.Instance.graphicEvents.OnMaxStaminaChange -= ChangeMaxStaminaBar;
    }

    void Start()
    {
        if(GameManager.Instance.GetCurrentLevel()==0)
        {
            healthBar.maxValue = stats.GetStatValue("Health");
            healthBar.value = stats.GetStatValue("Health");
            staminaBar.maxValue = stats.GetStatValue("Stamina");
            staminaBar.value = stats.GetStatValue("Stamina");
        } else
        {
            healthBar.maxValue = CharacterMovement.Instance.GetComponent<Character>().CurrentHealth.healthData.maxHealth;
            healthBar.value = CharacterMovement.Instance.GetComponent<Character>().CurrentHealth.healthData.currentHealth;
            staminaBar.maxValue = CharacterMovement.Instance.GetComponent<Character>().CurrentStamina.staminaData.maxStaminaUses;
            staminaBar.value = CharacterMovement.Instance.GetComponent<Character>().CurrentStamina.staminaData.currentStaminaUses;
        }
    }

    private void ChangeCurrentHealthBar(int amount)
    {
        healthBar.value += amount;
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

    private void ChangeMaxStaminaBar(int rise)
    {
        staminaBar.maxValue += rise;
    }
}
