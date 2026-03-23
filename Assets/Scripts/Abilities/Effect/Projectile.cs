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
        transform.position += target * speed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Apply damage
            Debug.Log("here");
            Health health = other.GetComponent<Health>();
            if (health != null)
            {
                health.DamageHealth(damage);
                GameEventsManager.Instance.graphicEvents.ChangeCurrentHealthUI(-damage);
            }
            Destroy(gameObject);
        }
    }
}