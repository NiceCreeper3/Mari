using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoints : MonoBehaviour
{
    public Vector3 CheckPointPosition;
    private Transform CheckPointFlag;

    private void Awake()
    {
        CheckPointPosition = gameObject.transform.position;
        CheckPointFlag = gameObject.transform.GetChild(0);
    }

    private void OnTriggerEnter(Collider other)
    {
        CheckPointFlag.GetComponent<Renderer>().material.color = Color.red;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
