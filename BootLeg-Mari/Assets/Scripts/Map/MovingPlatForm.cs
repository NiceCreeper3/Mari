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

    // makes the platform move back and forth
    void MoveBackAndForth()
    {
        float time = Mathf.PingPong(Time.time * _speed, 1);
        transform.position = Vector3.Lerp(_posison1, _posison2, time);
    }


    // Is does nothing speshel but is supposed to make the platform stop for a bit after reathing its distenason
    IEnumerator MoveBackAndForth1()
    {


        float time = Mathf.PingPong(Time.time * _speed, 1);
        transform.position = Vector3.Lerp(_posison1, _posison2, time);
        
        if(transform.position == _posison1 && transform.position == _posison1)
            yield return new WaitForSecondsRealtime(_switcheTimer);

        // figer avt how to make it stop for som seconds
    }

}