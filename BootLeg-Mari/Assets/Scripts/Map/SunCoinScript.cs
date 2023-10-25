using System;
using UnityEngine;

public class SunCoinScript : MonoBehaviour
{
    //[SerializeField] GameObject _sunCoinOrder;
    [Range(1, 3)]
    [SerializeField] int _sunCoinNumber;

    // sents event 
    [SerializeField] private GameEventScriptebolObjecks OnCoinPikOp;

    private void Awake()
    {
        if (WorldValues.SunCoinNummber1 && _sunCoinNumber == 1)
        {
            CoinHasBeanTaken();
        }
        else if (WorldValues.SunCoinNummber2 && _sunCoinNumber == 2)
        {
            CoinHasBeanTaken();
        }
        else if (WorldValues.SunCoinNummber2 && _sunCoinNumber == 2)
        {
            CoinHasBeanTaken();
        }
        else
        {
            WorldValues.ScoreSunCoinsColleted = WorldValues.SavedSuncoins;
        }

        Debug.Log("you have " + WorldValues.ScoreSunCoinsColleted + " SunCoins");
    }

    private void Update()
    {
        transform.Rotate(0, 1, 0, Space.Self);
    }

    private void OnTriggerEnter(Collider other)
    {
        GotSunCoin();
    }

    // set the info of getting coin
    private void GotSunCoin()
    {
        WorldValues.ScoreSunCoinsColleted += 1;
        FindObjectOfType<AudioMangerScript>().PlayAudio("CoinPikOp", true);

        // sets the
        OnCoinPikOp.Raise(_sunCoinNumber);

        Destroy(gameObject);
    }

    private void CoinHasBeanTaken()
    {
        Debug.Log("SunCoinHasBenDeleted");
        Destroy(gameObject);
        OnCoinPikOp.Raise(_sunCoinNumber);
    }
}
