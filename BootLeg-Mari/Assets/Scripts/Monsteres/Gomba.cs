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

    [SerializeField] float turnSmoothVelocity;

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

            // gives the X.Y.Z position of target
            Vector3 gombaMove = Vector3.MoveTowards(transform.position, _targetToMoveTo.position, _gombaSpeed * Time.deltaTime);


            float targetAngel = Mathf.Atan2(gombaMove.x, gombaMove.y) * Mathf.Rad2Deg;
            float gombaAngel = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngel, ref turnSmoothVelocity, 0.1f);
            transform.rotation = Quaternion.Euler(0f, gombaAngel, 0f);

            // makes the Gomba move towards the targets positon. with herer is the players positon
            transform.position = gombaMove;
            //transform.position = Vector3.MoveTowards(transform.position, _targetToMoveTo.position, _gombaSpeed * Time.deltaTime);
        }
    }


    void IJumpable.JumpetOn(int hit)
    {
        Debug.Log("hit");
        _currentHealt = -hit;

        if (_currentHealt <= 0)
        {
            MariValues.Velocity.y = Mathf.Sqrt((MariValues.JumpHight * -2f * MariValues.Gravity) / 2);
            Destroy(gameObject);
        }
    }
}
