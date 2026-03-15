using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/Attack Profile")]
public class AttackProfile : ScriptableObject
{
    public AttackElement elements;
}

public enum AttackElement
{
    None,
    Fire,
    Water
}