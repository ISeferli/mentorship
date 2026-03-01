using UnityEngine;

public static class UpgradeFactory
{
    public static IAbility CreateAttackUpgrade(string type, IAttack statUpgrade)
    {
        switch(type)
        {
            case "Fire": return new FireAttackDecorator(statUpgrade);
            case "Water": return new WaterAttackDecorator(statUpgrade);
            default: return null;
        }   
    }
}
