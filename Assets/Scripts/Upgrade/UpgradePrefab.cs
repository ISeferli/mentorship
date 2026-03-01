using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradePrefab : MonoBehaviour
{
    [Header("Upgrade Prefab Components")]
    [SerializeField] private RawImage icon;
    [SerializeField] private TMP_Text title;
    [SerializeField] private TMP_Text description;

    // Currently assigned objects
    private UpgradePanel assignedPanel;
    private Upgrade assignedUpgrade;

    public void SetupUpgrade(Upgrade upgrade, UpgradePanel panel)
    {
        assignedUpgrade = upgrade;
        assignedPanel = panel;
        title.text = upgrade.upgradeName;
        description.text = upgrade.upgradeDescription;
        icon.texture = upgrade.icon;
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        assignedUpgrade.ApplyUpgrade();
        assignedPanel.ClosePanel();
    }
}
