using UnityEngine;

public interface IAttack
{
    public AttackData attackData { get; set; }
    public void PerformAttack(int pointsDamage, GameObject personToHit);
}

public class AttackData
{
    public int damage;
    public Color color;
    public Color weakColor;
    public Color betterColor;
}
