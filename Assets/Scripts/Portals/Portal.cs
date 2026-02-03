using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private string transitionScene;
    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            // Transition To Scene
            Debug.Log("Scene to transition: " + transitionScene);
            GameEventsManager.instance.levelEvents.LoadSceneEvent(transitionScene);
        }
    }
}
