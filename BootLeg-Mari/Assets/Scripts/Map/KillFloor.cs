using UnityEngine;

public class KillFloor : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
/*        if (other.CompareTag("Player")) 
        { 

        }*/

        if (other.TryGetComponent<IIsHitebol>(out var hitebol))
        {

            Debug.Log("Player Hit KilleZone");
            MariValues.Healf = 0;
            hitebol.ObjegtHasBenHit(3);

            //return;
            //StartCoroutine(MariDead.PalyerReaspawn());

        }
        else if (!other.CompareTag("PlatForm"))
        {
            Destroy(other.gameObject);
            Debug.Log(other.gameObject);
        }



    }
}


