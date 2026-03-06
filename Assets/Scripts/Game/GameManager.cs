using UnityEngine;

public class GameManager : LevelSingleton<GameManager>
{
    [Header("Spawn Settings")]
    [SerializeField] public int enemyWaves;
    [SerializeField] public int enemyNumber;

    [Header("Upgrade Settings")]
    [SerializeField] public int upgradesNo;

    [Header("Level Settings")]
    [SerializeField] public int maxLevelRun = 3;

    // Gameplay logic
    private EnemySpawner enemySpawner;
    public static bool startedFromMainMenu = false;
    private static int currentLevel = 0;

    protected override void Awake()
    {
        base.Awake();
        enemySpawner = FindAnyObjectByType<EnemySpawner>();
        if(startedFromMainMenu)
        {
            currentLevel = 0;
            startedFromMainMenu = false;
        }
    }

    public int GetCurrentLevel()
    {
        return currentLevel;
    }

    public void IncreaseCurrentLevel()
    {
        Debug.Log("increasing levels");
        currentLevel++;
        if(currentLevel >= maxLevelRun) GameEventsManager.Instance.gameEvents.RunCompleteEvent();
    }
}
