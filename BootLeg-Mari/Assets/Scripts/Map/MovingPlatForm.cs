using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatForm : MonoBehaviour
{
    [SerializeField] float _switcheTimer;
    [SerializeField] float _speed;

    [SerializeField] Vector3 _posison1, _posison2;
    [SerializeField] GameObject OrigenalMariParent;

    public static bool o;


    //stuff
    private GameObject target = null;
    private Vector3 offset;


    private void Start()
    {
        _posison1 += transform.position;
        _posison2 += transform.position;

        target = null;
    }


    // Currentlig works but is not optemol
    // on Stay is inntet but freeses the player. and Enter makes so player can,t move
    void OnTriggerEnter(Collider col)
    {
        col.transform.SetParent(transform);

        Debug.Log("Player is on clude");

        //target = col.gameObject;
        //offset = target.transform.position - transform.position;
    }
    void OnTriggerExit(Collider col)
    {
        col.transform.SetParent(OrigenalMariParent.transform);
        Debug.Log("Player left platform");
        target = null;
    }


    private void FixedUpdate()
    {
/*
        if (target != null)
        {
            //target.transform.position = transform.position + offset;
        }
*/

        MoveBackAndForth();
    }


    // makes the platform move back and forth
    void MoveBackAndForth()
    {
        float time = Mathf.PingPong(Time.time * _speed, 1);
        transform.position = Vector3.Lerp(_posison1, _posison2, time);
    }
}