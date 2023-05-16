using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Gomba : Monster, IJumpable
{

    [SerializeField] Transform _targetToMoveTo;

    // torturial
    private NavMeshAgent _navAI;
    [SerializeField] LayerMask _aggroRange;
    private Collider[] _withInAggroRange;

    // Start is called before the first frame update
    void Awake()
    {
        // sets the max HP of Gomba
        _maxHealt = 1;

        _navAI = GetComponent<NavMeshAgent>();

        // makes the player target
        _targetToMoveTo = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        _withInAggroRange = Physics.OverlapSphere(transform.position, 10, _aggroRange);
        if (_withInAggroRange.Length > 0)
        {
/*
            float targetAngel = Mathf.Atan2(move.x, move.z) * Mathf.Rad2Deg;

            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngel, ref turnSmoothVelosetig, _turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
*/

            // makes the Gomba move towards the targets positon. with herer is the players positon
            transform.position = Vector3.MoveTowards(transform.position, _targetToMoveTo.position, _gombaSpeed * Time.deltaTime);
        }
    }


    void IJumpable.JumpetOn(int hit)
    {
        Debug.Log("hit");
        _currentHealt = -hit;

        if (_currentHealt <= 0)
        {
            PlayerGravity._velocity.y = Mathf.Sqrt((Jump._jumpHight * -2f * PlayerGravity._gravity) / 2);
            Destroy(gameObject);
        }
    }
}
