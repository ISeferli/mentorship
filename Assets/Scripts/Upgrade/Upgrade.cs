using UnityEngine;

[CreateAssetMenu(fileName = "New Upgrade", menuName = "New Upgrade")]
public class Upgrade : ScriptableObject
{
    public Texture icon { get; set; }
    public UpgradeType upgradeType = UpgradeType.Ability;
    public string upgradeName = "";
    public string upgradeTitle = "";
    [TextArea] public string upgradeDescription = "";
    
    [Header("Stats Range")]
    public int minAmount = 5;
    public int maxAmount = 10;
    
    [Header("Dynamic Value (Runtime Only)")]
    [HideInInspector] public int amount;
    public GameObject upgradePrefab;
}

public enum UpgradeType
{
    Ability,
    Attack,
    Health,
    Stamina
}
