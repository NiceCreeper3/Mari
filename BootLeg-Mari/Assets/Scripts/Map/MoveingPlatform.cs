using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveingPlatform : MonoBehaviour
{
    [Header("determens how fast the cloud moved")]
    [SerializeField] float _speedOfCloud;

    [Header("determens were the cloud shode move")]
    [SerializeField] Transform[] _positonsToMove;
    int _nextPositionMove = 0;
    private float _distanseBetviePoints;

    //stuff
    private Rigidbody rb;
    private CharacterController cc;
    private Vector3 currentPos;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _distanseBetviePoints = Vector3.Distance(transform.position, _positonsToMove[0].position);
    }

    private void OnTriggerEnter(Collider other)
    {
        // gets the players CharacterController
        if (other.CompareTag("Player"))
            cc = other.GetComponent<CharacterController>();
    }

    //moves the palyer ind a cortens to the platforms velocity. whille the player stands on it
    private void OnTriggerStay(Collider other)
    {
        //moves the palyer ind a cortens to the platforms velocity
        if (other.CompareTag("Player"))
            cc.Move( rb.velocity * Time.deltaTime);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MovingCloud();
    }

    void MovingCloud()
    {
        // makes the enemy
        if (transform.position == _positonsToMove[_nextPositionMove].position)
        {
            _nextPositionMove = (_nextPositionMove + 1) % _positonsToMove.Length;

            _distanseBetviePoints = Vector3.Distance(transform.position, _positonsToMove[_nextPositionMove].position);
        }
        else
        {
            currentPos = Vector3.MoveTowards(transform.position, _positonsToMove[_nextPositionMove].position, _distanseBetviePoints * _speedOfCloud * Time.fixedDeltaTime);
            rb.MovePosition(currentPos);
        }
    }
}
