using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcyFloor : MonoBehaviour
{
    
    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            MariValues.OnIcyFloor = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            MariValues.OnIcyFloor = false;
        }
    }
}
