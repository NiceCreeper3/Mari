using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    //Valus
    #region
    public static float _jumpHight = 3f;
    [SerializeField] float _StompHight;
    [SerializeField] float rayRange;

    [SerializeField] Transform _mariBoot;
    #endregion

    // Update is called once per frame
    void LateUpdate()
    {
        JumpMethode();

        JumpetOnSomthing();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (!PlayerGravity._isGrounded && hit.normal.y < 0.1f)
        {

        }
    }


    // Methodes
    #region

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
    #endregion
}
