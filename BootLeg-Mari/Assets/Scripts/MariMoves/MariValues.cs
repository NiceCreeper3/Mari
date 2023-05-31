using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MariValues : MonoBehaviour
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
}
