using System;

public class LevelEvents
{
    public event Action<string> OnSceneLoad;

    public void LoadSceneEvent(string sceneName)
    {
        if (OnSceneLoad != null)
        {
            OnSceneLoad(sceneName);            
        }
    }
}