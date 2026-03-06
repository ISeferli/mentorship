using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    public void StartButton()
    {
        GameManager.startedFromMainMenu = true;
        GameEventsManager.Instance.levelEvents.LoadSceneEvent("SceneThree");
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
