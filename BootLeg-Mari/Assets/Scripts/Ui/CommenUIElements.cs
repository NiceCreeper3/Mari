using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class CommenUIElements : MonoBehaviour
{
    public static void ReasetGameStates()
    {
        //Reasets score rikvaerments. ind kluding all the suncoins and wheter the player has died
        WorldValues.ScoreHasPlayerDied = WorldValues.SunCoinNummber1 = WorldValues.SunCoinNummber2 = WorldValues.SunCoinNummber3 = false;
        WorldValues.SavedSunCoins = 0;

        // makes it so the player can take check point flag agien
        WorldValues.HasGotCheckPoint = false;


        Debug.Log("has reaset");
    }


    // exits the game
    public void QuitGame()
    {
        Debug.Log("Qutting game");
        Application.Quit();
    }
}
