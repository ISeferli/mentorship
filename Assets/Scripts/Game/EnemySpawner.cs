using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    [SerializeField] float spawnRadius;

    [Header("Enemy Type To Spawn")]
    [SerializeField] private EnemyType enemyType;

    // Current settings of enemy waves
    private int currentEnemyWave = 0;
    private int currentEnemies = 0;

    void OnEnable()
    {
        GameEventsManager.Instance.gameEvents.OnEnemyDeath += DeleteEnemy;
    }

    void OnDisable()
    {
        GameEventsManager.Instance.gameEvents.OnEnemyDeath -= DeleteEnemy;
    }

    void Start()
    {
        SpawnEnemiesForLevel();
    }

    /// <summary>
    /// For each level difficulty sees if a wave should be spawned and if there are no
    /// enemies currently on level. If all the waves are completed, calls the event to inform
    /// that the waves are completed and to inform every listener that the level is completed
    /// </summary>
    public void SpawnEnemiesForLevel()
    {
        if(GetCurrentEnemies()==0 && GetCurrentWave()<GameManager.Instance.enemyWaves) 
            SpawnWave(GameManager.Instance.enemyNumber);
        else
            GameEventsManager.Instance.gameEvents.EnemyWaveCompletedEvent();
    }

    /// <summary>
    /// For the number of enemies that we want spawned, spawns each enemy and 
    /// increases the wave
    /// </summary>
    /// <param name="enemyNumber">Number of enemies that need to be spawned</param>
    public void SpawnWave(int enemyNumber)
    {
        for (int i = 0; i < enemyNumber; i++)
            SpawnOneEnemy();
        currentEnemyWave++;
    }

    /// <summary>
    /// Spawns each enemy separately. Inside a Sphere, points to the nav mesh to 
    /// see in which place it is valiable to spawn an enemy. Then increases the current
    /// enemy number
    /// </summary>
    private void SpawnOneEnemy()
    {
        int maxAttempts = 20;
        int attempts = 0;
        while(attempts < maxAttempts)
        {
            Vector3 randomPoint = this.transform.position + Random.insideUnitSphere * spawnRadius;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 10.0f, NavMesh.AllAreas))
            {
                int waterLayer = LayerMask.NameToLayer("Water");
                Collider[] colliders = Physics.OverlapSphere(hit.position, 0.5f, 1 << waterLayer);
                // If collider finds water then find another spot to spawn
                if (colliders.Length > 0)
                {
                    attempts++;
                    continue;
                }
                GameObject newEnemy = Instantiate(enemyType.prefab, hit.position, Quaternion.identity);
                Enemy enemy = newEnemy.GetComponent<Enemy>();
                enemy.Initialize();
                newEnemy.transform.parent = transform;
                currentEnemies++;
                return;
            }
            attempts++;
        }
    }

    public int GetCurrentWave()
    {
        return currentEnemyWave;
    }

    public int GetCurrentEnemies()
    {
        return currentEnemies;
    }

    private void DeleteEnemy()
    {
        currentEnemies--;
        if (currentEnemies == 0) SpawnEnemiesForLevel();
    }
}
