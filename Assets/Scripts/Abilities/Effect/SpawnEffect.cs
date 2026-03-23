using UnityEngine;

public class SpawnEffect : IEffect
{
    public string EffectID => "Spawn";
    private GameObject spawnPrefab;

    public SpawnEffect(GameObject prefab)
    {
        spawnPrefab = prefab;
    }

    public void ExecuteEffect(GameObject target, AttackData data)
    {
        if (spawnPrefab == null)
        {
            Debug.LogWarning("ProjectileEffect missing prefab");
            return;
        }

        GameObject.Instantiate(spawnPrefab, GameObject.FindGameObjectWithTag("Boss").transform.position, Quaternion.identity);
    }
}