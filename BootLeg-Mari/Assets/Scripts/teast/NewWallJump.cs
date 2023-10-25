using UnityEngine;

public class NewWallJump : Jump
{
    #region
    [Header("WallSlideStatas")]
    private bool _isWallSliding;
    [SerializeField] private float wallSlidingSpeed;

    [Header("Check and what to check four")]
    [SerializeField] private Transform wallCheck;
    [SerializeField] private LayerMask wallLayer;
    #endregion

    #region
    private bool iswWallJumping;
    private float wallJumpingDirection;
    private float wallJumpngCounter;

    [SerializeField] private float wallJumpngTime;
    [SerializeField] private float wallJumpngDuration;
    [SerializeField] private Vector3 wallJumpingPower;
    #endregion

    protected override void LateUpdate()
    {
        base.LateUpdate();

        wallslide();
    }

    protected override void OnControllerColliderHit(ControllerColliderHit hit)
    {

    }

    protected override void WallJump(ControllerColliderHit Hit)
    {

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
            _isWallSliding = true;

            //rb.velocity = Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));
            MariValues.Velocity = new Vector3(MariValues.Velocity.x, Mathf.Clamp(MariValues.Velocity.y, -wallSlidingSpeed, float.MaxValue), MariValues.Velocity.z);
        }
        else
        {
            _isWallSliding = false;
        }
    }


    private void WallJump()
    {
        if (_isWallSliding)
        {
            _isWallSliding = false;

            // (Warning) vedio uses localScale.x to rotate but i think i use rotation.y. if it does not work then try the vedio way
            wallJumpingDirection = -transform.rotation.y;
            //wallJumpingDirection = -transform.localScale.x;
        }
    }
}
