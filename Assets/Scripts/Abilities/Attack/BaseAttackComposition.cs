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

    
    /// <summary>
    /// Gets the attack of the list by number
    /// </summary>
    /// <param name="no">The position number of the attack</param>
    /// <returns> The attack in the list with that specific position number </returns>
    public IAttack GetAttackByNo(int no)
    {
        return baseAttacks[no];
    }


    /// <summary>
    /// Creates a new BaseAttack instance for adding a new attack in list
    /// </summary>
    /// <param name="attackID">The attack ID that you will add in the list</param>
    /// <returns> The attack that gets created </returns>
    public IAttack CreateNewAttack(string attackID)
    {
        return new BaseAttack(0, 1, attackID);
    }

    
    /// <summary>
    /// Upgrades the specific attack that handles the upgrade
    /// </summary>
    /// <param name="attackID">The attack ID that will be upgraded</param>
    /// <param name="upgradeAttack">The upgrade of the attack</param>
    /// <param name="baseAttack">The previous attack without the upgrade</param>
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


    /// <summary>
    /// Gets the length of the attack list
    /// </summary>
    /// <returns> The length of the attack list </returns>
    public int GetAttackListLength()
    {
        return baseAttacks.Count;
    }
}
