using UnityEngine;

public class TransparencyDetection : MonoBehaviour
{
    [Range(0, 1)]
    [SerializeField] private float transparencyAmount = .8f;
    [SerializeField] private float transparencyTime = .4f;

    private Renderer objectRenderer;

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
    }

}
