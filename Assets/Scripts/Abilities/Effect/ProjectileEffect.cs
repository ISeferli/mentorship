using UnityEngine;

public class ProjectileEffect : IEffect
{
    public string EffectID => "Projectile";
    private int BaseDamage = 0;
    private GameObject projectilePrefab;

    public ProjectileEffect(int baseDamage, GameObject prefab)
    {
        BaseDamage = baseDamage;
        projectilePrefab = prefab;
    }

    public void ExecuteEffect(GameObject target, AttackData data)
    {
        Debug.Log($"Applying {BaseDamage}");
        if (projectilePrefab == null)
        {
            Debug.LogWarning("ProjectileEffect missing prefab");
            return;
        }

        // Spawn projectile
        // TODO: This will for sure change, because it will change the ui of the character and it has specific enemy logic
        Vector3 direction = (target.transform.position - GameObject.FindGameObjectWithTag("Boss").transform.position).normalized;
        GameObject projectile = GameObject.Instantiate(projectilePrefab, GameObject.FindGameObjectWithTag("Boss").transform.position, Quaternion.identity);

        // Initialize projectile
        Projectile proj = projectile.GetComponent<Projectile>();
        if (proj != null)
            proj.Initialize(direction, BaseDamage);
    }
}