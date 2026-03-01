using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class UpgradeManager : MonoBehaviour
{
    [Header("Available Upgrades")]
    [SerializeField] private List<Upgrade> attackUpgrades;

    void OnEnable()
    {
        GameEventsManager.instance.gameEvents.OnEnemyWaveComplete += AssignDifferentUpgrades;
    }

    void OnDisable()
    {
        GameEventsManager.instance.gameEvents.OnEnemyWaveComplete -= AssignDifferentUpgrades;
    }

    /// <summary>
    /// Upgrades that are picked randomnly during gameplay to show to player
    /// </summary>
    private List<Upgrade> currentlyPickedUpgrades;

    public void AssignDifferentUpgrades()
    {
        Debug.Log("at least here");
        currentlyPickedUpgrades = new List<Upgrade>();
        // If list has fewer items, pick all of them
        int amountToPick = Mathf.Min(2, attackUpgrades.Count);
        currentlyPickedUpgrades = attackUpgrades.OrderBy(x => Random.value).Take(amountToPick).ToList();
        GameEventsManager.instance.graphicEvents.ShowUpgradesOnWaveTerm(currentlyPickedUpgrades);
    }
}
