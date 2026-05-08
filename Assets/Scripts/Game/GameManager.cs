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
    [SerializeField] public int maxLevelRun = 2;

    // Prepare the next spawn
    private int nextWaves;
    private int nextEnemies;

    // Gameplay logic
    public static bool startedFromMainMenu = false;
    public bool BossPortalAssigned { get; set; }
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

    /// <summary>
    /// Get the number of levels that the player has
    /// played so far in the playthrough
    /// </summary>
    /// <returns></returns>
    public int GetCurrentLevel()
    {
        return currentLevel;
    }

    /// <summary>
    /// Detect first level and preassign the difficulty on easy
    /// level
    /// </summary>
    private void SetupFirstLevel()
    {
        // Manually set Level 1 stats to Easy Difficulty
        enemyWaves = levelDifficulty.easy.baseWaves;
        enemyNumber = levelDifficulty.easy.baseEnemies;
    }

    /// <summary>
    /// Increase the level number when a level is complete
    /// </summary>
    public void IncreaseCurrentLevel()
    {
        currentLevel++;
        // if(currentLevel >= maxLevelRun) GameEventsManager.Instance.gameEvents.RunCompleteEvent();
    }


    /// <summary>
    /// Generation of level difficulty based on the portal assigned difficulty
    /// on start of the level. The enemy number and wave number is calculated with a
    /// math formula: Base * TierMultiplier * (1 + (CurrentLevel * Scaling))
    /// </summary>
    /// <param name="portalTier"></param>
    public void GenerateLevelDifficulty(DifficultyTier portalTier)
    {
        // Calculate Level Multiplier
        float levelBoost = 1f + (GetCurrentLevel() * levelDifficulty.levelScalingFactor);
        nextWaves = Mathf.RoundToInt(portalTier.baseWaves * portalTier.multiplier * levelBoost);
        nextEnemies = Mathf.RoundToInt(portalTier.baseEnemies * portalTier.multiplier * levelBoost);
    }

    /// <summary>
    /// Before loading next scene, assign the new numbers 
    /// to the base variables
    /// </summary>
    public void ApplyNextLevelSettings()
    {
        // Move the "Pending" stats into the "Active" stats
        enemyWaves = nextWaves;
        enemyNumber = nextEnemies;
    }
}
