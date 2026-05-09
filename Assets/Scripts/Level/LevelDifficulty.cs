using UnityEngine;

[System.Serializable]
public class DifficultyTier
{
    public string tierName;
    public int baseWaves;
    public int baseEnemies;
    public float multiplier;
    public Color difficultyColor;
}

[CreateAssetMenu(fileName = "Difficulty Settings", menuName = "Difficulty Settings")]
public class LevelDifficulty: ScriptableObject
{
    public DifficultyTier easy;
    public DifficultyTier medium;
    public DifficultyTier hard;
    public DifficultyTier boss;

    [Tooltip("How much difficulty increases per level (e.g., 0.1 is 10% increase)")]
    public float levelScalingFactor = 0.1f;
}