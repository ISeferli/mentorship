using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Vector3 target;
    private int damage;
    private float speed = 10f;
    private float lifetime = 3f;

    public void Initialize(Vector3 direction, int damage)
    {
        this.target = direction;
        this.damage = damage;
        // Destroy after time if no hit
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        // The projectile moves along as long as it stays active
        transform.position += target * speed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        // Apply damage
        Health health = other.GetComponent<Health>();
        if(health!=null)
            health.DamageHealth(damage);
        if (other.CompareTag("Player"))
        {
            GameEventsManager.Instance.graphicEvents.ChangeCurrentHealthUI(-damage);   
        }
        Destroy(gameObject);
    }
}