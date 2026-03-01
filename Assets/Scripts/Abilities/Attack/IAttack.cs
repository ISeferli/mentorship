using UnityEngine;

public interface IAttack : IAbility
{
    public AttackData attackData { get; set; }
    public void PerformAttack(int pointsDamage, GameObject personToHit);
}

public class AttackData
{
    //public List<Upgrades> upgrades typou fireball and such
    public int damage;
    public Color color;
    public Color weakColor;
    public Color betterColor;
}
