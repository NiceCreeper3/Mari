using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Copper : Monster, IShootebol, IJumpable
{

    [Header("is a buffer of how exakt the copper has to be the same position ")]
    [SerializeField] private float _conmpensad;

    [Header("Points to patrol")]
    [SerializeField] Transform[] _points;

    private int _targetPatrolPoint = 0;

    protected override void PassiveStands()
    {
        // gets how far the copper is from the _targetPatrolPoint
        float distanceToTarget = Vector3.Distance(transform.position, _points[_targetPatrolPoint].position);

        if (distanceToTarget < _conmpensad)
        {
            // addes 1 to over int, and if its over awer _points limmet then it reaset it to 0
            _targetPatrolPoint = (_targetPatrolPoint + 1) % _points.Length;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, _points[_targetPatrolPoint].position, _enemyStates._passeveSpeed * Time.deltaTime);

            // used a methode from the monster inhertinse, to rotate and look at the target
            RotatoLookAtTarget(_points[_targetPatrolPoint]);
        }
    }

    void IJumpable.JumpetOn(int hit)
    {
        StartCoroutine(EnemyWasStumpt(""));
    }

    void IShootebol.Shoot()
    {
        EnemyWasShot("");
    }

    private void OnTriggerStay(Collider other)
    {
        AttackPlayer(other);
    }
}
