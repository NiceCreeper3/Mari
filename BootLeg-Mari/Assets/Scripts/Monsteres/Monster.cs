using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour, IJumpebol
{
    [SerializeField] protected int _healt;
    [SerializeField] protected int _maxHealt;

    // Start is called before the first frame update
    void Start()
    {
        _healt = _maxHealt;    
    }

    void IJumpebol.JumpetOn(int hit)
    {
        Debug.Log("Hit");


        if (_healt <= 0)
        {
            Destroy(gameObject);
        }
    }
}
