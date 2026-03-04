using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private string transitionScene;

    void OnEnable()
    {
        GameEventsManager.instance.gameEvents.OnEnemyWaveComplete += PortalEffectAppear;
    }

    void OnDisable()
    {
        GameEventsManager.instance.gameEvents.OnEnemyWaveComplete -= PortalEffectAppear;
    }

    void Start()
    {
        GetComponent<MeshRenderer>().enabled = false;    
    }

    private void PortalEffectAppear()
    {
        GetComponent<MeshRenderer>().enabled = true; 
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            // Transition To Scene
            Debug.Log("Scene to transition: " + transitionScene);
            GameManager.Instance.IncreaseCurrentLevel();
            GameEventsManager.instance.levelEvents.LoadSceneEvent(transitionScene);
        }
    }
}
