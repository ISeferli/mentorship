using System.Collections.Generic;
using UnityEngine;

public interface WeaponInterface
{
    public List<BaseStat> stats { get; set; }

    void PerformAttack(GameObject personToHit, CharacterStats character);
}
