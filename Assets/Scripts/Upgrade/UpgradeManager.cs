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

    /// <summary>
    /// Checks from a pre-determined list the possible upgrades. It gathers two of them
    /// and sends them to the panel
    /// </summary>
    public void AssignDifferentUpgrades()
    {
        currentlyPickedUpgrades = new List<Upgrade>();
        // If list has fewer items, pick all of them
        int amountToPick = Mathf.Min(2, attackUpgrades.Count);
        currentlyPickedUpgrades = attackUpgrades.OrderBy(x => Random.value).Take(amountToPick).ToList();

        // If it's the first set of upgrades, delete from the list the ability upgrades to not appear again for now
        if (GameManager.Instance.GetCurrentLevel()==0)
            attackUpgrades.RemoveAll(upgrade => upgrade.upgradeType.ToString().Equals("Ability"));
        GameEventsManager.instance.graphicEvents.ShowUpgradesOnWaveTerm(currentlyPickedUpgrades);
    }
}
