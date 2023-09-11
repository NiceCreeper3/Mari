using UnityEngine;

[CreateAssetMenu(fileName = "MariScriptableObjects", menuName = "MariScriptableObjects/Gravity States")]
public class MariGravityScriptabolObject : ScriptableObject
{
    [Header("Is player grounded check")]
    // shise of boubel around player. amd deturments if the player is Gounded
    public float GroundDistance = 0.4f;

    // lookes what ground the player has to be on to reaset 
    public LayerMask GroundMask;

    [Header("Start gravitys. reamber to set it to -")]
    // the Gravity the player starts with
    public float DefaultGravity;
}
