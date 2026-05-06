using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class UpgradeManager : MonoBehaviour
{
    [Header("Available Upgrades")]
    [SerializeField] private List<Upgrade> attackUpgrades;

    void OnEnable()
    {
        GameEventsManager.Instance.gameEvents.OnEnemyWaveComplete += AssignDifferentUpgrades;
        GameEventsManager.Instance.gameEvents.OnAbilityChosen += RemoveOtherElementUpgrades;
    }

    void OnDisable()
    {
        GameEventsManager.Instance.gameEvents.OnEnemyWaveComplete -= AssignDifferentUpgrades;
        GameEventsManager.Instance.gameEvents.OnAbilityChosen -= RemoveOtherElementUpgrades;
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
        List<Upgrade> selectedUpgrades;
        // If list has fewer items, pick all of them
        int amountToPick = Mathf.Min(2, attackUpgrades.Count);
        if (GameManager.Instance.GetCurrentLevel() == 0)
        {
            selectedUpgrades = attackUpgrades.Where(u => u.upgradeType == UpgradeType.Ability).ToList();
            Debug.Log("First level detected: Filtering for Abilities only.");
        }
        else
            selectedUpgrades = attackUpgrades.OrderBy(x => Random.value).Take(amountToPick).ToList();
        RollUpgradeStats(selectedUpgrades);

        // If it's the first set of upgrades, delete from the list the ability upgrades to not appear again for now
        if (GameManager.Instance.GetCurrentLevel()==0)
            attackUpgrades.RemoveAll(upgrade => upgrade.upgradeType.ToString().Equals("Ability"));
        GameEventsManager.Instance.graphicEvents.ShowUpgradesOnWaveTerm(currentlyPickedUpgrades);
    }

    private void RollUpgradeStats(List<Upgrade> selected)
    {
        foreach (var upgrade in selected)
        {
            // Create a runtime instance so we don't overwrite the actual ScriptableObject file
            Upgrade runtimeUpgrade = Instantiate(upgrade);
            float difficultyBonus = 1.0f + (GameManager.Instance.GetCurrentLevel() * 0.1f); 
            
            // Roll the random number and apply difficulty
            int baseRoll = Random.Range(runtimeUpgrade.minAmount, runtimeUpgrade.maxAmount + 1);
            runtimeUpgrade.amount = Mathf.RoundToInt(baseRoll * difficultyBonus);
            currentlyPickedUpgrades.Add(runtimeUpgrade);
        }
    }

    private void RemoveOtherElementUpgrades(AttackElement attackElement)
    {
        attackUpgrades.RemoveAll(upgrade => !upgrade.element.Equals(attackElement) && upgrade.upgradeType.ToString().Equals("Attack"));
    }
}
