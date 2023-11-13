using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunCoinScript : MonoBehaviour
{
    //[SerializeField] GameObject _sunCoinOrder;
    [Range(1, 3)]
    [SerializeField] ushort _sunCoinNumber;

    // sents event 
    [SerializeField] private GameEventScriptebolObjecks OnCoinPikOp;

    private void Start()
    {
        if (WorldValues.SunCoinNummber1 == true && _sunCoinNumber == 1)
        {
            StartCoroutine(CoinHasBeanTaken());          
        }
        else if (WorldValues.SunCoinNummber2 == true && _sunCoinNumber == 2)
        {
            StartCoroutine(CoinHasBeanTaken());
        }
        else if (WorldValues.SunCoinNummber2 == true && _sunCoinNumber == 3)
        {
            StartCoroutine(CoinHasBeanTaken());
        }
        else
        {
            WorldValues.ScoreSunCoinsColleted = WorldValues.SavedSuncoins;
        }

        Debug.Log($"you have {WorldValues.ScoreSunCoinsColleted} SunCoins, and SunCoin nummber 1){WorldValues.SunCoinNummber1} 2){WorldValues.SunCoinNummber2} 3){WorldValues.SunCoinNummber3}");
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

    private IEnumerator CoinHasBeanTaken()
    {
        // waits a frame so the Ui can be loades
        yield return null;
        OnCoinPikOp.Raise(_sunCoinNumber);

        Debug.Log("SunCoinHasBenDeleted");
        Destroy(gameObject);
    }
}
