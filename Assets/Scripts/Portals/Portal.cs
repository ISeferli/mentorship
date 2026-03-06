using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private string transitionScene;

    private bool isOpen = false;

    void OnEnable()
    {
        GameEventsManager.Instance.gameEvents.OnEnemyWaveComplete += PortalEffectAppear;
    }

    void OnDisable()
    {
        GameEventsManager.Instance.gameEvents.OnEnemyWaveComplete -= PortalEffectAppear;
    }

    void Start()
    {
        GetComponent<MeshRenderer>().enabled = false;
        isOpen = false;
    }

    /// <summary>
    /// Portal appears and is opened when the event is called
    /// </summary>
    private void PortalEffectAppear()
    {
        GetComponent<MeshRenderer>().enabled = true;
        isOpen = true;
    }

    void OnTriggerEnter(Collider collider)
    {
        // Triggers the collider only when a player only is passing through
        // and when the portal is open
        if (collider.CompareTag("Player") && isOpen)
        {
            GameManager.Instance.IncreaseCurrentLevel();
            GameEventsManager.Instance.levelEvents.LoadSceneEvent(transitionScene);
        }
    }
}
