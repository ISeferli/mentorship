using UnityEngine;

[CreateAssetMenu(fileName = "Difficulty Settings", menuName = "Difficulty Settings")]
public class LevelDifficulty: ScriptableObject
{
    [Header("Enemy Spawning")]
    public int enemyWaves = 0;
    public int enemyNumber = 0;
}