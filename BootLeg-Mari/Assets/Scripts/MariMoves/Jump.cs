using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    //Valus
    #region
    // Jumping
    [Header("Jump Values")]
    public static float _jumpHight = 3f;
    [SerializeField] float _wallJumpForce;

    // Raycast / Stomp
    [Header("Stomp Values")]
    [SerializeField] float _StompHight;
    [SerializeField] float rayRange;

    // refrinse raycast Orige point
    [SerializeField] Transform _mariBoot;
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
        if (Input.GetButtonDown("Jump") && PlayerGravity._isGrounded)
            PlayerGravity._velocity.y = Mathf.Sqrt(_jumpHight * -2f * PlayerGravity._gravity);
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
            if (jumpable != null && PlayerGravity._velocity.y! < 1)
            {
                Debug.Log("Stomp");
                jumpable.JumpetOn(1);

            }
        }
    }

    void WallJump(ControllerColliderHit Hit)
    {
        if (!PlayerGravity._isGrounded && Hit.normal.y < 0.1f)
        {
            if (Input.GetButtonDown("Jump"))
            {
                Debug.DrawRay(Hit.point, Hit.normal, Color.red, 1.25F);
                PlayerGravity._velocity.y = _wallJumpForce;
                MariMove2._move = Hit.normal * 10 * Time.deltaTime;
            }
        }

    }
    #endregion
}
