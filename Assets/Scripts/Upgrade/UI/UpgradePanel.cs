using System.Collections.Generic;
using UnityEngine;

public class UpgradePanel : MonoBehaviour
{
    [Header("Upgrade Panel Components")]
    [SerializeField] private Transform upgradePanel;
    [SerializeField] private Transform upgradePrefab;

    void OnEnable()
    {
        GameEventsManager.instance.graphicEvents.OnWaveEnemyKilled += ShowUpgrades;
    }

    void OnDisable()
    {
        GameEventsManager.instance.graphicEvents.OnWaveEnemyKilled -= ShowUpgrades;
    }

    void Start()
    {
        upgradePanel.gameObject.SetActive(false);
    }

    /// <summary>
    /// Shows upgrades panel. It instantiates a new panel upgrade from the list
    /// provided by the argument
    /// </summary>
    /// <param name="posUpgrades">List of the upgrades that are selected</param>
    private void ShowUpgrades(List<Upgrade> posUpgrades)
    {
        upgradePanel.gameObject.SetActive(true);
        // Destroy previous upgrades
        foreach (Transform child in upgradePanel)
            Destroy(child.gameObject);

        // Initialize new upgrades
        foreach (Upgrade upgrade in posUpgrades)
        {
            Transform newUpgrade = Instantiate(upgradePrefab, upgradePanel);
            UpgradePrefab upgradeItem = newUpgrade.GetComponent<UpgradePrefab>();
            upgradeItem.SetupUpgrade(upgrade, this);
        }
        Time.timeScale = 0f;
    }

    public void ClosePanel()
    {
        upgradePanel.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}
