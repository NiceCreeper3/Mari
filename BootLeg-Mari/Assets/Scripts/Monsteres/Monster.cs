using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] protected int _gombaSpeed;
    [SerializeField] protected int _healt;
    [SerializeField] protected int _maxHealt;

    // Start is called before the first frame update
    void Start()
    {
        _healt = _maxHealt;    
    }

}
