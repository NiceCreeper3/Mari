using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillFloor : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Player")
        {

        }
        else if(collision.collider.tag != "Respawn")
        {
            Destroy(collision.gameObject);
        }
    }
}
