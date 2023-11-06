using System.Collections;
using UnityEngine;

public class Jump : MonoBehaviour
{
    //Valus
    #region

    [Header("WallSlideStatas")]
    private bool _isWallSliding;

    [Header("Check if facing a wall")]
    [SerializeField] private Transform _wallCheck;
    [SerializeField] private LayerMask _wallLayerToCheck;

    // refrinse raycast Orige point
    [Header("Check if mari jumpet on somthing")]
    [SerializeField] private Transform _mariBoot;

    [Header("Maris Jump States")]
    [SerializeField] protected MariJumpScripttebolObject mariJumpStats;
    #endregion

    // Unity Triggeres
    #region
    // Update is called once per frame
    protected virtual void LateUpdate()
    {
        if (!MariValues.MariIsDead)
        {
            MariJumpMethod(mariJumpStats.JumpHight);
            JumpetOnSomthing();
        }
        if (Input.GetButtonUp("Jump"))
        {
            mariJumpStats.HasJumped = false;
        }

        // checkes if the player is facing a wall
        wallslide();
    }

    protected virtual void OnControllerColliderHit(ControllerColliderHit hit)
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
    void MariJumpMethod(float theJumpHigth)
    {
        if (Input.GetButtonDown("Jump") && MariValues.IsGrounded)
        {
            MariValues.Velocity.y = Mathf.Sqrt(theJumpHigth * -2f * MariValues.Gravity);
            FindObjectOfType<AudioMangerScript>().PlayAudio("JumpAudio", true);
        }           
    }

    /// <summary>
    /// raycast til at hvise laning og angribe
    /// </summary>
    void JumpetOnSomthing()
    {
        RaycastHit hitInfo;
        bool hit = Physics.Raycast(_mariBoot.position, Vector3.down, out hitInfo, mariJumpStats.RayRange);

        //draws a fake line that gives visual indekator
        Debug.DrawRay(_mariBoot.position, Vector3.down, Color.red, mariJumpStats.RayRange);

        if (hit)
        {
            //Atempets to get the hit opjeket IJumpable if it has one
            IJumpable jumpable = hitInfo.collider.GetComponent<IJumpable>();

            // the PlayerGravity._velocity.y does not work jet
            if (jumpable != null && MariValues.Velocity.y! < 1)
            {
                
                jumpable.JumpetOn(1);

            }
        }
    }

    // checkes if the palyer is facing a wall
    private bool isWalled()
    {
        // checks if the player is fasing a wall
        return Physics.CheckSphere(_wallCheck.position, 0.2f, _wallLayerToCheck);
    }

    // makes it so the player is not draged down by gravity as qikklig when there are facing a wall. giving the elusen of a wall slide
    private void wallslide()
    {
        if (isWalled() && !MariValues.IsGrounded)
        {
            _isWallSliding = true;

            //rb.velocity = Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));
            MariValues.Velocity = new Vector3(MariValues.Velocity.x, Mathf.Clamp(MariValues.Velocity.y, -mariJumpStats.WallSlidingSpeed, float.MaxValue), MariValues.Velocity.z);
        }
        else
        {
            _isWallSliding = false;
        }
    }

    /// <summary>
    /// makes the player Jump away from a wall
    /// and then makes it so he can,t move
    /// </summary>
    /// <param name="Hit"></param>
    protected virtual void WallJump(ControllerColliderHit Hit)
    {
        if (Input.GetButton("Jump") && _isWallSliding && !MariValues.IsGrounded && !Hit.gameObject.CompareTag("NoWallJump"))
        {
            #region DebugMessenges
            // hows if we hit the wall
            Debug.Log(gameObject.transform.position);
            Debug.DrawRay(Hit.point, Hit.normal, Color.green, 1.25F);
            #endregion

            if (isWalled())
            {
                // rotates the player
                transform.Rotate(new Vector3(transform.rotation.y, transform.rotation.y + 180, transform.rotation.z));
            }

            // makes teh player walljump. is broken and only works if the cammara is pointed a serten way
            MariValues.Velocity.y = mariJumpStats.WallJumpForce;
            MariValues.ForsMovePlayer = Hit.normal * 1000 * Time.deltaTime;


            if (!mariJumpStats.HasJumped)
            {
                FindObjectOfType<AudioMangerScript>().PlayAudio("WallJumpAudio", true);
            }

            mariJumpStats.HasJumped = true;


            StartCoroutine(Timer());
        }
    }

    /// <summary>
    /// Timer ontil player can have controlle agien
    /// </summary>
    /// <returns></returns>
    protected IEnumerator Timer()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        MariValues.IsWallJumping = true;

        // gives controll bak to player after som time has passed
        yield return new WaitForSecondsRealtime(mariJumpStats.WallJumpngDuration);
        MariValues.IsWallJumping = false;
    }
    #endregion
}
