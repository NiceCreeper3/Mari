using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gomba : Monster, IJumpable
{
    // torturial

    [Header("Enemy Setting")]
    [SerializeField] LayerMask _aggroRange;
    private Collider[] _withInAggroRange;

    [SerializeField] float _turnSmoothVelocity;


    // Start is called before the first frame update
    void Awake()
    {
        // sets the max HP of Gomba
        _maxHealt = 1;

        // makes the player target
        _targetToMoveTo = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        FollwPlayer();
    }

    private void OnTriggerStay(Collider other)
    {
        AttackPlayer(other);
    }

    void IJumpable.JumpetOn(int hit)
    {
        EnemyHit(hit);
    }


    //Methodes
    #region

    void FollwPlayer()
    {
        _withInAggroRange = Physics.OverlapSphere(transform.position, 10, _aggroRange);
        if (_withInAggroRange.Length > 0)
        {
            // makes the Gomba move towards the targets positon. with herer is the players positon
            transform.position = Vector3.MoveTowards(transform.position, _targetToMoveTo.position, _gombaSpeed * Time.deltaTime);

            // gets the players position - the players y. withe here is the gombas y position
            Vector3 TargetPosisionExepetY = new Vector3(_targetToMoveTo.position.x, transform.position.y, _targetToMoveTo.position.z);

            // makes the gomba rotate to look towordes the player
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, TargetPosisionExepetY - transform.position, 3f, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDirection);
        }
    }



    void AttackPlayer(Collider _other)
    {
        if (_other.TryGetComponent<IIsHitebol>(out var hitebol))
        {
            Debug.Log("Gomba Hit Player");
            hitebol.ObjegtHasBenHit(1);

            // play MariDamigeAudio
        }
    }

    #endregion
}
