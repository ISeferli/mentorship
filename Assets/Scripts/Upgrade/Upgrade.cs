using UnityEngine;

[CreateAssetMenu(fileName = "New Upgrade", menuName = "New Upgrade")]
public class Upgrade : ScriptableObject
{
    public Texture icon { get; set; }
    public UpgradeType upgradeType = UpgradeType.Ability;
    public string upgradeName = "";
    public string upgradeTitle = "";
    public string upgradeDescription = "";
    public int amount = 0;
}

public enum UpgradeType
{
    Ability,
    Damage,
    Health,
    Stamina
}
