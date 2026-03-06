using UnityEngine;

public class GameEventsManager : LevelSingleton<GameEventsManager>
{
    public LevelEvents levelEvents;
    public GraphicEvents graphicEvents;
    public GameEvents gameEvents;

    protected override void Awake()
    {
        base.Awake();
        // Initialize all events
        levelEvents = new LevelEvents();
        graphicEvents = new GraphicEvents();
        gameEvents = new GameEvents();
    }
}
