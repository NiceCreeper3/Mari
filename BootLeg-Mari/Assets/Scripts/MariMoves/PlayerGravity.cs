using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGravity : MonoBehaviour
{
    [SerializeField] Transform _mariLegs;
    [SerializeField] float _groundDistance = 0.4f;
    [SerializeField] LayerMask _groundMask;

    bool _isGrounded;

    Vector3 _velocity;
    // Update is called once per frame
    void LateUpdate()
    {
        _isGrounded = Physics.CheckSphere(_mariLegs.position, _groundDistance, _groundMask);
        if (_isGrounded == true && _velocity.y < 0)
        {
            _velocity.y = -2f;
        }
    }
}
