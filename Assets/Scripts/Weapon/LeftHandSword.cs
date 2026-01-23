using System.Collections.Generic;
using UnityEngine;

public class LeftHandSword : MonoBehaviour, WeaponInterface
{
    public List<BaseStat> stats { get; set; }

    public void PerformAttack(GameObject personToHit, CharacterStats character)
    {
        Debug.Log("Left Hand Attack: " + character.attributes["Strength"].CalculateStatValue());
    }
}
