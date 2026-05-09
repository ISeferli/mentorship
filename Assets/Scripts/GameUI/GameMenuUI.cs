using UnityEngine;

public class GameMenuUI : MonoBehaviour
{
    [Header("In-game Menu Settings")]
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject winPanel;
    [SerializeField] GameObject gameOverPanel;

    void OnEnable()
    {
        GameEventsManager.Instance.gameEvents.OnRunCompleted += OpenWinPanel;
        GameEventsManager.Instance.gameEvents.OnRunFailed += OpenGameOverPanel;
    }

    void OnDisable()
    {
        GameEventsManager.Instance.gameEvents.OnRunCompleted -= OpenWinPanel;
        GameEventsManager.Instance.gameEvents.OnRunFailed -= OpenGameOverPanel;
    }

    void Start()
    {
        //At the start of the game don't show pause panel
        pausePanel.SetActive(false);
        gameOverPanel.SetActive(false);
        winPanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            pausePanel.SetActive(!pausePanel.activeSelf);
            if (pausePanel.activeSelf) Time.timeScale = 0f;
            else Time.timeScale = 1f;
        }
    }

    public void ResumeButton()
    {
        pausePanel.SetActive(!pausePanel.activeSelf);
        Time.timeScale = 1f;
    }

    public void BackButton()
    {
        pausePanel.SetActive(false);
        gameOverPanel.SetActive(false);
        GameEventsManager.Instance.levelEvents.LoadSceneEvent("MainMenu");
        Time.timeScale = 1f;
    }

    public void OpenGameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }

    public void OpenWinPanel()
    {
        winPanel.SetActive(true);
    }
}
