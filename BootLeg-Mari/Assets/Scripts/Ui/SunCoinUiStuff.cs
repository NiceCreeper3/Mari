using System.Collections.Generic;
using UnityEngine;

public class SunCoinUiStuff : MonoBehaviour
{
    [SerializeField] private Transform _sunCoinBox;

    // list of coin pictures
    private List<Transform> _sunCoinsToActivate = new List<Transform>();

    // grabes a refrens to all 3 coin pictures and subribes to the event 
    private void Start()
    {
        // grabes a refrens to all 3 coin pictures
        foreach (Transform coin in _sunCoinBox)
            _sunCoinsToActivate.Add(coin);
    }

    // the event is called by the SunCoinScript
    public void SunCoinHasBenPikkedOp(object data)
    {
        ushort witheCoinWasPikedOp = (ushort)data;

        // makes the aprobriet coin wisebol. uses -1 to akount four the list order
        _sunCoinsToActivate[witheCoinWasPikedOp - 1].gameObject.SetActive(true);
    }
}
