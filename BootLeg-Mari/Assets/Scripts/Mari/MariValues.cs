using UnityEngine;

public class MariValues
{
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
    /// Is linked: PlayerGravity, Jump, Monster, BounsPadSkript, WallJumpGPT
    public static Vector3 Velocity;

    /// The playes starting gravity
    /// Origen: PlayerGravity
    /// Is linked: PlayerGravity, Jump, Gomba
    public static float Gravity = -10;

    /// Shows if the player is WallJumping. and vill inabel movemt if the player is
    /// Origen: Jump
    ///Is linked: Jump, MariMove2
    public static bool IsWallJumping = false;

    /// Is aktevatet to disabel player contolle as mari is "ded"
    /// Origen: MariDead
    ///Is linked: MariDead, Jump, MariMove2
    public static bool MariIsDead = false;

    /// disabels the playeres gravity and control so he can teleport
    /// Origen: Teleport
    ///Is linked: Teleport, MariMove2, PlayerGravity, Spikes
    public static bool PlayerIsTeleporting = false;

    /// Determens if the player is on ice or not
    /// Origen: MariMove2
    ///Is linked: IcyFloor, MariMove2,
    public static bool OnIcyFloor;
}
