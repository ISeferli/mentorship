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
    public event Action<int> OnHealthChange;

    public void ChangeHealthUI(int damageTaken)
    {
        OnHealthChange?.Invoke(damageTaken);
    }
}