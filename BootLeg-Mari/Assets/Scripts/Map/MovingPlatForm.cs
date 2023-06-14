using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatForm : MonoBehaviour
{
    [SerializeField] float SwitcheTimer;
    [SerializeField] float _speed;

    [SerializeField] Vector3 _posison1, _posison2;

    private void Awake()
    {
        _posison1 += transform.position;
        _posison2 += transform.position;

        /*
                if(SwitcheTimer < 0)
                {
                    SwitcheTimer = 1;
                }
        */
        StartCoroutine(MoveBackAndForth());
    }

    // gives the player som invincebiletig time
    IEnumerator MoveBackAndForth()
    {
        while (true)
        {
            transform.position = Vector3.MoveTowards(transform.position, _posison2, _speed * Time.deltaTime);
            yield return new WaitForSecondsRealtime(SwitcheTimer);
            transform.position = Vector3.MoveTowards(transform.position, _posison1, _speed * Time.deltaTime);

        }
    }

}
