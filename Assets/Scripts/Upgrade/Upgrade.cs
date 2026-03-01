using UnityEngine;

[CreateAssetMenu(fileName = "New Upgrade", menuName = "New Upgrade")]
public class Upgrade : ScriptableObject
{
    public Texture icon { get; set; }
    public string upgradeName;
    public string upgradeDescription;
    public int amount;

    public void ApplyUpgrade()
    {
        Debug.Log("Specified Upgrade");
    }
}
