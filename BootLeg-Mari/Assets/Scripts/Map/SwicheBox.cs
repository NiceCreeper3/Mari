using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwicheBox : MonoBehaviour
{

    Transform _isOn;

    private void Start()
    {
        _isOn = transform.GetChild(0);
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && MariValues.IsGrounded)
        {
            // Swithes if the Box is Solid or not
            if (_isOn.gameObject.activeSelf)
            {
                // makes the box ghost
                _isOn.gameObject.SetActive(false);
            }
            else
            {
                // makes the box solid
                _isOn.gameObject.SetActive(true);
            }

        }
    }
}
