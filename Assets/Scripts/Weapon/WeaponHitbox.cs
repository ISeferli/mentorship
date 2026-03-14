using UnityEngine;

public class WeaponHitbox : MonoBehaviour
{
    public SwordWeapon weapon;

    private void OnTriggerEnter(Collider other)
    {
        weapon.HandleHit(other);
    }
}