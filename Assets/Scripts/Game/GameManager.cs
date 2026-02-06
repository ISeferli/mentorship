using UnityEngine;

public class GameManager : LevelSingleton<GameManager>
{
    [Header("Spawn Settings")]
    [SerializeField] private EnemySpawner enemySpawner;
    [SerializeField] public int enemyWaves;
    [SerializeField] public int enemyNumber;

    protected override void Awake()
    {
        base.Awake();
        Debug.Log("Game Manager exists everywhere");
    }
}
