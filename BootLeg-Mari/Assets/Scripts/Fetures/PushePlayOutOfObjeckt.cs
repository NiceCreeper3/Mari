using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushePlayOutOfObjeckt : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        // gets where to move the object that is stuke ind
        Vector3 PusheDir = new Vector3(other.transform.position.x - transform.position.x, other.transform.position.y, other.transform.position.z - transform.position.z);
        //Vector3 PusheDir = new Vector3(other.transform.position.x - 1, other.transform.position.y, other.transform.position.z - 1);

        MariMove2 player = other.GetComponent<MariMove2>();
        if (player != null)
        {
            Debug.Log("GetOut");
            MariValues.ForsMovePlayer = PusheDir;
        }
        else
        {
            other.transform.position = PusheDir;
        }
    }
}
