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

    /// <summary>
    /// Call the coroutine to start loading the next level
    /// </summary>
    /// <param name="sceneName">The name of the next level</param>
    private void LoadNextLevel(string sceneName)
    {
        StartCoroutine(LoadLevel(sceneName));
    }

    /// <summary>
    /// Load the next level. Wait for the transition time and then load it, for
    /// the animation to finish
    /// </summary>
    /// <param name="sceneName">Scene name that will come up next</param>
    /// <returns>Waits for specific seconds until the scene changes</returns>
    private IEnumerator LoadLevel(string sceneName)
    {
        levelAnimator.SetTrigger("Start");

        // Start loading the next scene asynchronously, but don’t allow activation yet
        AsyncOperation operation;
        operation = SceneManager.LoadSceneAsync(sceneName);
        operation.allowSceneActivation = false;
        yield return new WaitForSeconds(transitionTime);

        while (operation.progress < 0.9f)
            yield return null;
        operation.allowSceneActivation = true;
    }
}
