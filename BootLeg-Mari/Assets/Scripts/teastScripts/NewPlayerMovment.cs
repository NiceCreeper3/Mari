using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerMovment : MonoBehaviour
{
    // <camara>
    [Header("Camerra")]
    [SerializeField] private Transform somthingToRemoveWarrning;

     private Rigidbody rb;

    private Vector3 movement;
    [SerializeField] float speed;

    //oooooooooooo
    private float velocityX;
    private float velocityZ;
    [SerializeField] private float maxVelocityX;
    [SerializeField] private float maxVelocityZ;

    [Header("how qikkelig the player pikes op ind speed. and how qikkelig it goves back to normal")]
    [SerializeField] private float accleration;
    [SerializeField] private float decleration;


    private void Awake()
    {


        // get refrends to the rididbody
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
    }


    void FixedUpdate()
    {
        moveCharacter(movement);
    }


    void moveCharacter(Vector3 direction)
    {
        //rb.velocity = direction * speed * Time.fixedDeltaTime;
        rb.AddForce(direction * speed * Time.fixedDeltaTime);
    }


    void MoveingChareture()
    {
        // Input will be true if the player is pressing on the passed in key parameter
        // gets Key Input from player
        bool forwardPressed = Input.GetKey("w");
        bool leftPressed = Input.GetKey("a");
        bool rightPressed = Input.GetKey("d");
       

        //if player presses forward, increase velocity in z direction
        if (forwardPressed && velocityZ < maxVelocityZ)
        {
            velocityZ += Time.deltaTime * accleration;
        }

        // increase velocity in left direction
        if (leftPressed && velocityX < maxVelocityX)
        {
            velocityX -= Time.deltaTime * accleration;
        }

        // increase velocity in left direction
        if (rightPressed  && velocityX < maxVelocityX)
        {
            velocityX += Time.deltaTime * accleration;
        }

        //decrease velocityZ
        if (!forwardPressed && velocityZ > 0)
        {
            velocityZ -= Time.deltaTime * decleration;
        }
        //reaset velocityZ
        if (!forwardPressed && velocityZ < 0.0)
        {
            velocityZ = 0.0f;
        }

        //decrease velocityZ
        if (!forwardPressed && velocityX < 0.0)
        {
            velocityX = 0.0f;
        }
        //reaset velocityZ
        if (!forwardPressed && velocityX < 0.0)
        {
            velocityX = 0.0f;
        }

        if (!leftPressed && !rightPressed && velocityX != 0.0f && velocityX > -maxVelocityX && velocityZ < maxVelocityZ)
        {
            velocityZ = maxVelocityZ;
        }

        //rb.AddForce();
        //rb.MovePosition(new Vector3(velocityX, transform.position.y, velocityZ));
    }
}
