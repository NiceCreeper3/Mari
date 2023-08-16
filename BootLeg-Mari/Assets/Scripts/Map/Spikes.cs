using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spikes : MonoBehaviour
{
    [SerializeField] GameObject _teleprotFromTrap;

    private void OnTriggerEnter(Collider other)
    {
        // Killes the player if he hits the killefloor
        if (other.TryGetComponent<IIsHitebol>(out var hitebol))
        {
            hitebol.ObjegtHasBenHit(1);
            StartCoroutine(TeleportPlayer(other));
        }
        // if somthing that is not a plaform hits the killfloor. then it is deleted. this is mostly made to get ride of Enemys
        else if (!other.CompareTag("PlatForm"))
        {
            Destroy(other.gameObject);
        }
    }

    private IEnumerator TeleportPlayer(Collider Player)
    {
        yield return new WaitForSecondsRealtime(1);
        MariValues.PlayerIsTeleporting = true;
        yield return new WaitForSecondsRealtime(1);
        Player.transform.position = _teleprotFromTrap.transform.position;
        yield return new WaitForSecondsRealtime(0.5f);
        MariValues.PlayerIsTeleporting = false;



    }

}
