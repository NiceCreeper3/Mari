using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icy : MonoBehaviour
{
    private Vector3 moveDirection = Vector3.zero;
    private Vector3 lastMoveDirection = Vector3.zero;
    private float moveSpeed = 2f;
    private float slideSpeed = 1.75f;
    private bool icy = false;

    public void LateUpdate()
    {


        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 moveDirection = z * camera.forward + x * camera.right;

        float inputMagnitude = Mathf.Min(new Vector3(x, 0, z).sqrMagnitude, 1f);

        // store last direction when received some movement
        if (inputMagnitude > 0.225f)
        {
            lastMoveDirection = MariValues.Move;
        }

        // add speed
        // keeps sliding when still, runs slowly when moving
        if (icy)
        {
            MariValues.Move = lastMoveDirection * slideSpeed;
        }
        else
        {
            MariValues.Move *= moveSpeed;
        }

        // ...
        // apply
        controller.Move(MariValues.Move * Time.deltaTime);
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        icy = hit.collider.CompareTag("Ice");
    }
}
