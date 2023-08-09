using UnityEngine;

public class MariValues
{
    /// The jump higt of the player
    /// Origen: Jump
    /// Is linked: Enemys, Jump    
    public static float JumpHight = 3f;

    /// The MoveMent of Mari
    /// Origen: MariMove2
    /// Is linked: Jump, MariMove2
    public static Vector3 Move;

    /// Telles the code wheder the player is Grounded
    /// Origen: PlayerGravity
    /// Is linked: PlayerGravity, Jump 
    public static bool IsGrounded;

    /// Is how hard the player gets polled down
    /// Origen: PlayerGravity
    /// Is linked: PlayerGravity, Jump, Gomba
    public static Vector3 Velocity;

    /// The playes starting gravity
    /// Origen: PlayerGravity
    /// Is linked: PlayerGravity, Jump, Gomba
    public static float Gravity = -10;

    /// Shows if the player is WallJumping. and vill inabel movemt if the player is
    /// Origen: Jump
    ///Is linked: Jump, MariMove2
    public static bool IsWallJumping = false;

    /// shows how mane times the player kan be hit before die ing
    /// Origen: MariDead
    ///Is linked: MariDead, KillFloor, MariMove2
    public static short Health = 3;

    /// Is aktevatet to disabel player contolle as mari is "ded"
    /// Origen: MariDead
    ///Is linked: MariDead, Jump, MariMove2
    public static bool MariIsDead = false;

    /// disabels the playeres gravity and control so he can teleport
    /// Origen: Teleport
    ///Is linked: Teleport, MariMove2, PlayerGravity, Spikes
    public static bool PlayerIsTeleporting = false;
}
