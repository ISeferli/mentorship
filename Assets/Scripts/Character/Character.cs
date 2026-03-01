using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("Get characters' base abilities.")]
    public IHealth CurrentHealth { get; set; }

    void Awake()
    {
        CurrentHealth = GetComponent<Health>(); 
    }
}