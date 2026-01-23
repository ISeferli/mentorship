using UnityEngine;

public class TestingBehaviours : MonoBehaviour
{
    [SerializeField] private GameObject character;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            character.GetComponent<Health>().DamageHealth(3);
        }
    }
}
