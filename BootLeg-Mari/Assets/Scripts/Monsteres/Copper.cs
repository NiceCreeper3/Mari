using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Copper : Monster, IShootebol, IJumpable
{
    [Header("Points to patrol")]
    [SerializeField] Transform[] _points;
    int _tagetPatrolPoint = 0;

    protected override void PassiveStands()
    {
        // makes the enemy
        if (transform.position == _points[_tagetPatrolPoint].position)
        {
            _tagetPatrolPoint++;

            // reasets 
            if (_tagetPatrolPoint >= _points.Length)
                _tagetPatrolPoint = 0;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, _points[_tagetPatrolPoint].position, _passeveSpeed * Time.deltaTime);

            // used a methode from the monster inhertinse, to rotate and look at the target
            RotatoLookAtTarget(_points[_tagetPatrolPoint]);
        }
    }

    void IJumpable.JumpetOn(int hit)
    {
        EnemyHit();
    }

    void IShootebol.Shoot()
    {
        EnemyHit();
    }

    private void OnTriggerStay(Collider other)
    {
        AttackPlayer(other);
    }
}
