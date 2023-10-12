using UnityEngine;

public class SwicheBox : MonoBehaviour
{
    // refrens to the ON part of the swiche box
     private Transform _isOn;

    private void Start()
    {
        // gets refrens to the ON part of the swiche box
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
