using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MariMove : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] CharacterController controller;

    // Update is called once per frame
    void LateUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * _speed * Time.deltaTime);
    }
}
