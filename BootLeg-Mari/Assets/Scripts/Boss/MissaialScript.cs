using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissaialScript : MonoBehaviour
{
    [SerializeField] LayerMask _hitPlayer;
    [SerializeField] float BlastRange;

    private Collider[] _isWithIndExplosenRange;
    

    private void OnTriggerEnter(Collider other)
    {

        try
        {
            //Makes a shere around the rocked and does damig to the player 
            _isWithIndExplosenRange = Physics.OverlapSphere(transform.position, BlastRange, _hitPlayer);
            if (_isWithIndExplosenRange[0].TryGetComponent<IIsHitebol>(out var hitebol))
            {
                Debug.Log("Player Hit Exploson");
                hitebol.ObjegtHasBenHit(1);
            }
        }
        catch
        {
            Debug.LogWarning("Please rember to fix if rocket doesnt hit");
        }


        gameObject.SetActive(false);
    }

}
