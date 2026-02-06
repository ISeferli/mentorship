using System;

public class GameEvents
{
    public event Action OnEnemyDeath;

    public void EnemyDeathEvent()
    {
        OnEnemyDeath?.Invoke();
    }

    public event Action OnEnemyWaveComplete;

    public void EnemyWaveCompletedEvent()
    {
        OnEnemyWaveComplete?.Invoke();
    }
}