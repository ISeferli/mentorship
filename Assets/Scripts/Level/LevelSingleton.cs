using UnityEngine;

public class LevelSingleton<T> : MonoBehaviour where T: LevelSingleton<T>
{
    private static T instance;
    public static T Instance { get { return instance; }}

    protected virtual void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = (T)this;
        DontDestroyOnLoad(gameObject);
    }
}
