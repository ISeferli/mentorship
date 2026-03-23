using UnityEngine;

public class FireBallEffect : IEffect
{
    public string EffectID => "FireballEffect";

    // private GameObject rockPrefab;
    // private int rockCount;
    // private float spawnRadius;

    // public FireBallEffect(GameObject prefab, int count, float radius)
    // {
    //     rockPrefab = prefab;
    //     rockCount = count;
    //     spawnRadius = radius;
    // }

    public void ExecuteEffect(GameObject target, AttackData data)
    {
        // for (int i = 0; i < rockCount; i++)
        // {
        //     Vector3 pos = target.transform.position + new Vector3(
        //         Random.Range(-spawnRadius, spawnRadius),
        //         10f,
        //         Random.Range(-spawnRadius, spawnRadius)
        //     );

        //     GameObject.Instantiate(rockPrefab, pos, Quaternion.identity);
        // }
    }
}