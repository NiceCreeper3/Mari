using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gomba : Monster
{

    [SerializeField] Transform _targetToMoveTo;

    // Start is called before the first frame update
    void Awake()
    {
        _maxHealt = 1;
        //_targetToMoveTo = GameObject.FindGameObjectsWithTag("Player").GetComponent
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetToMoveTo.position, _gombaSpeed * Time.deltaTime);
    }
}
