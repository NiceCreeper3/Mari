using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [Header("Enemy States")]
    [SerializeField] protected int _gombaSpeed;
    [SerializeField] protected int _currentHealt;
    [SerializeField] protected int _maxHealt;
    [SerializeField] protected Transform _targetToMoveTo;

    // Start is called before the first frame update
    void Start()
    {
        _currentHealt = _maxHealt;    
    }

    protected void EnemyHit(int _hit)
    {
        Debug.Log("hit");
        _currentHealt = -_hit;

        if (_currentHealt <= 0)
        {
            MariValues.Velocity.y = Mathf.Sqrt((MariValues.JumpHight * -2f * MariValues.Gravity) / 2);
            Destroy(gameObject);
        }
    }

}
