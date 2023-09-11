using UnityEngine;

[CreateAssetMenu(fileName = "EnemyScriptableObjects", menuName = "EnemyScripteabelObject/EnemyStats")]
public class EnemyStatesSkripteabelObjects : ScriptableObject
{
    [Header("Enemy States")]
    public float _aggroRangeOfEnemy;
    public float _enemySpeed, _passeveSpeed;
}
