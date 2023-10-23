using UnityEngine;

[CreateAssetMenu(fileName = "MariScriptableObjects", menuName = "MariScriptableObjects/MariHealt")]
public class MariHealtScriptebolObjeckt : ScriptableObject
{
    [Header("Player helt")]
    public short PlayerStartHealt;
    [HideInInspector] public short PlayerCurrentHealt;

    [Header("how long the player is ivonerabol after takking damige")]
    public float InviseFamesTime;
    // the reason _isInvinsebol is not here is that it is a simpel check that the dev does not interat with
}
