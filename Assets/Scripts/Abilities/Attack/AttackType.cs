using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/Attack Profile")]
public class AttackProfile : ScriptableObject
{
    public AttackElement elements = AttackElement.None;
    public List<EffectData> additionalEffects = new List<EffectData>();
}

[System.Serializable]
public class EffectData 
{
    public string effectID = "";
    public int effectDamage = 0;
    public GameObject prefab = null;
}

public enum AttackElement
{
    None,
    Fire,
    Water
}