using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private string transitionScene;

    [Header("Level Difficulty Database")]
    [SerializeField] private LevelDifficulty levelDifficulty;
    public DifficultyTier PortalLevelDifficulty { get; private set; }
    private bool isOpen = false;

    void OnEnable()
    {
        GameEventsManager.Instance.gameEvents.OnEnemyWaveComplete += PortalEffectAppear;
    }

    void OnDisable()
    {
        GameEventsManager.Instance.gameEvents.OnEnemyWaveComplete -= PortalEffectAppear;
    }

    void Start()
    {
        GetComponent<MeshRenderer>().enabled = false;
        AssignNextLevelDifficulty();
        isOpen = false;
    }

    /// <summary>
    /// Portal appears and is opened when the event is called
    /// </summary>
    private void PortalEffectAppear()
    {
        GetComponent<MeshRenderer>().enabled = true;
        isOpen = true;
    }

    /// <summary>
    /// Assign for the portal the specific difficulty level it will hold
    /// </summary>
    private void AssignNextLevelDifficulty()
    {
        bool canSpawnBoss = GameManager.Instance.GetCurrentLevel() >= GameManager.Instance.maxLevelRun && !GameManager.Instance.BossPortalAssigned;
        if(canSpawnBoss)
        {
            PortalLevelDifficulty = levelDifficulty.boss;
            GameManager.Instance.BossPortalAssigned = true;
            transitionScene = "BossScene";
        }
        else
        {
            // Pick a random tier from the list of tiers in the LevelDifficultyManager
            int roll = Random.Range(0, 3);
            switch (roll)
            {
                case 0: PortalLevelDifficulty = levelDifficulty.easy; break;
                case 1: PortalLevelDifficulty = levelDifficulty.medium; break;
                default: PortalLevelDifficulty = levelDifficulty.hard; break;
            }
        }
        GetComponent<Renderer>().material.color = PortalLevelDifficulty.difficultyColor;
    }

    void OnTriggerEnter(Collider collider)
    {
        // Triggers the collider only when a player only is passing through
        // and when the portal is open
        GameManager.Instance.GenerateLevelDifficulty(PortalLevelDifficulty);
        GameManager.Instance.BossPortalAssigned = false;
        if (collider.CompareTag("Player") && isOpen)
        {
            GameManager.Instance.IncreaseCurrentLevel();
            GameManager.Instance.ApplyNextLevelSettings();
            GameEventsManager.Instance.levelEvents.LoadSceneEvent(transitionScene);
        }
    }
}
