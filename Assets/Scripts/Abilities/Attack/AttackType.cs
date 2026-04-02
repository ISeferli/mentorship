using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/Attack Profile")]
public class AttackProfile : ScriptableObject
{
    public AttackElement elements = AttackElement.None;
    public List<EffectData> additionalAttacks = new List<EffectData>();
}

[System.Serializable]
public class EffectData 
{
    public string attackID = "";
    public string attackDecoratorID = "";
    public int attackDamage = 0;
    public GameObject attackPrefab = null;
}

public enum AttackElement
{
    None,
    Fire,
    Water
}