using UnityEngine;

[CreateAssetMenu(menuName="Enemy/EnemyType")]
public class EnemyType : ScriptableObject
{
    public GameObject prefab = null;
    public PlayableStats stats = null;
    public AttackProfile attackProfile = null;
}