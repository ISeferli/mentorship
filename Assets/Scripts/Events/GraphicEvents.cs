using System;
using System.Collections.Generic;

public class GraphicEvents
{
    public event Action<int> OnShowEnemyDamage;

    public void ShowEnemyDamage(int damageTaken)
    {
        if (OnShowEnemyDamage != null)
        {
            OnShowEnemyDamage(damageTaken);            
        }
    }

    /// <summary>
    /// Event that is called when the wave of enemies are terminated
    /// to inform the UI to show the upgrades
    /// </summary>
    public event Action<List<Upgrade>> OnWaveEnemyKilled;

    public void ShowUpgradesOnWaveTerm(List<Upgrade> posUpgrades)
    {
        OnWaveEnemyKilled?.Invoke(posUpgrades);
    }

    /// <summary>
    /// Event that is called from the EnemyAttack when the character takes damage
    /// </summary>
    public event Action<int> OnCurrentHealthChange;

    public void ChangeCurrentHealthUI(int damageTaken)
    {
        OnCurrentHealthChange?.Invoke(damageTaken);
    }

    /// <summary>
    /// Event that is called when an upgrade on max health happens
    /// </summary>
    public event Action<int> OnMaxHealthChange;

    public void ChangeMaxHealthUI(int damageTaken)
    {
        OnMaxHealthChange?.Invoke(damageTaken);
    }

    /// <summary>
    /// Event that is called when a stamina use is used
    /// </summary>
    public event Action<bool> OnStaminaUse;

    public void ChangeStaminaUI(bool riseStamina)
    {
        OnStaminaUse?.Invoke(riseStamina);
    }

    /// <summary>
    /// Event that is called when an upgrade on max stamina is used
    /// </summary>
    public event Action<int> OnMaxStaminaChange;

    public void ChangeMaxStaminaUI(int rise)
    {
        OnMaxStaminaChange?.Invoke(rise);
    }
}