using UnityEngine;

public class GameManager : LevelSingleton<GameManager>
{
    [Header("Spawn Settings")]
    [SerializeField] private EnemySpawner enemySpawner;
    [SerializeField] private int enemyWaves;
    [SerializeField] private int enemyNumber;

    protected override void Awake()
    {
        base.Awake();
        Debug.Log("Game Manager exists everywhere");
        SpawnEnemiesForLevel();
    }

    public void SpawnEnemiesForLevel()
    {
        if(enemySpawner.GetCurrentEnemies()==0 && enemySpawner.GetCurrentWave()<enemyWaves)
            enemySpawner.SpawnWave(enemyNumber);
    }
}
