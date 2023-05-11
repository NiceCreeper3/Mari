using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] float _jumpHight = 3f;
    [SerializeField] float _StompHight;
    [SerializeField] float rayRange;

    [SerializeField] Transform _mariBoot;

    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetButtonDown("Jump") && PlayerGravity._isGrounded)
            PlayerGravity._velocity.y = Mathf.Sqrt(_jumpHight * -2f * PlayerGravity._gravity);

        /// <summary>
        /// raycast til at hvise laning og angribe
        /// </summary>
        /// 

        RaycastHit hitInfo;
        bool hit = Physics.Raycast(_mariBoot.position, Vector3.down, out hitInfo, rayRange);

        //draws a fake line that gives visual indekator
        Debug.DrawRay(_mariBoot.position, Vector3.down, Color.red, rayRange);

        if (hit)
        {
            IJumpable jumpable = hitInfo.collider.GetComponent<IJumpable>();
            if(jumpable != null)
            {
                Debug.Log("Stomp");
                jumpable.JumpetOn(1);
                PlayerGravity._velocity.y = Mathf.Sqrt(_jumpHight * -2f * PlayerGravity._gravity);
            }
        }
    }
}
