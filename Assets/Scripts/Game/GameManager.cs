using UnityEngine;

public class GameManager : LevelSingleton<GameManager>
{
    [Header("Spawn Settings")]
    [SerializeField] public int enemyWaves;
    [SerializeField] public int enemyNumber;

    [Header("Upgrade Settings")]
    [SerializeField] public int upgradesNo;

    // Gameplay logic
    private EnemySpawner enemySpawner;
    private int currentLevel = 0;

    protected override void Awake()
    {
        base.Awake();
        enemySpawner = FindAnyObjectByType<EnemySpawner>();
    }

    public int GetCurrentLevel()
    {
        return currentLevel;
    }

    public void IncreaseCurrentLevel()
    {
        currentLevel++;
    }
}
