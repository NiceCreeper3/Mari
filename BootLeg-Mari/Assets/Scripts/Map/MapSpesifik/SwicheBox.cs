using System.Collections;
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
                StartCoroutine(WaitSoPlayerCanJump(false));
            }
            else
            {
                // makes the box solid
                StartCoroutine(WaitSoPlayerCanJump(true));
            }
        }
    }

    private IEnumerator WaitSoPlayerCanJump(bool setObject)
    {
        // waits four the next frame
        yield return null;
        _isOn.gameObject.SetActive(setObject);
    }
}
