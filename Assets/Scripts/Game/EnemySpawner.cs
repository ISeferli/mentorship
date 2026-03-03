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
        GameEventsManager.instance.gameEvents.OnEnemyDeath += DeleteEnemy;
    }

    void OnDisable()
    {
        GameEventsManager.instance.gameEvents.OnEnemyDeath -= DeleteEnemy;
    }

    void Start()
    {
        SpawnEnemiesForLevel();
    }

    public void SpawnEnemiesForLevel()
    {
        if(GetCurrentEnemies()==0 && GetCurrentWave()<GameManager.Instance.enemyWaves) 
            SpawnWave(GameManager.Instance.enemyNumber);
        else
            GameEventsManager.instance.gameEvents.EnemyWaveCompletedEvent();
    }

    public void SpawnWave(int enemyNumber)
    {
        for (int i = 0; i < enemyNumber; i++)
            SpawnOneEnemy();
        currentEnemyWave++;
    }

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
