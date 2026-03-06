using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] float spawnRadius;

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
        Vector3 randomPoint = this.transform.position + Random.insideUnitSphere * spawnRadius;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 10.0f, NavMesh.AllAreas))
        {
            GameObject newEnemy = Instantiate(enemyPrefab, hit.position, Quaternion.identity);
            newEnemy.transform.parent = transform;
            currentEnemies++;
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
