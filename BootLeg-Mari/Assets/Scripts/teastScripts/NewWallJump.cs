using UnityEngine;

public class NewWallJump : Jump
{
    #region
    [Header("WallSlideStatas")]
    private bool sild;
    [SerializeField] private float wallSlidingSpeed;

    [Header("Check and what to check four")]
    [SerializeField] private Transform wallCheck;
    [SerializeField] private LayerMask wallLayer;
    #endregion

    MariHealtScriptebolObjeckt sb;

    #region
    private float wallJumpingDirection;
    private float wallJumpngCounter;

    [SerializeField] private float wallJumpngTime;
    [SerializeField] private float wallJumpngDuration;
    [SerializeField] private Vector3 wallJumpingPower;
    #endregion

    BetterMovemnt refr; 


    private void Awake()
    {
        refr = GetComponent<BetterMovemnt>();
    }
    protected override void LateUpdate()
    {
        base.LateUpdate();

        wallslide();
        newWallJump();
    }

/* 
    protected override void OnControllerColliderHit(ControllerColliderHit hit)
    {

    }*/

    protected override void WallJump(ControllerColliderHit Hit)
    {

        if (Input.GetButton("Jump") && sild && !MariValues.IsGrounded && !Hit.gameObject.CompareTag("NoWallJump"))
        {

            if (isWalled())
            {
                // rotates the player
                transform.Rotate(new Vector3(transform.rotation.y, transform.rotation.y + 180, transform.rotation.z));
            }

            //MariValues.Velocity.y = mariJumpStats.WallJumpForce;
            Vector3 wallJump = new Vector3(wallJumpingPower.x, MariValues.Velocity.y = wallJumpingPower.y, wallJumpingPower.z);
            refr.MovePlayer(wallJump, wallJumpngDuration, false);

            //Vector3 s = Hit.normal * 1000 * Time.deltaTime;
            //refr.MovePlayer(s, 1, true);


            if (!mariJumpStats.HasJumped)
            {
                FindObjectOfType<AudioMangerScript>().PlayAudio("WallJumpAudio", true);
            }

            mariJumpStats.HasJumped = true;


            StartCoroutine(Timer());
        }
    }

    private void newWallJump()
    {
        if (Input.GetButton("Jump") && sild && !MariValues.IsGrounded)
        {

            if (isWalled())
            {
                // rotates the player
                transform.Rotate(new Vector3(transform.rotation.y, transform.rotation.y + 180, transform.rotation.z));
            }

            //MariValues.Velocity.y = mariJumpStats.WallJumpForce;
            Vector3 wallJump = new Vector3(wallJumpingPower.x, MariValues.Velocity.y = wallJumpingPower.y, wallJumpingPower.z);
            refr.MovePlayer(wallJump, wallJumpngDuration, false);
            //MariValues.ForsMovePlayer = Hit.normal * 1000 * Time.deltaTime;



            if (!mariJumpStats.HasJumped)
            {
                FindObjectOfType<AudioMangerScript>().PlayAudio("WallJumpAudio", true);
            }

            mariJumpStats.HasJumped = true;

            Debug.Log("walljump?");

            StartCoroutine(Timer());
        }
    }


    private bool isWalled()
    {
        // checks if the player is fasing a wall
        return Physics.CheckSphere(wallCheck.position, 0.2f, wallLayer);
    }

    private void wallslide()
    {
        if (isWalled() && !MariValues.IsGrounded)
        {
            sild = true;

            //rb.velocity = Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));
            MariValues.Velocity = new Vector3(MariValues.Velocity.x, Mathf.Clamp(MariValues.Velocity.y, -wallSlidingSpeed, float.MaxValue), MariValues.Velocity.z);
        }
        else
        {
            sild = false;
        }
    }

    private void StopWallJumping()
    {
        MariValues.IsWallJumping = false;
    }


