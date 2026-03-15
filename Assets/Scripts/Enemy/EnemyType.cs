using UnityEngine;

[CreateAssetMenu(menuName="Enemy/EnemyType")]
public class EnemyType : ScriptableObject
{
    public GameObject prefab;
    public PlayableStats stats;
    public AttackProfile attackProfile;
}