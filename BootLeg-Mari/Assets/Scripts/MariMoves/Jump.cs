using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] float _jumpHight = 3f;
    [SerializeField] float _StompHight;

    [SerializeField] Transform _mariBoot;

    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetButtonDown("Jump") && PlayerGravity._isGrounded)
            PlayerGravity._velocity.y = Mathf.Sqrt(_jumpHight * -2f * PlayerGravity._gravity);

        /// <summary>
        /// raycast til at hvise laning og angribe
        /// </summary>
        RaycastHit hit;

        Ray landing = new Ray(_mariBoot.position, Vector3.down);

        if (Physics.Raycast(landing,out hit, _StompHight))
        {
            if (!hit.GetHashCode<IJumpebol>(out var damageable))
            {
                return;
            }

            if (!hit.TryGetComponent<IJumpebol>(out var damageable))
            {
                return;
            }

            IJumpebol interactable = hit.collider.gameObject.GetComponent<IJumpebol>();
            interactable.JumpetOn(1);

            damageable.JumpetOn(1);
        }
    }
}
