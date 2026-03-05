using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    public void StartButton()
    {
        GameEventsManager.instance.levelEvents.LoadSceneEvent("SceneThree");
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
