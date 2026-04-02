using UnityEngine;

public class SpawnAttackDecorator : ElementalDecorator
{
    private int noToSpawn;

    /// <summary>
    /// Spawn decorator that spawns new enemies of a specific type according to
    /// the prefab provided to the constructor
    /// </summary>
    /// <param name="specificAttack">The base attack that will be modified</param>
    /// <param name="spawnNo">The amount of enemies that will be spawned</param>
    /// <param name="attackPrefab">The prefab of the enemies to be spawned</param>
    /// <param name="radius">Radius of the attack</param>
    public SpawnAttackDecorator(int spawnNo, int radius, GameObject attackPrefab, IAttack specificAttack) : base(specificAttack)
    {
        noToSpawn = spawnNo;
        attackData.range += radius;
        attackData.attackPrefab = attackPrefab;
    }

    public override void PerformAttack(int pointsDamage, GameObject personToHit, GameObject attacker)
    {
        for (int i = 0; i < noToSpawn; i++)
            SpawnOneEnemy(attacker);
    }

    /// <summary>
    /// Spawns each enemy separately. Inside a Sphere, points to the nav mesh to 
    /// see in which place it is valiable to spawn an enemy. Then increases the current
    /// enemy number
    /// </summary>
    /// <param name="attacker">Character that calls the spawn ability</param>
    private void SpawnOneEnemy(GameObject attacker)
    {
        int maxAttempts = 20;
        int attempts = 0;
        while(attempts < maxAttempts)
        {
            Vector3 randomPoint = attacker.transform.position + Random.insideUnitSphere * attackData.range;
            UnityEngine.AI.NavMeshHit hit;
            if (UnityEngine.AI.NavMesh.SamplePosition(randomPoint, out hit, 10.0f, UnityEngine.AI.NavMesh.AllAreas))
            {
                int waterLayer = LayerMask.NameToLayer("Water");
                Collider[] colliders = Physics.OverlapSphere(hit.position, 0.5f, 1 << waterLayer);
                // If collider finds water then find another spot to spawn
                if (colliders.Length > 0)
                {
                    attempts++;
                    continue;
                }
                GameObject newEnemy = UnityEngine.Object.Instantiate(attackData.attackPrefab, hit.position, Quaternion.identity);
                Enemy enemy = newEnemy.GetComponent<Enemy>();
                enemy.Initialize();
                newEnemy.transform.parent = attacker.transform;
                return;
            }
            attempts++;
        }
    }
}