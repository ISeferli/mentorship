using System.Collections.Generic;
using UnityEngine;

public class BaseAttackComposition
{
    private List<IAttack> baseAttacks = new List<IAttack>();

    /// <summary>
    /// Add to the list of possible attack of the character
    /// </summary>
    /// <param name="attack">The base attack that will be added to the list</param>
    public void AddAttack(IAttack attack)
    {
        if(attack == null) return;
        if(baseAttacks.Count == 0) baseAttacks.Add(attack);
        if(!AttackExists(attack.attackData.id))
            baseAttacks.Add(attack);
    }

    /// <summary>
    /// Check the list of attacks 
    /// </summary>
    /// <param name="attackID">The base attack that will be added to the list</param>
    /// <returns> <b>True</b> if the id of the attack already exists on the list, <b>False</b> otherwise </returns>
    public bool AttackExists(string attackID)
    {
        for(int i=0; i<baseAttacks.Count; i++)
        {
            if(baseAttacks[i].attackData.id.Equals(attackID))
                return true;
        }
        return false;
    }

    /// <summary>
    /// Check the list of attacks for a specific type of attack based on the ID
    /// </summary>
    /// <param name="attackID">The attack ID that you search for</param>
    /// <returns> The attack in the list with that specific ID </returns>
    public IAttack GetBaseAttack(string attackID)
    {
        for(int i=0; i<baseAttacks.Count; i++)
        {
            if(baseAttacks[i].attackData.id.Equals(attackID))
                return baseAttacks[i];
        }

        return null;
    }

    public IAttack CreateNewBaseAttack(PlayableStats stats, string attackID)
    {
        return new BaseAttack(stats.GetStatValue("Attack"), 1, attackID);
    }

    public void UpgradeSpecificAttack(string attackID, IAttack upgradeAttack, IAttack baseAttack)
    {
        baseAttack = upgradeAttack;
        if(!AttackExists(attackID))
            AddAttack(baseAttack);
        else
        {
            for (int i = 0; i < baseAttacks.Count; i++)
            {
                if (baseAttacks[i].attackData.id.Equals(attackID))
                {
                    // Replace the old version with the new decorated version
                    baseAttacks[i] = baseAttack;
                    return;
                }
            }
        }
    }
}
