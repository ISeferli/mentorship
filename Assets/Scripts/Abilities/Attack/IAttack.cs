using UnityEngine;

public interface IAttack: IAbility
{
    public AttackData attackData { get; set; }
    public void PerformAttack(int pointsDamage, GameObject personToHit, GameObject attacker);
    public void AttackTick();
}

public class AttackData
{
    public string id;
    public int damage;
    public Color color;
    public Color weakColor;
    public Color betterColor;
    public GameObject effect;
    public AttackElement element;
    public int range;
    public GameObject attackPrefab;
    public float cooldown;
    public float cooldownTimer;
}
