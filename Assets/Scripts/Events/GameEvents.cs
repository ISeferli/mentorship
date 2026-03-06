using System;

public class GameEvents
{
    /// <summary>
    /// Event that is called when an enemy is destroyed by the character
    /// </summary>
    public event Action OnEnemyDeath;

    public void EnemyDeathEvent()
    {
        OnEnemyDeath?.Invoke();
    }

    /// <summary>
    /// Event that is called when the wave of enemies are terminated
    /// to inform the listeners in case they want to bring other enemies
    /// </summary>
    public event Action OnEnemyWaveComplete;

    public void EnemyWaveCompletedEvent()
    {
        OnEnemyWaveComplete?.Invoke();
    }

    /// <summary>
    /// Event that is called when the run is completed
    /// </summary>
    public event Action OnRunCompleted;

    public void RunCompleteEvent()
    {
        OnRunCompleted?.Invoke();
    }
}