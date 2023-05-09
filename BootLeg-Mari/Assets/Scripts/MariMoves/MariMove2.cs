using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MariMove2 : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] CharacterController _controller;

    // camara
    [SerializeField] Transform cam;


    // turning
    [SerializeField] float _turnSmoothTime = 0.1f;
    [SerializeField] float turnSmoothVelosetig;

    // Update is called once per frame
    void LateUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        //Vector3 move = transform.right * x + transform.forward * z;

        // the .normalize makes it so we don,t get extra speed by holding bofe buttons
        Vector3 move = new Vector3(x, 0f, z).normalized;

        if (move.magnitude >= 0.1f)
        {
            float targetAngel = Mathf.Atan2(move.x, move.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngel, ref turnSmoothVelosetig, _turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle,0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngel, 0f) * Vector3.forward;
            _controller.Move(moveDir.normalized * _speed * Time.deltaTime);
        }



        //_controller.Move(move * _speed * Time.deltaTime);



        
    }


}
