using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public Dictionary<string, BaseStat> attributes = new Dictionary<string, BaseStat>();

    void Start()
    {
        BaseStat strength = new BaseStat(15, "Strength");
        AddCharacterStat(strength);
        BaseStat dexterity = new BaseStat(10, "Dexterity");
        AddCharacterStat(dexterity);
        BaseStat constitution = new BaseStat(20, "Constitution");
        AddCharacterStat(constitution);
    }

    /// <summary>
    /// Add in the specific character their stats
    /// </summary>
    /// <param name="stat"><b>BaseStat</b> variable that shows which attribute the character has</param>
    public void AddCharacterStat(BaseStat stat)
    {
        attributes.Add(stat.statName, stat);
    }

    /// <summary>
    /// Get the value of a specific stat
    /// </summary>
    /// <param name="statName"><b>string</b> of the name of the stat you want the value of</param>
    /// <returns><b>integer</b> of the value or <b>0</b> if the stat doesn't exist on the player</returns>
    public int GetStatValue(string statName){
        for(int i=0; i<attributes.Count; i++){
            if(attributes[statName]!=null){
                return attributes[statName].CalculateStatValue();
            }
        }
        return 0;
    }
}
