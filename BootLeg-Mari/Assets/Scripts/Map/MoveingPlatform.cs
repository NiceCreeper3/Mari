using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveingPlatform : MonoBehaviour
{
    [Header("determens how fast the cloud moves. the higer the number distu solwer")]
    [SerializeField] float _speed;

    [Header("determens were the cloud shode move")]
    [SerializeField] Transform _posisonStart;
    [SerializeField] Transform _posisonEnd;

    //stuff
    private Rigidbody rb;
    private CharacterController cc;
    private Vector3 currentPos;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // gets the players CharacterController
        if (other.tag == "Player")
            cc = other.GetComponent<CharacterController>();
    }

    //moves the palyer ind a cortens to the platforms velocity. whille the player stands on it
    private void OnTriggerStay(Collider other)
    {
        //moves the palyer ind a cortens to the platforms velocity
        if (other.tag == "Player")
            cc.Move( rb.velocity * Time.deltaTime);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // makes the platform move bake and forfe
        currentPos = Vector3.Lerp(_posisonStart.position, _posisonEnd.position, Mathf.Cos(Time.time / -_speed * Mathf.PI * 2) * -.5f + .5f);
        rb.MovePosition(currentPos);
    }
}
