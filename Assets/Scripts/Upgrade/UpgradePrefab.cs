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
    private GameObject player;
    private UpgradePanel assignedPanel;
    private Upgrade assignedUpgrade;

    void Start()
    {
        player = CharacterMovement.Instance.gameObject;
    }

    public void SetupUpgrade(Upgrade upgrade, UpgradePanel panel)
    {
        assignedUpgrade = upgrade;
        assignedPanel = panel;
        title.text = upgrade.upgradeTitle;
        description.text = upgrade.upgradeDescription;
        icon.texture = upgrade.icon;
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        BaseAttackComposition attackComposition = player.GetComponent<CharacterAttack>().upgradeSword.attackSet;
        CharacterMovement character = player.GetComponent<CharacterMovement>();
        switch (assignedUpgrade.upgradeType)
        {
            case UpgradeType.Ability:
                var newAbility = UpgradeFactory.CreateUpgrade(assignedUpgrade, attackComposition.GetBaseAttack("Base"));
                player.GetComponent<CharacterAttack>().upgradeSword.SetAttackAbility(newAbility, "Base");
                break;
            case UpgradeType.Attack:
                var baseAtk = attackComposition.AttackExists(assignedUpgrade.upgradeName)
                    ? attackComposition.GetBaseAttack(assignedUpgrade.upgradeName)
                    : attackComposition.CreateNewAttack(assignedUpgrade.upgradeName);

                var newAttack = UpgradeFactory.CreateUpgrade(assignedUpgrade, baseAtk);
                player.GetComponent<CharacterAttack>().upgradeSword.SetAttackAbility(newAttack, assignedUpgrade.upgradeName);
                break;
            case UpgradeType.Health:
                player.GetComponent<Character>().CurrentHealth = UpgradeFactory.CreateUpgrade(assignedUpgrade, player.GetComponent<Character>().CurrentHealth);
                break;
            case UpgradeType.Stamina:
                player.GetComponent<Character>().CurrentStamina = UpgradeFactory.CreateUpgrade(assignedUpgrade, player.GetComponent<Character>().CurrentStamina);
                break;
        }
        assignedPanel.ClosePanel();
    }
}
