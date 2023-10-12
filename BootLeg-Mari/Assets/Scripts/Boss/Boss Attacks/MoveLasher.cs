using System.Collections;
using UnityEngine;

public class MoveLasher : MonoBehaviour
{
    [Header("LasherProbitgs")]
    [SerializeField] private float _lasserSpeed;

    [Header("what stage the lashers move")]
    [SerializeField] [Range(1,3)] private ushort _stageAperens;

    [Header("Positions to move to")]
    [SerializeField] private Transform _toMoveTo;
    private Vector3 _origanalPosition;

    private void Start()
    {
        _origanalPosition = transform.position;
    }

    // Event is triggeret by boss skript
    public void SendtLasheres(object data)
    {
        ushort attackStage = (ushort)data;

            if (attackStage >= _stageAperens)
            StartCoroutine(MoveLashers());
    }

    private IEnumerator MoveLashers()
    {

        while (transform.position.x != _toMoveTo.position.x)
        {
            // move towards the other side of the arina. it has a wait to make it so it does not move so fast that you can,t se
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(_toMoveTo.position.x, transform.position.y, transform.position.z), _lasserSpeed * Time.deltaTime);
            yield return new WaitForSecondsRealtime(0);
        }

        // resets to the origanial position
        transform.position = _origanalPosition;
    }
}
