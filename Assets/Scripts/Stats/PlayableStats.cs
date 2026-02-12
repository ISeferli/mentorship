using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Stat Profile", menuName = "Stat Profile")]
public class PlayableStats : ScriptableObject
{
    public List<BaseStat> statsList = new List<BaseStat>();

    public int GetStatValue(string statName)
    {
        foreach (BaseStat stat in statsList)
        {
            if(stat.statName.Equals(statName)) return stat.CalculateStatValue();
        }
        return 0;
    }
}