    // works when fine whe the cammar is pointed one way but not on other
    private void Etemp1()
    {
        if (sild)
        {
            sild = false;
            // (Warning) vedio uses localScale.x to rotate but i think i use rotation.y. if it does not work then try the vedio way
            wallJumpingDirection = -transform.rotation.y;
            //wallJumpingDirection = -transform.localScale.x;
            wallJumpngCounter = wallJumpngTime;

            Invoke(nameof(StopWallJumping), wallJumpngDuration);
        }
        else
        {
            // alows the player som spare extra time to wall jump
            wallJumpngCounter -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump") && wallJumpngCounter > 0f)
        {
            // rotates teh player if there are not alrede rotated
            if (isWalled())
            {
                // rotates the player
                transform.Rotate(new Vector3(transform.rotation.y, transform.rotation.y + 180, transform.rotation.z));
            }

            //makes it so the player can,t move. and then shotes them of the wall
            MariValues.IsWallJumping = true;
            MariValues.ForsMovePlayer = new Vector3(transform.forward.x, MariValues.Velocity.y = wallJumpingPower.y, transform.forward.z);

            // makes sure the player cant spam to get extra speed
            wallJumpngCounter = 0f;

            FindObjectOfType<AudioMangerScript>().PlayAudio("WallJumpAudio", true);

            StartCoroutine(Timer());
            MariValues.Velocity = Vector3.zero;
        }
    }

    private void Etemp2()
    {
        if (sild)
        {
            sild = false;
            // (Warning) vedio uses localScale.x to rotate but i think i use rotation.y. if it does not work then try the vedio way
            wallJumpingDirection = -transform.rotation.y;
            //wallJumpingDirection = -transform.localScale.x;
            wallJumpngCounter = wallJumpngTime;

            Invoke(nameof(StopWallJumping), wallJumpngDuration);
        }
        else
        {
            // alows the player som spare extra time to wall jump
            wallJumpngCounter -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump") && wallJumpngCounter > 0f)
        {
            // rotates teh player if there are not alrede rotated
            if (isWalled())
            {
                // rotates the player
                transform.Rotate(new Vector3(transform.rotation.y, transform.rotation.y + 180, transform.rotation.z));
            }

            //makes it so the player can,t move. and then shotes them of the wall
            MariValues.IsWallJumping = true;

            //Vector3 k = new Vector3(transform.forward.x + wallJumpingPower.x, MariValues.Velocity.y = wallJumpingPower.y, transform.forward.z + wallJumpingPower.z) * Cam.eulerAngles.y;
            //MariValues.Move = new Vector3(transform.forward.x, MariValues.Velocity.y = wallJumpingPower.y, transform.forward.z);
            //Vector3 NormalCamMove = LookDependingOnCam();

            // moves the player
            //_controller.Move(NormalCa * wallJumpForce * Time.deltaTime);


            /*
                        MariValues.Move = new Vector3(
                            -transform.forward.x - wallJumpingDirection,
                            MariValues.Velocity.y = wallJumpingPower.y,
                            -transform.forward.z - wallJumpingDirection);

                        _controller.Move(new Vector3(
                            transform.forward.x - wallJumpingDirection,
                            MariValues.Velocity.y = wallJumpingPower.y,
                            transform.forward.z - wallJumpingDirection));
            */

            // makes sure the player cant spam to get extra speed
            wallJumpngCounter = 0f;

            FindObjectOfType<AudioMangerScript>().PlayAudio("WallJumpAudio", true);

            StartCoroutine(Timer());
            MariValues.Velocity = Vector3.zero;
        }
    }

    private void OrignalWallJump(ControllerColliderHit Hit)
    {
        if (!MariValues.IsGrounded && Hit.normal.y < 3f && !Hit.gameObject.CompareTag("NoWallJump"))
        {
            if (Input.GetButton("Jump"))
            {
                #region DebugMessenges

                // hows if we hit the wall
                Debug.Log(gameObject.transform.position);
                Debug.DrawRay(Hit.point, Hit.normal, Color.green, 1.25F);
                #endregion
                // søger for at spiller ikke bare kan holde jump inde

                MariValues.ForsMovePlayer = Hit.normal * 10000 * Time.deltaTime;
                MariValues.Velocity.y = mariJumpStats.WallJumpForce;

                if (!mariJumpStats.HasJumped)
                {
                    FindObjectOfType<AudioMangerScript>().PlayAudio("WallJumpAudio", true);
                }
                mariJumpStats.HasJumped = true;


                StartCoroutine(Timer());
            }
        }
    }
}
