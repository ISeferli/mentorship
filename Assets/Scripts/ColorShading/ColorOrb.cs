using UnityEngine;

public class ColorOrb : MonoBehaviour
{
    private Transform target;
    private float speed = 5f;
    private System.Action onArrived;

    public void Initialize(Transform playerTarget, float moveSpeed, System.Action arrivedCallback)
    {
        target = playerTarget;
        speed = moveSpeed;
        onArrived = arrivedCallback;
    }

    void Update()
    {
        if (target == null) return;

        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) < 0.2f)
        {
            onArrived?.Invoke();
            Destroy(gameObject);
        }
    }
}