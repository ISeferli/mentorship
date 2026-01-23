using System.Collections.Generic;
using UnityEngine;

public class RightHandSword : MonoBehaviour, WeaponInterface
{
    public List<BaseStat> stats { get; set; }

    public void PerformAttack(GameObject personToHit, CharacterStats character)
    {
        Debug.Log("Right Hand Attack: " + character.attributes["Strength"].CalculateStatValue());
    }
}
