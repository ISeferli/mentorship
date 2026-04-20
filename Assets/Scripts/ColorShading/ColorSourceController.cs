using UnityEngine;

[ExecuteInEditMode]
public class ColorSourceController : MonoBehaviour
{
    [Header("Grayscale Shader")]
    [SerializeField] private Material effectMaterial;
    [SerializeField] private Transform colorSource;

    // Shader Setting taking effect
    private float radius = 1.5f;
    private float softness = 2f;

    void OnEnable()
    {
        GameEventsManager.Instance.gameEvents.OnEnemyDeath += IncreaseRadiusOnEnemyDeath;
    }

    void OnDisable()
    {
        GameEventsManager.Instance.gameEvents.OnEnemyDeath -= IncreaseRadiusOnEnemyDeath;
    }

    void Update()
    {
        if (effectMaterial != null && colorSource != null)
        {
            effectMaterial.SetVector("_SourcePos", colorSource.position);
            effectMaterial.SetFloat("_Radius", radius);
            effectMaterial.SetFloat("_Softness", softness);
        }
    }

    private void IncreaseRadiusOnEnemyDeath()
    {
        Debug.Log("Color radius = " + radius);
        radius = radius + 0.3f;
    }
}