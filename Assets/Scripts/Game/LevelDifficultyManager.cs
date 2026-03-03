using UnityEngine;

public class LevelDifficultyManager : MonoBehaviour
{
    [Header("Level Difficulty")]
    [SerializeField] private LevelDifficulty levelDifficulty;

    void Start()
    {
        GameManager.Instance.enemyNumber = levelDifficulty.enemyNumber;
        GameManager.Instance.enemyWaves = levelDifficulty.enemyWaves;
    }
}