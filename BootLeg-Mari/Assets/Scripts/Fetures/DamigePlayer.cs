using UnityEngine;

public class DamigePlayer : MonoBehaviour
{
    [SerializeField] private short _damigeToDo = 1;

    private void OnTriggerStay(Collider other)
    {
        // Killes the player if he hits the killefloor
        if (other.TryGetComponent<IIsHitebol>(out var hitebol))
        {
            hitebol.ObjegtHasBenHit(_damigeToDo);
        }
    }
}
