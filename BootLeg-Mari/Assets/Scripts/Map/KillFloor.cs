using UnityEngine;

public class KillFloor : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Killes the player if he hits the killefloor
        if (other.TryGetComponent<IIsHitebol>(out var hitebol))
        {
            Debug.Log("Player Hit KilleZone");
            MariValues.Health = 0;
            hitebol.ObjegtHasBenHit(3);
        }
        // if somthing that is not a plaform hits the killfloor. then it is deleted. this is mostly made to get ride of Enemys
        else if (other.CompareTag("enemy"))
        {
            Destroy(other.gameObject);
            Debug.Log(other.gameObject);
        }
    }
}


