using UnityEngine;

[CreateAssetMenu(fileName = "MariScriptableObjects", menuName = "MariScriptableObjects/Jump states")]
public class MariJumpScripttebolObject : ScriptableObject
{
    [Header("Stomp Values")]
    // how long the playeres raycast check is
    public float RayRange;

    //Walljumping
    [Header("Jump Values")]
    /// The jump higt of the player
    /// Origen: Jump
    /// Is linked: Enemys, Jump    
    public float JumpHight;

    // deturmens if the game neds to play its aduio agien
    [HideInInspector] public bool HasJumped;

    [Header("WallJump values")]
    // deturmens how long it takes before the player can move agien
    public float WallJumpngDuration;

    // deturmens how hige the player walljumps
    public float WallJumpForce;

    [Header("Wall slide Values")]
    // deturmens how qikklig the player falls when facing a wall
    public float WallSlidingSpeed;





}
