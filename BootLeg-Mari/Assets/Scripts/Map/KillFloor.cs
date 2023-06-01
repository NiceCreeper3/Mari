using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillFloor : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            Debug.Log("Player Hit KilleZone");
        }
        else if (!other.CompareTag("PlatForm"))
        {
            Destroy(other.gameObject);
            Debug.Log(other.gameObject);
        }
    }
}
