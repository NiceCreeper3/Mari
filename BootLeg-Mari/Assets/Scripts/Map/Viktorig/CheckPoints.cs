using UnityEngine;

public class CheckPoints : MonoBehaviour
{
    [Header("Color of Falg as it is takken")]
    [SerializeField] Material _flagTakkenColor;

    [Header("Checks if we got coin and reambes it")]
    [SerializeField] GameObject _sunCoinFiled1, _sunCoinFiled2, _sunCoinFiled3;

    private Transform CheckPointFlag;

    // unity trrigeres
    #region
    private void Awake()
    {
        // gets a refrends to the flag part of the check point
        CheckPointFlag = gameObject.transform.GetChild(0);

        // makes collecked sun coins the same as savedSunCoins
        WorldValues.CurrentSunCoins = WorldValues.SavedSunCoins;

        // changes the flag color to the tagen color
        if (WorldValues.HasGotCheckPoint)
            CheckPointFlag.GetComponent<Renderer>().material.color = _flagTakkenColor.color;

        // debugs about what SunCoin is aktive
        Debug.Log(
            $"you have {WorldValues.CurrentSunCoins} SunCoins, " +
            $"and saved coins is {WorldValues.SavedSunCoins}, " +
            $"and SunCoin nummber 1){WorldValues.SunCoinNummber1} " +
            $"2){WorldValues.SunCoinNummber2} " +
            $"3){WorldValues.SunCoinNummber3}");
    }

    private void OnTriggerEnter(Collider other)
    {
        SetNewSpawnPoint();
    }
    #endregion

    // sets Maris new spawnpoint and saves info
    private void SetNewSpawnPoint()
    {
        if (!WorldValues.HasGotCheckPoint)
        {
            // reammberes stuff
            #region
            // makes it so the game remmberes the mini falg has bean takken
            WorldValues.HasGotCheckPoint = true;

            // sets the playeres new spawn point
            WorldValues.PlayerSpawnPoint = transform.position;

            // (Warning) is mabey the cause
            WorldValues.SavedSunCoins = WorldValues.CurrentSunCoins;

            //reammberes what SunCoin has bean taken
            ReamberSunCoins();
            #endregion

            // does pure aperens stuff
            #region
            // tanges the color of the flag to _flagTakkenColor. and then playes a audio sampel
            CheckPointFlag.GetComponent<Renderer>().material.color = _flagTakkenColor.color;
            FindObjectOfType<AudioMangerScript>().PlayAudio("CheckPonintGot", true);

            Debug.Log("Player has new Spawn");
            #endregion
        }
    }

    private void ReamberSunCoins()
    {
        // the code belove needs to be changed. as it is annoying to set op the refrenses ithe time you add a this script and is generlig not good and makes a dependensig on the UI objeck

        /// (Saves what suncoins we have gotten allrede)
        /// it does this by checking if the Ui elemet represending the spisifik suncoin is active
        /// if yeas then it putes SunCoinNummberX to true
        if (_sunCoinFiled1.activeSelf)
            WorldValues.SunCoinNummber1 = true;
        if (_sunCoinFiled2.activeSelf)
            WorldValues.SunCoinNummber2 = true;
        if (_sunCoinFiled3.activeSelf)
            WorldValues.SunCoinNummber3 = true;
    }

}
