using UnityEngine;

[ExecuteInEditMode]
public class ColorSourceController : MonoBehaviour
{
    [Header("Grayscale Shader")]
    [SerializeField] private Material effectMaterial;
    [SerializeField] private Transform colorSource;

    [Header("Orb Settings")]
    [SerializeField] private GameObject colorOrbPrefab;
    [SerializeField] private float orbSpeed = 5f;
    [SerializeField] private float radiusIncreaseAmount = 0.3f;

    // Shader Setting taking effect
    private float radius = 1.5f;
    private float softness = 2f;

    void OnEnable()
    {
        GameEventsManager.Instance.gameEvents.OnEnemyDeath += SpawnOrbOnEnemyDeath;
    }

    void OnDisable()
    {
        GameEventsManager.Instance.gameEvents.OnEnemyDeath -= SpawnOrbOnEnemyDeath;
    }

    void Update()
    {
        if (effectMaterial != null && colorSource != null)
        {
            // Update variables that exist in shader to apply the visual changes
            effectMaterial.SetVector("_SourcePos", colorSource.position);
            effectMaterial.SetFloat("_Radius", radius);
            effectMaterial.SetFloat("_Softness", softness);
        }
    }

    /// <summary>
    /// Every time an enemy dies, an orb spawns that will track the player 
    /// and disappear when it reaches the color range. Needs fixing to put the 
    /// orb as a color source too.
    /// </summary>
    /// <param name="enemyPosition">Position of the enemy where the orb will spawn</param>
    /// <param name="player">Player that the orb will go to</param>
    private void SpawnOrbOnEnemyDeath(Vector3 enemyPosition, Transform player)
    {
        if (colorOrbPrefab == null) return;
        GameObject orb = Instantiate(colorOrbPrefab, enemyPosition, Quaternion.identity);
        ColorOrb colorOrb = orb.GetComponent<ColorOrb>();

        colorOrb.Initialize(player, orbSpeed, () =>
        {
            radius += radiusIncreaseAmount;
            Debug.Log("Orb arrived! New radius = " + radius);
        });
    }
}