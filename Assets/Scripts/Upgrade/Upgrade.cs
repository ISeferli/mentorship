using UnityEngine;

[CreateAssetMenu(fileName = "New Upgrade", menuName = "New Upgrade")]
public class Upgrade : ScriptableObject
{
    public Texture icon { get; set; }
    public UpgradeType upgradeType;
    public string upgradeName;
    public string upgradeDescription;
    public int amount;

    public void ApplyUpgrade(IAbility currentAbility)
    {
        // The Factory returns a new decorated version of the ability
        if (upgradeType == UpgradeType.Ability)
        {
            UpgradeFactory.CreateAttackUpgrade(upgradeName, (IAttack)currentAbility);
        }
    }
}

public enum UpgradeType
{
    Ability,
    Damage,
    Health,
    Stamina
}
