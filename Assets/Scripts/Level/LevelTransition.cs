using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Animator))]
public class LevelTransition : MonoBehaviour
{
    // Get game object animator
    private Animator levelAnimator;
    private float transitionTime = .3f;

    private void OnEnable()
    {
        GameEventsManager.instance.levelEvents.OnSceneLoad += LoadNextLevel;
    }

    private void OnDisable()
    {
        GameEventsManager.instance.levelEvents.OnSceneLoad -= LoadNextLevel;
    }

    void Start()
    {
        levelAnimator = GetComponent<Animator>();  
    }

    private void LoadNextLevel(string sceneName)
    {
        StartCoroutine(LoadLevel(sceneName));
    }

    private IEnumerator LoadLevel(string sceneName)
    {
        levelAnimator.SetTrigger("Start");

        // Start loading the next scene asynchronously, but don’t allow activation yet
        AsyncOperation operation;
        operation = SceneManager.LoadSceneAsync(sceneName);
        operation.allowSceneActivation = false;
        yield return new WaitForSeconds(transitionTime);

        while (operation.progress < 0.9f)
        {
            yield return null;
        }

        operation.allowSceneActivation = true;
    }
}
