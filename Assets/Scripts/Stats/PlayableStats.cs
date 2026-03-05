using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Stat Profile", menuName = "Stat Profile")]
public class PlayableStats : ScriptableObject
{
    public List<BaseStat> statsList = new List<BaseStat>();

    /// <summary>
    /// Get value of the stat from the list, based on the name
    /// </summary>
    /// <param name="statName">Name of the stat</param>
    /// <returns>Stat value</returns>
    public int GetStatValue(string statName)
    {
        if (statsList == null) return 0;
        foreach (BaseStat stat in statsList)
        {
            if(stat.statName.Equals(statName)) return stat.CalculateStatValue();
        }
        return 0;
    }
}
