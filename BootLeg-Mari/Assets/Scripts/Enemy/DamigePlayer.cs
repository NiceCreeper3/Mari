using System;
using UnityEngine;

public class DamigePlayer : MonoBehaviour
{
    [SerializeField] int _damigeToDeal;
    public event Action<int> PlayerIsHit;   

    private void OnTriggerStay(Collider other)
    {
        //does damige to the player if the player hits a trigger
        if (other.gameObject.CompareTag("Player")) PlayerIsHit?.Invoke(_damigeToDeal);
    }
}
