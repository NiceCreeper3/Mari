using UnityEngine;

[CreateAssetMenu(fileName = "MariScriptableObjects", menuName = "MariScriptableObjects/Jump states")]
public class MariJumpScripttebolObject : ScriptableObject
{
    [Header("Stomp Values")]
    // how long the playeres raycast check is
    public float RayRange;

    //Walljumping
    [Header("Jump Values")]
    // deturmens how hige the player walljumps
    public float WallJumpForce;

    // deturmens if the game neds to play its aduio agien
    [HideInInspector] public bool HasJumped;

    /// The jump higt of the player
    /// Origen: Jump
    /// Is linked: Enemys, Jump    
    public float JumpHight;
}
