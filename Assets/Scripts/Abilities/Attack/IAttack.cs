using UnityEngine;

public interface IAttack: IAbility
{
    public AttackData attackData { get; set; }
    public void PerformAttack(int pointsDamage, GameObject personToHit, GameObject attacker);
}

public class AttackData
{
    public string id;
    public int damage;
    public Color color;
    public Color weakColor;
    public Color betterColor;
    public int range;
    public GameObject attackPrefab;
}
