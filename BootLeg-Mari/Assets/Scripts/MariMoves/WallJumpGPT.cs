using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJumpGPT : MonoBehaviour
{
    public float jumpForce = 5f;
    public float wallJumpForce = 10f;
    public float wallCheckDistance = 0.5f;
    public LayerMask wallLayer;

    private bool isJumping = false;

    private void OnCollisionStay(Collision collision)
    {

    }

    private void OnCollisionEnter(Collision collision)
    {

    }

    //WallJump
    void ThankYouChatGPT(Collision _collision)
    {
        if (_collision.gameObject.CompareTag(""))
        {
            Vector3 contactNormal = _collision.contacts[0].normal;

            if (Vector3.Dot(transform.forward, contactNormal) < 0)
            {
                //_wallJumpForce

                Vector3 JumpDirection = Vector3.Reflect(-transform.forward, contactNormal).normalized;
                GetComponent<Rigidbody>().velocity = (JumpDirection * wallJumpForce) + (Vector3.up * MariValues.JumpHight);
                MariValues.IsWallJumping = true;
            }
        }
    }

    private void Update()
    {
        // Check if the jump key is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Check if the player is currently touching a wall
            if (IsTouchingWall())
            {
                // Get the wall jump direction
                Vector3 jumpDirection = CalculateWallJumpDirection();

                // Apply the wall jump force
                Vector3 jumpVelocity = (jumpDirection * wallJumpForce) + (Vector3.up * jumpForce);
                GetComponent<CharacterController>().Move(jumpVelocity * Time.deltaTime);
                isJumping = true;
            }
        }

        // Apply gravity if the player is in the air and not performing a wall jump
        if (!GetComponent<CharacterController>().isGrounded && !isJumping)
        {
            GetComponent<CharacterController>().Move(Physics.gravity * Time.deltaTime);
        }

        // Reset the isJumping flag when the player lands
        if (GetComponent<CharacterController>().isGrounded)
        {
            isJumping = false;
        }
    }

    private bool IsTouchingWall()
    {
        // Cast a sphere in the direction of the character's movement to detect if it's touching a wall
        RaycastHit hit;
        if (Physics.SphereCast(transform.position, GetComponent<CharacterController>().radius, transform.forward, out hit, wallCheckDistance, wallLayer))
        {
            return true;
        }
        return false;
    }

    private Vector3 CalculateWallJumpDirection()
    {
        // Get the wall jump direction by reflecting the player's forward vector with the wall's normal
        RaycastHit hit;
        Physics.SphereCast(transform.position, GetComponent<CharacterController>().radius, transform.forward, out hit, wallCheckDistance, wallLayer);
        Vector3 wallNormal = hit.normal;
        Vector3 jumpDirection = Vector3.Reflect(-transform.forward, wallNormal).normalized;
        return jumpDirection;
    }
}
