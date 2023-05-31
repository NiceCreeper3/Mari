using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    //Valus
    #region
    // Jumping
    [Header("Jump Values")]

    [SerializeField] float _wallJumpForce;

    // Raycast / Stomp
    [Header("Stomp Values")]
    [SerializeField] float _StompHight;
    [SerializeField] float rayRange;

    // refrinse raycast Orige point
    [SerializeField] Transform _mariBoot;

    private ControllerColliderHit _remberHitWall;

/*
    // no defrint tortorial
    [Header("Wall sliding")]
    private bool _isWallSliding;
    private float _wallSlidingSpeed = 2f;

    [SerializeField] private Transform _wallCheck;
    [SerializeField] private LayerMask _wallLayer;

    [Header("Wall jump")]
    private bool _isWallJumping;
    private float _wallJumpingDirection, _wallJumpingTime = 0.2f, _wallJumpingCounter, _wallJumpingDuration = 0.4f;
    private Vector3 _wallJumpingPower = new Vector3(8f,16,0);

*/
    #endregion
    // Update is called once per frame
    void LateUpdate()
    {
        JumpMethode();

        JumpetOnSomthing();
    }

    //WallJump
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        WallJump(hit);
    }


    // Methodes
    #region
    /// <summary>
    /// Makes the player jump 
    /// </summary>
    void JumpMethode()
    {
        if (Input.GetButtonDown("Jump") && MariValues.IsGrounded)
            MariValues.Velocity.y = Mathf.Sqrt(MariValues.JumpHight * -2f * MariValues.Gravity);
    }

    /// <summary>
    /// raycast til at hvise laning og angribe
    /// </summary>
    void JumpetOnSomthing()
    {
        RaycastHit hitInfo;
        bool hit = Physics.Raycast(_mariBoot.position, Vector3.down, out hitInfo, rayRange);

        //draws a fake line that gives visual indekator
        Debug.DrawRay(_mariBoot.position, Vector3.down, Color.red, rayRange);

        if (hit)
        {
            IJumpable jumpable = hitInfo.collider.GetComponent<IJumpable>();

            // the PlayerGravity._velocity.y does not work jet
            if (jumpable != null && MariValues.Velocity.y! < 1)
            {
                Debug.Log("Stomp");
                jumpable.JumpetOn(1);

            }
        }
    }

    void WallJump(ControllerColliderHit Hit)
    {
        if (!MariValues.IsGrounded && Hit.normal.y < 0.1f)
        {
            if (Input.GetButtonDown("Jump"))
            {
                // hows if we hit the wall
                Debug.Log(gameObject.transform.position);
                Debug.DrawRay(Hit.point, Hit.normal, Color.green, 1.25F);

                // indekates
                MariValues.IsWallJumping = true;
                MariValues.Move.x = -5;
                MariValues.Velocity.y = _wallJumpForce;

                StartCoroutine(Timer());

                MariValues.Move = Hit.normal * 10 * Time.deltaTime;
            }
        }

    }

    IEnumerator Timer()
    {
        // gives controll bak to player after som time has passed
        yield return new WaitForSecondsRealtime(1.5f);
        MariValues.IsWallJumping = false;
    } 
    #endregion
}
