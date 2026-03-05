using System;

public class LevelEvents
{
    /// <summary>
    /// Event that is called when a level loads
    /// </summary>
    public event Action<string> OnSceneLoad;

    public void LoadSceneEvent(string sceneName)
    {
        OnSceneLoad?.Invoke(sceneName);
    }
}