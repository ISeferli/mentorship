using UnityEngine;

public class GameManager : LevelSingleton<GameManager>
{
    [Header("Spawn Settings")]
    [SerializeField] public int enemyWaves;
    [SerializeField] public int enemyNumber;

    [Header("Upgrade Settings")]
    [SerializeField] public int upgradesNo;

    [Header("Level Difficulty Database")]
    [SerializeField] private LevelDifficulty levelDifficulty;
    [SerializeField] public int maxLevelRun = 3;

    // Prepare the next spawn
    private int nextWaves;
    private int nextEnemies;

    // Gameplay logic
    public static bool startedFromMainMenu = false;
    private static int currentLevel = 0;

    protected override void Awake()
    {
        base.Awake();
        if(startedFromMainMenu)
        {
            currentLevel = 0;
            startedFromMainMenu = false;
            SetupFirstLevel();
        }
    }

    public int GetCurrentLevel()
    {
        return currentLevel;
    }

    private void SetupFirstLevel()
    {
        // Manually set Level 1 stats to Easy Difficulty
        enemyWaves = levelDifficulty.easy.baseWaves;
        enemyNumber = levelDifficulty.easy.baseEnemies;
        Debug.Log(enemyNumber);
        Debug.Log(levelDifficulty.easy.baseEnemies);
    }

    public void IncreaseCurrentLevel()
    {
        Debug.Log("increasing levels");
        currentLevel++;
        if(currentLevel >= maxLevelRun) GameEventsManager.Instance.gameEvents.RunCompleteEvent();
    }


    public void GenerateLevelDifficulty(DifficultyTier portalTier)
    {
        // Calculate Level Multiplier
        // Formula: Base * TierMultiplier * (1 + (CurrentLevel * Scaling))
        float levelBoost = 1f + (GetCurrentLevel() * levelDifficulty.levelScalingFactor);
        nextWaves = Mathf.RoundToInt(portalTier.baseWaves * portalTier.multiplier * levelBoost);
        nextEnemies = Mathf.RoundToInt(portalTier.baseEnemies * portalTier.multiplier * levelBoost);
        Debug.Log($"Level {GetCurrentLevel()} generated: {portalTier.tierName} mode. Waves: {enemyWaves}, Enemies: {enemyNumber}");
    }

    public void ApplyNextLevelSettings()
    {
        // Move the "Pending" stats into the "Active" stats
        enemyWaves = nextWaves;
        enemyNumber = nextEnemies;
    }
}
