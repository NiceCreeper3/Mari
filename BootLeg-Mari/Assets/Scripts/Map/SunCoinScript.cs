using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunCoinScript : MonoBehaviour
{
    [Range(1, 3)]
    [SerializeField] ushort _sunCoinNumber;

    // sents event 
    [SerializeField] private GameEventScriptebolObjecks OnCoinPikOp;

    // unity Triggeres
    #region
    private void Start()
    {
        /// checks if the sun coin has allrede bean taken after a check point.
        /// if so then it calls a method the destroys the sun coin
        if (WorldValues.SunCoinNummber1 == true && _sunCoinNumber == 1)
        {
            StartCoroutine(CoinHasBeanTaken());         
        }
        else if (WorldValues.SunCoinNummber2 == true && _sunCoinNumber == 2)
        {
            StartCoroutine(CoinHasBeanTaken());
        }
        else if (WorldValues.SunCoinNummber3 == true && _sunCoinNumber == 3)
        {
            StartCoroutine(CoinHasBeanTaken());
        }
    }

    private void Update()
    {
        // makes the SunCoin spin
        transform.Rotate(0, 1, 0, Space.Self);
    }

    private void OnTriggerEnter(Collider other)
    {
        GotSunCoin();
    }
    #endregion

    // funksens
    #region
    // set the info of getting coin
    private void GotSunCoin()
    {
        // adds one to the current suncoins and plays a audio clip
        WorldValues.CurrentSunCoins += 1;
        FindObjectOfType<AudioMangerScript>().PlayAudio("CoinPikOp", true);

        // makes the suncoin as takken and destroys it
        StartCoroutine(CoinHasBeanTaken());

    }

    // tells the ui to show coin and destroyrs the coin
    private IEnumerator CoinHasBeanTaken()
    {
        // waits a frame so the Ui can be loades
        yield return null;

        // calls a even the tels the ui to show aprobriet SunCoin UI
        OnCoinPikOp.Raise(_sunCoinNumber);

        Debug.Log($"SunCoin has ben Deleted. the saved coins is ({WorldValues.SavedSunCoins}) and current is ({WorldValues.CurrentSunCoins})");
        Destroy(gameObject);
    }
    #endregion
}
