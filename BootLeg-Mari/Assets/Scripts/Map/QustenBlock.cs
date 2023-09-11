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
            // playes audio
            FindObjectOfType<AudioMangerScript>().PlayAudio("QustenBlockHit", true);

            MariValues.Velocity.y = -1f;

            // makes a "emptig" box adn the destoris this one
            Instantiate(EmtigBocks, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
