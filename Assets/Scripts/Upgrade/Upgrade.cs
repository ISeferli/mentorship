using UnityEngine;

[CreateAssetMenu(fileName = "New Upgrade", menuName = "New Upgrade")]
public class Upgrade : ScriptableObject
{
    public Texture icon { get; set; }
    public UpgradeType upgradeType;
    public string upgradeName;
    public string upgradeTitle;
    public string upgradeDescription;
    public int amount;
}

public enum UpgradeType
{
    Ability,
    Damage,
    Health,
    Stamina
}
