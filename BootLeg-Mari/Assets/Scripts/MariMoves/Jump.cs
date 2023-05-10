using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] float _jumpHight = 3f;
    [SerializeField] float _StompHight;
    [SerializeField] float rayRange = 4;

    [SerializeField] Transform _mariBoot;

    void Update()
    {
        CastRay();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetButtonDown("Jump") && PlayerGravity._isGrounded)
            PlayerGravity._velocity.y = Mathf.Sqrt(_jumpHight * -2f * PlayerGravity._gravity);

        /// <summary>
        /// raycast til at hvise laning og angribe
        /// </summary>
        /// 



        /*
                RaycastHit hit;

                Ray landing = new Ray(_mariBoot.position, Vector3.down);

                if (Physics.Raycast(landing, out hit, _StompHight))
                {

                    IJumpebol interactable = hit.collider.gameObject.GetComponent<IJumpebol>();
                    interactable.JumpetOn(1);
                }*/



        //curent etempt
        RaycastHit hitInfo = new RaycastHit();
        bool hit = Physics.Raycast(_mariBoot.position, out hitInfo, rayRange);
        Ray landing = new Ray(_mariBoot.position, Vector3.down);
        if (hit)
        {
            GameObject hitObject = hitInfo.transform.gameObject;
            hitObject.GetComponent<IJumpebol>().JumpetOn(1);
        }
    }

    void CastRay()
    {
        RaycastHit hitInfo = new RaycastHit();
        bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo, rayRange);
        if (hit)
        {
            GameObject hitObject = hitInfo.transform.gameObject;
            if (Input.GetMouseButtonDown(0))
            {
                hitObject.GetComponent<IJumpebol>().JumpetOn(1);
            }
        }
    }
}
