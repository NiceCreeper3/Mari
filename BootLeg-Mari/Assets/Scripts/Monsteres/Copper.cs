using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Copper : Monster, IShootebol, IJumpable
{
    [Header("Points to patrol")]
    [SerializeField] Transform[] _points;
    short _tagetPatrolPoint = 0;

    protected override void PassiveStands()
    {
        // makes the enemy
        if (transform.position == _points[_tagetPatrolPoint].position)
        {
            _tagetPatrolPoint = (short)((_tagetPatrolPoint + 1) % _points.Length);
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
