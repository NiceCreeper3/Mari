using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatForm : MonoBehaviour
{
    [SerializeField] float _switcheTimer;
    [SerializeField] float _speed;

    [SerializeField] Vector3 _posison1, _posison2;
    private void Awake()
    {
        _posison1 += transform.position;
        _posison2 += transform.position;
    }

    private void Update()
    {    
        MoveBackAndForth();
        //StartCoroutine(MoveBackAndForth1());
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("i am tired");
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("i am tired");
            collision.gameObject.transform.SetParent(null);
        }
        //collision.collider.transform.SetParent(null);
    }

    // makes the platform move back and forth
    void MoveBackAndForth()
    {
        float time = Mathf.PingPong(Time.time * _speed, 1);
        transform.position = Vector3.Lerp(_posison1, _posison2, time);
    }

}