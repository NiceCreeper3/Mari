using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MariMove2 : MonoBehaviour
{
    // values
    #region
    // <movment>
    [SerializeField] float _speed;
    [SerializeField] CharacterController _controller;
    public static Vector3 _move;

    // <camara>
    [SerializeField] Transform _cam;

    // <turning>
    [SerializeField] float _turnSmoothTime = 0.1f;
    [SerializeField] float turnSmoothVelosetig;
    #endregion

    // Update is called once per frame
    void LateUpdate()
    {
        Movement();
    }

    // brackys
    void Movement()
    {
        // gets W.A.S.D to mode
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        // the .normalize makes it so we don,t get extra speed by holding bofe buttons
        _move = new Vector3(x, 0f, z).normalized;

        if (_move.magnitude >= 0.1f)
        {
            // makes Mari curkel and wake ind akottens to cam
            float targetAngel = Mathf.Atan2(_move.x, _move.z) * Mathf.Rad2Deg + _cam.eulerAngles.y;

            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngel, ref turnSmoothVelosetig, _turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngel, 0f) * Vector3.forward;

            // moves the player
            _controller.Move(moveDir.normalized * _speed * Time.deltaTime);
        }
    }
}
