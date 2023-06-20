using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QustenBlock : MonoBehaviour
{
    [SerializeField] GameObject EmtigBocks;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Block Hit");
        if (other.CompareTag("Player") )
        {
            FindObjectOfType<AudioMangerScript>().PlayAudio("QustenBlockHit", true);         
            Instantiate(EmtigBocks, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
