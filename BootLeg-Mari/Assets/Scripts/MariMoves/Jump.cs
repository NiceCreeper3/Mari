using System.Collections;
using UnityEngine;

public class Jump : MonoBehaviour
{
    //Valus
    #region
    // Jumping
    [Header("Jump Values")]

    //Walljumping
    [SerializeField] float _wallJumpForce;
    private bool hasJumped;

    // Raycast / Stomp
    [Header("Stomp Values")]
    [SerializeField] float _StompHight;
    [SerializeField] float rayRange;

    // refrinse raycast Orige point
    [SerializeField] Transform _mariBoot;

    private MariValues _mariValues;
    #endregion

    // Unity Triggeres
    #region
    // Update is called once per frame
    void LateUpdate()
    {
        if (!MariValues.MariIsDead)
        {
            JumpMethode();
            JumpetOnSomthing();
        }
        if (Input.GetButtonUp("Jump"))
        {
            hasJumped = false;
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag != "NoWallJump")
        {
            WallJump(hit);
        }    
    }
    #endregion

    // Methodes
    #region

    /// <summary>
    /// Makes the player jump 
    /// </summary>
    void JumpMethode()
    {
        if (Input.GetButtonDown("Jump") && MariValues.IsGrounded)
        {
            MariValues.Velocity.y = Mathf.Sqrt(MariValues.JumpHight * -2f * MariValues.Gravity);
            FindObjectOfType<AudioMangerScript>().PlayAudio("JumpAudio", true);
        }           
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
            //Atempets to get the hit opjeket IJumpable if it has one
            IJumpable jumpable = hitInfo.collider.GetComponent<IJumpable>();

            // the PlayerGravity._velocity.y does not work jet
            if (jumpable != null && MariValues.Velocity.y! < 1)
            {
                Debug.Log("Stomp");
                jumpable.JumpetOn(1);

            }
        }
    }

    /// <summary>
    /// makes the player Jump away from a wall
    /// and the makes it so he can,t move
    /// </summary>
    /// <param name="Hit"></param>
    private void WallJump(ControllerColliderHit Hit)
    {
        if (!MariValues.IsGrounded && Hit.normal.y < 3f)
        {
            if (Input.GetButton("Jump"))
            {
                #region DebugMessenges

                // hows if we hit the wall
                Debug.Log(gameObject.transform.position);
                Debug.DrawRay(Hit.point, Hit.normal, Color.green, 1.25F);
                #endregion
                // søger for at spiller ikke bare kan holde jump inde


                MariValues.Move = Hit.normal * 10000 * Time.deltaTime;
                MariValues.Velocity.y = _wallJumpForce;

                if (!hasJumped)
                {
                    FindObjectOfType<AudioMangerScript>().PlayAudio("WallJumpAudio", true);
                }
                hasJumped = true;


                StartCoroutine(Timer());
            }
        }
    }

    /// <summary>
    /// Timer ontil player can have controlle agien
    /// </summary>
    /// <returns></returns>
    private IEnumerator Timer()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        MariValues.IsWallJumping = true;

        // gives controll bak to player after som time has passed
        yield return new WaitForSecondsRealtime(1.5f);
        MariValues.IsWallJumping = false;
    }
    #endregion
}
