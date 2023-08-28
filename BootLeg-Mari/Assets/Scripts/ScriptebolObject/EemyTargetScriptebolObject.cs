using UnityEngine;

[CreateAssetMenu(fileName = "EnemyScriptableObjects", menuName = "EnemyScripteabelObject/Targeting")]
public class EemyTargetScriptebolObject : ScriptableObject
{
    // torturial
    [Header("Layer to look after target")]
    public LayerMask TargetsLayer;
}
