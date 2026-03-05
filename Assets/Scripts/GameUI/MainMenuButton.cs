using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainMenuButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public RectTransform[] leaves;

    [Header("Hover Effects Settings")]
    [SerializeField] private float hoverScale = 1.08f;
    [SerializeField] private float scaleSpeed = 8f;

    // Original Sizes
    private Vector3 originalScale;
    private Vector3 targetScale;
    private bool isHovering;

    void Start()
    {
        originalScale = this.transform.localScale;
        targetScale = originalScale;
    }

    void Update()
    {
       transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * scaleSpeed);
        if (isHovering)
        {
            foreach (RectTransform leaf in leaves)
            {
                leaf.GetComponent<Animator>().SetTrigger("Shake");
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovering = true;
        targetScale = originalScale * hoverScale;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovering = false;
        targetScale = originalScale;
    }
}
