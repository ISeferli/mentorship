using System;
using UnityEngine;

public class GameEvents
{
    /// <summary>
    /// Event that is called when an enemy is destroyed by the character
    /// </summary>
    public event Action<Vector3, Transform> OnEnemyDeath;

    public void EnemyDeathEvent(Vector3 position, Transform transform)
    {
        OnEnemyDeath?.Invoke(position, transform);
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