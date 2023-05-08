using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MariMove2 : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] CharacterController _controller;
    [SerializeField] float _gravity;
    [SerializeField] float _jumpHight = 5f;

    Vector3 _velocity;

    [SerializeField] Transform _mariLegs;
    [SerializeField] float _groundDistance = 0.4f;
    [SerializeField] LayerMask _groundMask;

    bool _isGrounded;

    // Update is called once per frame
    void LateUpdate()
    {
        _isGrounded = Physics.CheckSphere(_mariLegs.position, _groundDistance, _groundMask);
        if (_isGrounded == true && _velocity.y < 0)
        {
            _velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        _controller.Move(move * _speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && _isGrounded)
        {
            _velocity.y = Mathf.Sqrt(_jumpHight * -2f * _gravity);
        }


        _velocity.y += _gravity * Time.deltaTime;
        _controller.Move(_velocity * Time.deltaTime);
    }


}
