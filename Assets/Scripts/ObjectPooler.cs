using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.SceneManagement;

public class ObjectPooler : LevelSingleton<ObjectPooler>
{
    [System.Serializable]
    public class Pool
    {
        public string tag = "";
        public GameObject prefab = null;
        public int maxSize = 0;
    }

    public Dictionary<string, ObjectPool<GameObject>> poolDictionary;
    public List<Pool> pools;

    protected override void Awake()
    {
        base.Awake();
        poolDictionary = new Dictionary<string, ObjectPool<GameObject>>();
        foreach(Pool pool in pools)
        {
            Pool capturedPool = pool;
            poolDictionary[pool.tag] = new ObjectPool<GameObject>(
                createFunc:      () => Instantiate(capturedPool.prefab),
                actionOnGet:     obj => obj.SetActive(true),
                actionOnRelease: obj => obj.SetActive(false),
                actionOnDestroy: obj => Destroy(obj),
                maxSize:         pool.maxSize
            );
        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("No tag " + tag + " found in pool");
            return null;
        }
        GameObject objectToSpawn = poolDictionary[tag].Get();
        objectToSpawn.transform.parent = transform;
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;
        return objectToSpawn;
    }

    public void ReturnToPool(string tag, GameObject obj)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Destroy(obj);
            return;
        }
        poolDictionary[tag].Release(obj);
    }
}
