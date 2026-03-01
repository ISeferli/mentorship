using UnityEngine;

public class GameManager : LevelSingleton<GameManager>
{
    [Header("Spawn Settings")]
    [SerializeField] private EnemySpawner enemySpawner;
    [SerializeField] public int enemyWaves;
    [SerializeField] public int enemyNumber;

    [Header("Upgrade Settings")]
    [SerializeField] public int upgradesNo;

    protected override void Awake()
    {
        base.Awake();
    }
}
