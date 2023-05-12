using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gomba : Monster, IJumpable
{

    [SerializeField] Transform _targetToMoveTo;

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
        // makes the Gomba move towards the targets positon. with herer is the players positon
        transform.position = Vector3.MoveTowards(transform.position, _targetToMoveTo.position, _gombaSpeed * Time.deltaTime);

    }


    void IJumpable.JumpetOn(int hit)
    {
        Debug.Log("hit");
        _healt = -hit;

        if (_healt <= 0)
        {
            PlayerGravity._velocity.y = Mathf.Sqrt((Jump._jumpHight * -2f * PlayerGravity._gravity) / 2);
            Destroy(gameObject);
        }
    }


}
