using UnityEngine;

public class GameEventsManager : MonoBehaviour
{
    public static GameEventsManager instance { get; private set; }
    public LevelEvents levelEvents;
    public GraphicEvents graphicEvents;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Game Events Manager in Scene");
        }
        instance = this;

        // Initialize all events
        levelEvents = new LevelEvents();
        graphicEvents = new GraphicEvents();
    }
}
